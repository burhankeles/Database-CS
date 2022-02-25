using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProductName
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        { 
            using (SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-T2G46R2;Initial Catalog=ETRADE;Integrated Security=True"))
            {
                string queryLogin = "SELECT * FROM USER_ WHERE USERNAME_ = '" + UsernameText.Text.Trim() + "'AND PASSWORD_ = '" + PasswordText.Text.Trim() + "'";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(queryLogin, connect))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count == 1)
                    {

                        using (SqlDataAdapter dataAdapterAdmin = new SqlDataAdapter("SELECT * FROM USER_ WHERE ADMIN_ID = 1 AND USERNAME_ = '" + UsernameText.Text.Trim() + "'AND PASSWORD_ = '" + PasswordText.Text.Trim() + "'", connect))
                        {
                            DataTable dataTableAdmin = new DataTable();
                            dataAdapterAdmin.Fill(dataTableAdmin);
                            if (dataTableAdmin.Rows.Count == 1)
                            {
                                AdminPage AdminFrame = new AdminPage();
                                this.Hide();
                                AdminFrame.Show();
                            }
                            else
                            {
                                Main MainFrame = new Main();
                                this.Hide();
                                MainFrame.Show();
                            }
                        }



                    }
                    else
                    {
                        MessageBox.Show("Check Username and password!");
                    }
                }
            }    

            
            
            
            
        }

        private void UsernameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-T2G46R2;Initial Catalog=ETRADE;Integrated Security=True"))
            {
                connect.Open();
                string registerQuery = "INSERT INTO USER_ (USERNAME_,PASSWORD_) VALUES ('" + UsernameText.Text + "', '" + PasswordText.Text + "')";
                SqlCommand commands = new SqlCommand(registerQuery, connect);
                commands.ExecuteNonQuery();
                MessageBox.Show("Data Createad Successfully!");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Resources/pngwing_com_odK_icon.ico");
        }
    }
}
