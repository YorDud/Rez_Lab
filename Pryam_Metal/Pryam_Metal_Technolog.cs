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

namespace Rez_Lab.Pryam_Metal
{
	public partial class Pryam_Metal_Technolog : Form
	{
		public Pryam_Metal_Technolog()
		{
			InitializeComponent();

			label11.Text = "Кондиционер:\r\nПМ 302 - 90-110 мл/л\r\nCu 2+ < 1 г/л\r\nОБЪЕМ ВАННЫ: 234 л";
			label2.Text = "Предметализация ПМ 303:\r\nHCl -  2-4 г/л\r\npH - < 1\r\nCu 2+ < 1 г/л\r\nОБЪЕМ ВАННЫ: 185 л";
			label3.Text = "Метализация ПМ 304:\r\nPdCl2 - 0,4 - 0,5 г/л\r\nSnCl2 - 10 - 18 г/л\r\nHCl -\r\nCu 2+ < 1 г/л\r\nОБЪЕМ ВАННЫ: 224 л";
			label4.Text = "Ускоритель:\r\nПМ 305 А - 90 - 100 %\r\nПМ 305 Б - 90 - 100 %\r\nПМ 305 В -  190 - 220 г/л\r\nОБЪЕМ ВАННЫ: 205 л";
		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Pryam_Metal ORDER BY Date_Create DESC", connection);
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
				dataGridView1.Columns["Pr_Met_1_PM302"].HeaderText = "PM302";
				dataGridView1.Columns["Pr_Met_1_Cu2"].HeaderText = "Cu^2+";
				dataGridView1.Columns["Pr_Met_1_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Pr_Met_2_HCl"].HeaderText = "HCl";
				dataGridView1.Columns["Pr_Met_2_pH"].HeaderText = "pH";
				dataGridView1.Columns["Pr_Met_2_Cu2"].HeaderText = "Cu^2+";
				dataGridView1.Columns["Pr_Met_2_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Pr_Met_3_PdCl2"].HeaderText = "PdCl2";
				dataGridView1.Columns["Pr_Met_3_HCl"].HeaderText = "HCl";
				dataGridView1.Columns["Pr_Met_3_SnCl2"].HeaderText = "SnCl2";
				dataGridView1.Columns["Pr_Met_3_Cu2"].HeaderText = "Cu^2+";
				dataGridView1.Columns["Pr_Met_3_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Pr_Met_4_PM305A"].HeaderText = "PM305A";
				dataGridView1.Columns["Pr_Met_4_PM305b"].HeaderText = "PM305b";
				dataGridView1.Columns["Pr_Met_4_PM305V"].HeaderText = "PM305V";
				dataGridView1.Columns["Pr_Met_4_Correction"].HeaderText = "Корректировка";
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

				dataGridView1.Columns["Pr_Met_1_Correction"].DefaultCellStyle.BackColor = Color.PeachPuff;
				dataGridView1.Columns["Pr_Met_2_Correction"].DefaultCellStyle.BackColor = Color.PeachPuff;
				dataGridView1.Columns["Pr_Met_3_Correction"].DefaultCellStyle.BackColor = Color.PeachPuff;
				dataGridView1.Columns["Pr_Met_4_Correction"].DefaultCellStyle.BackColor = Color.PeachPuff;



				HighlightEmptyCells(dataGridView1);
			}

		}

		private void Pryam_Metal_Technolog_Load(object sender, EventArgs e)
		{
			LoadData();
			label8.Text = WC.fio.ToString();
			//this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			NotClickOnTable();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}





		//private void button1_Click(object sender, EventArgs e)
		//{
		//	// Проверка выбранного элемента comboBox_id
		//	if (textBox1.Text == "")
		//	{
		//		MessageBox.Show("Пожалуйста впишите корректировку!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//		return;
		//	}


		//	string corr1 = textBox1.Text;
		//	string connectionString = WC.ConnectionString;

		//	using (SqlConnection connection = new SqlConnection(connectionString))
		//	{
		//		connection.Open();



		//		string query = @"
		//      UPDATE Pryam_Metal SET
		//          [Date_tech] = @Date_tech,
		//          Trav_Med_Correction = @Сorrection,
		//          FIO_tech = @FIO_tech
		//      WHERE ID = @Id";


		//		using (SqlCommand command = new SqlCommand(query, connection))
		//		{
		//			command.Parameters.AddWithValue("@Date_tech", DateTime.Now);
		//			command.Parameters.AddWithValue("@Сorrection", corr1);
		//			command.Parameters.AddWithValue("@FIO_tech", WC.fio);
		//			command.Parameters.AddWithValue("@Id", WC.id_click);

		//			int rowsAffected = command.ExecuteNonQuery();
		//			MessageBox.Show("Корректировка добавлена!");

		//		}
		//		LoadData();


		//	}

		//}
		private void NotClickOnTable()
		{
			foreach (DataGridViewColumn column in dataGridView1.Columns)
			{
				if (column.Name != "Pr_Met_1_Correction" &&
					column.Name != "Pr_Met_2_Correction" &&
					column.Name != "Pr_Met_3_Correction" &&
					column.Name != "Pr_Met_4_Correction" &&
					column.Name != "Сomment") // предполагается, что "ID" - это столбец, который можно редактировать
				{
					column.ReadOnly = true;
				}
			}
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
				var Pr_Met_1_Correction = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_1_Correction"].Value;
				var Pr_Met_2_Correction = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_2_Correction"].Value;
				var Pr_Met_3_Correction = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_3_Correction"].Value;
				var Pr_Met_4_Correction = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_4_Correction"].Value;
				var Comment = dataGridView1.Rows[e.RowIndex].Cells["Сomment"].Value;



				// Запрос для обновления данных
				string updateQuery = @"
        UPDATE Pryam_Metal SET
            [Date_tech] = @Date_tech,
            [Pr_Met_1_Correction] = @Pr_Met_1_Correction
			,[Pr_Met_2_Correction] = @Pr_Met_2_Correction
			,[Pr_Met_3_Correction] = @Pr_Met_3_Correction
			,[Pr_Met_4_Correction] = @Pr_Met_4_Correction
			,[Сomment] = @Comment
            ,FIO_tech = @FIO_tech
        WHERE ID = @Id";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Параметры команды
					command.Parameters.AddWithValue("@Date_tech", Date_tech);
					command.Parameters.AddWithValue("@FIO_tech", FIO_tech);
					command.Parameters.AddWithValue("@Pr_Met_1_Correction", Pr_Met_1_Correction);
					command.Parameters.AddWithValue("@Pr_Met_2_Correction", Pr_Met_2_Correction);
					command.Parameters.AddWithValue("@Pr_Met_3_Correction", Pr_Met_3_Correction);
					command.Parameters.AddWithValue("@Pr_Met_4_Correction", Pr_Met_4_Correction);
					command.Parameters.AddWithValue("@Comment", Comment);


					command.Parameters.AddWithValue("@ID", id);

					// Выполнение запроса
					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();

					//LoadData();
					//HighlightEmptyCells(dataGridView1, columnsToCheck);

				}

				//MessageBox.Show("Данные успешно обновлены!");

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

				string query = "SELECT * FROM Pryam_Metal WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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

		private void Refresh_btn_Click(object sender, EventArgs e)
		{
			LoadData();
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
			//HighlightEmptyCells(dataGridView1, columnsToCheck);
		}

		private void LoadDataByDateRange(DateTime startDate, DateTime endDate)
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				string query = "SELECT * FROM Pryam_Metal WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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

						//string completed = "  ";
						string connectionString = WC.ConnectionString;

						string query = @"UPDATE Pryam_Metal SET
                [Date_tech] = @Date_tech,
                FIO_tech = @FIO_tech
            WHERE ID = @Id";

						using (SqlConnection connection = new SqlConnection(connectionString))
						{
							connection.Open();

							using (SqlCommand command = new SqlCommand(query, connection))
							{
								command.Parameters.AddWithValue("@Date_tech", DateTime.Now);
								command.Parameters.AddWithValue("@FIO_tech", WC.fio);
								command.Parameters.AddWithValue("@Id", WC.id_click);

								int rowsAffected = command.ExecuteNonQuery();
								if (rowsAffected > 0)
								{
									MessageBox.Show("Корректировка добавлена!");
									LoadData();
									//int[] columnsToCheck = { 14 };
									//HighlightEmptyCells(dataGridView1, columnsToCheck);
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

		private void HighlightEmptyCells(DataGridView dataGridView)
		{
			// Определите индексы столбцов
			int idColumnIndex = 0; // Индекс столбца ID (измените по необходимости)
			int dateTechColumnIndex = 20; // Индекс столбца Date_tech (измените по необходимости)

			// Проходите по всем строкам в DataGridView
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				// Получаем значения из ячеек ID и Date_tech
				string idValue = row.Cells[idColumnIndex].Value?.ToString();
				string dateTechValue = row.Cells[dateTechColumnIndex].Value?.ToString();

				// Проверка условий: Date_tech пустое и ID не пустое
				bool isDateTechEmpty = string.IsNullOrEmpty(dateTechValue);
				bool isIdNotEmpty = !string.IsNullOrEmpty(idValue);

				// Если ячейка в столбце Date_tech пуста и ID не пустое, перекрашиваем ячейку в столбце ID
				if (isDateTechEmpty && isIdNotEmpty)
				{
					row.Cells[idColumnIndex].Style.BackColor = Color.Red; // Устанавливаем цвет фона ячейки в красный
				}
				else
				{
					row.Cells[idColumnIndex].Style.BackColor = Color.White; // Восстанавливаем цвет, если условия не выполняются
				}
			}

		}

		//private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		//{
		//	// Проверьте, что клик был не по заголовку столбца
		//	if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
		//	{
		//		// Получите значение ID из первой колонки (например, индекс 0)
		//		var idValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value;

		//		// Проверка на null значение
		//		if (idValue != null)
		//		{

		//			if (int.TryParse(idValue.ToString(), out WC.id_click))
		//			{
		//				// Используйте значение id по вашему усмотрению
		//				//MessageBox.Show("ID выбранной строки: " + id_click);
		//				groupBox2.Visible = true;
		//			}
		//			else
		//			{
		//				MessageBox.Show("Не удалось преобразовать значение ID.");
		//			}
		//		}
		//	}
		//}
	}
}
