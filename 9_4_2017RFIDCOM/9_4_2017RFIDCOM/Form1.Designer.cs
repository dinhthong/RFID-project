namespace _9_4_2017RFIDCOM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtkq = new System.Windows.Forms.TextBox();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.cbRate = new System.Windows.Forms.ComboBox();
            this.cbBits = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btKetnoi = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btdisc = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtkq
            // 
            this.txtkq.Location = new System.Drawing.Point(260, 57);
            this.txtkq.Multiline = true;
            this.txtkq.Name = "txtkq";
            this.txtkq.Size = new System.Drawing.Size(336, 121);
            this.txtkq.TabIndex = 0;
            // 
            // cbCom
            // 
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(85, 25);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(121, 21);
            this.cbCom.TabIndex = 1;
            this.cbCom.SelectedIndexChanged += new System.EventHandler(this.cbCom_SelectedIndexChanged);
            this.cbCom.SelectedValueChanged += new System.EventHandler(this.cbCom_SelectedValueChanged);
            // 
            // cbRate
            // 
            this.cbRate.FormattingEnabled = true;
            this.cbRate.Location = new System.Drawing.Point(85, 65);
            this.cbRate.Name = "cbRate";
            this.cbRate.Size = new System.Drawing.Size(121, 21);
            this.cbRate.TabIndex = 1;
            this.cbRate.SelectedIndexChanged += new System.EventHandler(this.cbRate_SelectedIndexChanged);
            // 
            // cbBits
            // 
            this.cbBits.FormattingEnabled = true;
            this.cbBits.Location = new System.Drawing.Point(85, 110);
            this.cbBits.Name = "cbBits";
            this.cbBits.Size = new System.Drawing.Size(121, 21);
            this.cbBits.TabIndex = 1;
            this.cbBits.SelectedIndexChanged += new System.EventHandler(this.cbBits_SelectedIndexChanged);
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(85, 157);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(121, 21);
            this.cbParity.TabIndex = 1;
            this.cbParity.SelectedIndexChanged += new System.EventHandler(this.cbParity_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Parity";
            // 
            // cbBit
            // 
            this.cbBit.FormattingEnabled = true;
            this.cbBit.Location = new System.Drawing.Point(85, 203);
            this.cbBit.Name = "cbBit";
            this.cbBit.Size = new System.Drawing.Size(121, 21);
            this.cbBit.TabIndex = 6;
            this.cbBit.SelectedIndexChanged += new System.EventHandler(this.cbBit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Stopbit";
            // 
            // btKetnoi
            // 
            this.btKetnoi.Location = new System.Drawing.Point(15, 247);
            this.btKetnoi.Name = "btKetnoi";
            this.btKetnoi.Size = new System.Drawing.Size(75, 23);
            this.btKetnoi.TabIndex = 8;
            this.btKetnoi.Text = "CONNECT";
            this.btKetnoi.UseVisualStyleBackColor = true;
            this.btKetnoi.Click += new System.EventHandler(this.btKetnoi_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(260, 196);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(75, 23);
            this.btXoa.TabIndex = 9;
            this.btXoa.Text = "Clear";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Received Data";
            // 
            // btdisc
            // 
            this.btdisc.Location = new System.Drawing.Point(116, 247);
            this.btdisc.Name = "btdisc";
            this.btdisc.Size = new System.Drawing.Size(90, 23);
            this.btdisc.TabIndex = 11;
            this.btdisc.Text = "DISCONNECT";
            this.btdisc.UseVisualStyleBackColor = true;
            this.btdisc.Click += new System.EventHandler(this.btdisc_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(40, 280);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 12;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(260, 237);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(336, 20);
            this.txtSend.TabIndex = 13;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(521, 280);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 14;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 315);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.btdisc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btKetnoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbBit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbParity);
            this.Controls.Add(this.cbBits);
            this.Controls.Add(this.cbRate);
            this.Controls.Add(this.cbCom);
            this.Controls.Add(this.txtkq);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txtkq;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.ComboBox cbRate;
        private System.Windows.Forms.ComboBox cbBits;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btKetnoi;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btdisc;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btSend;
    }
}

