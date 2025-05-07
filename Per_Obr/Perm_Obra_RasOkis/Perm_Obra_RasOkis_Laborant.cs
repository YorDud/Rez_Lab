using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rez_Lab.Black_Hole
{
	public partial class Perm_Obra_RasOkis_Laborant : Form
	{
		public Perm_Obra_RasOkis_Laborant()
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

				dataGridView1.Columns["Per_Obr_2_obshee"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_avtiv_okis"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_pokaz_avtiv"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
				dataGridView1.Columns["Per_Obr_2_plot"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_NaMnO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_Na2MnO4"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
				dataGridView1.Columns["Per_Obr_2_402b"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
				dataGridView1.Columns["Per_Obr_2_NaOH"].DefaultCellStyle.BackColor = Color.LightBlue;

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


		private void Perm_Obra_RasOkis_Laborant_Load(object sender, EventArgs e)
		{
			LoadData();
			label8.Text = WC.fio.ToString();
			//this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			NotClickOnTable();
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

				var Per_Obr_2_obshee = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_obshee"].Value;
				var Per_Obr_2_avtiv_okis = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_avtiv_okis"].Value;

				decimal perObr2Obshee = Per_Obr_2_obshee != DBNull.Value
	? Math.Round(Convert.ToDecimal(Per_Obr_2_obshee), 2)
	: 0;

				decimal perObr2AvtivOkis = Per_Obr_2_avtiv_okis != DBNull.Value
					? Math.Round(Convert.ToDecimal(Per_Obr_2_avtiv_okis), 2)
					: 0;

				decimal Per_Obr_2_pokaz_avtiv = (perObr2Obshee != 0)
					? Math.Round(perObr2AvtivOkis / perObr2Obshee, 2)
					: 0;

				//var Per_Obr_2_pokaz_avtiv = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_pokaz_avtiv"].Value;
				var Per_Obr_2_plot = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_plot"].Value;

				var Per_Obr_2_NaMnO4 = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_NaMnO4"].Value;
				var Per_Obr_2_Na2MnO4 = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_Na2MnO4"].Value;
				var Per_Obr_2_402b = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_402b"].Value;
				var Per_Obr_2_NaOH = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_NaOH"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Perm_Obra_RasOkis
   SET [Per_Obr_2_obshee] = @Per_Obr_2_obshee,
[Per_Obr_2_avtiv_okis] = @Per_Obr_2_avtiv_okis, 
[Per_Obr_2_pokaz_avtiv] = @Per_Obr_2_pokaz_avtiv, 
[Per_Obr_2_plot] = @Per_Obr_2_plot, 
[Per_Obr_2_NaMnO4] = @Per_Obr_2_NaMnO4,
[Per_Obr_2_Na2MnO4] = @Per_Obr_2_Na2MnO4,
[Per_Obr_2_402b] = @Per_Obr_2_402b,
[Per_Obr_2_NaOH] = @Per_Obr_2_NaOH
      ,[Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", fioLab);
					//
					command.Parameters.AddWithValue("@Per_Obr_2_obshee", Per_Obr_2_obshee);
					command.Parameters.AddWithValue("@Per_Obr_2_avtiv_okis", Per_Obr_2_avtiv_okis);
					command.Parameters.AddWithValue("@Per_Obr_2_pokaz_avtiv", Per_Obr_2_pokaz_avtiv);
					command.Parameters.AddWithValue("@Per_Obr_2_plot", Per_Obr_2_plot);
					command.Parameters.AddWithValue("@Per_Obr_2_NaMnO4", Per_Obr_2_NaMnO4);
					command.Parameters.AddWithValue("@Per_Obr_2_Na2MnO4", Per_Obr_2_Na2MnO4);
					command.Parameters.AddWithValue("@Per_Obr_2_402b", Per_Obr_2_402b);
					command.Parameters.AddWithValue("@Per_Obr_2_NaOH", Per_Obr_2_NaOH);

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
				if (column.Name != "Per_Obr_2_obshee" 
					&& column.Name != "Per_Obr_2_avtiv_okis" 
					&& column.Name != "Per_Obr_2_plot"
					&& column.Name != "Per_Obr_2_NaMnO4" 
					&& column.Name != "Per_Obr_2_Na2MnO4"
					&& column.Name != "Per_Obr_2_402b"
					&& column.Name != "Per_Obr_2_NaOH")
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


				var Per_Obr_2_obshee = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_obshee"].Value;
				var Per_Obr_2_avtiv_okis = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_avtiv_okis"].Value;

				decimal perObr2Obshee = Per_Obr_2_obshee != DBNull.Value
	? Math.Round(Convert.ToDecimal(Per_Obr_2_obshee), 2)
	: 0;

				decimal perObr2AvtivOkis = Per_Obr_2_avtiv_okis != DBNull.Value
					? Math.Round(Convert.ToDecimal(Per_Obr_2_avtiv_okis), 2)
					: 0;

				decimal Per_Obr_2_pokaz_avtiv = (perObr2Obshee != 0)
					? Math.Round(perObr2AvtivOkis / perObr2Obshee, 2)
					: 0;

				var Per_Obr_2_plot = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_plot"].Value;

				var Per_Obr_2_NaMnO4 = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_NaMnO4"].Value;
				var Per_Obr_2_Na2MnO4 = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_Na2MnO4"].Value;
				var Per_Obr_2_402b = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_402b"].Value;
				var Per_Obr_2_NaOH = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_NaOH"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Perm_Obra_RasOkis
   SET [Per_Obr_2_obshee] = @Per_Obr_2_obshee,
[Per_Obr_2_avtiv_okis] = @Per_Obr_2_avtiv_okis, 
[Per_Obr_2_pokaz_avtiv] = @Per_Obr_2_pokaz_avtiv, 
[Per_Obr_2_plot] = @Per_Obr_2_plot, 
[Per_Obr_2_NaMnO4] = @Per_Obr_2_NaMnO4,
[Per_Obr_2_Na2MnO4] = @Per_Obr_2_Na2MnO4,
[Per_Obr_2_402b] = @Per_Obr_2_402b,
[Per_Obr_2_NaOH] = @Per_Obr_2_NaOH
      ,[FIO_Lab_Update] = @FIO_Lab_Update
      ,[Date_Lab_Update] = @Date_Lab_Update
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					//
					command.Parameters.AddWithValue("@Per_Obr_2_obshee", Per_Obr_2_obshee);
					command.Parameters.AddWithValue("@Per_Obr_2_avtiv_okis", Per_Obr_2_avtiv_okis);
					command.Parameters.AddWithValue("@Per_Obr_2_pokaz_avtiv", Per_Obr_2_pokaz_avtiv);
					command.Parameters.AddWithValue("@Per_Obr_2_plot", Per_Obr_2_plot);
					command.Parameters.AddWithValue("@Per_Obr_2_NaMnO4", Per_Obr_2_NaMnO4);
					command.Parameters.AddWithValue("@Per_Obr_2_Na2MnO4", Per_Obr_2_Na2MnO4);
					command.Parameters.AddWithValue("@Per_Obr_2_402b", Per_Obr_2_402b);
					command.Parameters.AddWithValue("@Per_Obr_2_NaOH", Per_Obr_2_NaOH);
					//
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}


		private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
		{
			var currentCell = dataGridView1.CurrentCell;

			if (currentCell != null)
			{
				string[] targetColumns = { "Per_Obr_2_obshee", "Per_Obr_2_avtiv_okis" };
				if (targetColumns.Contains(dataGridView1.Columns[currentCell.ColumnIndex].Name))
				{
					var culture = CultureInfo.CurrentCulture;
					var decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
					var alternateSeparator = decimalSeparator == "." ? "," : ".";

					// Разрешаем цифры, управляющие символы и один из разделителей
					if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
						e.KeyChar.ToString() != decimalSeparator && e.KeyChar.ToString() != alternateSeparator)
					{
						e.Handled = true;
					}

					// Разрешаем только один разделитель
					if ((e.KeyChar.ToString() == decimalSeparator || e.KeyChar.ToString() == alternateSeparator) &&
						currentCell.Value != null &&
						currentCell.Value.ToString().Contains(decimalSeparator))
					{
						e.Handled = true;
					}
				}
			}
		}





		// Обработчик события CellValidating
		private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
	{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			// Замените "Per_Obr_2_obshee" и "Per_Obr_2_avtiv_okis" на ваши реальные имена колонок
			string[] targetColumns = { "Per_Obr_2_obshee", "Per_Obr_2_avtiv_okis" };

		if (targetColumns.Contains(dataGridView1.Columns[e.ColumnIndex].Name))
		{
			string userInput = e.FormattedValue.ToString().Trim();

			// Разрешаем пустое значение, если необходимо
			if (string.IsNullOrEmpty(userInput))
			{
				// Можно установить значение по умолчанию, например, 0
				dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0m;
				return;
			}

			// Попытка парсинга с учётом нескольких культур
			bool parsed = false;
			decimal result = 0m;

			// Определяем культуры для парсинга
			CultureInfo[] cultures = new CultureInfo[]
			{
			CultureInfo.CurrentCulture,
			CultureInfo.InvariantCulture,
			new CultureInfo("ru-RU"), // Русская культура (запятая)
            new CultureInfo("en-US")  // Английская культура (точка)
			};

			foreach (var culture in cultures)
			{
				if (decimal.TryParse(userInput, NumberStyles.Number, culture, out result))
				{
					parsed = true;
					break;
				}
			}

			if (!parsed)
			{
				// Если ни одна культура не подошла, отображаем сообщение и отменяем ввод
				MessageBox.Show("Введите корректное числовое значение (используйте точку или запятую как десятичный разделитель).",
								"Ошибка ввода",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
				e.Cancel = true;
			}
			else
			{
				// Присваиваем корректно спарсенное значение
				dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result;
			}
		}
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


			if (e.RowIndex >= 0 && e.ColumnIndex == 3) // Проверяем, что ячейка выбрана
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
					inputForm.Text = "H общ";

					Label labelValue1 = new Label()
					{
						Text = "H общ = a * 0.1 * 28.39",
						Top = 10,
						Left = 30,
						Width = 330
					};

					Label labelValueA = new Label()
					{
						Text = "а - количество 0,1Н раств. тиосульф. натрия, израсход. на титров., мл\r\n",
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
						if (double.TryParse(value1.Text, out double v1))
						{
							double result = Math.Round(v1 * 0.1 * 28.39, 2); // Пример формулы (сложение)

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
					//inputForm.Controls.Add(value2);
					//inputForm.Controls.Add(labelValue3);
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
					inputForm.Text = "H a";

					Label labelValue1 = new Label()
					{
						Text = "H a = a * 0.1 * 28.39",
						Top = 10,
						Left = 30,
						Width = 330
					};

					Label labelValueA = new Label()
					{
						Text = "а - количество 0,1Н тиосульф. натрия, израсход. на титров., мл\r\n",
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
						if (double.TryParse(value1.Text, out double v1))
						{
							double result = Math.Round(v1 * 0.1 * 28.39, 2); // Пример формулы (сложение)

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
					//inputForm.Controls.Add(value2);
					//inputForm.Controls.Add(labelValue3);
					inputForm.AcceptButton = calculateButton;
					inputForm.Controls.Add(calculateButton);

					inputForm.ShowDialog();
				}
			}
			//else if (e.RowIndex >= 0 && e.ColumnIndex == 9) // Проверяем, что ячейка выбрана
			//{
			//	// Открытие диалогового окна
			//	// Открытие диалогового окна
			//	using (Form inputForm = new Form())
			//	{
			//		// Установка размеров формы
			//		inputForm.Width = 350;
			//		inputForm.Height = 300;
			//		inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			//		inputForm.MaximizeBox = false;
			//		inputForm.MinimizeBox = false;
			//		inputForm.StartPosition = FormStartPosition.CenterParent;
			//		inputForm.Text = "ПО 402Б";

			//		Label labelValue1 = new Label()
			//		{
			//			Text = "С(402Б) = a * 13.3",
			//			Top = 10,
			//			Left = 30,
			//			Width = 330
			//		};

			//		Label labelValueA = new Label()
			//		{
			//			Text = "а - количество 1Н раств. серной кислоты, израсход. на титров., мл\r\n",
			//			Top = 40,
			//			Left = 10,
			//			Width = 330,
			//			Height = 100
			//		};

			//		Label labelValue2 = new Label()
			//		{
			//			Text = "а:",
			//			Top = 150,
			//			Left = 10,
			//			Width = 100
			//		};


			//		// Создание и настройка текстовых полей
			//		TextBox value1 = new TextBox
			//		{
			//			Top = 150,
			//			Left = 30,
			//			Width = 100
			//		};
			//		Label labelValue3 = new Label()
			//		{
			//			Text = "V:",
			//			Top = 180,
			//			Left = 10,
			//			Width = 100
			//		};

			//		TextBox value2 = new TextBox
			//		{
			//			Top = 180,
			//			Left = 30,
			//			Width = 100
			//		};
			//		Label labelValue4 = new Label()
			//		{
			//			Text = "V:",
			//			Top = 150,
			//			Left = 175,
			//			Width = 20
			//		};

			//		TextBox value3 = new TextBox
			//		{
			//			Top = 150,
			//			Left = 200,
			//			Width = 100
			//		};

			//		// Добавление обработчиков событий для ограничения ввода только числами
			//		value1.KeyPress += NumericTextBox_KeyPress;
			//		value2.KeyPress += NumericTextBox_KeyPress;

			//		// Создание и настройка кнопки
			//		Button calculateButton = new Button
			//		{
			//			Text = "Вычислить",
			//			Top = 220,
			//			Left = 10,
			//			Width = 290
			//		};
			//		calculateButton.Click += (s, args) =>
			//		{
			//			// Валидация и получение значений
			//			if (double.TryParse(value1.Text, out double v1))
			//			{
			//				double result = Math.Round(v1 * 13.3, 2); // Пример формулы (сложение)

			//				// Запись результата в выбранную ячейку
			//				dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result;

			//				// Обновление базы данных
			//				UpdateDatabase(e.RowIndex, e.ColumnIndex, result, sender, e);

			//				inputForm.Close();
			//			}
			//			else
			//			{
			//				MessageBox.Show("Пожалуйста, введите корректные числовые значения.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//			}
			//		};

			//		// Добавление элементов на форму
			//		inputForm.Controls.Add(value1);
			//		inputForm.Controls.Add(labelValue1);
			//		inputForm.Controls.Add(labelValueA);
			//		inputForm.Controls.Add(labelValue2);
			//		//inputForm.Controls.Add(value2);
			//		//inputForm.Controls.Add(labelValue3);
			//		inputForm.AcceptButton = calculateButton;
			//		inputForm.Controls.Add(calculateButton);

			//		inputForm.ShowDialog();
			//	}
			//}
			else if (e.RowIndex >= 0 && e.ColumnIndex == 10) // Проверяем, что ячейка выбрана
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
					inputForm.Text = "NaOH";

					Label labelValue1 = new Label()
					{
						Text = "С(NaOH) = a * 4",
						Top = 10,
						Left = 30,
						Width = 330
					};

					Label labelValueA = new Label()
					{
						Text = "а - количество 0.5M соляной кислоты, израсход. на титров., мл\r\n",
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
						if (double.TryParse(value1.Text, out double v1))
						{
							double result = Math.Round(v1 * 4, 2); // Пример формулы (сложение)

							// Запись результата в выбранную ячейку
							dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result;

							// Обновление базы данных
							UpdateDatabase(e.RowIndex, e.ColumnIndex, result, sender, e);





							double result2 = Math.Round(result / 0.36, 2);

							dataGridView1.Rows[e.RowIndex].Cells[9].Value = result2;

							// Обновление базы данных
							UpdateDatabase(e.RowIndex, 9, result2, sender, e);


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
					//inputForm.Controls.Add(value2);
					//inputForm.Controls.Add(labelValue3);
					inputForm.AcceptButton = calculateButton;
					inputForm.Controls.Add(calculateButton);

					inputForm.ShowDialog();
				}
			}
			else if (e.RowIndex >= 0 && e.ColumnIndex == 7) // Проверяем, что ячейка выбрана
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
					inputForm.Text = "NaMnO4";

					Label labelValue1 = new Label()
					{
						Text = "С(NaMnO4) = ((E526 * 48.7) - (E603 * 15.9)) * 1.193",
						Top = 10,
						Left = 30,
						Width = 330
					};

					Label labelValueA = new Label()
					{
						Text = "E526 - показание прибора при длине волны 526 нм\r\nE603 - показание прибора при длине волны 603 нм",
						Top = 40,
						Left = 10,
						Width = 330,
						Height = 100
					};

					Label labelValue2 = new Label()
					{
						Text = "E526:",
						Top = 150,
						Left = 10,
						Width = 100
					};


					// Создание и настройка текстовых полей
					TextBox value1 = new TextBox
					{
						Top = 150,
						Left = 50,
						Width = 100
					};
					Label labelValue3 = new Label()
					{
						Text = "E603:",
						Top = 180,
						Left = 10,
						Width = 100
					};

					TextBox value2 = new TextBox
					{
						Top = 180,
						Left = 50,
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
							double result = Math.Round(((v1 * 48.7) - (v2 * 15.9)) * 1.193, 2); // Пример формулы (сложение)

							// Запись результата в выбранную ячейку
							dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result;

							// Обновление базы данных
							UpdateDatabase(e.RowIndex, e.ColumnIndex, result, sender, e);






							double result2 = Math.Round(((v2 * 82.4) - (v1 * 7.34)) * 1.387, 2);

							dataGridView1.Rows[e.RowIndex].Cells[8].Value = result2;

							// Обновление базы данных
							UpdateDatabase(e.RowIndex, 8, result2, sender, e);

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
			//else if (e.RowIndex >= 0 && e.ColumnIndex == 8) // Проверяем, что ячейка выбрана
			//{
			//	// Открытие диалогового окна
			//	// Открытие диалогового окна
			//	using (Form inputForm = new Form())
			//	{
			//		// Установка размеров формы
			//		inputForm.Width = 350;
			//		inputForm.Height = 300;
			//		inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			//		inputForm.MaximizeBox = false;
			//		inputForm.MinimizeBox = false;
			//		inputForm.StartPosition = FormStartPosition.CenterParent;
			//		inputForm.Text = "Na2MnO4";

			//		Label labelValue1 = new Label()
			//		{
			//			Text = "С(Na2MnO4) = ((E603 * 82.4) - (E526 * 7.34)) * 1.387",
			//			Top = 10,
			//			Left = 30,
			//			Width = 330
			//		};

			//		Label labelValueA = new Label()
			//		{
			//			Text = "E526 - показание прибора при длине волны 526 нм\r\nE603 - показание прибора при длине волны 603 нм",
			//			Top = 40,
			//			Left = 10,
			//			Width = 330,
			//			Height = 100
			//		};

			//		Label labelValue2 = new Label()
			//		{
			//			Text = "E526:",
			//			Top = 150,
			//			Left = 10,
			//			Width = 100
			//		};


			//		// Создание и настройка текстовых полей
			//		TextBox value1 = new TextBox
			//		{
			//			Top = 150,
			//			Left = 50,
			//			Width = 100
			//		};
			//		Label labelValue3 = new Label()
			//		{
			//			Text = "E603:",
			//			Top = 180,
			//			Left = 10,
			//			Width = 100
			//		};

			//		TextBox value2 = new TextBox
			//		{
			//			Top = 180,
			//			Left = 50,
			//			Width = 100
			//		};
			//		Label labelValue4 = new Label()
			//		{
			//			Text = "V:",
			//			Top = 150,
			//			Left = 175,
			//			Width = 20
			//		};

			//		TextBox value3 = new TextBox
			//		{
			//			Top = 150,
			//			Left = 200,
			//			Width = 100
			//		};

			//		// Добавление обработчиков событий для ограничения ввода только числами
			//		value1.KeyPress += NumericTextBox_KeyPress;
			//		value2.KeyPress += NumericTextBox_KeyPress;

			//		// Создание и настройка кнопки
			//		Button calculateButton = new Button
			//		{
			//			Text = "Вычислить",
			//			Top = 220,
			//			Left = 10,
			//			Width = 290
			//		};
			//		calculateButton.Click += (s, args) =>
			//		{
			//			// Валидация и получение значений
			//			if (double.TryParse(value1.Text, out double v1) && double.TryParse(value2.Text, out double v2))
			//			{
			//				double result = Math.Round(((v2* 82.4) - (v1 * 7.34)) * 1.387, 2); // Пример формулы (сложение)

			//				// Запись результата в выбранную ячейку
			//				dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = result;

			//				// Обновление базы данных
			//				UpdateDatabase(e.RowIndex, e.ColumnIndex, result, sender, e);

			//				inputForm.Close();
			//			}
			//			else
			//			{
			//				MessageBox.Show("Пожалуйста, введите корректные числовые значения.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//			}
			//		};

			//		// Добавление элементов на форму
			//		inputForm.Controls.Add(value1);
			//		inputForm.Controls.Add(labelValue1);
			//		inputForm.Controls.Add(labelValueA);
			//		inputForm.Controls.Add(labelValue2);
			//		inputForm.Controls.Add(value2);
			//		inputForm.Controls.Add(labelValue3);
			//		inputForm.AcceptButton = calculateButton;
			//		inputForm.Controls.Add(calculateButton);

			//		inputForm.ShowDialog();
			//	}
			//}



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
			if (dataGridView1.Columns[e.ColumnIndex].Name == "ID") return;
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				// Получаем значение первичного ключа
				var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

				// Получаем значения обновляемых столбцов
				var FIO_Lab_Update = WC.fio; // Название столбца FIO_Lab
				var Date_Lab_Update = DateTime.Now;

				var Per_Obr_2_obshee = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_obshee"].Value;
				var Per_Obr_2_avtiv_okis = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_avtiv_okis"].Value;

				decimal perObr2Obshee = Per_Obr_2_obshee != DBNull.Value
					? Math.Round(Convert.ToDecimal(Per_Obr_2_obshee), 2)
					: 0;

				decimal perObr2AvtivOkis = Per_Obr_2_avtiv_okis != DBNull.Value
					? Math.Round(Convert.ToDecimal(Per_Obr_2_avtiv_okis), 2)
					: 0;

				// Объявляем Per_Obr_2_pokaz_avtiv как nullable
				decimal? Per_Obr_2_pokaz_avtiv = null;

				// Проверяем, что оба значения указаны и perObr2Obshee не равен 0
				if (Per_Obr_2_obshee != DBNull.Value && Per_Obr_2_avtiv_okis != DBNull.Value && perObr2Obshee != 0)
				{
					decimal result = Math.Round(perObr2AvtivOkis / perObr2Obshee, 2);
					if (result != 0)
					{
						Per_Obr_2_pokaz_avtiv = result;
					}
					// Если result == 0, оставляем Per_Obr_2_pokaz_avtiv как null
				}

				// Остальные значения
				var Per_Obr_2_plot = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_plot"].Value;
				var Per_Obr_2_NaMnO4 = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_NaMnO4"].Value;
				var Per_Obr_2_Na2MnO4 = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_Na2MnO4"].Value;
				var Per_Obr_2_402b = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_402b"].Value;
				var Per_Obr_2_NaOH = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_NaOH"].Value;

				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Perm_Obra_RasOkis
            SET 
                [Per_Obr_2_obshee] = @Per_Obr_2_obshee,
                [Per_Obr_2_avtiv_okis] = @Per_Obr_2_avtiv_okis, 
                [Per_Obr_2_pokaz_avtiv] = @Per_Obr_2_pokaz_avtiv, 
                [Per_Obr_2_plot] = @Per_Obr_2_plot, 
                [Per_Obr_2_NaMnO4] = @Per_Obr_2_NaMnO4,
                [Per_Obr_2_Na2MnO4] = @Per_Obr_2_Na2MnO4,
                [Per_Obr_2_402b] = @Per_Obr_2_402b,
                [Per_Obr_2_NaOH] = @Per_Obr_2_NaOH,
                [FIO_Lab_Update] = @FIO_Lab_Update,
                [Date_Lab_Update] = @Date_Lab_Update 
            WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Per_Obr_2_obshee", Per_Obr_2_obshee != DBNull.Value ? (object)perObr2Obshee : DBNull.Value);
					command.Parameters.AddWithValue("@Per_Obr_2_avtiv_okis", Per_Obr_2_avtiv_okis != DBNull.Value ? (object)perObr2AvtivOkis : DBNull.Value);
					// Добавляем Per_Obr_2_pokaz_avtiv: если null, передаём DBNull.Value
					if (Per_Obr_2_pokaz_avtiv.HasValue)
						command.Parameters.AddWithValue("@Per_Obr_2_pokaz_avtiv", Per_Obr_2_pokaz_avtiv.Value);
					else
						command.Parameters.AddWithValue("@Per_Obr_2_pokaz_avtiv", DBNull.Value);

					command.Parameters.AddWithValue("@Per_Obr_2_plot", Per_Obr_2_plot ?? DBNull.Value);
					command.Parameters.AddWithValue("@Per_Obr_2_NaMnO4", Per_Obr_2_NaMnO4 ?? DBNull.Value);
					command.Parameters.AddWithValue("@Per_Obr_2_Na2MnO4", Per_Obr_2_Na2MnO4 ?? DBNull.Value);
					command.Parameters.AddWithValue("@Per_Obr_2_402b", Per_Obr_2_402b ?? DBNull.Value);
					command.Parameters.AddWithValue("@Per_Obr_2_NaOH", Per_Obr_2_NaOH ?? DBNull.Value);

					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			groupBox2.Visible = !groupBox2.Visible;
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
	}
}
