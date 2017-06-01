namespace _4_5_2017Cswithdatabaserfid
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
            this.txtdep = new System.Windows.Forms.TextBox();
            this.txtsid = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtbirth = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btadd = new System.Windows.Forms.Button();
            this.btmodify = new System.Windows.Forms.Button();
            this.btdelete = new System.Windows.Forms.Button();
            this.btsave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtdep
            // 
            this.txtdep.Location = new System.Drawing.Point(394, 100);
            this.txtdep.Name = "txtdep";
            this.txtdep.Size = new System.Drawing.Size(127, 20);
            this.txtdep.TabIndex = 0;
            // 
            // txtsid
            // 
            this.txtsid.Location = new System.Drawing.Point(260, 63);
            this.txtsid.Name = "txtsid";
            this.txtsid.Size = new System.Drawing.Size(127, 20);
            this.txtsid.TabIndex = 1;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(260, 12);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(127, 20);
            this.txtname.TabIndex = 3;
            // 
            // txtbirth
            // 
            this.txtbirth.Location = new System.Drawing.Point(526, 16);
            this.txtbirth.Name = "txtbirth";
            this.txtbirth.Size = new System.Drawing.Size(127, 20);
            this.txtbirth.TabIndex = 4;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(526, 63);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(127, 20);
            this.txtid.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Full name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Birthday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Student ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "RFID ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Department";
            // 
            // btadd
            // 
            this.btadd.Location = new System.Drawing.Point(31, 139);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(75, 23);
            this.btadd.TabIndex = 11;
            this.btadd.Text = "Add";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // btmodify
            // 
            this.btmodify.Location = new System.Drawing.Point(199, 139);
            this.btmodify.Name = "btmodify";
            this.btmodify.Size = new System.Drawing.Size(75, 23);
            this.btmodify.TabIndex = 12;
            this.btmodify.Text = "Modify";
            this.btmodify.UseVisualStyleBackColor = true;
            this.btmodify.Click += new System.EventHandler(this.btmodify_Click);
            // 
            // btdelete
            // 
            this.btdelete.Location = new System.Drawing.Point(381, 139);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(75, 23);
            this.btdelete.TabIndex = 13;
            this.btdelete.Text = "Delete";
            this.btdelete.UseVisualStyleBackColor = true;
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(560, 139);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 23);
            this.btsave.TabIndex = 14;
            this.btsave.Text = "Save";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fullname,
            this.Birthday,
            this.Department,
            this.StudentID,
            this.TagID});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 188);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(730, 150);
            this.dataGridView1.TabIndex = 15;
            // 
            // Fullname
            // 
            this.Fullname.DataPropertyName = "Fullname";
            this.Fullname.HeaderText = "Full Name";
            this.Fullname.Name = "Fullname";
            // 
            // Birthday
            // 
            this.Birthday.DataPropertyName = "Birthday";
            this.Birthday.HeaderText = "Birth Day";
            this.Birthday.Name = "Birthday";
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "DePartment";
            this.Department.Name = "Department";
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "StudentID";
            this.StudentID.HeaderText = "Student ID";
            this.StudentID.Name = "StudentID";
            // 
            // TagID
            // 
            this.TagID.DataPropertyName = "TagID";
            this.TagID.HeaderText = "Tag ID";
            this.TagID.Name = "TagID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 340);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.btdelete);
            this.Controls.Add(this.btmodify);
            this.Controls.Add(this.btadd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtbirth);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtsid);
            this.Controls.Add(this.txtdep);
            this.Name = "Form1";
            this.Text = "D";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtdep;
        private System.Windows.Forms.TextBox txtsid;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtbirth;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.Button btmodify;
        private System.Windows.Forms.Button btdelete;
        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagID;
    }
}

