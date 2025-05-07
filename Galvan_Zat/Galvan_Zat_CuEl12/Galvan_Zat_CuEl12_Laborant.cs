using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rez_Lab.Black_Hole
{
	public partial class Galvan_Zat_CuEl12_Laborant : Form
	{
		public Galvan_Zat_CuEl12_Laborant()
		{
			InitializeComponent();
			//label11.Text = "H2SO4 - 180-200 г/л                          NaCl - 40-60 мг/л\r\nПМ 614БВ - 5-10 мл/л               ПМ 624А - 2-3 мл/л\r\nСuSO4 - 80-100 г/л\r\n                           ОБЪЕМ ВАННЫ: 2000 л";

		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;
		int[] columnsToCheck = { 17 };

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Galvan_Zat_CuEl12 ORDER BY Date_Create DESC", connection);
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
				dataGridView1.Columns["Gal_Zat_2_H2SO4"].HeaderText = "H2SO4";
				dataGridView1.Columns["Gal_Zat_2_NaCl"].HeaderText = "NaCl";
				dataGridView1.Columns["Gal_Zat_2_PM624Ast"].HeaderText = "ПМ 614БВ (подавитель)";
				dataGridView1.Columns["Gal_Zat_2_PM624A"].HeaderText = "ПМ 624А (блеск)";
				dataGridView1.Columns["Gal_Zat_2_CuSO4"].HeaderText = "CuSO4";
				dataGridView1.Columns["Gal_Line_Ah"].HeaderText = "Ah";
				dataGridView1.Columns["Gal_Zat_2_Correction_Mat"].HeaderText = "Корректировка Материал";
				dataGridView1.Columns["Gal_Zat_2_Correction_Score"].HeaderText = "Корректировка Количество";


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

				dataGridView1.Columns["Gal_Zat_2_H2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_2_NaCl"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_2_PM624Ast"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_2_PM624A"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_2_CuSO4"].DefaultCellStyle.BackColor = Color.LightBlue;

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

		private void HighlightEmptyCells(DataGridView dataGridView, int[] columns)
		{
			// Получаем индекс столбца "Gal_Line_4_Correction_Mat"
			int correctionMatColumnIndex;
			try
			{
				correctionMatColumnIndex = dataGridView.Columns["Gal_Zat_2_Correction_Mat"].Index;
			}
			catch (ArgumentException)
			{
				throw new ArgumentException("Столбец 'Gal_Zat_2_Correction_Mat' не найден в DataGridView.");
			}

			// Получаем индексы столбцов "Completed" и "Start_corr"
			int completedColumnIndex;
			int startCorrColumnIndex;
			try
			{
				completedColumnIndex = dataGridView.Columns["Сompleted"].Index;
				startCorrColumnIndex = dataGridView.Columns["Start_corr"].Index;
			}
			catch (ArgumentException)
			{
				throw new ArgumentException("Столбцы 'Completed' или 'Start_corr' не найдены в DataGridView.");
			}

			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				// Пропускаем новую строку (если разрешено добавление строк пользователем)
				if (row.IsNewRow) continue;

				// Получаем значение из столбца "Gal_Line_4_Correction_Mat"
				var correctionMatValue = row.Cells[correctionMatColumnIndex].Value?.ToString();

				// Проверяем, содержит ли correctionMatValue "NaCl" (без учета регистра)
				if (!string.IsNullOrEmpty(correctionMatValue) &&
					correctionMatValue.IndexOf("NaCl", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					bool rowHasEmptyCell = false;

					// Проходим по указанным столбцам и проверяем на пустые значения
					foreach (int columnIndex in columns)
					{
						var cellValue = row.Cells[columnIndex].Value?.ToString();

						if (string.IsNullOrEmpty(cellValue))
						{
							// Выделяем пустую ячейку красным цветом
							row.Cells[columnIndex].Style.BackColor = Color.Red;

							// Выделяем всю строку светло-лососевым цветом
							row.DefaultCellStyle.BackColor = Color.LightSalmon;

							rowHasEmptyCell = true;
						}
						else
						{
							// Сбрасываем цвет ячейки, если она не пустая
							//row.Cells[columnIndex].Style.BackColor = Color.White;
						}
					}

					// Дополнительные проверки для столбцов "Completed" и "Start_corr"
					var completedValue = row.Cells[completedColumnIndex].Value?.ToString();
					var startCorrValue = row.Cells[startCorrColumnIndex].Value?.ToString();

					if (string.IsNullOrEmpty(completedValue) && string.IsNullOrEmpty(startCorrValue))
					{
						// Устанавливаем желтый цвет фона для ячейки "Start_corr"
						row.Cells[startCorrColumnIndex].Style.BackColor = Color.Yellow;
						// Можно установить цвет для всей строки, если требуется
						// row.DefaultCellStyle.BackColor = Color.LightSalmon;
					}

					if (!string.IsNullOrEmpty(startCorrValue) && string.IsNullOrEmpty(completedValue))
					{
						// Устанавливаем светло-зелёный цвет фона для всей строки
						row.DefaultCellStyle.BackColor = Color.FromArgb(217, 253, 38);
					}
				}
				else
				{
					// Сбрасываем цвета, если условие "NaCl" не выполнено
					foreach (int columnIndex in columns)
					{
						row.Cells[columnIndex].Style.BackColor = Color.White;
					}

					// Сбрасываем цвет всей строки, если требуется
					//row.DefaultCellStyle.BackColor = Color.White;
				}
			}
		}
		private void Galvan_Zat_CuEl12_Laborant_Load(object sender, EventArgs e)
		{
			LoadData();
			label8.Text = WC.fio.ToString();
			//this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			NotClickOnTable();
			HighlightEmptyCells(dataGridView1, columnsToCheck);
		}

		private void LoadDataDateTimePicker(DateTime date)
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();

				string query = "SELECT * FROM Galvan_Zat_CuEl12 WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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

		}

		int clickCount = 0;
		private void button3_Click(object sender, EventArgs e)
		{

			clickCount++;

			switch (clickCount)
			{
				case 1:
					groupBox3.Visible = true;
					break;
				case 2:
					groupBox3.Visible = false;
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
				string query = "SELECT * FROM Galvan_Zat_CuEl12 WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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


		private void Add_Row()
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();

				string sqlInsert = "INSERT INTO Galvan_Zat_CuEl12 ([Date_Create],[FIO_Lab]) " +
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

				var Gal_Zat_2_H2SO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_2_H2SO4"].Value;
				var Gal_Zat_2_NaCl = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_2_NaCl"].Value;
				var Gal_Zat_2_PM624Ast = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_2_PM624Ast"].Value;
				var Gal_Zat_2_PM624A = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_2_PM624A"].Value;
				var Gal_Zat_2_CuSO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_2_CuSO4"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Galvan_Zat_CuEl12
   SET [Gal_Zat_2_H2SO4] = @Gal_Zat_2_H2SO4,
[Gal_Zat_2_NaCl] = @Gal_Zat_2_NaCl, 
[Gal_Zat_2_PM624Ast] = @Gal_Zat_2_PM624Ast, 
[Gal_Zat_2_PM624A] = @Gal_Zat_2_PM624A,
[Gal_Zat_2_CuSO4] = @Gal_Zat_2_CuSO4
      ,[Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", fioLab);
					//
					command.Parameters.AddWithValue("@Gal_Zat_2_H2SO4", Gal_Zat_2_H2SO4);
					command.Parameters.AddWithValue("@Gal_Zat_2_NaCl", Gal_Zat_2_NaCl);
					command.Parameters.AddWithValue("@Gal_Zat_2_PM624Ast", Gal_Zat_2_PM624Ast);
					command.Parameters.AddWithValue("@Gal_Zat_2_PM624A", Gal_Zat_2_PM624A);
					command.Parameters.AddWithValue("@Gal_Zat_2_CuSO4", Gal_Zat_2_CuSO4);

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



		private void NotClickOnTable()
		{
			foreach (DataGridViewColumn column in dataGridView1.Columns)
			{
				if (column.Name != "Gal_Zat_2_H2SO4" && column.Name != "Gal_Zat_2_NaCl" && column.Name != "Gal_Zat_2_PM624Ast" && column.Name != "Gal_Zat_2_PM624A" && column.Name != "Gal_Zat_2_CuSO4")
				{
					// предполагается, что стали только указанные выше столбцы можно редактировать
					column.ReadOnly = true;
				}
			}
		}


		//private bool isCellEndEditEnabled = true;

		private void button4_Click(object sender, EventArgs e)
		{
			Add_Row();
			LoadData();

			//if (isCellEndEditEnabled)
			//{
			//	// Удаляем обработчик события
			//	dataGridView1.CellEndEdit -= dataGridView1_CellEndEdit;
			//	isCellEndEditEnabled = false;
			//}

		}

		//private void button1_Click(object sender, EventArgs e)
		//{
		//	UpdateRow();

		//	if (!isCellEndEditEnabled)
		//	{
		//		// Добавляем обработчик события
		//		dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
		//		isCellEndEditEnabled = true;
		//	}
		//}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.Columns[e.ColumnIndex].Name == "ID")
				return;

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				// Получаем значение первичного ключа
				var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

				// Получаем значения обновляемых столбцов

				var FIO_Lab_Update = WC.fio; // Название столбца FIO_Lab
				var Date_Lab_Update = DateTime.Now;


				var Gal_Zat_2_H2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_H2SO4"].Value;
				var Gal_Zat_2_NaCl = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_NaCl"].Value;
				var Gal_Zat_2_PM624Ast = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_PM624Ast"].Value;
				var Gal_Zat_2_PM624A = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_PM624A"].Value;
				var Gal_Zat_2_CuSO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_CuSO4"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Galvan_Zat_CuEl12
   SET [Gal_Zat_2_H2SO4] = @Gal_Zat_2_H2SO4,
[Gal_Zat_2_NaCl] = @Gal_Zat_2_NaCl, 
[Gal_Zat_2_PM624Ast] = @Gal_Zat_2_PM624Ast, 
[Gal_Zat_2_PM624A] = @Gal_Zat_2_PM624A,
[Gal_Zat_2_CuSO4] = @Gal_Zat_2_CuSO4
      ,[FIO_Lab_Update] = @FIO_Lab_Update
      ,[Date_Lab_Update] = @Date_Lab_Update
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					//
					command.Parameters.AddWithValue("@Gal_Zat_2_H2SO4", Gal_Zat_2_H2SO4);
					command.Parameters.AddWithValue("@Gal_Zat_2_NaCl", Gal_Zat_2_NaCl);
					command.Parameters.AddWithValue("@Gal_Zat_2_PM624Ast", Gal_Zat_2_PM624Ast);
					command.Parameters.AddWithValue("@Gal_Zat_2_PM624A", Gal_Zat_2_PM624A);
					command.Parameters.AddWithValue("@Gal_Zat_2_CuSO4", Gal_Zat_2_CuSO4);
					//
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		private void label13_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			// Создаем скриншот текущей формы
			Bitmap screenshot = new Bitmap(this.Bounds.Width, this.Bounds.Height);
			this.DrawToBitmap(screenshot, new Rectangle(0, 0, screenshot.Width, screenshot.Height));

			// Создаем экземпляр формы отправки и передаем скриншот
			Send_Screenshot sendForm = new Send_Screenshot(screenshot);
			sendForm.ShowDialog();
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == 7) // Проверяем, что ячейка выбрана
			{

				using (Form inputForm = new Form())
				{
					// Установка размеров формы
					inputForm.Width = 350;
					inputForm.Height = 300;
					inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
					inputForm.MaximizeBox = false;
					inputForm.MinimizeBox = false;
					inputForm.StartPosition = FormStartPosition.CenterParent;
					inputForm.Text = "CuSO4";

					// Создание и настройка текстовых полей
					Label labelValue1 = new Label()
					{
						Text = "C(CuSO4 * 5H2O) = (a * T * 3,93 * 1000)/V",
						Top = 10,
						Left = 30,
						Width = 270
					};
					Label labelValueA = new Label()
					{
						Text = "а - количество 0,1Н раств., израсход. на титров., мл\r\nТ - титр 0,1Н раств. Трилона Б по меди (теор. титр 0,003177), г/мл\r\n3,93 - коэф. пересчета с меди на кристаллогидрат сернокислотной меди\r\nV - объем электролита, взятый на анализ, мл",
						Top = 40,
						Left = 10,
						Width = 300,
						Height = 100

					};


					Label labelValue2 = new Label()
					{
						Text = "а:",
						Top = 150,
						Left = 10,
						Width = 100
					};


					// Создание и настройка текстовых полей
					TextBox value1 = new TextBox
					{
						Top = 150,
						Left = 30,
						Width = 100
					};
					Label labelValue3 = new Label()
					{
						Text = "V:",
						Top = 180,
						Left = 10,
						Width = 100
					};

					TextBox value2 = new TextBox
					{
						Top = 180,
						Left = 30,
						Width = 100
					};
					Label labelValue4 = new Label()
					{
						Text = "V:",
						Top = 150,
						Left = 175,
						Width = 20
					};

					TextBox value3 = new TextBox
					{
						Top = 150,
						Left = 200,
						Width = 100
					};

					// Добавление обработчиков событий для ограничения ввода только числами
					value1.KeyPress += NumericTextBox_KeyPress;
					value2.KeyPress += NumericTextBox_KeyPress;

					// Создание и настройка кнопки
					Button calculateButton = new Button
					{
						Text = "Вычислить",
						Top = 220,
						Left = 10,
						Width = 290
					};
					calculateButton.Click += (s, args) =>
					{
						// Валидация и получение значений
						if (double.TryParse(value1.Text, out double v1) && double.TryParse(value2.Text, out double v2))
						{
							double result = Math.Round((v1 * 0.003177 * 3.93 * 1000) / v2, 2); // Пример формулы (вычитание)

							// Запись результата в выбранную ячейку
							dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result;

							// Обновление базы данных
							UpdateDatabase(e.RowIndex, e.ColumnIndex, result, sender, e);

							inputForm.Close();
						}
						else
						{
							MessageBox.Show("Пожалуйста, введите корректные числовые значения.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					};

					// Добавление элементов на форму
					inputForm.Controls.Add(value1);
					inputForm.Controls.Add(labelValue1);
					inputForm.Controls.Add(labelValueA);
					inputForm.Controls.Add(labelValue2);
					inputForm.Controls.Add(value2);
					inputForm.Controls.Add(labelValue3);
					//inputForm.Controls.Add(value3);
					//inputForm.Controls.Add(labelValue4);
					inputForm.AcceptButton = calculateButton;
					inputForm.Controls.Add(calculateButton);

					inputForm.ShowDialog();
				}
			}
			else if (e.RowIndex >= 0 && e.ColumnIndex == 3) // Проверяем, что ячейка выбрана
			{
				// Открытие диалогового окна
				// Открытие диалогового окна
				using (Form inputForm = new Form())
				{
					// Установка размеров формы
					inputForm.Width = 350;
					inputForm.Height = 300;
					inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
					inputForm.MaximizeBox = false;
					inputForm.MinimizeBox = false;
					inputForm.StartPosition = FormStartPosition.CenterParent;
					inputForm.Text = "H2SO4";

					Label labelValue1 = new Label()
					{
						Text = "C(H2SO4) = a * 9,81 * T",
						Top = 10,
						Left = 30,
						Width = 330
					};

					Label labelValueA = new Label()
					{
						Text = "а - количество 1Н раств. NaOH, израсход. на титров., мл\r\nТ - титр 1Н раств. NaOH по янтарной кислоте, г/мл",
						Top = 40,
						Left = 10,
						Width = 330,
						Height = 100
					};

					Label labelValue2 = new Label()
					{
						Text = "а:",
						Top = 150,
						Left = 10,
						Width = 100
					};


					// Создание и настройка текстовых полей
					TextBox value1 = new TextBox
					{
						Top = 150,
						Left = 30,
						Width = 100
					};
					Label labelValue3 = new Label()
					{
						Text = "T:",
						Top = 180,
						Left = 10,
						Width = 100
					};

					TextBox value2 = new TextBox
					{
						Top = 180,
						Left = 30,
						Width = 100
					};
					Label labelValue4 = new Label()
					{
						Text = "V:",
						Top = 150,
						Left = 175,
						Width = 20
					};

					TextBox value3 = new TextBox
					{
						Top = 150,
						Left = 200,
						Width = 100
					};

					// Добавление обработчиков событий для ограничения ввода только числами
					value1.KeyPress += NumericTextBox_KeyPress;
					value2.KeyPress += NumericTextBox_KeyPress;

					// Создание и настройка кнопки
					Button calculateButton = new Button
					{
						Text = "Вычислить",
						Top = 220,
						Left = 10,
						Width = 290
					};
					calculateButton.Click += (s, args) =>
					{
						// Валидация и получение значений
						if (double.TryParse(value1.Text, out double v1)&& double.TryParse(value2.Text, out double v2))
						{
							double result = Math.Round(v1 * 9.81 * v2, 2); // Пример формулы (сложение)

							// Запись результата в выбранную ячейку
							dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result;

							// Обновление базы данных
							UpdateDatabase(e.RowIndex, e.ColumnIndex, result, sender, e);

							inputForm.Close();
						}
						else
						{
							MessageBox.Show("Пожалуйста, введите корректные числовые значения.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					};

					// Добавление элементов на форму
					inputForm.Controls.Add(value1);
					inputForm.Controls.Add(labelValue1);
					inputForm.Controls.Add(labelValueA);
					inputForm.Controls.Add(labelValue2);
					inputForm.Controls.Add(value2);
					inputForm.Controls.Add(labelValue3);
					inputForm.AcceptButton = calculateButton;
					inputForm.Controls.Add(calculateButton);

					inputForm.ShowDialog();
				}
			}
			else if (e.RowIndex >= 0 && e.ColumnIndex == 4) // Проверяем, что ячейка выбрана
			{
				// Открытие диалогового окна
				// Открытие диалогового окна
				using (Form inputForm = new Form())
				{
					// Установка размеров формы
					inputForm.Width = 350;
					inputForm.Height = 300;
					inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
					inputForm.MaximizeBox = false;
					inputForm.MinimizeBox = false;
					inputForm.StartPosition = FormStartPosition.CenterParent;
					inputForm.Text = "NaCl";

					Label labelValue1 = new Label()
					{
						Text = "C(NaCl) = (a * T  * 10^6) /V",
						Top = 10,
						Left = 30,
						Width = 330
					};

					Label labelValueA = new Label()
					{
						Text = "а - количество 0,01Н раств. азот. серебра, израсход. на титров.(по графику), мл\r\nТ - титр 0,01Н раств. азот. серебра (теор. титр. 0,0005844), г/мл\r\nV - объем электролита, взятый на нализ, мл",
						Top = 40,
						Left = 10,
						Width = 330,
						Height = 100
					};

					Label labelValue2 = new Label()
					{
						Text = "а:",
						Top = 150,
						Left = 10,
						Width = 100
					};


					// Создание и настройка текстовых полей
					TextBox value1 = new TextBox
					{
						Top = 150,
						Left = 30,
						Width = 100
					};
					Label labelValue3 = new Label()
					{
						Text = "V:",
						Top = 180,
						Left = 10,
						Width = 100
					};

					TextBox value2 = new TextBox
					{
						Top = 180,
						Left = 30,
						Width = 100
					};
					Label labelValue4 = new Label()
					{
						Text = "V:",
						Top = 150,
						Left = 175,
						Width = 20
					};

					TextBox value3 = new TextBox
					{
						Top = 150,
						Left = 200,
						Width = 100
					};

					// Добавление обработчиков событий для ограничения ввода только числами
					value1.KeyPress += NumericTextBox_KeyPress;
					value2.KeyPress += NumericTextBox_KeyPress;

					// Создание и настройка кнопки
					Button calculateButton = new Button
					{
						Text = "Вычислить",
						Top = 220,
						Left = 10,
						Width = 290
					};
					calculateButton.Click += (s, args) =>
					{
						// Валидация и получение значений
						if (double.TryParse(value1.Text, out double v1)&& double.TryParse(value2.Text, out double v2))
						{
							double result = Math.Round((v1 * 0.0005844 * 1000000)/v2, 2); // Пример формулы (сложение)

							// Запись результата в выбранную ячейку
							dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result;

							// Обновление базы данных
							UpdateDatabase(e.RowIndex, e.ColumnIndex, result, sender, e);

							inputForm.Close();
						}
						else
						{
							MessageBox.Show("Пожалуйста, введите корректные числовые значения.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					};

					// Добавление элементов на форму
					inputForm.Controls.Add(value1);
					inputForm.Controls.Add(labelValue1);
					inputForm.Controls.Add(labelValueA);
					inputForm.Controls.Add(labelValue2);
					inputForm.Controls.Add(value2);
					inputForm.Controls.Add(labelValue3);
					inputForm.AcceptButton = calculateButton;
					inputForm.Controls.Add(calculateButton);

					inputForm.ShowDialog();
				}
			}
		}


		/// <summary>
		/// Обработчик события KeyPress для текстовых полей, позволяющий вводить только числа и управляющие символы.
		/// </summary>
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

		private void UpdateDatabase(int rowIndex, int columnIndex, double value, object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.Columns[e.ColumnIndex].Name == "ID")
				return;

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				// Получаем значение первичного ключа
				var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

				// Получаем значения обновляемых столбцов

				var FIO_Lab_Update = WC.fio; // Название столбца FIO_Lab
				var Date_Lab_Update = DateTime.Now;
				var Gal_Zat_2_H2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_H2SO4"].Value;
				var Gal_Zat_2_NaCl = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_NaCl"].Value;
				var Gal_Zat_2_PM624Ast = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_PM624Ast"].Value;
				var Gal_Zat_2_PM624A = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_PM624A"].Value;
				var Gal_Zat_2_CuSO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_CuSO4"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
	           UPDATE Galvan_Zat_CuEl12
	  SET [Gal_Zat_2_H2SO4] = @Gal_Zat_2_H2SO4
	     ,[Gal_Zat_2_NaCl] = @Gal_Zat_2_NaCl
	     ,[Gal_Zat_2_PM624Ast] = @Gal_Zat_2_PM624Ast
	     ,[Gal_Zat_2_PM624A] = @Gal_Zat_2_PM624A
	     ,[Gal_Zat_2_CuSO4] = @Gal_Zat_2_CuSO4
	     ,[FIO_Lab_Update] = @FIO_Lab_Update
	     ,[Date_Lab_Update] = @Date_Lab_Update
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					command.Parameters.AddWithValue("@Gal_Zat_2_H2SO4", Gal_Zat_2_H2SO4 ?? DBNull.Value);
					command.Parameters.AddWithValue("@Gal_Zat_2_NaCl", Gal_Zat_2_NaCl ?? DBNull.Value);
					command.Parameters.AddWithValue("@Gal_Zat_2_PM624Ast", Gal_Zat_2_PM624Ast ?? DBNull.Value);
					command.Parameters.AddWithValue("@Gal_Zat_2_PM624A", Gal_Zat_2_PM624A ?? DBNull.Value);
					command.Parameters.AddWithValue("@Gal_Zat_2_CuSO4", Gal_Zat_2_CuSO4 ?? DBNull.Value);
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			pictureBox2.Visible = !pictureBox2.Visible;
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			// Проверяем, что клик был совершен по существующей строке и по 15-му столбцу (индекс 14)
			if (e.RowIndex >= 0 && columnsToCheck.Contains(e.ColumnIndex))
			{
				// Получаем текущую строку
				DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

				// Получаем значения необходимых столбцов
				var completedValue = selectedRow.Cells["Сompleted"].Value;
				var correctionMatValue = selectedRow.Cells["Gal_Zat_2_Correction_Mat"].Value;

				// Проверяем, что "Completed" пустой (null, DBNull или пустая строка)
				bool isCompletedEmpty = completedValue == null ||
										completedValue == DBNull.Value ||
										(completedValue is string strCompleted && string.IsNullOrWhiteSpace(strCompleted));

				// Проверяем, что "Gal_Zat_2_Correction_Mat" не пустой и содержит "NaCl"
				bool isCorrectionMatValid = correctionMatValue != null &&
											correctionMatValue != DBNull.Value &&
											(correctionMatValue is string strCorrMat &&
											 !string.IsNullOrWhiteSpace(strCorrMat) &&
											 strCorrMat.IndexOf("NaCl", StringComparison.OrdinalIgnoreCase) >= 0);



				var startValue = selectedRow.Cells["Start_corr"].Value;
				bool isStart = startValue != null &&
										  startValue != DBNull.Value &&
										  !(startValue is string strstart && string.IsNullOrWhiteSpace(strstart));

				if (!isStart)
				{
					MessageBox.Show("Нельзя выполнить корректировку без начала ее выполнения! Редактирование недоступно.",
									"Информация",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return;
				}



				// Если "Completed" не пустой, показать сообщение и выйти из метода
				if (!isCompletedEmpty)
				{
					MessageBox.Show("Эта корректировка уже выполнена! Редактирование недоступно.",
									"Информация",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return;
				}

				if (!isCorrectionMatValid)
				{
					MessageBox.Show("Строка не содержит NaCl! Редактирование недоступно.",
									"Информация",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return;
				}

				

				// Получаем значение ID из первого столбца (индекс 0)
				var idValue = selectedRow.Cells[0].Value;

				// Проверяем, что ID не пустой
				if (idValue != null)
				{
					if (int.TryParse(idValue.ToString(), out int idClick))
					{
						// Подготовка SQL-запроса для обновления
						string completed = "Выполнено!";
						string connectionString = WC.ConnectionString;
						string query = @"UPDATE Galvan_Zat_CuEl12 SET 
                                 [Date_Corr] = @Date_Corr,
                                 [Сompleted] = @Сompleted,
                                 [FIO_Corr] = @FIO_Corr
                                 WHERE ID = @Id";

						try
						{
							using (SqlConnection connection = new SqlConnection(connectionString))
							{
								using (SqlCommand command = new SqlCommand(query, connection))
								{
									// Добавляем параметры с соответствующими значениями
									command.Parameters.AddWithValue("@Date_Corr", DateTime.Now);
									command.Parameters.AddWithValue("@Сompleted", completed);
									command.Parameters.AddWithValue("@FIO_Corr", WC.fio);
									command.Parameters.AddWithValue("@Id", idClick);

									// Отладочное сообщение (можно удалить в продакшен версии)
									//Console.WriteLine($"Executing UPDATE with ID: {idClick}, Date_Corr: {DateTime.Now}, Completed: {completed}, FIO_Corr: {WC.fio}");

									connection.Open();
									int rowsAffected = command.ExecuteNonQuery();

									if (rowsAffected > 0)
									{
										MessageBox.Show("Корректировка выполнена!",
														"Успех",
														MessageBoxButtons.OK,
														MessageBoxIcon.Information);
										LoadData(); // Обновляем данные в DataGridView
									}
									else
									{
										MessageBox.Show("Не удалось обновить данные.",
														"Ошибка",
														MessageBoxButtons.OK,
														MessageBoxIcon.Error);
									}
								}
							}
						}
						catch (Exception ex)
						{
							// Обработка возможных исключений
							MessageBox.Show("Произошла ошибка при обновлении данных: " + ex.Message,
											"Ошибка",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error);
						}
					}
					else
					{
						MessageBox.Show("Не удалось преобразовать значение ID.",
										"Ошибка",
										MessageBoxButtons.OK,
										MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("Значение ID отсутствует.",
									"Ошибка",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}
			}
			else if (e.RowIndex >= 0 && e.ColumnIndex == 18)
			{
				// Получаем текущую строку
				DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

				// Получаем значения необходимых столбцов
				var completedValue = selectedRow.Cells["Start_corr"].Value;
				var correctionMatValue = selectedRow.Cells["Gal_Zat_2_Correction_Mat"].Value;

				// Проверяем, что "Completed" пустой (null, DBNull или пустая строка)
				bool isCompletedEmpty = completedValue == null ||
										completedValue == DBNull.Value ||
										(completedValue is string strCompleted && string.IsNullOrWhiteSpace(strCompleted));

				// Проверяем, что "Gal_Zat_2_Correction_Mat" не пустой и содержит "NaCl"
				bool isCorrectionMatValid = correctionMatValue != null &&
											correctionMatValue != DBNull.Value &&
											(correctionMatValue is string strCorrMat &&
											 !string.IsNullOrWhiteSpace(strCorrMat) &&
											 strCorrMat.IndexOf("NaCl", StringComparison.OrdinalIgnoreCase) >= 0);



				// Если "Completed" не пустой, показать сообщение и выйти из метода
				if (!isCompletedEmpty)
				{
					MessageBox.Show("Эта корректировка уже выполняется! Редактирование недоступно.",
									"Информация",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return;
				}

				if (!isCorrectionMatValid)
				{
					MessageBox.Show("Строка не содержит NaCl! Редактирование недоступно.",
									"Информация",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return;
				}



				// Получаем значение ID из первого столбца (индекс 0)
				var idValue = selectedRow.Cells[0].Value;

				// Проверяем, что ID не пустой
				if (idValue != null)
				{
					if (int.TryParse(idValue.ToString(), out int idClick))
					{
						// Подготовка SQL-запроса для обновления
						string completed = "В работе";
						string connectionString = WC.ConnectionString;
						string query = @"UPDATE Galvan_Zat_CuEl12 SET 
                         [Date_start_corr] = @Date_start_corr,
                                 [Start_corr] = @Start_corr,
                                 [FIO_start_corr] = @FIO_start_corr
                                 WHERE ID = @Id";

						try
						{
							using (SqlConnection connection = new SqlConnection(connectionString))
							{
								using (SqlCommand command = new SqlCommand(query, connection))
								{
									// Добавляем параметры с соответствующими значениями
									command.Parameters.AddWithValue("@Date_start_corr", DateTime.Now);
									command.Parameters.AddWithValue("@Start_corr", completed);
									command.Parameters.AddWithValue("@FIO_start_corr", WC.fio);
									command.Parameters.AddWithValue("@Id", idClick);

									// Отладочное сообщение (можно удалить в продакшен версии)
									//Console.WriteLine($"Executing UPDATE with ID: {idClick}, Date_Corr: {DateTime.Now}, Completed: {completed}, FIO_Corr: {WC.fio}");

									connection.Open();
									int rowsAffected = command.ExecuteNonQuery();

									if (rowsAffected > 0)
									{
										MessageBox.Show("Корректировка принята в работу!",
														"Успех",
														MessageBoxButtons.OK,
														MessageBoxIcon.Information);
										LoadData(); // Обновляем данные в DataGridView
									}
									else
									{
										MessageBox.Show("Не удалось обновить данные.",
														"Ошибка",
														MessageBoxButtons.OK,
														MessageBoxIcon.Error);
									}
								}
							}
						}
						catch (Exception ex)
						{
							// Обработка возможных исключений
							MessageBox.Show("Произошла ошибка при обновлении данных: " + ex.Message,
											"Ошибка",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error);
						}
					}
					else
					{
						MessageBox.Show("Не удалось преобразовать значение ID.",
										"Ошибка",
										MessageBoxButtons.OK,
										MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("Значение ID отсутствует.",
									"Ошибка",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}
			}
		}
	}
}
