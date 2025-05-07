using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rez_Lab
{
    public partial class Lab_Form_Laborant : Form
    {
        


        public Lab_Form_Laborant()
        {
            InitializeComponent();
        }

        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date; // Получаем выбранную дату
            LoadDataDateTimePicker(selectedDate);
        }

        //private void btnSaveChanges_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        dataAdapter.Update(dataTable);
        //        MessageBox.Show("Данные успешно сохранены в базе данных.");
        //        LoadData(); // Перезагрузить данные, чтобы обновить DataGridView
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка сохранения данных: {ex.Message}");
        //    }
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Lab_Form_Laborant_Load(object sender, EventArgs e)
        {
            LoadData();
            Load_id();
            label8.Text = WC.fio.ToString();
            //this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            NotClickOnTable();


            //AddNewRowAtTop(DataGridView dataGridView1);
            //int[] columnsToCheck = { 0, 1, 2 }; // Индексы столбцов для проверки
            //HighlightEmptyCells(dataGridView1, columnsToCheck);
        }


        



        //private void HighlightEmptyCells(DataGridView dataGridView, int[] columns)
        //{
        //    foreach (DataGridViewRow row in dataGridView.Rows)
        //    {
        //        foreach (int columnIndex in columns)
        //        {
        //            if (string.IsNullOrEmpty(row.Cells[columnIndex].Value?.ToString()))
        //            {
        //                row.Cells[columnIndex].Style.BackColor = Color.Red;
        //            }
        //        }
        //    }
        //}






        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            
            LoadData();
            Load_id();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            //Add_data();

            MessageBox.Show("Данные добавлены !");
            //SendMail();
        }

        //private void Add_data()
        //{
        //    using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
        //    {
        //        connection.Open();

        //        string sqlInsert = "INSERT INTO Lab_Indicators ([Date_Create],[FIO_Lab],[indicator_1],[indicator_2],[indicator_3]) " +
        //                           "VALUES (@Date_Create, @FIO_Lab, @indicator_1, @indicator_2, @indicator_3)";

        //        using (SqlCommand command = new SqlCommand(sqlInsert, connection))
        //        {
        //            command.Parameters.AddWithValue("@Date_Create", DateTime.Now);
        //            command.Parameters.AddWithValue("@FIO_Lab", WC.fio);
        //            command.Parameters.AddWithValue("@indicator_1", txt_indicator_1.Text);
        //            command.Parameters.AddWithValue("@indicator_2", txt_indicator_2.Text);
        //            command.Parameters.AddWithValue("@indicator_3", txt_indicator_3.Text);

        //            command.ExecuteNonQuery();
        //            txt_indicator_1.Text = "";
        //            txt_indicator_2.Text = "";
        //            txt_indicator_3.Text = "";
        //        }
        //    }



        

        //    //using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
        //    //{
        //    //    connection.Open();



        //    //    // Вставка записи о действии в таблицу Logs_update
        //    //    //string login = "exampleUser"; // Замените реальными данными пользователя
        //    //    string logSql = "INSERT INTO Logs_add (AddedDate, Login, FIO, indicator_1, indicator_2, indicator_3) VALUES (@updatedDate, @login, @fio, @indicator_11, @indicator_22, @indicator_33);";

        //    //    using (SqlCommand logCommand = new SqlCommand(logSql, connection))
        //    //    {
        //    //        logCommand.Parameters.AddWithValue("@updatedDate", DateTime.Now);
        //    //        logCommand.Parameters.AddWithValue("@login", WC.login);
        //    //        logCommand.Parameters.AddWithValue("@fio", WC.fio);
        //    //        logCommand.Parameters.AddWithValue("@indicator_11", txt_indicator_1.Text);
        //    //        logCommand.Parameters.AddWithValue("@indicator_22", txt_indicator_2.Text);
        //    //        logCommand.Parameters.AddWithValue("@indicator_33", txt_indicator_3.Text);
        //    //        //logCommand.Parameters.AddWithValue("@id_indicators", selectedId);
        //    //        logCommand.ExecuteNonQuery();
        //    //    }

        //    //    //MessageBox.Show($"Данные изменены !");
        //    //}

        //    // Обновление таблицы после добавления новой записи
        //    LoadData();
        //}


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


        //private void SendMail()
        //{

        //    try
        //    {
        //        // Получаем email из текстового поля

        //        // Адрес отправителя с отображаемым именем
        //        MailAddress from = new MailAddress("rem.rab.mail@yandex.ru", "Лаборатория Резонит");

        //        // Адрес получателя
        //        MailAddress to = new MailAddress("ya.dudarev@rezonit.ru");

        //        // Создаем объект сообщения
        //        MailMessage msg = new MailMessage(from, to);

        //        // Тема письма
        //        msg.Subject = "Новые данные";

        //        // Текст письма
        //        msg.Body = "Сотрудник      " + WC.fio + "      Добавил новые данные: \n " +
        //            "Значение_1:  " + txt_indicator_1.Text + ";\n" +
        //            "Значение_2:  " + txt_indicator_2.Text + ";\n" +
        //            "Значение_3:  " + txt_indicator_3.Text + ".\n";

        //        // Письмо в формате HTML
        //        msg.IsBodyHtml = true;

        //        // Настройки SMTP-клиента
        //        SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587)
        //        {
        //            EnableSsl = true
        //        };

        //        // Установка учетных данных заранее
        //        smtp.Credentials = new NetworkCredential("rem.rab.mail@yandex.ru", "pqueycqykvevaqht");

        //        // Отправка письма
        //        smtp.Send(msg);

        //        // После отправки скрываем окно
        //        this.Hide();

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    // Проверка выбранного элемента comboBox_id
        //    if (textBox1.Text == "" &textBox2.Text == "" & textBox3.Text == "")
        //    {
        //        MessageBox.Show("Пожалуйста введите данные для обновления значений!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // Получение значений из элементов управления формы
        //    //string selectedId = comboBox_id.SelectedItem.ToString();
        //    string indicator1 = textBox1.Text;
        //    string indicator2 = textBox2.Text;
        //    string indicator3 = textBox3.Text;
        //    string connectionString = WC.ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        // Обновление данных в таблице Indicators
        //        //        string query = @"
        //        //UPDATE Indicators SET
        //        //    [date] = @CurrentDate,
        //        //    indicator_1 = @Indicator1,
        //        //    indicator_2 = @Indicator2,
        //        //    indicator_3 = @Indicator3,
        //        //    FIO = @FIO
        //        //WHERE id = @Id";


        //        string query = @"
        //UPDATE Lab_Indicators SET
        //    [Date_Lab_Update] = @CurrentDate,
        //    indicator_1 = @Indicator1,
        //    indicator_2 = @Indicator2,
        //    indicator_3 = @Indicator3,
        //    FIO_Lab_Update = @FIO_Lab_Update
        //WHERE ID = @Id";


        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
        //            command.Parameters.AddWithValue("@Indicator1", indicator1);
        //            command.Parameters.AddWithValue("@Indicator2", indicator2);
        //            command.Parameters.AddWithValue("@Indicator3", indicator3);
        //            command.Parameters.AddWithValue("@FIO_Lab_Update", WC.fio);
        //            command.Parameters.AddWithValue("@Id", WC.id_click);

        //            int rowsAffected = command.ExecuteNonQuery();
        //            MessageBox.Show("Данные изменены!");

        //        }
        //        LoadData();

        //    }
        //}



        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Убедитесь, что клик был не по заголовку столбца
        //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        //    {
        //        // Получение значения ID (предположим, что ID находится в первой колонке)
        //        var idValue = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

        //        // Проверка на null значение
        //        if (idValue != null && int.TryParse(idValue.ToString(), out WC.id_click))
        //        {
        //            // Показать groupBox2, если необходимо
        //            groupBox2.Visible = true;

        //            // Получение значений из колонок indicator_1, indicator_2 и indicator_3
        //            var indicator1Value = dataGridView1.Rows[e.RowIndex].Cells["indicator_1"].Value;
        //            var indicator2Value = dataGridView1.Rows[e.RowIndex].Cells["indicator_2"].Value;
        //            var indicator3Value = dataGridView1.Rows[e.RowIndex].Cells["indicator_3"].Value;

        //            // Установка значений в textbox'ы
        //            textBox1.Text = indicator1Value?.ToString() ?? string.Empty;
        //            textBox2.Text = indicator2Value?.ToString() ?? string.Empty;
        //            textBox3.Text = indicator3Value?.ToString() ?? string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Не удалось преобразовать значение ID.");
        //        }
        //    }
        //}
        int clickCount = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            
            clickCount++;

            switch (clickCount)
            {
                case 1:
                    groupBox3.Visible = true;
                    break;
                case 2:
                    groupBox3.Visible = false;
                    clickCount = 0;
                    LoadData();
                    break;

            }

            //groupBox3.Visible = true;
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
            //HighlightEmptyCells(dataGridView1, columnsToCheck);
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


        //private void AddNewRowAtTop(DataGridView dataGridView)
        //{
        //    DataGridViewRow newRow = new DataGridViewRow();
        //    newRow.CreateCells(dataGridView);
        //    newRow.Cells["Date_Create"].Value = DateTime.Now;  // Добавляем текущую дату
        //    dataGridView.Rows.Insert(0, newRow);
        //    dataGridView.CurrentCell = dataGridView.Rows[0].Cells[0];
        //}


        //private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex == 0)
        //    {
        //        // Получаем значения из данной строки
        //        var indicator1 = dataGridView1.Rows[0].Cells[0].Value?.ToString();
        //        var indicator2 = dataGridView1.Rows[0].Cells[1].Value?.ToString();
        //        var indicator3 = dataGridView1.Rows[0].Cells[2].Value?.ToString();

        //        // Переменная для FIO_Lab
        //        var fioLab = WC.fio;

        //        // Вставляем данные в базу данных
        //        InsertIntoDatabase(DateTime.Now, fioLab, indicator1, indicator2, indicator3);

        //        // Удаляем временную строку и добавляем новую строку сверху
        //        //dataGridView1.Rows.RemoveAt(0);
        //        //AddNewRowAtTop(dataGridView1);
        //    }
        //}

        //private void InsertIntoDatabase(DateTime dateCreate, string fioLab, string indicator1, string indicator2, string indicator3)
        //{
        //    using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
        //    {
        //        string query = "INSERT INTO Lab_Indicators (Date_Create, FIO_Lab, indicator_1, indicator_2, indicator_3) " +
        //                       "VALUES (@Date_Create, @FIO_Lab, @indicator_1, @indicator_2, @indicator_3)";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Date_Create", DateTime.Now);
        //            command.Parameters.AddWithValue("@FIO_Lab", fioLab);
        //            command.Parameters.AddWithValue("@indicator_1", indicator1 ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@indicator_2", indicator2 ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@indicator_3", indicator3 ?? (object)DBNull.Value);

        //            connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}




        private void Add_Row()
        {
            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                connection.Open();

                string sqlInsert = "INSERT INTO Lab_Indicators ([Date_Create],[FIO_Lab]) " +
                                   "VALUES (@Date_Create, @FIO_Lab)";

                using (SqlCommand command = new SqlCommand(sqlInsert, connection))
                {
                    command.Parameters.AddWithValue("@Date_Create", DateTime.Now);
                    command.Parameters.AddWithValue("@FIO_Lab", WC.fio);
                    command.ExecuteNonQuery();
                    
                }
            }
        }

        


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void UpdateRow()
        {
            // Убедитесь, что редактируемая ячейка находится в первой строке
            int rowIndex = 0;

            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                // Получаем значение первичного ключа
                var id = dataGridView1.Rows[rowIndex].Cells["ID"].Value;

                // Получаем значения обновляемых столбцов
                var fioLab = WC.fio; // Название столбца FIO_Lab
                var Date_Create = DateTime.Now;
                var indicator_1 = dataGridView1.Rows[rowIndex].Cells["indicator_1"].Value;
                var indicator_2 = dataGridView1.Rows[rowIndex].Cells["indicator_2"].Value;
                var indicator_3 = dataGridView1.Rows[rowIndex].Cells["indicator_3"].Value;

                // Создаем команду обновления с несколькими столбцами
                string updateQuery = @"
            UPDATE Lab_Indicators 
            SET [Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab,
                [indicator_1] = @indicator_1,
                [indicator_2] = @indicator_2,
                [indicator_3] = @indicator_3
            WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Добавляем параметры для каждого столбца
                    command.Parameters.AddWithValue("@Date_Create", Date_Create);
                    command.Parameters.AddWithValue("@FIO_Lab", fioLab);
                    command.Parameters.AddWithValue("@indicator_1", indicator_1 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@indicator_2", indicator_2 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@indicator_3", indicator_3 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Данные успешно Добавлены!");
                //LoadData();
            }
        }







        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что редактируется не столбец с ID
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
                    var FIO_Lab_Update = WC.fio; // Название столбца FIO_Lab
                    var Date_Lab_Update = DateTime.Now;
                    var indicator_1 = dataGridView1.Rows[e.RowIndex].Cells["indicator_1"].Value;
                    var indicator_2 = dataGridView1.Rows[e.RowIndex].Cells["indicator_2"].Value;
                    var indicator_3 = dataGridView1.Rows[e.RowIndex].Cells["indicator_3"].Value;

                    // Запрос для обновления данных
                    string updateQuery = @"
            UPDATE Lab_Indicators
            SET [Date_Lab_Update] = @Date_Lab_Update,
                [FIO_Lab_Update] = @FIO_Lab_Update,
                [indicator_1] = @indicator_1,
                [indicator_2] = @indicator_2,
                [indicator_3] = @indicator_3
            WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Параметры команды
                        command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
                        command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
                        command.Parameters.AddWithValue("@indicator_1", indicator_1 ?? DBNull.Value);
                        command.Parameters.AddWithValue("@indicator_2", indicator_2 ?? DBNull.Value);
                        command.Parameters.AddWithValue("@indicator_3", indicator_3 ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ID", id);

                        // Выполнение запроса
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                    }

                //MessageBox.Show("Данные успешно обновлены!");
                
                }
            // }
            //else
            //{
            // Сообщение об ошибке
            //MessageBox.Show("Вы не можете редактировать !", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            // Здесь вы можете вызвать метод LoadData() для обновления отображаемых данных, если это необходимо
            // LoadData();
            //LoadData();
        }

        private void NotClickOnTable()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "indicator_1" & column.Name != "indicator_2" & column.Name != "indicator_3") // предполагается, что "ID" - это столбец, который можно редактировать
                {
                    column.ReadOnly = true;
                }
            }
        }
        private bool isCellEndEditEnabled = true;

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Row();
            LoadData();

            if (isCellEndEditEnabled)
            {
                // Удаляем обработчик события
                dataGridView1.CellEndEdit -= dataGridView1_CellEndEdit_1;
                isCellEndEditEnabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateRow();

            if (!isCellEndEditEnabled)
            {
                // Добавляем обработчик события
                dataGridView1.CellEndEdit += dataGridView1_CellEndEdit_1;
                isCellEndEditEnabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }











    



}
