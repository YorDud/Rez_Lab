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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Rez_Lab.Himich_Podgotov
{
	public partial class Himich_Podgotov_Corrector : Form
	{
		public Himich_Podgotov_Corrector()
		{
			InitializeComponent();
			label11.Text = "Кислая очистка АС-23:\r\nкислотность - 0,3-0,8\r\nСи2+ - \r\nОБЪЕМ ВАННЫ: 120 - 175 л";
			label2.Text = "Микротравление:\r\nСи2+ - 15-35 г/л\r\nподтрав - 07-1,6 мкм\r\nкислотность > 1,3 моль/л\r\npH - 2-5\r\nОБЪЕМ ВАННЫ: 290 - 385 л";
			label3.Text = "Декапир:\r\nHCl - 1-1,5 моль/л\r\nСи2+ < 2 г/л\r\nОБЪЕМ ВАННЫ: 95 - 165 л";
		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;
		int[] columnsToCheck = { 20 };

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Himich_Podgotov ORDER BY Date_Create DESC", connection);
				SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
				dataTable = new DataTable();
				dataAdapter.Fill(dataTable);
				dataGridView1.DataSource = dataTable; // Устанавливаем источник данных

				// Изменение названий столбцов
				dataGridView1.Columns["ID"].HeaderText = "Номер";
				//dataGridView1.Columns["ID"].HeaderCell.Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
				dataGridView1.Columns["Date_Create"].HeaderText = "Дата создания";
				dataGridView1.Columns["FIO_Lab"].HeaderText = "ФИО Создателя";
				//
				dataGridView1.Columns["Him_Podg_1_kislot"].HeaderText = "Кислотность";
				dataGridView1.Columns["Him_Podg_1_Ci2"].HeaderText = "Cи 2+";
				dataGridView1.Columns["Him_Podg_1_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Him_Podg_2_Ci2"].HeaderText = "Cи 2+";
				dataGridView1.Columns["Him_Podg_2_podtrav"].HeaderText = "Подтрав";
				dataGridView1.Columns["Him_Podg_2_kislot"].HeaderText = "Кислотность";
				dataGridView1.Columns["Him_Podg_2_pH"].HeaderText = "pH";
				dataGridView1.Columns["Him_Podg_2_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Him_Podg_3_plotnost1"].HeaderText = "Плотность 1";
				dataGridView1.Columns["Him_Podg_3_plotnost2"].HeaderText = "Плотность 2";
				dataGridView1.Columns["Him_Podg_3_Correction"].HeaderText = "Корректировка";
				//
				dataGridView1.Columns["FIO_tech"].HeaderText = "ФИО Технолога";
				dataGridView1.Columns["Date_tech"].HeaderText = "Дата создания корректировки";
				dataGridView1.Columns["FIO_Lab_Update"].HeaderText = "ФИО Лаборанта (редакт)";
				dataGridView1.Columns["Date_Lab_Update"].HeaderText = "Дата (редакт)";
				dataGridView1.Columns["FIO_Corr"].HeaderText = "ФИО Корректировщика";
				dataGridView1.Columns["Date_Corr"].HeaderText = "Время выполнения корректировки";
				dataGridView1.Columns["Сompleted"].HeaderText = "Выполнение";
dataGridView1.Columns["Start_corr"].HeaderText = "Принятие в работу";
dataGridView1.Columns["Date_start_corr"].HeaderText = "Время принятия корректировки в выполнение";
dataGridView1.Columns["FIO_start_corr"].HeaderText = "ФИО Корректировщика";
dataGridView1.Columns["Сomment"].HeaderText = "Комментарий";

				// Продолжайте добавлять другие столбцы по мере необходимости
				
foreach (DataGridViewRow row in dataGridView1.Rows)
{
				// Проверяем, что значение в ячейке не null
				if (row.Cells["Сomment"].Value != null)
				{
					string comment = row.Cells["Сomment"].Value.ToString();
					if (comment.Contains("НР"))
					{
						// Устанавливаем синий цвет фона и белый цвет текста
						row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
						//row.DefaultCellStyle.ForeColor = Color.White;
					}
				}
}
HighlightEmptyCells(dataGridView1, columnsToCheck);
			}

		}


		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void Himich_Podgotov_Corrector_Load(object sender, EventArgs e)
		{
			LoadData();
			label8.Text = WC.fio.ToString();
			//this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			HighlightEmptyCells(dataGridView1, columnsToCheck);
			NotClickOnTable();
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

		private void LoadDataDateTimePicker(DateTime date)
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();

				string query = "SELECT * FROM Himich_Podgotov WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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

		private void Refresh_btn_Click(object sender, EventArgs e)
		{
			LoadData();
			HighlightEmptyCells(dataGridView1, columnsToCheck);
		}

		private void HighlightEmptyCells(DataGridView dataGridView, int[] columns)
		{
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				// Проверяем, что значение в 6-м столбике (индекс 5) не пустое
				if (!string.IsNullOrEmpty(row.Cells[5].Value?.ToString()) || !string.IsNullOrEmpty(row.Cells[10].Value?.ToString()) || !string.IsNullOrEmpty(row.Cells[13].Value?.ToString()))
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
		



		int clickCount = 0;
		private void button3_Click(object sender, EventArgs e)
		{
			clickCount++;

			switch (clickCount)
			{
				case 1:
					groupBox1.Visible = true;
					break;
				case 2:
					groupBox1.Visible = false;
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
			HighlightEmptyCells(dataGridView1, columnsToCheck);
		}

		private void LoadDataByDateRange(DateTime startDate, DateTime endDate)
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				string query = "SELECT * FROM Himich_Podgotov WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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

						string query = @"UPDATE Himich_Podgotov SET
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
	}
}
