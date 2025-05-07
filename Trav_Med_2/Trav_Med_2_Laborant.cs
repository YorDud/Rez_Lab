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

namespace Rez_Lab.Trav_Med_2
{
	public partial class Trav_Med_2_Laborant : Form
	{
		public Trav_Med_2_Laborant()
		{
			InitializeComponent();
			//label3.Text = "Травление меди - 2:\r\nNH4Cl - 8 - 10 г/л\r\nSO4 2- - 100 - 140 г/л\r\nСu2+ - 45 - 50 г/л\r\nОБЪЕМ ВАННЫ: 900 л";

		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Trav_Med_2 ORDER BY Date_Create DESC", connection);
				SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
				dataTable = new DataTable();
				dataAdapter.Fill(dataTable);
				dataGridView1.DataSource = dataTable; // Устанавливаем источник данных

				// Изменение названий столбцов
				dataGridView1.Columns["ID"].HeaderText = "Номер";
				//dataGridView1.Columns["ID"].HeaderCell.Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
				dataGridView1.Columns["Date_Create"].HeaderText = "Дата создания";
				dataGridView1.Columns["FIO_Lab"].HeaderText = "ФИО Создателя";
				dataGridView1.Columns["Trav_Med_2_NH4C"].HeaderText = "Травление меди NH4Cl";
				dataGridView1.Columns["Trav_Med_2_SO42"].HeaderText = "Травление меди SO4 2-";
				dataGridView1.Columns["Trav_Med_2_Сu2"].HeaderText = "Травление меди Сu2+";
				dataGridView1.Columns["Trav_Med_2_V"].HeaderText = "Объем при взятии пробы";
				dataGridView1.Columns["Trav_Med_2_pH"].HeaderText = "pH";
				dataGridView1.Columns["Trav_Med_2_Correction_Mat"].HeaderText = "Корректировка Материал";
				dataGridView1.Columns["Trav_Med_2_Correction_Score"].HeaderText = "Корректировка Количество";
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
				dataGridView1.Columns["Trav_Med_2_NH4C"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Trav_Med_2_SO42"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Trav_Med_2_Сu2"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Trav_Med_2_V"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Trav_Med_2_pH"].DefaultCellStyle.BackColor = Color.LightBlue;

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


		private void Trav_Med_2_Laborant_Load(object sender, EventArgs e)
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

				string query = "SELECT * FROM Trav_Med_2 WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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
				string query = "SELECT * FROM Trav_Med_2 WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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

				string sqlInsert = "INSERT INTO Trav_Med_2 ([Date_Create],[FIO_Lab]) " +
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
				var Trav_Med_NH4C = dataGridView1.Rows[rowIndex].Cells["Trav_Med_2_NH4C"].Value;
				var Trav_Med_SO42 = dataGridView1.Rows[rowIndex].Cells["Trav_Med_2_SO42"].Value;
				var Trav_Med_Сu2 = dataGridView1.Rows[rowIndex].Cells["Trav_Med_2_Сu2"].Value;
				var Trav_Med_2_V = dataGridView1.Rows[rowIndex].Cells["Trav_Med_2_V"].Value;
				var Trav_Med_2_pH = dataGridView1.Rows[rowIndex].Cells["Trav_Med_2_pH"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Trav_Med_2
   SET [Trav_Med_2_NH4C] = @Trav_Med_NH4C
      ,[Trav_Med_2_SO42] = @Trav_Med_SO42
      ,[Trav_Med_2_Сu2] = @Trav_Med_Сu2
      ,[Trav_Med_2_V] = @Trav_Med_2_V
      ,[Trav_Med_2_pH] = @Trav_Med_2_pH
      ,[Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", fioLab);
					command.Parameters.AddWithValue("@Trav_Med_NH4C", Trav_Med_NH4C ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_SO42", Trav_Med_SO42 ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_Сu2", Trav_Med_Сu2 ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_2_V", Trav_Med_2_V ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_2_pH", Trav_Med_2_pH ?? DBNull.Value);
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
				if (column.Name != "Trav_Med_2_NH4C" && column.Name != "Trav_Med_2_SO42" && column.Name != "Trav_Med_2_Сu2" && column.Name != "Trav_Med_2_V" && column.Name != "Trav_Med_2_pH") // предполагается, что "ID" - это столбец, который можно редактировать
				{
					column.ReadOnly = true;
				}
			}
		}
		private bool isCellEndEditEnabled = true;

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

		private void button1_Click(object sender, EventArgs e)
		{
			UpdateRow();

			//if (!isCellEndEditEnabled)
			//{
			//	// Добавляем обработчик события
			//	dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
			//	isCellEndEditEnabled = true;
			//}
		}

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
				var Trav_Med_NH4C = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_2_NH4C"].Value;
				var Trav_Med_SO42 = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_2_SO42"].Value;
				var Trav_Med_Сu2 = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_2_Сu2"].Value;
				var Trav_Med_2_V = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_2_V"].Value;
				var Trav_Med_2_pH = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_2_pH"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Trav_Med_2
   SET [Trav_Med_2_NH4C] = @Trav_Med_NH4C
      ,[Trav_Med_2_SO42] = @Trav_Med_SO42
      ,[Trav_Med_2_Сu2] = @Trav_Med_Сu2
      ,[Trav_Med_2_V] = @Trav_Med_2_V
      ,[Trav_Med_2_pH] = @Trav_Med_2_pH
      ,[FIO_Lab_Update] = @FIO_Lab_Update
      ,[Date_Lab_Update] = @Date_Lab_Update
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					command.Parameters.AddWithValue("@Trav_Med_NH4C", Trav_Med_NH4C ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_SO42", Trav_Med_SO42 ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_Сu2", Trav_Med_Сu2 ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_2_V", Trav_Med_2_V ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_2_pH", Trav_Med_2_pH ?? DBNull.Value);
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
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
					inputForm.Text = "NH4Cl";

					Label labelValue1 = new Label()
					{
						Text = "C(NH4Cl) = ((Abs/2) * 139,55 + 0,47) * 100/1000 * 1.507",
						Top = 10,
						Left = 30,
						Width = 330
					};

					Label labelValueA = new Label()
					{
						Text = "Abs - показание спектрофотометра\r\n",
						Top = 40,
						Left = 10,
						Width = 330,
						Height = 100
					};

					Label labelValue2 = new Label()
					{
						Text = "Abs:",
						Top = 150,
						Left = 10,
						Width = 100
					};


					// Создание и настройка текстовых полей
					TextBox value1 = new TextBox
					{
						Top = 150,
						Left = 40,
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
							double result = Math.Round((((v1 / 2) * 139.55 + 0.47) * 100) / 1000 * 1.507, 2); // Пример формулы (сложение)

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
					inputForm.Text = "SO4 2-";

					Label labelValue1 = new Label()
					{
						Text = "C((NH4)2SO4) = (a1 - a0) * 48.032 * T",
						Top = 10,
						Left = 30,
						Width = 330
					};

					Label labelValueA = new Label()
					{
						Text = "а1 - количество 1Н раств. NaOH, израсход. на титров. элюата, мл\r\nа0 - количество 1Н раств. NaOH, израсход. на титров. хол. пробы, мл\r\nT - титр 1Н раств. NaOH по янтарной кислоте, г/мл",
						Top = 40,
						Left = 10,
						Width = 330,
						Height = 100
					};

					Label labelValue2 = new Label()
					{
						Text = "а1:",
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
						Text = "a0:",
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
						Text = "T:",
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
						if (double.TryParse(value1.Text, out double v1) && double.TryParse(value2.Text, out double v2) && double.TryParse(value3.Text, out double v3))
						{
							double result = Math.Round((v1 - v2) * 48.032 * v3, 2); // Пример формулы (сложение)

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
					inputForm.Controls.Add(value3);
					inputForm.Controls.Add(labelValue4);
					inputForm.AcceptButton = calculateButton;
					inputForm.Controls.Add(calculateButton);

					inputForm.ShowDialog();
				}
			}
			else if (e.RowIndex >= 0 && e.ColumnIndex == 5) // Проверяем, что ячейка выбрана
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
					inputForm.Text = "Cu 2+";

					Label labelValue1 = new Label()
					{
						Text = "C(Cu 2+) = a * 6,35",
						Top = 10,
						Left = 30,
						Width = 330
					};

					Label labelValueA = new Label()
					{
						Text = "а - количество 0,1Н раств. Трилона Б, израсход. на титров., мл\r\n",
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
							double result = Math.Round(v1 * 6.35, 0); // Пример формулы (сложение)

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
				var Trav_Med_NH4C = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_2_NH4C"].Value;
				var Trav_Med_SO42 = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_2_SO42"].Value;
				var Trav_Med_Сu2 = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_2_Сu2"].Value;
				var Trav_Med_2_V = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_2_V"].Value;
				var Trav_Med_2_pH = dataGridView1.Rows[e.RowIndex].Cells["Trav_Med_2_pH"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Trav_Med_2
   SET [Trav_Med_2_NH4C] = @Trav_Med_NH4C
      ,[Trav_Med_2_SO42] = @Trav_Med_SO42
      ,[Trav_Med_2_Сu2] = @Trav_Med_Сu2
      ,[Trav_Med_2_V] = @Trav_Med_2_V
      ,[Trav_Med_2_pH] = @Trav_Med_2_pH
      ,[FIO_Lab_Update] = @FIO_Lab_Update
      ,[Date_Lab_Update] = @Date_Lab_Update
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					command.Parameters.AddWithValue("@Trav_Med_NH4C", Trav_Med_NH4C ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_SO42", Trav_Med_SO42 ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_Сu2", Trav_Med_Сu2 ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_2_V", Trav_Med_2_V ?? DBNull.Value);
					command.Parameters.AddWithValue("@Trav_Med_2_pH", Trav_Med_2_pH ?? DBNull.Value);
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
	}
}
