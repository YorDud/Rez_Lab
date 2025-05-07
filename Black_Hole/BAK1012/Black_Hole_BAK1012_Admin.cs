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

namespace Rez_Lab.Black_Hole_BAK1012
{
	public partial class Black_Hole_BAK1012_Admin : Form
	{
		public Black_Hole_BAK1012_Admin()
		{
			InitializeComponent();

			//label11.Text = "BHC-1012 - 65 мл/л\npH > 10\r\nОБЪЕМ ВАННЫ: 100 л";
			//label2.Text = "Conditioner BHC-1022:    \r\nщелочность  - 0,25-0,31 норм.\r\npH > 10 ";
			//label3.Text = "Микротравление 1: \r\nNa2S2O3- 60 - 70 г/л\r\n H2SO4 - 10 - 15 г/л \r\nCu 2+ < 15";
			//label4.Text = "Микротравление 2 и 3: \r\nNa2S2O3- 100 - 120 г/л \r\nH2SO4 - 15 - 20 г/л \r\nCu 2+ < 15 \r\nподтрав - 0,8 - 1,2 мкм/мин";
			//label5.Text = "Black Hole BHC- 1032 (ваннa 1): \r\nсодерж. тв. частиц - 2 - 5 % \r\nрН - 9,5 - 10,5";
			//label6.Text = "Black Hole BHC- 1032 (ваннa 2): \r\nсодерж. тв. частиц - 2 - 5 % \r\nрН - 9,5 - 10,5";
			//label7.Text = "БАК микротравление 1: \r\nNa2S2O3- 80 г/л";
			//label9.Text = "БАК микротравление 3: \r\nNa2S2O3- 120 г/л";
			

		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Black_Hole_BAK1012 ORDER BY Date_Create DESC", connection);
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
				dataGridView1.Columns["Black_Hole_1_shelochnost"].HeaderText = "Щелочность";
				dataGridView1.Columns["Black_Hole_1_pH"].HeaderText = "pH";
				dataGridView1.Columns["Black_Hole_1_Correction_Mat"].HeaderText = "Корректировка Материал";
				dataGridView1.Columns["Black_Hole_1_Correction_Score"].HeaderText = "Корректировка Количество";


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
			}

		}

		

		private void Black_Hole_BAK1012_Admin_Load(object sender, EventArgs e)
		{
			label8.Text = WC.fio.ToString();
			LoadData();
			
		}

		private void Refresh_btn_Click(object sender, EventArgs e)
		{
			LoadData();
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

				string query = "SELECT * FROM Black_Hole_BAK1012 WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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

		int clickCount = 0;
		private void button3_Click(object sender, EventArgs e)
		{
			//int clickCount = 0;
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
			//groupBox1.Visible = true;
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
		}

		private void LoadDataByDateRange(DateTime startDate, DateTime endDate)
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				string query = "SELECT * FROM Black_Hole_BAK1012 WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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


		private bool isCellEndEditEnabled = true;
		private void button4_Click(object sender, EventArgs e)
		{
			Add_Row();
			LoadData();

			//if (isCellEndEditEnabled)
			//{
			//	// Удаляем обработчик события
			//	dataGridView1.CellEndEdit -= dataGridView1_CellEndEdit_1;
			//	isCellEndEditEnabled = false;
			//}
		}

		
		private void Add_Row()
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();

				string sqlInsert = "INSERT INTO Black_Hole_BAK1012 ([Date_Create], [FIO_Lab]) " +
					 "VALUES (@Date_Create, @FIO_Lab)";

				using (SqlCommand command = new SqlCommand(sqlInsert, connection))
				{
					command.Parameters.AddWithValue("@Date_Create", DateTime.Now);
					command.Parameters.AddWithValue("@FIO_Lab", WC.fio);
					//command.Parameters.AddWithValue("@FIO_Lab", WC.fio);
					command.ExecuteNonQuery();

				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//UpdateRow();

			//if (!isCellEndEditEnabled)
			//{
			//	// Добавляем обработчик события
			//	dataGridView1.CellEndEdit += dataGridView1_CellEndEdit_1;
			//	isCellEndEditEnabled = true;
			//}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
			
		}

		private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.Columns[e.ColumnIndex].Name == "ID")
				return;

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				// Получаем значение первичного ключа
				var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

				// Получаем значения обновляемых столбцов

				var Date_Create = dataGridView1.Rows[e.RowIndex].Cells["Date_Create"].Value;
				var FIO_Lab = dataGridView1.Rows[e.RowIndex].Cells["FIO_Lab"].Value; // Название столбца FIO_Lab
																					 //
				var Black_Hole_1_shelochnost = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_1_shelochnost"].Value;
				var Black_Hole_1_pH = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_1_pH"].Value;
				var Black_Hole_1_Correction_Mat = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_1_Correction_Mat"].Value;
				var Black_Hole_1_Correction_Score = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_1_Correction_Score"].Value;

				

				//
				var FIO_tech = dataGridView1.Rows[e.RowIndex].Cells["FIO_tech"].Value;
var Date_tech = dataGridView1.Rows[e.RowIndex].Cells["Date_tech"].Value;
var FIO_Lab_Update = dataGridView1.Rows[e.RowIndex].Cells["FIO_Lab_Update"].Value;
var Date_Lab_Update = dataGridView1.Rows[e.RowIndex].Cells["Date_Lab_Update"].Value;
var FIO_Corr = dataGridView1.Rows[e.RowIndex].Cells["FIO_Corr"].Value;
var Date_Corr = dataGridView1.Rows[e.RowIndex].Cells["Date_Corr"].Value;
var Сompleted = dataGridView1.Rows[e.RowIndex].Cells["Сompleted"].Value;
var Start_corr = dataGridView1.Rows[e.RowIndex].Cells["Start_corr"].Value;
var Date_start_corr = dataGridView1.Rows[e.RowIndex].Cells["Date_start_corr"].Value;
var FIO_start_corr = dataGridView1.Rows[e.RowIndex].Cells["FIO_start_corr"].Value;
var Сomment = dataGridView1.Rows[e.RowIndex].Cells["Сomment"].Value;


				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Black_Hole_BAK1012
   SET [Date_Create] = @Date_Create
      ,[FIO_Lab] = @FIO_Lab
      ,[Black_Hole_1_shelochnost] = @Black_Hole_1_shelochnost,
[Black_Hole_1_pH] = @Black_Hole_1_pH,
[Black_Hole_1_Correction_Mat] = @Black_Hole_1_Correction_Mat,
[Black_Hole_1_Correction_Score] = @Black_Hole_1_Correction_Score
      ,[FIO_tech] = @FIO_tech
,[Date_tech] = @Date_tech
,[FIO_Lab_Update] = @FIO_Lab_Update
,[Date_Lab_Update] = @Date_Lab_Update
,[FIO_Corr] = @FIO_Corr
,[Date_Corr] = @Date_Corr
,[Сompleted] = @Сompleted
,[Start_corr] = @Start_corr
,[Date_start_corr] = @Date_start_corr
,[FIO_start_corr] = @FIO_start_corr
,[Сomment] = @Сomment
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", FIO_Lab);
					//
					command.Parameters.AddWithValue("@Black_Hole_1_shelochnost", Black_Hole_1_shelochnost);
					command.Parameters.AddWithValue("@Black_Hole_1_pH", Black_Hole_1_pH);
					command.Parameters.AddWithValue("@Black_Hole_1_Correction_Mat", Black_Hole_1_Correction_Mat);
					command.Parameters.AddWithValue("@Black_Hole_1_Correction_Score", Black_Hole_1_Correction_Score);
					
					//
					command.Parameters.AddWithValue("@FIO_tech", FIO_tech);
command.Parameters.AddWithValue("@Date_tech", Date_tech);
command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
command.Parameters.AddWithValue("@FIO_Corr", FIO_Corr);
command.Parameters.AddWithValue("@Date_Corr", Date_Corr);
command.Parameters.AddWithValue("@Сompleted", Сompleted);
command.Parameters.AddWithValue("@Start_corr", Start_corr);
command.Parameters.AddWithValue("@Date_start_corr", Date_start_corr);
command.Parameters.AddWithValue("@FIO_start_corr", FIO_start_corr);
command.Parameters.AddWithValue("@Сomment", Сomment);
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Проверяем, в какой ячейке в данный момент происходит ввод
			var currentCell = dataGridView1.CurrentCell;

			// Убедимся, что активна нужная ячейка
			if (currentCell.ColumnIndex == dataGridView1.Columns["Date_Create"].Index ||
				currentCell.ColumnIndex == dataGridView1.Columns["Date_tech"].Index ||
				currentCell.ColumnIndex == dataGridView1.Columns["Date_Lab_Update"].Index ||
				currentCell.ColumnIndex == dataGridView1.Columns["Date_Corr"].Index ||
				currentCell.ColumnIndex == dataGridView1.Columns["Date_start_corr"].Index)
			{
				// Позволяем вводить только цифры, точки, слеши и управление
				if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.' && e.KeyChar != '/')
				{
					e.Handled = true; // Отменяем ввод
				}

				// Проверка для исключения повторного ввода точки или слеша
				if ((e.KeyChar == '.' || e.KeyChar == '/') &&
					(currentCell.Value != null &&
					(currentCell.Value.ToString().Contains(".") || currentCell.Value.ToString().Contains("/"))))
				{
					e.Handled = true; // Отменяем ввод, если уже есть точка или слэш
				}

				// Проверка на максимальную длину (формат дд.мм.гггг = 10 символов)
				if (currentCell.Value != null && currentCell.Value.ToString().Length >= 10)
				{
					if (!char.IsControl(e.KeyChar)) // Не допускаем ввод, если длина уже 10 символов и не нажата клавиша управления
					{
						e.Handled = true;
					}
				}
			}
		}

		private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.ColumnIndex == dataGridView1.Columns["Date_Create"].Index ||
				e.ColumnIndex == dataGridView1.Columns["Date_tech"].Index ||
				e.ColumnIndex == dataGridView1.Columns["Date_Lab_Update"].Index ||
				e.ColumnIndex == dataGridView1.Columns["Date_Corr"].Index ||
				e.ColumnIndex == dataGridView1.Columns["Date_start_corr"].Index)
			{
				// Получаем введенное значение
				string userInput = e.FormattedValue.ToString();

				// Проверка на корректный формат даты
				if (!string.IsNullOrWhiteSpace(userInput))
				{
					if (!DateTime.TryParseExact(userInput, "dd.MM.yyyy",
						CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _))
					{
						// Если не удалось преобразовать, отменяем введение и выдаем сообщение
						MessageBox.Show("Введите дату в формате дд.мм.гггг.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
						e.Cancel = true; // Отменяем изменение в ячейке
					}
				}
			}
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			pictureBox2.Visible = !pictureBox2.Visible;
		}
	}
}
