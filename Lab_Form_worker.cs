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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Rez_Lab
{
    public partial class Lab_Form_worker : Form
    {
        public Lab_Form_worker()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void Lab_Form_worker_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                string sqlQuery = "SELECT * FROM Indicators ORDER BY Date_Create DESC";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void Add_data()
        {
            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                connection.Open();

                string sqlInsert = "INSERT INTO Indicators ([date], [indicator_1], [indicator_2], [indicator_3], [FIO]) " +
                                   "VALUES (@date, @indicator_1, @indicator_2, @indicator_3, @FIO)";

                using (SqlCommand command = new SqlCommand(sqlInsert, connection))
                {
                    command.Parameters.AddWithValue("@date", DateTime.Now);
                    command.Parameters.AddWithValue("@indicator_1", txt_indicator_1.Text);
                    command.Parameters.AddWithValue("@indicator_2", txt_indicator_2.Text);
                    command.Parameters.AddWithValue("@indicator_3", txt_indicator_3.Text);
                    command.Parameters.AddWithValue("@FIO", WC.fio);

                    command.ExecuteNonQuery();
                }
            }

            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                connection.Open();

                

                // Вставка записи о действии в таблицу Logs_update
                //string login = "exampleUser"; // Замените реальными данными пользователя
                string logSql = "INSERT INTO Logs_add (AddedDate, Login, FIO, indicator_1, indicator_2, indicator_3) VALUES (@updatedDate, @login, @fio, @indicator_11, @indicator_22, @indicator_33);";

                using (SqlCommand logCommand = new SqlCommand(logSql, connection))
                {
                    
                    logCommand.Parameters.AddWithValue("@updatedDate", DateTime.Now);
                    logCommand.Parameters.AddWithValue("@login", WC.login);
                    logCommand.Parameters.AddWithValue("@fio", WC.fio);
                    logCommand.Parameters.AddWithValue("@indicator_11", txt_indicator_1.Text);
                    logCommand.Parameters.AddWithValue("@indicator_22", txt_indicator_2.Text);
                    logCommand.Parameters.AddWithValue("@indicator_33", txt_indicator_3.Text);
                    //logCommand.Parameters.AddWithValue("@id_indicators", selectedId);
                    logCommand.ExecuteNonQuery();
                }

                //MessageBox.Show($"Данные изменены !");
            }

            // Обновление таблицы после добавления новой записи
            LoadData();
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            Add_data();
           
            MessageBox.Show("Данные добавлены !");
            SendMail();


        }

        private void SendMail()
        {

            try
            {
                // Получаем email из текстового поля

                // Адрес отправителя с отображаемым именем
                MailAddress from = new MailAddress("rem.rab.mail@yandex.ru", "Лаборатория Резонит");

                // Адрес получателя
                MailAddress to = new MailAddress("ya.dudarev@rezonit.ru");

                // Создаем объект сообщения
                MailMessage msg = new MailMessage(from, to);

                // Тема письма
                msg.Subject = "Новые данные";

                // Текст письма
                msg.Body = "Сотрудник      " + WC.fio + "      Добавил новые данные: \n " +
                    "Значение_1:  " + txt_indicator_1.Text + ";\n" +
                    "Значение_2:  " + txt_indicator_2.Text + ";\n" +
                    "Значение_3:  " + txt_indicator_3.Text + ".\n";

                // Письмо в формате HTML
                msg.IsBodyHtml = true;

                // Настройки SMTP-клиента
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587)
                {
                    EnableSsl = true
                };

                // Установка учетных данных заранее
                smtp.Credentials = new NetworkCredential("rem.rab.mail@yandex.ru", "pqueycqykvevaqht");

                // Отправка письма
                smtp.Send(msg);

                // После отправки скрываем окно
                this.Hide();

            }
            catch (Exception ex)
            {
               
            }
        }


     
        }
    }




