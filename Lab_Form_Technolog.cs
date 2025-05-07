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


namespace Rez_Lab
{
    public partial class Lab_Form_Technolog : Form
    {
        
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        int[] columnsToCheck = { 6 }; // Индексы столбцов для проверки
        public Lab_Form_Technolog()
        {
            InitializeComponent();

            // Конфигурация DateTimePicker
            //dateTimePickerStart.Value = DateTime.Now.AddMonths(-1); // Установка начальной даты на месяц назад
            //dateTimePickerEnd.Value = DateTime.Now;


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


        private void Lab_Form_Technolog_Load(object sender, EventArgs e)
        {
            label8.Text = WC.fio.ToString();
            LoadData();
            //Load_id();
            // Задайте обработчик событий для DataGridView
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            HighlightEmptyCells(dataGridView1, columnsToCheck);

            NotClickOnTable();
        }


        private void HighlightEmptyCells(DataGridView dataGridView, int[] columns)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (int columnIndex in columns)
                {
                    if (string.IsNullOrEmpty(row.Cells[columnIndex].Value?.ToString()))
                    {
                        row.Cells[columnIndex].Style.BackColor = Color.Red;
                    }
                }
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка выбранного элемента comboBox_id
            if (textBox1.Text == "")
            {
                MessageBox.Show("Пожалуйста впишите корректировку!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получение значений из элементов управления формы
            //string selectedId = comboBox_id.SelectedItem.ToString();
            string corr = textBox1.Text;
            //string indicator2 = textBox2.Text;
            //string indicator3 = textBox3.Text;
            string connectionString = WC.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Обновление данных в таблице Indicators
                //        string query = @"
                //UPDATE Indicators SET
                //    [date] = @CurrentDate,
                //    indicator_1 = @Indicator1,
                //    indicator_2 = @Indicator2,
                //    indicator_3 = @Indicator3,
                //    FIO = @FIO
                //WHERE id = @Id";


                string query = @"
        UPDATE Lab_Indicators SET
            [Date_tech] = @Date_tech,
            Сorrection = @Сorrection,
            FIO_tech = @FIO_tech
        WHERE ID = @Id";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date_tech", DateTime.Now);
                    command.Parameters.AddWithValue("@Сorrection", corr);
                    //command.Parameters.AddWithValue("@Indicator2", indicator2);
                    //command.Parameters.AddWithValue("@Indicator3", indicator3);
                    command.Parameters.AddWithValue("@FIO_tech", WC.fio);
                    command.Parameters.AddWithValue("@Id", WC.id_click);

                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show("Корректировка добавлена!");

                }
                LoadData();
                HighlightEmptyCells(dataGridView1, columnsToCheck);

            }

        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            LoadData();
            //Load_id();
            HighlightEmptyCells(dataGridView1, columnsToCheck);
        }

        //private void Load_id()
        //{
        //    //comboBox_id.Items.Clear();
        //    string connectionString = WC.ConnectionString; // Замените вашей строкой подключения
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT DISTINCT ID FROM Lab_Indicators ORDER BY Date_Create DESC";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    //comboBox_id.Items.Clear();
        //                    //comboBox_id.Items.Add(reader["id"].ToString());
        //                }
        //            }
        //        }
        //    }
        //    HighlightEmptyCells(dataGridView1, columnsToCheck);
        //}





        

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
            HighlightEmptyCells(dataGridView1, columnsToCheck);
        }


        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            
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

        // Метод, который можно использовать для обработки изменения даты, если необходимо
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = ((DateTimePicker)sender).Value.Date;
            // Можно использовать selectedDate для выполнения каких-либо действий при изменении даты
        }






        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверьте, что клик был не по заголовку столбца
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
                        groupBox2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Не удалось преобразовать значение ID.");
                    }
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ID")
                return;

            // Проверяем, что редактируемая ячейка находится не в первой строке
            //if (e.RowIndex != 0)
            // {
            // Подключение к базе данных
            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                // Получаем значение первичного ключа
                var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

                // Подготавливаем обновляемые данные
                var FIO_tech = WC.fio; // Название столбца FIO_Lab
                var Date_tech = DateTime.Now;
                var Сorrection = dataGridView1.Rows[e.RowIndex].Cells["Сorrection"].Value;
                

                // Запрос для обновления данных
                string updateQuery = @"
            UPDATE Lab_Indicators
            SET [Date_tech] = @Date_tech,
                [FIO_tech] = @FIO_tech,
                [Сorrection] = @Сorrection
            WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Параметры команды
                    command.Parameters.AddWithValue("@Date_tech", Date_tech);
                    command.Parameters.AddWithValue("@FIO_tech", FIO_tech);
                    command.Parameters.AddWithValue("@Сorrection", Сorrection ?? DBNull.Value);
            
                    command.Parameters.AddWithValue("@ID", id);

                    // Выполнение запроса
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    //LoadData();
                    HighlightEmptyCells(dataGridView1, columnsToCheck);

                }

                //MessageBox.Show("Данные успешно обновлены!");

            }
        }


        private void NotClickOnTable()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "Сorrection") // предполагается, что "ID" - это столбец, который можно редактировать
                {
                    column.ReadOnly = true;
                }
            }
        }


    }
}
