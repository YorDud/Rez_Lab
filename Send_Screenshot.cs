using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Word = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Net.Mail;
using System.Net;
using Rez_Lab.Trav_Med_1;

namespace Rez_Lab
{
    public partial class Send_Screenshot : Form
    {
		private Bitmap _screenshot;
		//private ComboBox comboBox1;
		public Send_Screenshot(Bitmap screenshot)
        {
            InitializeComponent();

			_screenshot = screenshot;

			this.MaximizeBox = false;

			
			//checkBox1.CheckedChanged += CheckBoxShowComboBox_CheckedChanged;

        }
		string selectedEmployee;
		string email;


		private void comboBoxFIO_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxFIO.SelectedIndex != -1)
			{
				// Получаем выбранное значение из ValueMember (Login)
				selectedEmployee = comboBoxFIO.SelectedValue.ToString();
				// Для отладки можно отобразить выбранный Login
				// MessageBox.Show($"Выбранный Login: {selectedEmployee}");
			}
			else
			{
				selectedEmployee = null;
			}

			
			if (selectedEmployee != null)
			{
				email = $"{selectedEmployee}@rezonit.ru";

			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			SendMail(_screenshot);

		}
		private void SendMail(Bitmap screenshot)
		{
			try
			{
				// Указываем адрес отправителя и получателя
				MailAddress from = new MailAddress("labrezonit@yandex.ru", "Лаборатория Резонит");
				MailAddress to = new MailAddress(email);

				// Создаем объект сообщения
				MailMessage msg = new MailMessage(from, to)
				{
					Subject = $"Скриншот от: {WC.fio}",
					Body = $"ФИО отправителя:  {WC.fio}{Environment.NewLine}Сообщение:  {textBox1.Text}"
				};

				// Конвертируем скриншот в поток и прикрепляем к письму
				using (MemoryStream memoryStream = new MemoryStream())
				{
					screenshot.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
					memoryStream.Position = 0; // Сбрасываем позицию потока

					Attachment attachment = new Attachment(memoryStream, "screenshot.png", "image/png");
					msg.Attachments.Add(attachment);

					// Настройки SMTP-клиента
					SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587)
					{
						EnableSsl = true,
						Credentials = new NetworkCredential("labrezonit@yandex.ru", "rzogoynecstkvdth")
					};

					// Отправка письма
					smtp.Send(msg);
				}

				// Уведомление об успешной отправке
				MessageBox.Show("Скриншот успешно отправлен на почту.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

				// Закрываем форму после отправки
				this.Close();
			}
			catch (Exception ex)
			{
				// Обработка ошибок при отправке
				MessageBox.Show($"Ошибка при отправке почты: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	

		

		private void CheckBoxShowComboBox_CheckedChanged(object sender, EventArgs e)
		{
			// Изменяем видимость ComboBox в зависимости от состояния CheckBox
			//comboBox1.Visible = checkBox1.Checked;
		}








		

        private void Send_Screenshot_Load(object sender, EventArgs e)
        {
			LoadFIOs();
		}
		private void LoadFIOs()
		{
			try
			{
				// Список для хранения пользователей
				List<User> users = new List<User>();

				using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
				{
					conn.Open();

					// Запрос для получения FIO и Login из таблицы Users
					string query = "SELECT FIO, Login FROM Users";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								users.Add(new User
								{
									FIO = reader["FIO"].ToString(),
									Login = reader["Login"].ToString()
								});
							}
						}
					}
				}

				// Настраиваем ComboBox
				comboBoxFIO.DataSource = users;
				comboBoxFIO.DisplayMember = "FIO"; // Столбец для отображения
				comboBoxFIO.ValueMember = "Login"; // Соответствующее значение
				comboBoxFIO.SelectedIndex = -1; // Снимаем выбор по умолчанию
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}




		private void pictureBox1_Click(object sender, EventArgs e)
		{
            this.Hide();
		}

		
	}
    
}

