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

namespace ProductName
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
            displayDataUser();
            DisplayDataItems();
        }
        private void AdminPage_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Resources/pngwing_com_odK_icon.ico");
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductName.Properties.Settings.ETRADEConnectionString"].ConnectionString))
            {
                connection.Open();
                string ItemSelect = "SELECT DISTINCT CATEGORY1 FROM ITEM";
                SqlCommand commands = new SqlCommand(ItemSelect, connection);
                commands.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commands);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach(DataRow dataRow in dataTable.Rows)
                {
                    Category1Combo.Items.Add(dataRow["CATEGORY1"].ToString());
                }
                string ItemSelect2 = "SELECT DISTINCT CATEGORY2 FROM ITEM";
                SqlCommand commands2 = new SqlCommand(ItemSelect2, connection);
                commands2.ExecuteNonQuery();
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(commands2);
                DataTable dataTable2 = new DataTable();
                dataAdapter2.Fill(dataTable2);
                foreach (DataRow dataRow in dataTable2.Rows)
                {
                    Category2Combo.Items.Add(dataRow["CATEGORY2"].ToString());
                }
                string ItemSelect3 = "SELECT DISTINCT CATEGORY3 FROM ITEM";
                SqlCommand commands3 = new SqlCommand(ItemSelect3, connection);
                commands3.ExecuteNonQuery();
                SqlDataAdapter dataAdapter3 = new SqlDataAdapter(commands3);
                DataTable dataTable3 = new DataTable();
                dataAdapter3.Fill(dataTable3);
                foreach (DataRow dataRow in dataTable3.Rows)
                {
                    Category3Combo.Items.Add(dataRow["CATEGORY3"].ToString());
                }

            }


        }


        private void dataGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void displayDataUser()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductName.Properties.Settings.ETRADEConnectionString"].ConnectionString))
            {
                string ShowQuery = "SELECT ID,USERNAME_,PASSWORD_,ADMIN_ID FROM USER_";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(ShowQuery, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridUser.DataSource = dataTable;
            }
        }
        private void DisplayDataItems()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductName.Properties.Settings.ETRADEConnectionString"].ConnectionString))
            {
                string ShowQuery = "SELECT ID,ITEMCODE,ITEMNAME,PRICE,CATEGORY1,CATEGORY2,CATEGORY3 FROM ITEM";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(ShowQuery, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridItem.DataSource = dataTable;
            }
        }
        public void ClearMethods()
        {
            UsernameText.Text = " ";
            PasswordText.Text = " ";
            AdminText.Text = " ";
        }
        public void ClearMethod()
        {
            CodeText.Text = " ";
            NameText.Text = " ";
            PriceText.Text = " ";
            Category1Combo.Text = " ";
            Category2Combo.Text = " ";
            Category3Combo.Text = " ";
        }
        int userID;


        private void Category1Combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void AddButton1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductName.Properties.Settings.ETRADEConnectionString"].ConnectionString))
            {
                connection.Open();
                string AddQuery = "INSERT INTO USER_ (USERNAME_,PASSWORD_,ADMIN_ID) VALUES ('" + UsernameText.Text + "', '" + PasswordText.Text + "','" + AdminText.Text + "')";
                SqlCommand commands = new SqlCommand(AddQuery, connection);
                commands.ExecuteNonQuery();
                MessageBox.Show("Data Createad Successfully!");
                ClearMethods();
                displayDataUser(); //DIKKAT ET

            }
        }

        private void dataGridUser_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            userID = Convert.ToInt32(dataGridUser.Rows[e.RowIndex].Cells[0].Value.ToString());
            UsernameText.Text = dataGridUser.Rows[e.RowIndex].Cells[1].Value.ToString();
            PasswordText.Text = dataGridUser.Rows[e.RowIndex].Cells[2].Value.ToString();
            AdminText.Text = dataGridUser.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductName.Properties.Settings.ETRADEConnectionString"].ConnectionString))
            {
                connection.Open();
                string UpdateQuery = "UPDATE USER_ SET USERNAME_ = '" + UsernameText.Text + "', PASSWORD_ = '" + PasswordText.Text + "', ADMIN_ID = '" + AdminText.Text + "' WHERE ID = '" + userID + "'";
                SqlCommand commands = new SqlCommand(UpdateQuery, connection);
                commands.ExecuteNonQuery();
                MessageBox.Show("Data Updated Successfully!");
                ClearMethods();
                displayDataUser(); //DIKKAT ET

            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductName.Properties.Settings.ETRADEConnectionString"].ConnectionString))
            {
                connection.Open();
                string DeleteQuery = "DELETE FROM USER_ WHERE ID = '" + userID + "'";
                SqlCommand commands = new SqlCommand(DeleteQuery, connection);
                commands.ExecuteNonQuery();
                MessageBox.Show("Data Deleted Successfully!");
                ClearMethods();
                displayDataUser(); //DIKKAT ET

            }
        }

        private void dataGridItem_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int itemID;
        private void dataGridItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            itemID = Convert.ToInt32(dataGridItem.Rows[e.RowIndex].Cells[0].Value.ToString());
            CodeText.Text = dataGridItem.Rows[e.RowIndex].Cells[1].Value.ToString();
            NameText.Text = dataGridItem.Rows[e.RowIndex].Cells[2].Value.ToString();
            PriceText.Text = dataGridItem.Rows[e.RowIndex].Cells[3].Value.ToString();
            Category1Combo.Text = dataGridItem.Rows[e.RowIndex].Cells[4].Value.ToString();
            Category2Combo.Text = dataGridItem.Rows[e.RowIndex].Cells[5].Value.ToString();
            Category3Combo.Text = dataGridItem.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void AddButton2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductName.Properties.Settings.ETRADEConnectionString"].ConnectionString))
            {
                connection.Open();
                string AddQuery = "INSERT INTO ITEM (ITEMCODE, ITEMNAME, PRICE, CATEGORY1, CATEGORY2, CATEGORY3) VALUES ('" + CodeText.Text + "', '" + NameText.Text + "','" + PriceText.Text + "','" + Category1Combo.Text + "','" + Category2Combo.Text + "','" + Category3Combo.Text + "')";
                SqlCommand commands = new SqlCommand(AddQuery, connection);
                commands.ExecuteNonQuery();
                MessageBox.Show("Data Createad Successfully!");
                ClearMethod();
                DisplayDataItems(); //DIKKAT ET

            }
        }

        private void UpdateButton2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductName.Properties.Settings.ETRADEConnectionString"].ConnectionString))
            {
                connection.Open();
                string UpdateQuery = "UPDATE ITEM SET ITEMCODE = '" + CodeText.Text + "', ITEMNAME = '" + NameText.Text + "', PRICE = '" + PriceText.Text + "', CATEGORY1 = '" + Category1Combo.Text + "', CATEGORY2 = '" + Category2Combo.Text + "', CATEGORY3 = '" + Category3Combo.Text + "' WHERE ID = '" + itemID + "'";
                SqlCommand commands = new SqlCommand(UpdateQuery, connection);
                commands.ExecuteNonQuery();
                MessageBox.Show("Data Updated Successfully!");
                ClearMethod();
                DisplayDataItems(); //DIKKAT ET

            }
        }

        private void DeleteButton2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductName.Properties.Settings.ETRADEConnectionString"].ConnectionString))
            {
                connection.Open();
                string DeleteQuery = "DELETE FROM ITEM WHERE ID = '" + itemID + "'";
                SqlCommand commands = new SqlCommand(DeleteQuery, connection);
                commands.ExecuteNonQuery();
                MessageBox.Show("Data Deleted Successfully!");
                ClearMethod();
                DisplayDataItems(); //DIKKAT ET

            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginFrame = new Login();
            loginFrame.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
