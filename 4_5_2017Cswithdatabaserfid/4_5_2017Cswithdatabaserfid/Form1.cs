using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_5_2017Cswithdatabaserfid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7M6OGCJ\SQLEXPRESS;Initial Catalog=VIDU;Integrated Security=True"); // connection string
        //private void ketnoicsdl()
        //{
        //    con.Open();
        //    string sql = "select * from BKU";  // lay het du lieu trong bang sinh vien
        //    SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
        //    com.CommandType = CommandType.Text;
        //    SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
        //    DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
        //    da.Fill(dt);  // đổ dữ liệu vào kho
        //    con.Close();  // đóng kết nối
        //    dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        //}
        private connectdatabase kn = new connectdatabase();
        private void Form1_Load(object sender, EventArgs e)
        {
            loadform();
        }

        private void loadform()
        {
            kn.loadall(this.dataGridView1);
            btsave.Enabled = false;
            loadTextBox();
        }
        private bool kt;
        private void btadd_Click(object sender, EventArgs e)
        {
            kt = true;
            btsave.Enabled = true;
            btadd.Enabled = false;
            btmodify.Enabled = false;
            btdelete.Enabled = false;
        }

        private void loadTextBox()
        {
            txtname.DataBindings.Clear();
            txtname.DataBindings.Add("Text", dataGridView1.DataSource, "Fullname");
            txtbirth.DataBindings.Clear();
            txtbirth.DataBindings.Add("Text", dataGridView1.DataSource, "Birthday");
            txtdep.DataBindings.Clear();
            txtdep.DataBindings.Add("Text", dataGridView1.DataSource, "Department");
            txtsid.DataBindings.Clear();
            txtsid.DataBindings.Add("Text", dataGridView1.DataSource, "StudentID");
            txtid.DataBindings.Clear();
            txtid.DataBindings.Add("Text", dataGridView1.DataSource, "TagID");

        }
        private void btsave_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim() != "")
            {
                if (kt)
                {
                    btadd.Enabled = false;
                    btdelete.Enabled = false;
                    kn.addStudent(txtname.Text, txtbirth.Text, txtdep.Text, txtid.Text, txtsid.Text);
                    loadform();
                    btadd.Enabled = true;
                    btmodify.Enabled = true;
                    btdelete.Enabled = true;
                    btsave.Enabled = false;
                    MessageBox.Show("Add successfully");
                    loadTextBox();
                }
                else
                {
                    btadd.Enabled = false;
                    btdelete.Enabled = false;
                    kn.modifyStudent(txtname.Text, txtbirth.Text, txtdep.Text, txtid.Text, txtsid.Text);
                    loadform();
                    btadd.Enabled = true;
                    btmodify.Enabled = true;
                    btdelete.Enabled = true;
                    btsave.Enabled = false;
                    MessageBox.Show("Modify successfully");
                    loadTextBox();
                    txtname.ReadOnly = false;
                }
                
            }
        }

        private void btmodify_Click(object sender, EventArgs e)
        {
            kt = false;
            txtname.ReadOnly = true;
            btsave.Enabled = true;
            btadd.Enabled = false;
            btmodify.Enabled = false;
            btdelete.Enabled = false;
        }
    }
}
