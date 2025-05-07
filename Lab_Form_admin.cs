using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Rez_Lab
{
    public partial class Lab_Form_admin : Form
    {
        public Lab_Form_admin()
        {
            InitializeComponent();

            //this.MaximizeBox = false;

            LoadData();


        }

        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        private void LoadData()
        {
            // SQL-запрос для получения данных из таблицы Users
            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter("SELECT * FROM Lab_Indicators ORDER BY Date_Create DESC", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable; // Устанавливаем источник данных

                // Изменение названий столбцов
                dataGridView1.Columns["ID"].HeaderText = "Номер";
                dataGridView1.Columns["ID"].HeaderCell.Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                dataGridView1.Columns["Date_Create"].HeaderText = "Дата создания";
                dataGridView1.Columns["FIO_Lab"].HeaderText = "ФИО Создателя";
                dataGridView1.Columns["indicator_1"].HeaderText = "Значение 1";
                dataGridView1.Columns["indicator_2"].HeaderText = "Значение 2";
                dataGridView1.Columns["indicator_3"].HeaderText = "Значение 3";
                dataGridView1.Columns["Сorrection"].HeaderText = "Корректировка";
                dataGridView1.Columns["FIO_tech"].HeaderText = "ФИО Технолога";
                dataGridView1.Columns["Date_tech"].HeaderText = "Дата создания корректировки";
                dataGridView1.Columns["FIO_Lab_Update"].HeaderText = "ФИО Лаборанта (редакт)";
                dataGridView1.Columns["Date_Lab_Update"].HeaderText = "Дата (редакт)";
                dataGridView1.Columns["FIO_Corr"].HeaderText = "ФИО Корректировщика";
                dataGridView1.Columns["Date_Corr"].HeaderText = "Время выполнения корректировки";
                dataGridView1.Columns["Сompleted"].HeaderText = "Выполнение";

                // Продолжайте добавлять другие столбцы по мере необходимости
            }

        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        

        private void Lab_Form_admin_Load(object sender, EventArgs e)
        {
            label8.Text = WC.fio.ToString();

            LoadData();
        }

        


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ID")
                return;

            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                // Получаем значение первичного ключа
                var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

                // Получаем значения обновляемых столбцов
                var fioLab = dataGridView1.Rows[e.RowIndex].Cells["FIO_Lab"].Value; // Название столбца FIO_Lab
                var Date_Create = dataGridView1.Rows[e.RowIndex].Cells["Date_Create"].Value; 
                var indicator_1 = dataGridView1.Rows[e.RowIndex].Cells["indicator_1"].Value; 
                var indicator_2 = dataGridView1.Rows[e.RowIndex].Cells["indicator_2"].Value; 
                var indicator_3 = dataGridView1.Rows[e.RowIndex].Cells["indicator_3"].Value; 
                var Сorrection = dataGridView1.Rows[e.RowIndex].Cells["Сorrection"].Value; 
                var FIO_tech = dataGridView1.Rows[e.RowIndex].Cells["FIO_tech"].Value; 
                var Date_tech = dataGridView1.Rows[e.RowIndex].Cells["Date_tech"].Value; 
                var FIO_Lab_Update = dataGridView1.Rows[e.RowIndex].Cells["FIO_Lab_Update"].Value; 
                var Date_Lab_Update = dataGridView1.Rows[e.RowIndex].Cells["Date_Lab_Update"].Value; 
                var FIO_Corr = dataGridView1.Rows[e.RowIndex].Cells["FIO_Corr"].Value; 
                var Date_Corr = dataGridView1.Rows[e.RowIndex].Cells["Date_Corr"].Value;  
                var Сompleted = dataGridView1.Rows[e.RowIndex].Cells["Сompleted"].Value;  


                // Создаем команду обновления с несколькими столбцами
                string updateQuery = @"
            UPDATE Lab_Indicators 
            SET 
       [Date_Create] = @Date_Create
      ,[FIO_Lab] = @FIO_Lab
      ,[indicator_1] = @indicator_1
      ,[indicator_2] = @indicator_2
      ,[indicator_3] = @indicator_3
      ,[Сorrection] = @Сorrection
      ,[FIO_tech] = @FIO_tech
      ,[Date_tech] = @Date_tech
      ,[FIO_Lab_Update] = @FIO_Lab_Update
      ,[Date_Lab_Update] = @Date_Lab_Update
      ,[FIO_Corr] = @FIO_Corr
      ,[Date_Corr] = @Date_Corr
      ,[Сompleted] = @Сompleted
            WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Добавляем параметры для каждого столбца
                    command.Parameters.AddWithValue("@Date_Create", Date_Create);
                    command.Parameters.AddWithValue("@FIO_Lab", fioLab);
                    command.Parameters.AddWithValue("@indicator_1", indicator_1);
                    command.Parameters.AddWithValue("@indicator_2", indicator_2);
                    command.Parameters.AddWithValue("@indicator_3", indicator_3);
                    command.Parameters.AddWithValue("@Сorrection", Сorrection);
                    command.Parameters.AddWithValue("@FIO_tech", FIO_tech);
                    command.Parameters.AddWithValue("@Date_tech", Date_tech);
                    command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
                    command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
                    command.Parameters.AddWithValue("@FIO_Corr", FIO_Corr);
                    command.Parameters.AddWithValue("@Date_Corr", Date_Corr);
                    command.Parameters.AddWithValue("@Сompleted", Сompleted);
                    command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date; // Получаем выбранную дату
            LoadDataDateTimePicker(selectedDate);
        }

        private void LoadDataDateTimePicker(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Lab_Indicators WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SelectedDate", date);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable; // Отображаем данные в DataGridView
                }
            }
        }

        int clickCount = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            //int clickCount = 0;
            clickCount++;

            switch (clickCount)
            {
                case 1:
                    groupBox1.Visible = true;
                    break;
                case 2:
                    groupBox1.Visible = false;
                    clickCount = 0;
                    break;

            }
            //groupBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker2.Value.Date;
            DateTime endDate = dateTimePicker3.Value.Date;

            // Проверка, что начальная дата не позже конечной
            if (startDate > endDate)
            {
                MessageBox.Show("Начальная дата не может быть позже конечной даты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Дальнейшие действия с диапазоном дат
            //MessageBox.Show($"Выбранный диапазон дат:\nС: {startDate.ToShortDateString()}\nПо: {endDate.ToShortDateString()}");

            // Загрузка данных на основании выбранного диапазона
            LoadDataByDateRange(startDate, endDate);
        }

        private void LoadDataByDateRange(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Lab_Indicators WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Отображаем данные в DataGridView
                }
            }
        }
    }





}





