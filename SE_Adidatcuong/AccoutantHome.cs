using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SE_Adidatcuong
{
    public partial class AccoutantHome : Form
    {
        String WRid = "";
        String DBid = "";
        String OrderID = "";
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AdidatcuongConn"].ConnectionString);
        public AccoutantHome()
        {
            InitializeComponent();
            customizeDesign();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy";
            dateTimePicker2.ShowUpDown = true;
        }

        private void customizeDesign()
        {
            panel_wrSubmenu.Visible = false;
            panel_dbSubmenu.Visible = false;
            panel_OrderSubmenu.Visible = false;
            panel_StatisticsSubmenu.Visible = false;
        }

        private void HideSubMenu()
        {
            if(panel_wrSubmenu.Visible == true)
            {
                panel_wrSubmenu.Visible = false;
            }
            if (panel_dbSubmenu.Visible == true)
            {
                panel_dbSubmenu.Visible = false;
            }
            if (panel_OrderSubmenu.Visible == true)
            {
                panel_OrderSubmenu.Visible = false;
            }
            if (panel_StatisticsSubmenu.Visible == true)
            {
                panel_StatisticsSubmenu.Visible = false;
            }
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void AccoutantHome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adidatcuongDataSet.Order_Detail' table. You can move, or remove it, as needed.
            this.order_DetailTableAdapter.Fill(this.adidatcuongDataSet.Order_Detail);
            // TODO: This line of code loads data into the 'adidatcuongDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.adidatcuongDataSet.Orders);
            // TODO: This line of code loads data into the 'adidatcuongDataSet.DB_Detail' table. You can move, or remove it, as needed.
            this.dB_DetailTableAdapter.Fill(this.adidatcuongDataSet.DB_Detail);
            // TODO: This line of code loads data into the 'adidatcuongDataSet.DeliveryBill' table. You can move, or remove it, as needed.
            this.deliveryBillTableAdapter.Fill(this.adidatcuongDataSet.DeliveryBill);
            // TODO: This line of code loads data into the 'adidatcuongDataSet.WR_Detail' table. You can move, or remove it, as needed.
            this.wR_DetailTableAdapter.Fill(this.adidatcuongDataSet.WR_Detail);
            // TODO: This line of code loads data into the 'adidatcuongDataSet.WarehouseReceipt' table. You can move, or remove it, as needed.
            this.warehouseReceiptTableAdapter.Fill(this.adidatcuongDataSet.WarehouseReceipt);
            callOnLoad();
        }

        private void callOnLoad()
        {
            AccoutantSignIn accs = new AccoutantSignIn();
            accs.ShowDialog();
            panel_WR.BringToFront();
            label_datetime.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
        }

        private void button_warehouseReceipt_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_wrSubmenu);
        }

        private void button_deliveryBill_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_dbSubmenu);
        }

        private void button_order_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_OrderSubmenu);
        }

        private void button_statistics_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_StatisticsSubmenu);
        }

        private void button_WRview_Click(object sender, EventArgs e)
        {
            updateDataWR();
            panel_WR.BringToFront();
            HideSubMenu();
        }

        public void updateDataWR()
        {
            this.warehouseReceiptTableAdapter.Fill(this.adidatcuongDataSet.WarehouseReceipt);
            this.wR_DetailTableAdapter.Fill(this.adidatcuongDataSet.WR_Detail);
            dataGridView_WR.Update();
            dataGridView_WRdetail.Update();
            dataGridView_WR.Refresh();
            dataGridView_WRdetail.Refresh();
        }
        private void button_WRnew_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(DateTime.Now);
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "INSERT INTO WarehouseReceipt VALUES ('" + date.ToString("yyyy-MM-dd") + "',0,'" + AccoutantSignIn.accID + "')";
            cmd.ExecuteNonQuery();
            cnn.Close();
            dataGridView_WR.Refresh();
            WRcreator wrc = new WRcreator(this);
            wrc.ShowDialog();
            HideSubMenu();
        }

        private void button_DBview_Click(object sender, EventArgs e)
        {
            updateDataDB();
            panel_DB.BringToFront();
            HideSubMenu();
        }

        public void updateDataDB()
        {
            this.deliveryBillTableAdapter.Fill(this.adidatcuongDataSet.DeliveryBill);
            this.dB_DetailTableAdapter.Fill(this.adidatcuongDataSet.DB_Detail);
            dataGridView_DB.Update();
            dataGridView_DBdetail.Update();
            dataGridView_DB.Refresh();
            dataGridView_DBdetail.Refresh();
        }
        private void button_DBnew_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(DateTime.Now);
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "INSERT INTO DeliveryBill VALUES ('OD001','" + date.ToString("yyyy-MM-dd") + "','" + AccoutantSignIn.accID + "')";
            cmd.ExecuteNonQuery();
            cnn.Close();
            dataGridView_DB.Refresh();
            DBcreator dbc = new DBcreator(this);
            dbc.ShowDialog();
            HideSubMenu();
        }

        private void button_Orderview_Click(object sender, EventArgs e)
        {
            this.order_DetailTableAdapter.Fill(this.adidatcuongDataSet.Order_Detail);
            this.ordersTableAdapter.Fill(this.adidatcuongDataSet.Orders);
            dataGridView_Order.Update();
            dataGridView_Orderdetail.Update();
            dataGridView_Order.Refresh();
            dataGridView_Orderdetail.Refresh();
            panel_Order.BringToFront();
            HideSubMenu();
        }

        private void button_Statview_Click(object sender, EventArgs e)
        {
            dataGridView_Import.Update();
            dataGridView_Export.Update();
            dataGridView_Import.Refresh();
            dataGridView_Export.Refresh();
            panel_Statistics.BringToFront();
            HideSubMenu();
        }

        private void button_signout_Click(object sender, EventArgs e)
        {
            if(System.Windows.MessageBox.Show("Do you want to Sign out?","SIGN OUT", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Restart();
            }
        }

        private void dataGridView_WR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataWRdetail();
            dataGridView_WR.Refresh();
            dataGridView_WRdetail.Refresh();
            WRid = dataGridView_WR.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void LoadDataWRdetail()
        {
            try
            {
                int index = dataGridView_WR.SelectedCells[0].RowIndex;
                if(index < 0 || index >= dataGridView_WR.RowCount)
                {
                    System.Windows.Forms.MessageBox.Show("Please select a Warehouse Receipt first");
                }

                DataGridViewRow row = dataGridView_WR.Rows[index];
                String wrID = row.Cells[0].Value.ToString();
                SqlCommand cmd = new SqlCommand("Select * FROM WR_Detail where WRID='" + wrID + "'", cnn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    dataGridView_WRdetail.DataSource = dt;
                }
                else
                {
                }
                adapter.Dispose();
                dataGridView_WRdetail.Refresh();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView_DB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataDBdetail();
            dataGridView_DB.Refresh();
            dataGridView_DBdetail.Refresh();
            DBid = dataGridView_DB.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void LoadDataDBdetail()
        {
            try
            {
                int index = dataGridView_DB.SelectedCells[0].RowIndex;
                if (index < 0 || index >= dataGridView_DB.RowCount)
                {
                    System.Windows.Forms.MessageBox.Show("Please select a Delivery Bill first");
                }

                DataGridViewRow row = dataGridView_DB.Rows[index];
                String dbID = row.Cells[0].Value.ToString();
                SqlCommand cmd = new SqlCommand("Select * FROM DB_Detail where [DBID]='" + dbID + "'", cnn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView_DBdetail.DataSource = dt;
                }
                else
                {
                }
                adapter.Dispose();
                dataGridView_DBdetail.Refresh();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView_Order_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataOrderdetail();
            dataGridView_Order.Refresh();
            dataGridView_Orderdetail.Refresh();
            OrderID = dataGridView_Order.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void LoadDataOrderdetail()
        {
            try
            {
                int index = dataGridView_Order.SelectedCells[0].RowIndex;
                if (index < 0 || index >= dataGridView_Order.RowCount)
                {
                    System.Windows.Forms.MessageBox.Show("Please select an Order first");
                }

                DataGridViewRow row = dataGridView_Order.Rows[index];
                String orderID = row.Cells[0].Value.ToString();
                SqlCommand cmd = new SqlCommand("Select * FROM Order_Detail where OrderID='" + orderID + "'", cnn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView_Orderdetail.DataSource = dt;
                }
                else
                {
                }
                adapter.Dispose();
                dataGridView_Orderdetail.Refresh();
            }
            catch (Exception)
            {

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String month = dateTimePicker1.Value.Month.ToString();
            String year = dateTimePicker2.Value.Year.ToString();

            //System.Windows.Forms.MessageBox.Show(month, year);

            cnn.Open();

            SqlCommand cmd1 = new SqlCommand("SP_ImportByMonth", cnn);
            SqlCommand cmd2 = new SqlCommand("SP_ExportByMonth", cnn);

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@inputMonth", SqlDbType.Char).Value = month;
            cmd1.Parameters.Add("@inputYear", SqlDbType.Char).Value = year;

            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@inputMonth", SqlDbType.Char).Value = month;
            cmd2.Parameters.Add("@inputYear", SqlDbType.Char).Value = year;

            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            cnn.Close();

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);

            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dataGridView_Import.DataSource = dt1;

            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            dataGridView_Export.DataSource = dt2;

            dataGridView_Import.Refresh();
            dataGridView_Export.Refresh();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            String month = dateTimePicker1.Value.Month.ToString();
            String year = dateTimePicker2.Value.Year.ToString();

            cnn.Open();

            SqlCommand cmd1 = new SqlCommand("SP_ImportByMonth", cnn);
            SqlCommand cmd2 = new SqlCommand("SP_ExportByMonth", cnn);

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@inputMonth", SqlDbType.Char).Value = month;
            cmd1.Parameters.Add("@inputYear", SqlDbType.Char).Value = year;

            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@inputMonth", SqlDbType.Char).Value = month;
            cmd2.Parameters.Add("@inputYear", SqlDbType.Char).Value = year;

            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            cnn.Close();

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);

            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dataGridView_Import.DataSource = dt1;

            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            dataGridView_Export.DataSource = dt2;

            dataGridView_Import.Refresh();
            dataGridView_Export.Refresh();
        }

        private void button_WRdelete_Click(object sender, EventArgs e)
        {
            if(WRid != "")
            {
                SqlCommand cmd1 = new SqlCommand();
                SqlCommand cmd2 = new SqlCommand();
                cnn.Open();
                cmd1.Connection = cnn;
                cmd1.CommandText = "DELETE FROM WR_Detail WHERE WRID= '" + WRid + "'";
                cmd1.ExecuteNonQuery();

                cmd2.Connection = cnn;
                cmd2.CommandText = "DELETE FROM WarehouseReceipt WHERE WRID= '" + WRid + "'";
                cmd2.ExecuteNonQuery();
                cnn.Close();
                updateDataWR();
            }
            else
            {
                MessageBox.Show("Select a row to delete!");
            }
        }

        private void button_DBdelete_Click(object sender, EventArgs e)
        {
            if (DBid != "")
            {
                SqlCommand cmd1 = new SqlCommand();
                SqlCommand cmd2 = new SqlCommand();
                cnn.Open();
                cmd1.Connection = cnn;
                cmd1.CommandText = "DELETE FROM DB_Detail WHERE [DBID]= '" + DBid + "'";
                cmd1.ExecuteNonQuery();

                cmd2.Connection = cnn;
                cmd2.CommandText = "DELETE FROM DeliveryBill WHERE [DBID]= '" + DBid + "'";
                cmd2.ExecuteNonQuery();
                cnn.Close();
                updateDataDB();
            }
            else
            {
                MessageBox.Show("Select a row to delete!");
            }
        }
        public void updateDataOrder()
        {
            this.ordersTableAdapter.Fill(this.adidatcuongDataSet.Orders);
            dataGridView_Order.Update();
            dataGridView_Order.Refresh();
        }
        private void button_Waiting_Click(object sender, EventArgs e)
        {
            if(OrderID != "")
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Orders SET Status='Waiting' WHERE OrderID='" + OrderID + "'";
                cmd.ExecuteNonQuery();
                cnn.Close();
                updateDataOrder();
            }
            else
            {
                MessageBox.Show("Select an order to update status.");
            }
        }

        private void button_Transferring_Click(object sender, EventArgs e)
        {
            if (OrderID != "")
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Orders SET Status='Transferring' WHERE OrderID='" + OrderID + "'";
                cmd.ExecuteNonQuery();
                cnn.Close();
                updateDataOrder();
            }
            else
            {
                MessageBox.Show("Select an order to update status.");
            }
        }

        private void button_Paid_Click(object sender, EventArgs e)
        {
            if (OrderID != "")
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Orders SET Status='Paid' WHERE OrderID='" + OrderID + "'";
                cmd.ExecuteNonQuery();
                cnn.Close();
                updateDataOrder();
            }
            else
            {
                MessageBox.Show("Select an order to update status.");
            }
        }
    }
}
