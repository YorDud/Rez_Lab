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

namespace Rez_Lab
{
    public partial class Save_Excel : Form
    {
		
		//private ComboBox comboBox1;
		public Save_Excel()
        {
            InitializeComponent();

            this.MaximizeBox = false;

			
			//checkBox1.CheckedChanged += CheckBoxShowComboBox_CheckedChanged;

        }
		

		private void button1_Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				comboBox1.Visible = false;
				string tablesQuery = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'Lab_Rez'";
				List<string> tableNames = new List<string>();

				using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
				{
					SqlCommand command = new SqlCommand(tablesQuery, connection);
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						tableNames.Add(reader.GetString(0));
					}
					reader.Close();
				}

				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = "Excel Files|*.xlsx";
					saveFileDialog.Title = "Выгрузить данные в файл Excel";
					saveFileDialog.FileName = "report.xlsx";

					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						string filePath = saveFileDialog.FileName;
						var excelApp = new Microsoft.Office.Interop.Excel.Application();
						var workbook = excelApp.Workbooks.Add();

						foreach (var tableName in tableNames)
						{
							// Запрос для получения данных из текущей таблицы  
							string query = $"SELECT * FROM [{tableName}]";

							using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
							{
								SqlCommand command = new SqlCommand(query, connection);
								connection.Open();
								SqlDataReader reader = command.ExecuteReader();

								// Создание нового листа для каждой таблицы  
								var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets.Add();
								worksheet.Name = tableName; // Назначаем имя листа  

								// Запись заголовков колонок  
								for (int col = 0; col < reader.FieldCount; col++)
								{
									worksheet.Cells[1, col + 1] = reader.GetName(col);
								}

								// Запись данных  
								int row = 2; // Начинаем с 2-й строки, так как 1-я занята заголовками  
								while (reader.Read())
								{
									for (int col = 0; col < reader.FieldCount; col++)
									{
										worksheet.Cells[row, col + 1] = reader[col].ToString();
									}
									row++;
								}

								reader.Close();
							}
						}

						workbook.SaveAs(filePath);
						workbook.Close();
						excelApp.Quit();
						MessageBox.Show("Данные успешно выгружены в документ Excel.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			else
			{
				comboBox1.Visible = true;
				// Проверка на наличие выбранного элемента в ComboBox
				if (comboBox1.SelectedItem == null)
				{
					MessageBox.Show("Пожалуйста, выберите таблицу из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Получаем выбранное имя таблицы
				string selectedTableName = comboBox1.SelectedItem.ToString();

				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = "Excel Files|*.xlsx";
					saveFileDialog.Title = "Выгрузить данные в файл Excel";
					saveFileDialog.FileName = "report.xlsx";

					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						string filePath = saveFileDialog.FileName;
						var excelApp = new Microsoft.Office.Interop.Excel.Application();
						var workbook = excelApp.Workbooks.Add();

						// Запрос для получения данных из выбранной таблицы
						string query = $"SELECT * FROM [{selectedTableName}]";

						using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
						{
							SqlCommand command = new SqlCommand(query, connection);
							connection.Open();
							SqlDataReader reader = command.ExecuteReader();

							// Создание нового листа для выбранной таблицы
							var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets.Add();
							worksheet.Name = selectedTableName; // Назначаем имя листа

							// Запись заголовков колонок
							for (int col = 0; col < reader.FieldCount; col++)
							{
								worksheet.Cells[1, col + 1] = reader.GetName(col);
							}

							// Запись данных
							int row = 2; // Начинаем с 2-й строки, так как 1-я занята заголовками
							while (reader.Read())
							{
								for (int col = 0; col < reader.FieldCount; col++)
								{
									worksheet.Cells[row, col + 1] = reader[col].ToString();
								}
								row++;
							}

							reader.Close();
						}

						workbook.SaveAs(filePath);
						workbook.Close();
						excelApp.Quit();
						MessageBox.Show("Данные успешно выгружены в документ Excel.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}

				
				
			}
			
		}


		private void CheckBoxShowComboBox_CheckedChanged(object sender, EventArgs e)
		{
			// Изменяем видимость ComboBox в зависимости от состояния CheckBox
			comboBox1.Visible = checkBox1.Checked;
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

        private void Save_Excel_Load(object sender, EventArgs e)
        {
            
        }

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
            this.Hide();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			comboBox1.Visible = !checkBox1.Checked;
		}

		private void checkBox1_CheckStateChanged(object sender, EventArgs e)
		{
			
		}
	}
    
}

