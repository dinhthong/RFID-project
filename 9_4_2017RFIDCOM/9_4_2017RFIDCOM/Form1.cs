using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml;
namespace _9_4_2017RFIDCOM
{
    public partial class Form1 : Form
    {
        //Create a new Serial Port object
        SerialPort P = new SerialPort();
        //Declare a buffer for storing data
        string InputData = String.Empty;
        //declare an event inside a class
        delegate void SetTextCallback(string text);
        public Form1()
        {
            InitializeComponent();
            //ports variable to store all the available COM ports in Device List
            string[] ports = SerialPort.GetPortNames();
            /* Thêm toàn bộ các COM đã tìm được vào combox cbCom
             * Sử dụng AddRange thay vì dùng foreach
            */
            cbCom.Items.AddRange(ports);
            P.ReadTimeout = 1000;
            P.DataReceived += new SerialDataReceivedEventHandler(DataReceive);

            // Cài đặt cho BaudRate
            string[] BaudRate = { "1200", "2400", "4800", "9600", "19200",
"38400", "57600", "115200" };
            cbRate.Items.AddRange(BaudRate);
            // Cài đặt cho DataBits
            string[] Databits = { "6", "7", "8" };
            cbBits.Items.AddRange(Databits);
            //Cho Parity
            string[] Parity = { "None", "Odd", "Even" };
            cbParity.Items.AddRange(Parity);
            //Cho Stop bit
            string[] stopbit = { "1", "1.5", "2" };
            cbBit.Items.AddRange(stopbit);
            /* Mấy cái này khá đơn giản, bạn đừng hỏi vì sao. cứ COPY paste
            cho nhanh. :D */
        }

        // Hàm này được sự kiện nhận dử liệu gọi đến. Mục đích để hiển thị thôi
        private void DataReceive(object obj, SerialDataReceivedEventArgs e)
        {
            InputData = P.ReadExisting();
            if (InputData != String.Empty)
            {
                /* txtIn.Text = InputData; // Ko dùng đc như thế này vì khác
                threads. */
                SetText(InputData); /* Chính vì vậy phải sử dụng ủy quyền tại
                đây.Gọi delegate đã khai báo trước đó. */
            }
        }
        // Hàm của em nó là ở đây. Đừng hỏi vì sao lại thế.
        private void SetText(string text)
        {
            this.txtkq.Text = "";
            if (this.txtkq.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText); /* khởi tạo
                1 delegate mới gọi đến SetText */
                this.Invoke(d, new object[] { text });
            }
            else this.txtkq.Text += text;
        }
        // Toàn bộ cái này bạn nên COPY, nó cũng làm tôi đau đầu. :D

        private void Form1_Load(object sender, EventArgs e)
        {
            cbCom.SelectedIndex = 0; // chọn COM được tìm thấy đầu tiên
            cbRate.SelectedIndex = 3; // 9600
            cbBits.SelectedIndex = 2; // 8
            cbParity.SelectedIndex = 0; // None
            cbBit.SelectedIndex = 0; // None
            btdisc.Enabled = false;
            P.Close();
        }

        private void cbCom_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                // Nếu đang mở Port thì phải đóng lại. Vì không thể đang chạy mà thay đổi Port được
                P.Close(); 
            }
            P.PortName = cbCom.SelectedItem.ToString(); // Assign PortName by selected COM port!
            P.Open();
        }

        private void cbRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.BaudRate = Convert.ToInt32(cbRate.Text);
            P.Open();
        }

        private void cbBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.DataBits = Convert.ToInt32(cbBits.Text);
            P.Open();
        }

        private void cbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            // Với thằng Parity hơn lằng nhằng. Nhưng cũng OK thôi. ^_^
            switch (cbParity.SelectedItem.ToString())
            {
                case "Odd":
                    P.Parity = Parity.Odd;
                    break;
                case "None":
                    P.Parity = Parity.None;
                    break;
                case "Even":
                    P.Parity = Parity.Even;
                    break;
            }
            P.Open();
        }

        private void cbBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            switch (cbBit.SelectedItem.ToString())
            {
                case "1":
                    P.StopBits = StopBits.One;
                    break;
                case "1.5":
                    P.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    P.StopBits = StopBits.Two;
                    break;
            }
            P.Open();
        }

        private void btKetnoi_Click(object sender, EventArgs e)
        {
           
                    P.Open();
            //User cannot click in the btKetnoi button anymore
            
                    btKetnoi.Enabled = false;
            //User now can click in the btdisc button
            btdisc.Enabled = true;
            // Hiện thị Status
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            txtkq.Clear();
        }

        private void btdisc_Click(object sender, EventArgs e)
        {
            P.Close();
            btKetnoi.Enabled = true;
            btdisc.Enabled = false;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Do you want to exit?",
            "mfrc522", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                MessageBox.Show("Thanks!", "mfrc522");
                this.Close();
        }
    }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Write(txtSend.Text);
            }
            else MessageBox.Show("COM isn't connected", "mfrc522",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
