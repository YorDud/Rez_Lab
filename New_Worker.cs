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
    public partial class New_Worker : Form
    {
        public New_Worker()
        {
            InitializeComponent();

            this.MaximizeBox = false;

        }


        private void button1_Click(object sender, EventArgs e)
        {
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				string query = "INSERT INTO Users (Login, Password, Role, FIO) VALUES (@Login, @Password, @Role, @FIO)";

				using (SqlCommand command = new SqlCommand(query, connection))
				{
					
                    
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
                    {

						// Добавление параметров
						command.Parameters.AddWithValue("@Login", textBox2.Text);
						command.Parameters.AddWithValue("@Password", textBox1.Text);
						command.Parameters.AddWithValue("@Role", comboBox1.SelectedItem.ToString());
						command.Parameters.AddWithValue("@FIO", textBox3.Text);

						try
						{
							connection.Open();
							command.ExecuteNonQuery();
							MessageBox.Show("Пользователь успешно добавлен!");
							textBox1.Clear();
							textBox2.Clear();
							textBox3.Clear();
							comboBox1.Text = "";
						}
						catch (Exception ex)
						{
							MessageBox.Show("Ошибка: " + ex.Message);
						}
					}
                    else
                    {
						MessageBox.Show("Ошибка: " + "Заполните все поля!");
					}
					
				}
			}
		}





        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void Authorize_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
             

        }

        private void New_Worker_Load(object sender, EventArgs e)
        {
            
        }

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
            this.Hide();
		}
	}
    
}

