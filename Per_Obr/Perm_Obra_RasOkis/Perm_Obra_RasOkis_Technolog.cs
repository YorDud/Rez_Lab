using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Rez_Lab.Black_Hole
{
	public partial class Perm_Obra_RasOkis_Technolog : Form
	{
		public Perm_Obra_RasOkis_Technolog()
		{
			InitializeComponent();
			//label11.Text = "ПО 402А - общее кол-во окислителя - 50 - 60 г/л        NaMnO4 - 45 - 60 г/л\r\nПО 402А - активный окислитель в  г/л                            Na2MnO4 < 25 г/л\r\nПО 402А - показат.акт - 0,85-1,0                                        NaOH - 40 - 50 г/л\r\nПлотность - 1,07 - 1,24 г/см3                                               ПО 402Б - 110 - 150 мл/л\r\nОБЪЕМ ВАННЫ: 710 л";

		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;

		

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Perm_Obra_RasOkis ORDER BY Date_Create DESC", connection);
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
				dataGridView1.Columns["Per_Obr_2_obshee"].HeaderText = "общее кол-во";
				dataGridView1.Columns["Per_Obr_2_avtiv_okis"].HeaderText = "акт. окислитель";
				dataGridView1.Columns["Per_Obr_2_pokaz_avtiv"].HeaderText = "показат. акт";
				dataGridView1.Columns["Per_Obr_2_plot"].HeaderText = "плотность";
				dataGridView1.Columns["Per_Obr_2_NaMnO4"].HeaderText = "NaMnO4";
				dataGridView1.Columns["Per_Obr_2_Na2MnO4"].HeaderText = "Na2MnO4";
				dataGridView1.Columns["Per_Obr_2_402b"].HeaderText = "402Б";
				dataGridView1.Columns["Per_Obr_2_NaOH"].HeaderText = "NaOH";
				dataGridView1.Columns["Per_Obr_2_Correction_Mat"].HeaderText = "Корректировка Материал";
				dataGridView1.Columns["Per_Obr_2_Correction_Score"].HeaderText = "Корректировка Количество";
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

				dataGridView1.Columns["Per_Obr_2_Correction_Mat"].DefaultCellStyle.BackColor = Color.PeachPuff;
				dataGridView1.Columns["Per_Obr_2_Correction_Score"].DefaultCellStyle.BackColor = Color.PeachPuff;



				HighlightEmptyCells(dataGridView1);

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
			}

		}

		private void Perm_Obra_RasOkis_Technolog_Load(object sender, EventArgs e)
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
		//      UPDATE Black_Hole SET
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
				if (column.Name != "Per_Obr_2_Correction_Score" && column.Name != "Per_Obr_2_Correction_Mat" && column.Name != "Сomment") // предполагается, что "ID" - это столбец, который можно редактировать
				{
					column.ReadOnly = true;
				}
			}
		}
		//int[] columnsToCheck = { 5, 8, 12, 17, 20, 23, 25, 27 };
		




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
				var Per_Obr_2_Correction_Mat = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_Correction_Mat"].Value;
				var Per_Obr_2_Correction_Score = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_Correction_Score"].Value;

				var Comment = dataGridView1.Rows[e.RowIndex].Cells["Сomment"].Value;



				// Запрос для обновления данных
				string updateQuery = @"
        UPDATE Perm_Obra_RasOkis SET
            [Date_tech] = @Date_tech,
            [Per_Obr_2_Correction_Mat] = @Per_Obr_2_Correction_Mat
			,[Per_Obr_2_Correction_Score] = @Per_Obr_2_Correction_Score
			,[Сomment] = @Comment
            ,FIO_tech = @FIO_tech
        WHERE ID = @Id";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Параметры команды
					command.Parameters.AddWithValue("@Date_tech", Date_tech);
					command.Parameters.AddWithValue("@FIO_tech", FIO_tech);
					command.Parameters.AddWithValue("@Per_Obr_2_Correction_Mat", Per_Obr_2_Correction_Mat);
					command.Parameters.AddWithValue("@Per_Obr_2_Correction_Score", Per_Obr_2_Correction_Score);
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

				string query = "SELECT * FROM Perm_Obra_RasOkis WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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
				string query = "SELECT * FROM Perm_Obra_RasOkis WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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
			// Проверяем, что клик был совершен по существующей строке и по первому столбцу (индекс 0)
			if (e.RowIndex >= 0 && e.ColumnIndex == 0)
			{
				// Получаем текущую строку
				DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

				// Получаем значение столбца "Date_tech" (замените "Date_tech" на точное имя вашего столбца, если оно отличается)
				var dateTechValue = selectedRow.Cells["Date_tech"].Value;

				// Проверяем, что "Date_tech" пустой (null, DBNull или пустая строка)
				bool isDateTechEmpty = dateTechValue == null ||
									   dateTechValue == DBNull.Value ||
									   (dateTechValue is string str && string.IsNullOrWhiteSpace(str));

				if (!isDateTechEmpty)
				{
					// Если "Date_tech" не пустой, можно показать сообщение или просто выйти
					MessageBox.Show("Этот элемент уже обновлен. Редактирование недоступно.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				// Получаем значение ID из первого столбца (индекс 0)
				var idValue = selectedRow.Cells[0].Value;

				// Проверяем, что ID не пустой
				if (idValue != null)
				{
					if (int.TryParse(idValue.ToString(), out WC.id_click))
					{
						// Подготовка SQL-запроса для обновления
						string connectionString = WC.ConnectionString;
						string query = @"UPDATE Perm_Obra_RasOkis SET
                                 [Date_tech] = @Date_tech,
                                 [FIO_tech] = @FIO_tech
                                 WHERE ID = @Id";

						try
						{
							using (SqlConnection connection = new SqlConnection(connectionString))
							{
								using (SqlCommand command = new SqlCommand(query, connection))
								{
									// Добавляем параметры с соответствующими значениями
									command.Parameters.AddWithValue("@Date_tech", DateTime.Now);
									command.Parameters.AddWithValue("@FIO_tech", WC.fio);
									command.Parameters.AddWithValue("@Id", WC.id_click);

									connection.Open();
									int rowsAffected = command.ExecuteNonQuery();

									if (rowsAffected > 0)
									{
										MessageBox.Show("Корректировка добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
										LoadData(); // Обновляем данные в DataGridView
									}
									else
									{
										MessageBox.Show("Не удалось обновить данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
									}
								}
							}
						}
						catch (Exception ex)
						{
							// Обработка возможных исключений
							MessageBox.Show("Произошла ошибка при обновлении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					else
					{
						MessageBox.Show("Не удалось преобразовать значение ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("Значение ID отсутствует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		

		private void HighlightEmptyCells(DataGridView dataGridView)
		{
			// Определите индексы столбцов
			int idColumnIndex = 0; // Индекс столбца ID (измените по необходимости)
			int dateTechColumnIndex = 14; // Индекс столбца Date_tech (измените по необходимости)

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
					row.DefaultCellStyle.BackColor = Color.LightSalmon;
				}
				else
				{
					row.Cells[idColumnIndex].Style.BackColor = Color.White; // Восстанавливаем цвет, если условия не выполняются
				}
			}

		}

		private void label10_Click(object sender, EventArgs e)
		{

		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void label12_Click(object sender, EventArgs e)
		{

		}

		private void Add_Row()
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();

				string sqlInsert = "INSERT INTO Perm_Obra_RasOkis ([Date_Create],[FIO_Lab]) " +
								   "VALUES (@Date_Create, @FIO_Lab)";

				using (SqlCommand command = new SqlCommand(sqlInsert, connection))
				{
					command.Parameters.AddWithValue("@Date_Create", DateTime.Now);
					command.Parameters.AddWithValue("@FIO_Lab", WC.fio);
					command.ExecuteNonQuery();

				}
			}
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
				var Per_Obr_2_Correction_Mat = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_Correction_Mat"].Value;
				var Per_Obr_2_Correction_Score = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_Correction_Score"].Value;
				//var Comment = dataGridView1.Rows[e.RowIndex].Cells["Сomment"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Perm_Obra_RasOkis
   SET [Per_Obr_2_Correction_Mat] = @Per_Obr_2_Correction_Mat
			,[Per_Obr_2_Correction_Score] = @Per_Obr_2_Correction_Score
      ,[Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", fioLab);
					//
					command.Parameters.AddWithValue("@Per_Obr_2_Correction_Mat", Per_Obr_2_Correction_Mat);
					command.Parameters.AddWithValue("@Per_Obr_2_Correction_Score", Per_Obr_2_Correction_Score);
					//
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}

				MessageBox.Show("Данные успешно Добавлены!");
				//LoadData();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Add_Row();
			LoadData();
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Проверяем, что пользователь кликнул на действительную строку и на нужный столбец (например, столбец с индексом 7)
			if (e.RowIndex >= 0 && e.ColumnIndex == 12)
			{
				// Создаём и настраиваем форму для ввода данных
				using (Form inputForm = new Form())
				{
					// Установка размеров формы
					inputForm.Width = 250;
					inputForm.Height = 180;
					inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
					inputForm.MaximizeBox = false;
					inputForm.MinimizeBox = false;
					inputForm.StartPosition = FormStartPosition.CenterParent;
					inputForm.Text = "Введите количество и единицу измерения";

					// Создание и настройка меток для полей ввода
					Label labelValue1 = new Label()
					{
						Text = "Количество:",
						Top = 5,
						Left = 10,
						Width = 220
					};

					Label labelValue2 = new Label()
					{
						Text = "Единица измерения:",
						Top = 50,
						Left = 10,
						Width = 220
					};

					// Создание и настройка текстового поля для количества
					TextBox value1 = new TextBox()
					{
						Top = 30,
						Left = 10,
						Width = 200
					};
					// Ограничение ввода только числовыми символами (включая точку для дробных чисел)
					value1.KeyPress += NumericTextBox_KeyPress;

					// Создание и настройка комбобокса для выбора единицы измерения
					ComboBox value2 = new ComboBox()
					{
						Top = 75,
						Left = 10,
						Width = 200,
						DropDownStyle = ComboBoxStyle.DropDownList // Запрещаем ввод произвольного текста
					};
					value2.Items.AddRange(new string[] { " мл", " л", " г", " кг" });
					value2.SelectedIndex = 0; // Устанавливаем первый элемент по умолчанию

					// Создание и настройка кнопки для подтверждения ввода
					Button addButton = new Button()
					{
						Text = "Добавить",
						Top = 110,
						Left = 10,
						Width = 200
					};
					addButton.Click += (s, args) =>
					{
						// Попытка преобразовать введённое количество в double
						bool isV1Parsed = double.TryParse(value1.Text, out double v1);
						// Проверка, что единица измерения выбрана
						bool isV2Selected = value2.SelectedItem != null;

						if (isV1Parsed && isV2Selected)
						{
							string v2 = value2.SelectedItem.ToString();
							// Объединение числа и единицы измерения
							string result = $"{v1}{v2}";

							// Запись результата в выбранную ячейку DataGridView
							dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result;

							// Обновление базы данных с новым значением
							UpdateDatabase(e.RowIndex, e.ColumnIndex, result, sender, e);

							// Закрытие формы ввода
							inputForm.Close();
						}
						else
						{
							// Формирование сообщения об ошибке
							StringBuilder errorMessage = new StringBuilder("Некорректный ввод:\n");
							if (!isV1Parsed)
							{
								errorMessage.Append("- Количество должно быть числом (может содержать десятичную точку).\n");
							}
							if (!isV2Selected)
							{
								errorMessage.Append("- Необходимо выбрать единицу измерения.\n");
							}

							// Отображение сообщения об ошибке пользователю
							MessageBox.Show(errorMessage.ToString(), "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					};

					// Добавление элементов на форму
					inputForm.Controls.Add(labelValue1);
					inputForm.Controls.Add(value1);
					inputForm.Controls.Add(labelValue2);
					inputForm.Controls.Add(value2);
					inputForm.Controls.Add(addButton);

					// Отображение диалогового окна
					inputForm.ShowDialog();
				}
			}
		}



		private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Разрешаем только цифры, символы управления (например, Backspace) и один разделитель (точка или запятая)
			char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator)
			{
				e.Handled = true; // Запрещаем ввод
			}

			// Разрешаем только один десятичный разделитель
			TextBox textBox = sender as TextBox;
			if (e.KeyChar == decimalSeparator && textBox.Text.Contains(decimalSeparator.ToString()))
			{
				e.Handled = true;
			}
		}
		private void UpdateDatabase(int rowIndex, int columnIndex, string value, object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.Columns[e.ColumnIndex].Name == "ID")
				return;

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				// Получаем значение первичного ключа
				var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

				// Получаем значения обновляемых столбцов

				var FIO_tech = WC.fio; // Название столбца FIO_Lab
				var Date_tech = DateTime.Now;
				var Per_Obr_2_Correction_Mat = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_Correction_Mat"].Value;
				var Per_Obr_2_Correction_Score = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_Correction_Score"].Value;
				var Сomment = dataGridView1.Rows[e.RowIndex].Cells["Сomment"].Value;
				//var Comment = dataGridView1.Rows[e.RowIndex].Cells["Сomment"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
        UPDATE Perm_Obra_RasOkis SET
    [Date_tech] = @Date_tech,
    Per_Obr_2_Correction_Mat = @Per_Obr_2_Correction_Mat,
    Per_Obr_2_Correction_Score = @Per_Obr_2_Correction_Score,
	[Сomment] = @Сomment,
    FIO_tech = @FIO_tech
WHERE ID = @Id";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_tech", Date_tech);
					command.Parameters.AddWithValue("@FIO_tech", FIO_tech);
					command.Parameters.AddWithValue("@Per_Obr_2_Correction_Mat", Per_Obr_2_Correction_Mat);
					command.Parameters.AddWithValue("@Per_Obr_2_Correction_Score", Per_Obr_2_Correction_Score);
					command.Parameters.AddWithValue("@Сomment", Сomment);
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			groupBox3.Visible = !groupBox3.Visible;
			pictureBox7.Visible = false;
			pictureBox8.Visible = false;
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			pictureBox7.Visible = !pictureBox7.Visible;
			pictureBox8.Visible = false;
		}

		private void pictureBox6_Click(object sender, EventArgs e)
		{
			pictureBox8.Visible = !pictureBox8.Visible;
			pictureBox7.Visible = false;
		}

		//private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		//{
		//	// Проверьте, что клик был не по заголовку столбца
		//	if (e.RowIndex >= 0 && e.ColumnIndex == 0)
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
