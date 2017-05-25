using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_5_2017Cswithdatabaserfid
{
    class connectdatabase
    {
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7M6OGCJ\SQLEXPRESS;Initial Catalog=VIDU;Integrated Security=True"); // connection string
        private DataTable dt;
    

 
        public void loadall(DataGridView _dtV)
        {   
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "SELECT * from BKU";
                SqlCommand comd = new SqlCommand(sql, con);
                comd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(comd);
                dt = new DataTable();
                da.Fill(dt);
                _dtV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void addStudent(string name,string birth,string depart,string stuid,string tagid)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "tb_Add"; //ten cua SQL procedure
                SqlCommand comd = new SqlCommand(sql, con);
                comd.CommandType=CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("fullname", SqlDbType.NChar)).Value = name;//map trong store
                comd.Parameters.Add(new SqlParameter("birthday", SqlDbType.NChar)).Value = birth;
                comd.Parameters.Add(new SqlParameter("department", SqlDbType.NChar)).Value = depart;
                comd.Parameters.Add(new SqlParameter("studentid", SqlDbType.NChar)).Value = stuid;
                comd.Parameters.Add(new SqlParameter("tagid", SqlDbType.NChar)).Value = tagid;

                comd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void modifyStudent(string name, string birth, string depart, string stuid, string tagid)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "tb_Modify"; //ten cua SQL procedure
                SqlCommand comd = new SqlCommand(sql, con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("fullname", SqlDbType.NChar)).Value = name;//map trong store
                comd.Parameters.Add(new SqlParameter("birthday", SqlDbType.NChar)).Value = birth;
                comd.Parameters.Add(new SqlParameter("department", SqlDbType.NChar)).Value = depart;
                comd.Parameters.Add(new SqlParameter("studentid", SqlDbType.NChar)).Value = stuid;
                comd.Parameters.Add(new SqlParameter("tagid", SqlDbType.NChar)).Value = tagid;

                comd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
