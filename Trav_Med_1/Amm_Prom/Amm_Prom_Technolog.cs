﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Globalization;

namespace Rez_Lab.Amm_Prom
{
	public partial class Amm_Prom_Technolog : Form
	{
		public Amm_Prom_Technolog()
		{
			InitializeComponent();

			//this.FormClosing += MainForm_FormClosing;


			label3.Text = "NH4OH - 25% - 500 мл/л\r\nОБЪЕМ ВАННЫ: 120 л";

		}

		//private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		//{
		//	//Создаем скриншот
		//	Bitmap bmp = new Bitmap(this.Width, this.Height);
		//	this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));

		//	// Отправляем скриншот по электронной почте
		//	SendMail(bmp);
		//}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;
		private void ColorRows()
		{
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
		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Amm_Prom ORDER BY Date_Create DESC", connection);
				SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
				dataTable = new DataTable();
				dataAdapter.Fill(dataTable);
				dataGridView1.DataSource = dataTable; // Устанавливаем источник данных

				// Изменение названий столбцов
				dataGridView1.Columns["ID"].HeaderText = "Номер";
				//dataGridView1.Columns["ID"].HeaderCell.Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
				dataGridView1.Columns["Date_Create"].HeaderText = "Дата создания";
				dataGridView1.Columns["FIO_Lab"].HeaderText = "ФИО Создателя";
				dataGridView1.Columns["Trav_Med_NH4C"].HeaderText = "Травление меди NH4OH";
				dataGridView1.Columns["Trav_Med_Correction_Mat"].HeaderText = "Корректировка Материал";
				dataGridView1.Columns["Trav_Med_Correction_Score"].HeaderText = "Корректировка Количество";
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

				dataGridView1.Columns["Trav_Med_Correction_Mat"].DefaultCellStyle.BackColor = Color.PeachPuff;
				dataGridView1.Columns["Trav_Med_Correction_Score"].DefaultCellStyle.BackColor = Color.PeachPuff;


				HighlightEmptyCells(dataGridView1);
				ColorRows();

			}

		}

		private void Amm_Prom_Technolog_Load(object sender, EventArgs e)
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
		//      UPDATE Amm_Prom SET
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
				if (column.Name != "Trav_Med_Correction_Score" && column.Name != "Trav_Med_Correction_Mat" && column.Name != "Сomment") // предполагается, что "ID" - это столбец, который можно редактировать
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
				var Trav_Med_Correction_Mat = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_Correction_Mat"].Value;
				var Trav_Med_Correction_Score = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_Correction_Score"].Value;
				var Comment = dataGridView1.Rows[e.RowIndex].Cells["Сomment"].Value;

				// Запрос для обновления данных
				string updateQuery = @"
        UPDATE Amm_Prom SET
    [Date_tech] = @Date_tech,
    Trav_Med_Correction_Mat = @Trav_Med_Correction_Mat,
    Trav_Med_Correction_Score = @Trav_Med_Correction_Score,
	[Сomment] = @Comment,
    FIO_tech = @FIO_tech
WHERE ID = @Id";


				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Параметры команды
					command.Parameters.AddWithValue("@Date_tech", Date_tech);
					command.Parameters.AddWithValue("@FIO_tech", FIO_tech);
					command.Parameters.AddWithValue("@Trav_Med_Correction_Mat", Trav_Med_Correction_Mat);
					command.Parameters.AddWithValue("@Trav_Med_Correction_Score", Trav_Med_Correction_Score);
					command.Parameters.AddWithValue("@Comment", Comment);

					command.Parameters.AddWithValue("@ID", id);

					// Выполнение запроса
					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();

					//LoadData();
					//HighlightEmptyCells(dataGridView1, columnsToCheck);

				}

				////Создаем скриншот
				//	Bitmap bmp = new Bitmap(this.Width, this.Height);
				//this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));

				//// Отправляем скриншот по электронной почте
				//SendMail(bmp);

				////MessageBox.Show("Данные успешно обновлены!");

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

				string query = "SELECT * FROM Amm_Prom WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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
				string query = "SELECT * FROM Amm_Prom WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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
						string query = @"UPDATE Amm_Prom SET
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
			int dateTechColumnIndex = 7; // Индекс столбца Date_tech (измените по необходимости)

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
					row.Cells[idColumnIndex].Style.BackColor = Color.Red;
					row.DefaultCellStyle.BackColor = Color.LightSalmon;// Устанавливаем цвет фона ячейки в красный
				}
				else
				{
					row.Cells[idColumnIndex].Style.BackColor = Color.White; // Восстанавливаем цвет, если условия не выполняются
				}
			}

		}

		private void button4_Click(object sender, EventArgs e)
		{
			Add_Row();
			LoadData();
		}
		private void Add_Row()
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();

				string sqlInsert = "INSERT INTO Amm_Prom ([Date_Create],[FIO_Lab]) " +
								   "VALUES (@Date_Create, @FIO_Lab)";

				using (SqlCommand command = new SqlCommand(sqlInsert, connection))
				{
					command.Parameters.AddWithValue("@Date_Create", DateTime.Now);
					command.Parameters.AddWithValue("@FIO_Lab", WC.fio);
					command.ExecuteNonQuery();

				}
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Проверяем, что пользователь кликнул на действительную строку и на нужный столбец (например, столбец с индексом 7)
			if (e.RowIndex >= 0 && e.ColumnIndex == 5)
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
				var Trav_Med_Correction_Mat = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_Correction_Mat"].Value;
				var Trav_Med_Correction_Score = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_Correction_Score"].Value;
				var Comment = dataGridView1.Rows[e.RowIndex].Cells["Сomment"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
        UPDATE Amm_Prom SET
    [Date_tech] = @Date_tech,
    Trav_Med_Correction_Mat = @Trav_Med_Correction_Mat,
    Trav_Med_Correction_Score = @Trav_Med_Correction_Score,
	[Сomment] = @Comment,
    FIO_tech = @FIO_tech
WHERE ID = @Id";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_tech", Date_tech);
					command.Parameters.AddWithValue("@FIO_tech", FIO_tech);
					command.Parameters.AddWithValue("@Trav_Med_Correction_Mat", Trav_Med_Correction_Mat);
					command.Parameters.AddWithValue("@Trav_Med_Correction_Score", Trav_Med_Correction_Score);
					command.Parameters.AddWithValue("@Comment", Comment);
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}










	}























	//private void button1_Click(object sender, EventArgs e)
	//{
	//	Bitmap bmp = new Bitmap(this.Width, this.Height);
	//	this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));

	//	// Настройка документа для печати
	//	PrintDocument printDocument = new PrintDocument();
	//	printDocument.DefaultPageSettings.Landscape = true; // Устанавливаем альбомную ориентацию

	//	// Ивент, который обрабатывает печать
	//	printDocument.PrintPage += (s, ev) =>
	//	{
	//		// Получаем размеры страницы
	//		float pageWidth = ev.PageBounds.Width;
	//		float pageHeight = ev.PageBounds.Height;

	//		// Получаем размеры изображения
	//		float imageWidth = bmp.Width;
	//		float imageHeight = bmp.Height;

	//		// Вычисляем коэффициенты масштабирования
	//		float xRatio = pageWidth / imageWidth;
	//		float yRatio = pageHeight / imageHeight;
	//		float scale = Math.Min(xRatio, yRatio); // Минимум, чтобы все помещалось

	//		// Вычисляем новые размеры изображения
	//		float scaledWidth = imageWidth * scale;
	//		float scaledHeight = imageHeight * scale;

	//		// Вычисляем позицию для отрисовки изображения по центру
	//		float x = (pageWidth - scaledWidth) / 2;
	//		float y = (pageHeight - scaledHeight) / 2;

	//		// Рисуем изображение с учётом нарисованных размеров
	//		ev.Graphics.DrawImage(bmp, x, y, scaledWidth, scaledHeight);
	//	};

	//	// Предварительный просмотр печати
	//	PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
	//	printPreviewDialog.Document = printDocument;
	//	printPreviewDialog.ShowDialog();

	//	// Запускаем печать, если пользователь нажал "печать" в диалоге предварительного просмотра
	//	if (printPreviewDialog.DialogResult == DialogResult.OK)
	//	{
	//		PrintDialog printDialog = new PrintDialog();
	//		printDialog.Document = printDocument;
	//		if (printDialog.ShowDialog() == DialogResult.OK)
	//		{
	//			printDocument.Print();
	//		}
	//	}
	//}



	//private void button1_Click(object sender, EventArgs e)
	//{
	//	// Создаем скриншот
	//	Bitmap bmp = new Bitmap(this.Width, this.Height);
	//	this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));

	//	// Отправляем скриншот по электронной почте
	//	SendMail(bmp);
	//}

	//private void SendMail(Bitmap screenshot)
	//{
	//	try
	//	{
	//		// Получаем email из текстового поля
	//		MailAddress from = new MailAddress("rem.rab.mail@yandex.ru", "Лаборатория Резонит");
	//		MailAddress to = new MailAddress("ya.dudarev@rezonit.ru");

	//		// Создаем объект сообщения
	//		MailMessage msg = new MailMessage(from, to);
	//		msg.Subject = "Скриншот приложения";
	//		msg.Body = "Прикреплённый скриншот приложения.";

	//		// Создаем память для изображения и добавляем к сообщению
	//		using (MemoryStream memoryStream = new MemoryStream())
	//		{
	//			screenshot.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
	//			memoryStream.Position = 0; // Сбрасываем поток

	//			// Прикрепляем изображение к сообщению
	//			Attachment attachment = new Attachment(memoryStream, "screenshot.png", "image/png");
	//			msg.Attachments.Add(attachment);

	//			// Настройки SMTP-клиента
	//			SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587)
	//			{
	//				EnableSsl = true,
	//				Credentials = new NetworkCredential("rem.rab.mail@yandex.ru", "pqueycqykvevaqht")
	//			};

	//			// Отправка письма
	//			smtp.Send(msg);
	//		}
	//	}
	//	catch (Exception ex)
	//	{
	//		// Обработка исключений
	//		MessageBox.Show($"Ошибка при отправке почты: {ex.Message}");
	//	}
	//}





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

