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

namespace Rez_Lab
{
    public partial class Avtorize : Form
    {
	

		public Avtorize()
        {
            InitializeComponent();

			this.MaximizeBox = false;

			//comboBox1.Text = "";

			textBox1.Text = "Логин";
            textBox1.ForeColor = Color.Gray;

            textBox2.Text = "Пароль";
            textBox2.ForeColor = Color.Gray;
            textBox2.UseSystemPasswordChar = false;



			
		}

		




		private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = WC.ConnectionString; // Получаем FIO и Role по введенному логину и паролю
            string query = "SELECT id, FIO, Role, Login FROM Users WHERE Login = @login AND Password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", textBox1.Text);
                command.Parameters.AddWithValue("@password", textBox2.Text);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            WC.id_User = reader["id"].ToString();
                            WC.login = reader["Login"].ToString();
                            WC.fio = reader["FIO"].ToString();
                            string role = reader["Role"].ToString();

                            Form nextForm = null; // Объявляем переменную для следующей формы

                            // Определяем, какую форму открыть в зависимости от роли
                            if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                            {
                                nextForm = new StartWindow_admin();
                            }
                            else if (role.Equals("laborant", StringComparison.OrdinalIgnoreCase))
                            {
                                nextForm = new StartWindow_laborant();
                            }
                            else if (role.Equals("technolog", StringComparison.OrdinalIgnoreCase))
                            {
                                nextForm = new StartWindow_technolog();
                            }
                            else if (role.Equals("corrector", StringComparison.OrdinalIgnoreCase))
                            {
                                nextForm = new StartWindow_correcter();
                            }
							else if (role.Equals("info_corrector", StringComparison.OrdinalIgnoreCase))
							{
								nextForm = new Start_Info_correcter();
							}
							else if (role.Equals("info_technolog", StringComparison.OrdinalIgnoreCase))
							{
								nextForm = new Start_Info_technolog();
							}
							else
                            {
                                MessageBox.Show("Вашей роли не предусмотрен доступ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
							textBox1.Text = "Логин";
							textBox1.ForeColor = Color.Gray;

							textBox2.Text = "Пароль";
							textBox2.ForeColor = Color.Gray;
							textBox2.UseSystemPasswordChar = false;


							// Закрываем DataReader перед выполнением новой команды
							reader.Close();

                            // SQL-запрос для вставки данных в таблицу Logs_Avtorize
                            string insertQuery = @"INSERT INTO Logs_Avtorize (User_ID, User_Login, User_Role, User_FIO, Date_Avtorize)
                                           VALUES (@User_ID, @User_Login, @User_Role, @User_FIO, @Date_Avtorize)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                // Установка значений параметров
                                insertCommand.Parameters.AddWithValue("@User_ID", WC.id_User);
                                insertCommand.Parameters.AddWithValue("@User_Login", WC.login);
                                insertCommand.Parameters.AddWithValue("@User_Role", role);
                                insertCommand.Parameters.AddWithValue("@User_FIO", WC.fio);
                                insertCommand.Parameters.AddWithValue("@Date_Avtorize", DateTime.Now); // Текущее время

                                // Выполняем команду вставки
                                insertCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show($"Добро пожаловать, {WC.fio}!", "Приветствие", MessageBoxButtons.OK);
                            this.Hide();
                            nextForm.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Вы ввели неверный логин или пароль", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Логин")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Пароль";
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Логин";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void Authorize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                StartWindow_laborant sww = new StartWindow_laborant();
                sww.ShowDialog();
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = WC.ConnectionString; // Получаем FIO и Role по введенному логину и паролю
            string query = "SELECT id, FIO, Role, Login FROM Users WHERE Login = @login AND Password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", comboBox1.Text);
                command.Parameters.AddWithValue("@password", textBox2.Text);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            WC.id_User = reader["id"].ToString();
                            WC.login = reader["Login"].ToString();
                            WC.fio = reader["FIO"].ToString();
                            string role = reader["Role"].ToString();

                            Form nextForm = null; // Объявляем переменную для следующей формы

                            // Определяем, какую форму открыть в зависимости от роли
                            if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                            {
                                nextForm = new StartWindow_admin();
                            }
                            else if (role.Equals("worker", StringComparison.OrdinalIgnoreCase))
                            {
                                nextForm = new StartWindow_laborant();
                            }
                            else if (role.Equals("technolog", StringComparison.OrdinalIgnoreCase))
                            {
                                nextForm = new StartWindow_technolog();
                            }
                            else if (role.Equals("corrector", StringComparison.OrdinalIgnoreCase))
                            {
                                nextForm = new StartWindow_correcter();
                            }
                            else
                            {
                                MessageBox.Show("Вашей роли не предусмотрен доступ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Закрываем DataReader перед выполнением новой команды
                            reader.Close();

                            // SQL-запрос для вставки данных в таблицу Logs_Avtorize
                            string insertQuery = @"INSERT INTO Logs_Avtorize (User_ID, User_Login, User_Role, User_FIO, Date_Avtorize)
                                           VALUES (@User_ID, @User_Login, @User_Role, @User_FIO, @Date_Avtorize)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                // Установка значений параметров
                                insertCommand.Parameters.AddWithValue("@User_ID", WC.id_User);
                                insertCommand.Parameters.AddWithValue("@User_Login", WC.login);
                                insertCommand.Parameters.AddWithValue("@User_Role", role);
                                insertCommand.Parameters.AddWithValue("@User_FIO", WC.fio);
                                insertCommand.Parameters.AddWithValue("@Date_Avtorize", DateTime.Now); // Текущее время

                                // Выполняем команду вставки
                                insertCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show($"Добро пожаловать, {WC.fio}!", "Приветствие", MessageBoxButtons.OK);
                            this.Hide();
                            nextForm.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Вы ввели неверный логин или пароль", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DataTable usersTable = new DataTable();
        private void Load_FIO_Login()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
                {
                    string query = "SELECT Login FROM Users";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(usersTable);
                }

                comboBox1.DisplayMember = "Login";
                comboBox1.ValueMember = "Login";
                comboBox1.DataSource = usersTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                if (comboBox1.SelectedIndex != -1)
                {
                    WC.selectedLogin = comboBox1.SelectedValue.ToString();
                    comboBox1.Text = WC.selectedLogin;

                //MessageBox.Show("Выбранный логин: " + selectedLogin);
            }

        }

        private void Avtorize_Load(object sender, EventArgs e)
        {
            Load_FIO_Login();
        }
    }
    
}

