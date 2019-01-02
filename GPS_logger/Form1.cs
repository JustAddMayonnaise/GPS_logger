using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.IO;

namespace GPS_logger
{
    public partial class Form1 : Form
    {
        ConcurrentQueue<byte> outputDataQueue = new ConcurrentQueue<byte>();   // Concurrent queue for reading data stream from serial port
        byte removedItemInDataQueue;                                             // Byte array used to store for dequeue
        ConcurrentQueue<int> bytesToReadQueue = new ConcurrentQueue<int>();        // Concurrent queue for reading amount of bytes to read from serial port
        int removedBytesToRead;                                                    // Variable to store the number of bytes to read from serial port to form
        byte[] readBytes;                                                          // Byte array used to store for enqueue
        string myDataQueue = "";

        SaveFileDialog saveToCSV = new SaveFileDialog();                          // Save dialog to create the file to write to
        FileStream fileStreamForCSV;                                              // Used for creating the file to write to

        bool recordFlag = false;
        string recordString;    // To record the $GPS sentence
        string[] recordSubString;   // To split the $GPS sentence into an array
        string UTCTime;
        string GPSQualityIndication;

        int timeoutCntr;
        bool timeoutFlag = false;

        public Form1()
        {
            InitializeComponent();
            readBytes = new byte[serCOM.ReadBufferSize];
            serCOM.BaudRate = 4800;
            serCOM.DataBits = 8;
            serCOM.StopBits = System.IO.Ports.StopBits.One;
            serCOM.Parity = System.IO.Ports.Parity.None;
            txtbxBytesToRead.Text = "Hello!";

        }

        private void cmbbxCOMPortsMSP_DropDown(object sender, EventArgs e)
        {
            string[] COMPortNames = System.IO.Ports.SerialPort.GetPortNames().ToArray();
            cmbbxCOMPorts.Items.Clear();
            for (int cntr = 0; cntr < COMPortNames.Length; cntr++)
                cmbbxCOMPorts.Items.Add(COMPortNames[cntr]);
        }

        private void btnConnectMSP_Click(object sender, EventArgs e)
        {
            if (serCOM.IsOpen)
            {
                lock (serCOM) serCOM.Close();             // Mutex on the serial port
                btnConnectDisconnect.Text = "Connect";    // Changes button text to 'connect'
                cmbbxCOMPorts.Enabled = true;             // Enables clicking on the combo box for COM ports
                tmrSerRead.Enabled = false;               // Disables the timer for reading concurrent queue from serial port

                if (txtbxFileName.Text != "" )
                {
                    using (StreamWriter sw = File.AppendText(txtbxFileName.Text))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd h:mm:ss tt") + "," + "DISCONNECTED");
                    }

                    tmrTimeOut.Enabled = false;
                }

                while (outputDataQueue.TryDequeue(out removedItemInDataQueue)) { }      // Clears buffer in queue
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(cmbbxCOMPorts.Text))
                {
                    try
                    {
                        lock (serCOM)
                        {
                            serCOM.PortName = cmbbxCOMPorts.Text;
                            serCOM.Open();
                            btnConnectDisconnect.Text = "Disconnect";
                            cmbbxCOMPorts.Enabled = false;
                            tmrSerRead.Enabled = true;

                            if (txtbxFileName.Text != "")
                            {
                                using (StreamWriter sw = File.AppendText(txtbxFileName.Text))
                                {
                                    sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd h:mm:ss tt") + "," + "CONNECTED");
                                }
                            }

                            tmrTimeOut.Enabled = true;
                        }
                    }
                    catch (Exception myException)
                    {
                        MessageBox.Show(myException.Message);
                    }

                }
                else
                {
                    MessageBox.Show("No COM port selected. Please try again.", "ERROR");
                }

            }
        }

        
        // This timer is responsible for reading from the concurrent queue. As well, it will read from concurrent queue for the Clefairy mini-game
        private void tmrSerRead_Tick(object sender, EventArgs e)
        {
            txtbxBytesInQueue.Text = Convert.ToString(outputDataQueue.Count());

            

            while (outputDataQueue.TryDequeue(out removedItemInDataQueue))               // If statement to see if data can be read from the queue
            {
                
                if (bytesToReadQueue.TryDequeue(out removedBytesToRead))              // If statement to see how many bytes to read
                    txtbxBytesToRead.Text = Convert.ToString(removedBytesToRead);     // Display how many bytes to read to the form
                else txtbxBytesToRead.Text = "0";     // Display how many bytes to read to the form

                if (myDataQueue.Length > 1000) myDataQueue = "";

                myDataQueue += Convert.ToChar(removedItemInDataQueue).ToString();
                
                textBox1.Text = myDataQueue;

                if (Convert.ToChar(removedItemInDataQueue) == '$')
                {
                    recordFlag = true;
                    recordString = "";
                }

                if (recordFlag) recordString += Convert.ToChar(removedItemInDataQueue).ToString();

                if (Convert.ToChar(removedItemInDataQueue) == '\n' && recordFlag)
                {
                    recordFlag = false;
                    recordSubString = recordString.Split(',');

                    if (recordSubString[0] == "$GPGGA")
                    {
                        UTCTime = recordSubString[1];
                        GPSQualityIndication = recordSubString[6];
                    }
                }
                txtbxUTCTime.Text = UTCTime;
                txtbxGPSQual.Text = GPSQualityIndication;
            }

            textBox4.Text = timeoutCntr.ToString();
        }

        private void serCOM_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            lock (serCOM)                                                     // Lock the serial port for mutual exclusion
            {
                timeoutCntr = 0;
                byte newByte;                                                  // Initialize variable for reading bytes
                int bytesToRead = serCOM.BytesToRead;                         // Read from serial port the amount of bytes to read
                bytesToReadQueue.Enqueue(bytesToRead);                        // Puts amount of bytes to read to queue for updating form
                //newByte = serCOM.ReadByte();                                  // Read byte
                {
                    while(bytesToRead != 0 && serCOM.IsOpen == true)
                    {
                        newByte = (byte)serCOM.ReadByte();
                        bytesToRead = serCOM.BytesToRead;
                        outputDataQueue.Enqueue(newByte);                           // Enter the readBytes array into the concurrent outputDataQueue
                    } 

                    
                }
            }
        }

        private void tmrTimeOut_Tick(object sender, EventArgs e)
        {
            
            if (timeoutCntr == 10 && txtbxFileName.Text != "" && !timeoutFlag)
            {
                using (StreamWriter sw = File.AppendText(txtbxFileName.Text))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd h:mm:ss tt") + "," + "OFF");
                }

                timeoutFlag = true;
            }

            if (timeoutCntr == 0 && txtbxFileName.Text != "" && timeoutFlag)
            {
                using (StreamWriter sw = File.AppendText(txtbxFileName.Text))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd h:mm:ss tt") + "," + "ON");
                }

                timeoutFlag = false;
            }

            if (timeoutCntr == Int32.MaxValue) timeoutCntr = 10;
            timeoutCntr++;
        }

        private void txtbxFileName_Click(object sender, EventArgs e)
        {
            saveToCSV.Filter = "CSV|*.csv";
            saveToCSV.ShowDialog();
            if (saveToCSV.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                fileStreamForCSV = (System.IO.FileStream)saveToCSV.OpenFile();
                txtbxFileName.Text = fileStreamForCSV.Name.ToString();
                fileStreamForCSV.Close();
            }
            else
            {
                MessageBox.Show("No file selected. Please try again.", "ERROR");
            }
        }
    }
}
