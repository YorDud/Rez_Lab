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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Rez_Lab
{
    public partial class Lab_Form_Corrector : Form
    {
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        int[] columnsToCheck = { 13 };
        //int columnsToCheck =  13;
        int targetColumnIndex = 13; // Индекс столбца, который нужно проверить на пустые значения
        string buttonText = "✔"; // Текст на кнопке
        public Lab_Form_Corrector()
        {
            InitializeComponent();
        }

        
        private void LoadData()
        {
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
        

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date; // Получаем выбранную дату
            LoadDataDateTimePicker(selectedDate);
            //int columnsToCheck = 14;
            //int[] columnsToCheck = { 14 }; // теперь не надо закрывать и открывать страницу заново
            HighlightEmptyCells(dataGridView1, columnsToCheck);
        }

        private void Lab_Form_Corrector_Load(object sender, EventArgs e)
        {
            label8.Text = WC.fio.ToString();
            LoadData();
            Load_id();

            HighlightEmptyCells(dataGridView1, columnsToCheck);
            NotClickOnTable();


        }

        

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            LoadData();
            Load_id();


            HighlightEmptyCells(dataGridView1, columnsToCheck);
        }

        private void Load_id()
        {
            //comboBox_id.Items.Clear();
            string connectionString = WC.ConnectionString; // Замените вашей строкой подключения
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT ID FROM Lab_Indicators";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //comboBox_id.Items.Clear();
                            //comboBox_id.Items.Add(reader["id"].ToString());
                        }
                    }
                }
            }
        }


        private void HighlightEmptyCells(DataGridView dataGridView, int[] columns)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Проверяем, что значение в 6-м столбике (индекс 5) не пустое
                if (!string.IsNullOrEmpty(row.Cells[6].Value?.ToString()))
                {
                    foreach (int columnIndex in columns)
                    {
                        if (string.IsNullOrEmpty(row.Cells[columnIndex].Value?.ToString()))
                        {
                            row.Cells[columnIndex].Style.BackColor = Color.Red;
                            row.DefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }
                }
            }
        }





        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;

            // Убедиться, что клик был по кнопке
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Получить ID из соответствующей ячейки (например, первой ячейки строки)
                int selectedRowId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["ID"].Value);

                string completed = "Выполнено!";
                string connectionString = WC.ConnectionString;

                string query = @"UPDATE Lab_Indicators SET
                [Date_Corr] = @Date_Corr, 
                Сompleted = @Сompleted,
                FIO_Corr = @FIO_Corr
            WHERE ID = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Date_Corr", DateTime.Now);
                        command.Parameters.AddWithValue("@Сompleted", completed);
                        command.Parameters.AddWithValue("@FIO_Corr", WC.fio);
                        command.Parameters.AddWithValue("@Id", WC.id_click);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Корректировка добавлена!");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить данные.");
                        }
                    }
                }

                
            }
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
            HighlightEmptyCells(dataGridView1, columnsToCheck);

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

        private void button2_Click_1(object sender, EventArgs e)
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
            //int[] columnsToCheck = { 14 };
            HighlightEmptyCells(dataGridView1, columnsToCheck);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Получите значение ID из первой колонки (например, индекс 0)
                var idValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                // Проверка на null значение
                if (idValue != null)
                {

                    if (int.TryParse(idValue.ToString(), out WC.id_click))
                    {
                        // Используйте значение id по вашему усмотрению
                        //MessageBox.Show("ID выбранной строки: " + id_click);

                        string completed = "Выполнено!";
                        string connectionString = WC.ConnectionString;

                        string query = @"UPDATE Lab_Indicators SET
                [Date_Corr] = @Date_Corr, 
                Сompleted = @Сompleted,
                FIO_Corr = @FIO_Corr
            WHERE ID = @Id";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Date_Corr", DateTime.Now);
                                command.Parameters.AddWithValue("@Сompleted", completed);
                                command.Parameters.AddWithValue("@FIO_Corr", WC.fio);
                                command.Parameters.AddWithValue("@Id", WC.id_click);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Корректировка добавлена!");
                                    LoadData();
                                    //int[] columnsToCheck = { 14 };
                                    HighlightEmptyCells(dataGridView1, columnsToCheck);
                                }
                                else
                                {
                                    MessageBox.Show("Не удалось обновить данные.");
                                }
                            }
                        }



                    }
                    else
                    {
                        MessageBox.Show("Не удалось преобразовать значение ID.");
                    }
                }
            }


        }



        private void NotClickOnTable()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "R") // предполагается, что "ID" - это столбец, который можно редактировать
                {
                    column.ReadOnly = true;
                }
            }
        }




















    }
}
