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

namespace Rez_Lab
{
    public partial class Admin_LogsCheck_Form : Form
    {
        public Admin_LogsCheck_Form()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void Admin_LogsCheck_Form_Load(object sender, EventArgs e)
        {
            LoadData();

        }



        private void LoadData()
        {
            // SQL-запрос для получения данных из таблицы Users
            string query = "SELECT * FROM Logs_update";

            // Создание DataTable для хранения данных
            DataTable dataTable = new DataTable();

            // Использование SqlConnection и SqlDataAdapter для получения данных
            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    adapter.Fill(dataTable); // Заполнение DataTable

                    // Привязка DataGridView к DataTable
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                }
            }

        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
