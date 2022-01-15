using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Adidatcuong
{
    public partial class AccoutantSignIn : Form
    {
        public static string accID = "";
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AdidatcuongConn"].ConnectionString);
        public AccoutantSignIn()
        {
            InitializeComponent();
        }

        private void button_signin_Click(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select AccountantID, Password from [Accountant] where AccountantID ='" + input_accountantID.Text + "'and Password = '" + input_Password.Text + "'", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                accID = input_accountantID.Text;
                MessageBox.Show("Sign In Success");

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login, please check ID or password");
            }
            cnn.Close();
        }


        private void button_reset_Click(object sender, EventArgs e)
        {
            input_accountantID.Clear();
            input_Password.Clear();
        }

        private void AccoutantSignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((sender as Form).ActiveControl is Button)
            {

            }

            else
            {
                Application.Exit();
            }
        }

    }
}
