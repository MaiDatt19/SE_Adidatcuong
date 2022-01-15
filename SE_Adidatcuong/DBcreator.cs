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
    public partial class DBcreator : Form
    {
        public String newDBid = "";
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AdidatcuongConn"].ConnectionString);
        public DBcreator(AccoutantHome ah)
        {
            InitializeComponent();
            ahome = ah;
        }
        AccoutantHome ahome;

        private void button_WRreset_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown9.Value = 0;
            numericUpDown10.Value = 0;
        }
        private void WRcreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((sender as Form).ActiveControl is Button)
            {

            }

            else
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM DeliveryBill WHERE DBID= '" + newDBid + "'";
                cmd.ExecuteNonQuery();
                cnn.Close();
                ahome.updateDataWR();
            }
        }

        private void DBcreator_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adidatcuongDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.adidatcuongDataSet.Orders);
            cnn.Open();
            SqlCommand cmdDB = new SqlCommand("SELECT * FROM DeliveryBill WHERE ID in (SELECT MAX(ID) FROM DeliveryBill)", cnn);
            SqlDataAdapter adapterDB = new SqlDataAdapter(cmdDB);
            DataTable dtDB = new DataTable();
            adapterDB.Fill(dtDB);
            newDBid = (String)dtDB.Rows[0]["DBID"];
            cnn.Close();
        }

        private void button_DBcreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            //1
            if (numericUpDown1.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO DB_Detail VALUES ('" + newDBid + "','P001'," + numericUpDown1.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //2
            if (numericUpDown2.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO DB_Detail VALUES ('" + newDBid + "','P002'," + numericUpDown2.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //3
            if (numericUpDown3.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO DB_Detail VALUES ('" + newDBid + "','P003'," + numericUpDown3.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //4
            if (numericUpDown4.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO DB_Detail VALUES ('" + newDBid + "','P004'," + numericUpDown4.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //5
            if (numericUpDown5.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO DB_Detail VALUES ('" + newDBid + "','P005'," + numericUpDown5.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //6
            if (numericUpDown6.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO DB_Detail VALUES ('" + newDBid + "','P006'," + numericUpDown6.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //7
            if (numericUpDown7.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO DB_Detail VALUES ('" + newDBid + "','P007'," + numericUpDown7.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //8
            if (numericUpDown8.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO DB_Detail VALUES ('" + newDBid + "','P008'," + numericUpDown8.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //9
            if (numericUpDown9.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO DB_Detail VALUES ('" + newDBid + "','P009'," + numericUpDown9.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //10
            if (numericUpDown10.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO DB_Detail VALUES ('" + newDBid + "','P010'," + numericUpDown10.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            String orderID = comboBox_OrderID.Text;
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "UPDATE DeliveryBill SET OrderID='" + orderID + "' WHERE [DBID]='" + newDBid + "'";
            cmd.ExecuteNonQuery();
            cnn.Close();
            ahome.updateDataDB();
            this.Close();
        }
    }
}
