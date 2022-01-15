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
    public partial class WRcreator : Form
    {
        public int totalMoney=0;
        public String newWRid = "";
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AdidatcuongConn"].ConnectionString);
        public WRcreator(AccoutantHome ah)
        {
            InitializeComponent();
            ahome = ah;
        }
        AccoutantHome ahome;
        private void WRcreator_Load(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmdWR = new SqlCommand("SELECT * FROM WarehouseReceipt WHERE ID in (SELECT MAX(ID) FROM WarehouseReceipt)", cnn);
            SqlDataAdapter adapterWR = new SqlDataAdapter(cmdWR);
            DataTable dtWR = new DataTable();
            adapterWR.Fill(dtWR);
            newWRid = (String)dtWR.Rows[0]["WRID"];
            cnn.Close();
        }
        private void button_WRcreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            //1
            if(numericUpDown1.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO WR_Detail VALUES ('"+newWRid+"','P001',"+ numericUpDown1.Value+")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //2
            if (numericUpDown2.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO WR_Detail VALUES ('" + newWRid + "','P002'," + numericUpDown2.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //3
            if (numericUpDown3.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO WR_Detail VALUES ('" + newWRid + "','P003'," + numericUpDown3.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //4
            if (numericUpDown4.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO WR_Detail VALUES ('" + newWRid + "','P004'," + numericUpDown4.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //5
            if (numericUpDown5.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO WR_Detail VALUES ('" + newWRid + "','P005'," + numericUpDown5.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //6
            if (numericUpDown6.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO WR_Detail VALUES ('" + newWRid + "','P006'," + numericUpDown6.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //7
            if (numericUpDown7.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO WR_Detail VALUES ('" + newWRid + "','P007'," + numericUpDown7.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //8
            if (numericUpDown8.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO WR_Detail VALUES ('" + newWRid + "','P008'," + numericUpDown8.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //9
            if (numericUpDown9.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO WR_Detail VALUES ('" + newWRid + "','P009'," + numericUpDown9.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //10
            if (numericUpDown10.Value > 0)
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO WR_Detail VALUES ('" + newWRid + "','P010'," + numericUpDown10.Value + ")";
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "UPDATE WarehouseReceipt SET TotalMoney=" + numericUpDown_TotalMoney.Value + " WHERE WRID='" + newWRid + "'";
            cmd.ExecuteNonQuery();
            cnn.Close();
            ahome.updateDataWR();
            this.Close();
        }

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
            if((sender as Form).ActiveControl is Button)
            {
                
            }

            else
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM WarehouseReceipt WHERE WRID= '" + newWRid + "'";
                cmd.ExecuteNonQuery();
                cnn.Close();
                ahome.updateDataWR();
            }
        }
    }
}
