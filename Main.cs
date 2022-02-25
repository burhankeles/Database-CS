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
using System.Configuration;

namespace ProductName
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        DataTable dataTable = new DataTable("USER_");
        private void Main_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Resources/pngwing_com_odK_icon.ico");
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductName.Properties.Settings.ETRADEConnectionString"].ConnectionString))
            {
                string queryAdapter = "SELECT U.USERNAME_ KULLANICIADI, BD.LASTMODIFIEDDATE SONDEGISTIRMETARIHI, B.AMOUNT MIKTAR, B.PRICE UCRET, B.TOTAL TOPLAMUCRET,I.ITEMNAME, I.CATEGORY1, I.CATEGORY2, I.CATEGORY3, A.ADDRESSTEXT, C.CITY, INV.CARGOFICHENO, INVD.ORDERDETAILID FROM USER_ U INNER JOIN BASKET BD ON BD.USERID = U.ID INNER JOIN BASKETDETAIL B ON BD.ID = B.BASKETID INNER JOIN ITEM I ON I.ID = B.ID INNER JOIN ORDER_ O ON O.BASKETID = BD.ID INNER JOIN ADDRES A ON A.ID = O.ADDRESSID INNER JOIN CITY C ON C.ID=A.CITYID INNER JOIN INVOICE INV ON INV.ORDERID= O.ID INNER JOIN INVOICEDETAIL INVD ON INVD.ID = INV.ID";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(queryAdapter, connection))
                {
                    dataAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
            }
        }

        private void SearchBarText_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchBarText_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dataView = dataTable.DefaultView;
                dataView.RowFilter = string.Format("KULLANICIADI like '%{0}%'", SearchBarText.Text);
                dataGridView.DataSource = dataView.ToTable();
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginFrame = new Login();
            loginFrame.Show();
        }

        private void CloseApplicationButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


