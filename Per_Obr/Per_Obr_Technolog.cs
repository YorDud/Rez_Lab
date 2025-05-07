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

namespace Rez_Lab.Per_Obr
{
	public partial class Per_Obr_Technolog : Form
	{
		public Per_Obr_Technolog()
		{
			InitializeComponent();
			label11.Text = "Сенсибилизация:\r\nПO 401A - 0,68-0,9 норм.\r\nПО 401Б - 190 - 210 г/л\r\nОБЪЕМ ВАННЫ: 370 л";
			label2.Text = "Раствор окисления:\r\nПО 402А - общее кол-во окислителя - 50 - 60 г/л              NaMnO4 - 45 - 60 г/л\r\nПО 402А - активный окислитель в  г/л                                  Na2MnO4 < 25 г/л\r\nПО 402А - показат.акт - 0,85-1,0                                              NaOH - 40 - 50 г/л\r\nПО 402Б - 110 - 150 мл/л\r\nОБЪЕМ ВАННЫ: 710 л";
			label3.Text = "Преднейтрализация:\r\nН2SO4 - 7 - 11 %\r\nDES 430  - 8 - 12 %\r\nОБЪЕМ ВАННЫ: 90 л";
			label4.Text = "Преднейтрализация:\r\nН2SO4 - 7 - 11 %\r\nDES 430  - 8 - 12 %\r\nОБЪЕМ ВАННЫ: 180 л";
		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Per_Obr ORDER BY Date_Create DESC", connection);
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
				dataGridView1.Columns["Per_Obr_1_401A"].HeaderText = "Сенсибилизация\r\nПO 401A";
				dataGridView1.Columns["Per_Obr_1_401b"].HeaderText = "Сенсибилизация\r\nПО 401Б";
				dataGridView1.Columns["Per_Obr_1_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Per_Obr_2_obshee"].HeaderText = "Раствор ок-ния общее кол-во";
				dataGridView1.Columns["Per_Obr_2_avtiv_okis"].HeaderText = "Раствор ок-ния\r\nакт. окислитель";
				dataGridView1.Columns["Per_Obr_2_pokaz_avtiv"].HeaderText = "Раствор ок-ния\r\nпоказат.акт";
				dataGridView1.Columns["Per_Obr_2_NaMnO4"].HeaderText = "Раствор ок-ния\r\nNaMnO4";
				dataGridView1.Columns["Per_Obr_2_Na2MnO4"].HeaderText = "Раствор ок-ния\r\nNa2MnO4";
				dataGridView1.Columns["Per_Obr_2_402b"].HeaderText = "Раствор ок-ния\r\nПО 402Б";
				dataGridView1.Columns["Per_Obr_2_NaOH"].HeaderText = "Раствор ок-ния\r\nNaOH";
				dataGridView1.Columns["Per_Obr_2_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Per_Obr_3_Н2SO4"].HeaderText = "Предн-ция\r\nН2SO4";
				dataGridView1.Columns["Per_Obr_3_DES430"].HeaderText = "Предн-ция\r\nDES 430 ";
				dataGridView1.Columns["Per_Obr_3_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Per_Obr_4_Н2SO4"].HeaderText = "Предн-ция\r\nН2SO4";
				dataGridView1.Columns["Per_Obr_4_DES430"].HeaderText = "Нейтрализация DES 430";
				dataGridView1.Columns["Per_Obr_4_Correction"].HeaderText = "Корректировка";
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

				dataGridView1.Columns["Per_Obr_1_Correction"].DefaultCellStyle.BackColor = Color.PeachPuff;
				dataGridView1.Columns["Per_Obr_2_Correction"].DefaultCellStyle.BackColor = Color.PeachPuff;
				dataGridView1.Columns["Per_Obr_3_Correction"].DefaultCellStyle.BackColor = Color.PeachPuff;
				dataGridView1.Columns["Per_Obr_4_Correction"].DefaultCellStyle.BackColor = Color.PeachPuff;



				HighlightEmptyCells(dataGridView1);
			}

		}

		private void Per_Obr_Technolog_Load(object sender, EventArgs e)
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
  //      UPDATE Per_Obr SET
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
				if (column.Name != "Per_Obr_1_Correction" && column.Name != "Per_Obr_2_Correction" && column.Name != "Per_Obr_3_Correction" && column.Name != "Per_Obr_4_Correction" && column.Name != "Сomment") // предполагается, что "ID" - это столбец, который можно редактировать
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
				var Per_Obr_1_Correction = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_1_Correction"].Value;
				var Per_Obr_2_Correction = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_Correction"].Value;
				var Per_Obr_3_Correction = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_3_Correction"].Value;
				var Per_Obr_4_Correction = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_4_Correction"].Value;
				var Comment = dataGridView1.Rows[e.RowIndex].Cells["Сomment"].Value;



				// Запрос для обновления данных
				string updateQuery = @"
        UPDATE Per_Obr SET
            [Date_tech] = @Date_tech,
            [Per_Obr_1_Correction] = @Per_Obr_1_Correction
			,[Per_Obr_2_Correction] = @Per_Obr_2_Correction
			,[Per_Obr_3_Correction] = @Per_Obr_3_Correction
			,[Per_Obr_4_Correction] = @Per_Obr_4_Correction
			,[Сomment] = @Comment
            ,FIO_tech = @FIO_tech
        WHERE ID = @Id";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Параметры команды
					command.Parameters.AddWithValue("@Date_tech", Date_tech);
					command.Parameters.AddWithValue("@FIO_tech", FIO_tech);
					command.Parameters.AddWithValue("@Per_Obr_1_Correction", Per_Obr_1_Correction);
					command.Parameters.AddWithValue("@Per_Obr_2_Correction", Per_Obr_2_Correction);
					command.Parameters.AddWithValue("@Per_Obr_3_Correction", Per_Obr_3_Correction);
					command.Parameters.AddWithValue("@Per_Obr_4_Correction", Per_Obr_4_Correction);
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

				string query = "SELECT * FROM Per_Obr WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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
				string query = "SELECT * FROM Per_Obr WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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

		private void label13_Click(object sender, EventArgs e)
		{

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

						string query = @"UPDATE Per_Obr SET
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
			int dateTechColumnIndex = 21; // Индекс столбца Date_tech (измените по необходимости)

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
