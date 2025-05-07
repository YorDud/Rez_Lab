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

namespace Rez_Lab.Black_Hole
{
	public partial class Black_Hole_Laborant : Form
	{
		public Black_Hole_Laborant()
		{
			InitializeComponent();
			label11.Text = "Cleaner BHC-1012: \nщелочность  - 0,25-0,31 норм.\npH > 10";
			label2.Text = "Conditioner BHC-1022:    \r\nщелочность  - 0,25-0,31 норм.\r\npH > 10 ";
			label3.Text = "Микротравление 1: \r\nNa2S2O3- 60 - 70 г/л\r\n H2SO4 - 10 - 15 г/л \r\nCu 2+ < 15";
			label4.Text = "Микротравление 2 и 3: \r\nNa2S2O3- 100 - 120 г/л \r\nH2SO4 - 15 - 20 г/л \r\nCu 2+ < 15 \r\nподтрав - 0,8 - 1,2 мкм/мин";
			label5.Text = "Black Hole BHC- 1032 (ваннa 1): \r\nсодерж. тв. частиц - 2 - 5 % \r\nрН - 9,5 - 10,5";
			label6.Text = "Black Hole BHC- 1032 (ваннa 2): \r\nсодерж. тв. частиц - 2 - 5 % \r\nрН - 9,5 - 10,5";
			label7.Text = "БАК микротравление 1: \r\nNa2S2O3- 80 г/л";
			label1.Text = "БАК микротравление 3: \r\nNa2S2O3- 120 г/л";
		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Black_Hole ORDER BY Date_Create DESC", connection);
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
				//dataGridView1.Columns["Black_Hole_1_shelochnost"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_1_pH"].HeaderText = "pH";
				//dataGridView1.Columns["Black_Hole_1_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Black_Hole_2_shelochnost"].HeaderText = "Щелочность";
				dataGridView1.Columns["Black_Hole_2_pH"].HeaderText = "pH";
				//dataGridView1.Columns["Black_Hole_2_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Black_Hole_3_Na2S2O3"].HeaderText = "Na2S2O3";
				dataGridView1.Columns["Black_Hole_3_Н2SO4"].HeaderText = "Н2SO4";
				dataGridView1.Columns["Black_Hole_3_Cu2"].HeaderText = "Cu^2+";
				//dataGridView1.Columns["Black_Hole_3_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Black_Hole_4_Na2S2O3"].HeaderText = "Na2S2O3";
				dataGridView1.Columns["Black_Hole_4_Н2SO4"].HeaderText = "Н2SO4";
				dataGridView1.Columns["Black_Hole_4_Cu2"].HeaderText = "Cu^2+";
				dataGridView1.Columns["Black_Hole_4_podtrav"].HeaderText = "Подтравитель";
				//dataGridView1.Columns["Black_Hole_4_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Black_Hole_5_soder_tv_chast"].HeaderText = "Сод.тв. частиц";
				dataGridView1.Columns["Black_Hole_5_pH"].HeaderText = "pH";
				//dataGridView1.Columns["Black_Hole_5_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Black_Hole_6_soder_tv_chast"].HeaderText = "Сод.тв. частиц";
				dataGridView1.Columns["Black_Hole_6_pH"].HeaderText = "pH";
				//dataGridView1.Columns["Black_Hole_6_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Black_Hole_7_Na2S2O3"].HeaderText = "Na2S2O3";
				//dataGridView1.Columns["Black_Hole_7_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Black_Hole_8_Na2S2O3"].HeaderText = "Na2S2O3";
				//dataGridView1.Columns["Black_Hole_8_Correction"].HeaderText = "Корректировка";
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

				dataGridView1.Columns["Black_Hole_1_shelochnost"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_1_pH"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_2_shelochnost"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_2_pH"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_3_Na2S2O3"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_3_Н2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_3_Cu2"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_4_Na2S2O3"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_4_Н2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_4_Cu2"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_4_podtrav"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_5_soder_tv_chast"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_5_pH"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_6_soder_tv_chast"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_6_pH"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_7_Na2S2O3"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Black_Hole_8_Na2S2O3"].DefaultCellStyle.BackColor = Color.LightBlue;

			}

		}


		private void Black_Hole_Laborant_Load(object sender, EventArgs e)
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

				string query = "SELECT * FROM Black_Hole WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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
				string query = "SELECT * FROM Black_Hole WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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

				string sqlInsert = "INSERT INTO Black_Hole ([Date_Create],[FIO_Lab]) " +
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
				var Black_Hole_1_shelochnost = dataGridView1.Rows[rowIndex].Cells["Black_Hole_1_shelochnost"].Value;
				var Black_Hole_1_pH = dataGridView1.Rows[rowIndex].Cells["Black_Hole_1_pH"].Value;

				var Black_Hole_2_shelochnost = dataGridView1.Rows[rowIndex].Cells["Black_Hole_2_shelochnost"].Value;
				var Black_Hole_2_pH = dataGridView1.Rows[rowIndex].Cells["Black_Hole_2_pH"].Value;

				var Black_Hole_3_Na2S2O3 = dataGridView1.Rows[rowIndex].Cells["Black_Hole_3_Na2S2O3"].Value;
				var Black_Hole_3_Н2SO4 = dataGridView1.Rows[rowIndex].Cells["Black_Hole_3_Н2SO4"].Value;
				var Black_Hole_3_Cu2 = dataGridView1.Rows[rowIndex].Cells["Black_Hole_3_Cu2"].Value;

				var Black_Hole_4_Na2S2O3 = dataGridView1.Rows[rowIndex].Cells["Black_Hole_4_Na2S2O3"].Value;
				var Black_Hole_4_Н2SO4 = dataGridView1.Rows[rowIndex].Cells["Black_Hole_4_Н2SO4"].Value;
				var Black_Hole_4_Cu2 = dataGridView1.Rows[rowIndex].Cells["Black_Hole_4_Cu2"].Value;
				var Black_Hole_4_podtrav = dataGridView1.Rows[rowIndex].Cells["Black_Hole_4_podtrav"].Value;

				var Black_Hole_5_soder_tv_chast = dataGridView1.Rows[rowIndex].Cells["Black_Hole_5_soder_tv_chast"].Value;
				var Black_Hole_5_pH = dataGridView1.Rows[rowIndex].Cells["Black_Hole_5_pH"].Value;

				var Black_Hole_6_soder_tv_chast = dataGridView1.Rows[rowIndex].Cells["Black_Hole_6_soder_tv_chast"].Value;
				var Black_Hole_6_pH = dataGridView1.Rows[rowIndex].Cells["Black_Hole_6_pH"].Value;

				var Black_Hole_7_Na2S2O3 = dataGridView1.Rows[rowIndex].Cells["Black_Hole_7_Na2S2O3"].Value;

				var Black_Hole_8_Na2S2O3 = dataGridView1.Rows[rowIndex].Cells["Black_Hole_8_Na2S2O3"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Black_Hole
   SET [Black_Hole_1_shelochnost] = @Black_Hole_1_shelochnost,
[Black_Hole_1_pH] = @Black_Hole_1_pH,
[Black_Hole_2_shelochnost] = @Black_Hole_2_shelochnost,
[Black_Hole_2_pH] = @Black_Hole_2_pH,
[Black_Hole_3_Na2S2O3] = @Black_Hole_3_Na2S2O3,
[Black_Hole_3_Н2SO4] = @Black_Hole_3_Н2SO4,
[Black_Hole_3_Cu2] = @Black_Hole_3_Cu2,
[Black_Hole_4_Na2S2O3] = @Black_Hole_4_Na2S2O3,
[Black_Hole_4_Н2SO4] = @Black_Hole_4_Н2SO4,
[Black_Hole_4_Cu2] = @Black_Hole_4_Cu2,
[Black_Hole_4_podtrav] = @Black_Hole_4_podtrav,
[Black_Hole_5_soder_tv_chast] = @Black_Hole_5_soder_tv_chast,
[Black_Hole_5_pH] = @Black_Hole_5_pH,
[Black_Hole_6_soder_tv_chast] = @Black_Hole_6_soder_tv_chast,
[Black_Hole_6_pH] = @Black_Hole_6_pH,
[Black_Hole_7_Na2S2O3] = @Black_Hole_7_Na2S2O3,
[Black_Hole_8_Na2S2O3] = @Black_Hole_8_Na2S2O3
      ,[Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", fioLab);
					//
					command.Parameters.AddWithValue("@Black_Hole_1_shelochnost", Black_Hole_1_shelochnost);
					command.Parameters.AddWithValue("@Black_Hole_1_pH", Black_Hole_1_pH);
					command.Parameters.AddWithValue("@Black_Hole_2_shelochnost", Black_Hole_2_shelochnost);
					command.Parameters.AddWithValue("@Black_Hole_2_pH", Black_Hole_2_pH);
					command.Parameters.AddWithValue("@Black_Hole_3_Na2S2O3", Black_Hole_3_Na2S2O3);
					command.Parameters.AddWithValue("@Black_Hole_3_Н2SO4", Black_Hole_3_Н2SO4);
					command.Parameters.AddWithValue("@Black_Hole_3_Cu2", Black_Hole_3_Cu2);
					command.Parameters.AddWithValue("@Black_Hole_4_Na2S2O3", Black_Hole_4_Na2S2O3);
					command.Parameters.AddWithValue("@Black_Hole_4_Н2SO4", Black_Hole_4_Н2SO4);
					command.Parameters.AddWithValue("@Black_Hole_4_Cu2", Black_Hole_4_Cu2);
					command.Parameters.AddWithValue("@Black_Hole_4_podtrav", Black_Hole_4_podtrav);
					command.Parameters.AddWithValue("@Black_Hole_5_soder_tv_chast", Black_Hole_5_soder_tv_chast);
					command.Parameters.AddWithValue("@Black_Hole_5_pH", Black_Hole_5_pH);
					command.Parameters.AddWithValue("@Black_Hole_6_soder_tv_chast", Black_Hole_6_soder_tv_chast);
					command.Parameters.AddWithValue("@Black_Hole_6_pH", Black_Hole_6_pH);
					command.Parameters.AddWithValue("@Black_Hole_7_Na2S2O3", Black_Hole_7_Na2S2O3);
					command.Parameters.AddWithValue("@Black_Hole_8_Na2S2O3", Black_Hole_8_Na2S2O3);
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
				if (column.Name != "Black_Hole_1_shelochnost" && column.Name != "Black_Hole_1_pH" &&
					column.Name != "Black_Hole_2_shelochnost" && column.Name != "Black_Hole_2_pH" &&
					column.Name != "Black_Hole_3_Na2S2O3" && column.Name != "Black_Hole_3_Н2SO4" &&
					column.Name != "Black_Hole_3_Cu2" && column.Name != "Black_Hole_4_Na2S2O3" &&
					column.Name != "Black_Hole_4_Н2SO4" && column.Name != "Black_Hole_4_Cu2" &&
					column.Name != "Black_Hole_4_podtrav" && column.Name != "Black_Hole_5_soder_tv_chast" &&
					column.Name != "Black_Hole_5_pH" && column.Name != "Black_Hole_6_soder_tv_chast" &&
					column.Name != "Black_Hole_6_pH" && column.Name != "Black_Hole_7_Na2S2O3" &&
					column.Name != "Black_Hole_8_Na2S2O3")
				{
					// предполагается, что стали только указанные выше столбцы можно редактировать
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
				var Black_Hole_1_shelochnost = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_1_shelochnost"].Value;
				var Black_Hole_1_pH = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_1_pH"].Value;

				var Black_Hole_2_shelochnost = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_2_shelochnost"].Value;
				var Black_Hole_2_pH = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_2_pH"].Value;

				var Black_Hole_3_Na2S2O3 = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_3_Na2S2O3"].Value;
				var Black_Hole_3_Н2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_3_Н2SO4"].Value;
				var Black_Hole_3_Cu2 = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_3_Cu2"].Value;

				var Black_Hole_4_Na2S2O3 = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_4_Na2S2O3"].Value;
				var Black_Hole_4_Н2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_4_Н2SO4"].Value;
				var Black_Hole_4_Cu2 = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_4_Cu2"].Value;
				var Black_Hole_4_podtrav = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_4_podtrav"].Value;

				var Black_Hole_5_soder_tv_chast = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_5_soder_tv_chast"].Value;
				var Black_Hole_5_pH = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_5_pH"].Value;

				var Black_Hole_6_soder_tv_chast = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_6_soder_tv_chast"].Value;
				var Black_Hole_6_pH = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_6_pH"].Value;

				var Black_Hole_7_Na2S2O3 = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_7_Na2S2O3"].Value;

				var Black_Hole_8_Na2S2O3 = dataGridView1.Rows[e.RowIndex].Cells["Black_Hole_8_Na2S2O3"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Black_Hole
   SET [Black_Hole_1_shelochnost] = @Black_Hole_1_shelochnost,
[Black_Hole_1_pH] = @Black_Hole_1_pH,
[Black_Hole_2_shelochnost] = @Black_Hole_2_shelochnost,
[Black_Hole_2_pH] = @Black_Hole_2_pH,
[Black_Hole_3_Na2S2O3] = @Black_Hole_3_Na2S2O3,
[Black_Hole_3_Н2SO4] = @Black_Hole_3_Н2SO4,
[Black_Hole_3_Cu2] = @Black_Hole_3_Cu2,
[Black_Hole_4_Na2S2O3] = @Black_Hole_4_Na2S2O3,
[Black_Hole_4_Н2SO4] = @Black_Hole_4_Н2SO4,
[Black_Hole_4_Cu2] = @Black_Hole_4_Cu2,
[Black_Hole_4_podtrav] = @Black_Hole_4_podtrav,
[Black_Hole_5_soder_tv_chast] = @Black_Hole_5_soder_tv_chast,
[Black_Hole_5_pH] = @Black_Hole_5_pH,
[Black_Hole_6_soder_tv_chast] = @Black_Hole_6_soder_tv_chast,
[Black_Hole_6_pH] = @Black_Hole_6_pH,
[Black_Hole_7_Na2S2O3] = @Black_Hole_7_Na2S2O3,
[Black_Hole_8_Na2S2O3] = @Black_Hole_8_Na2S2O3
      ,[FIO_Lab_Update] = @FIO_Lab_Update
      ,[Date_Lab_Update] = @Date_Lab_Update
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					//
					command.Parameters.AddWithValue("@Black_Hole_1_shelochnost", Black_Hole_1_shelochnost);
					command.Parameters.AddWithValue("@Black_Hole_1_pH", Black_Hole_1_pH);
					command.Parameters.AddWithValue("@Black_Hole_2_shelochnost", Black_Hole_2_shelochnost);
					command.Parameters.AddWithValue("@Black_Hole_2_pH", Black_Hole_2_pH);
					command.Parameters.AddWithValue("@Black_Hole_3_Na2S2O3", Black_Hole_3_Na2S2O3);
					command.Parameters.AddWithValue("@Black_Hole_3_Н2SO4", Black_Hole_3_Н2SO4);
					command.Parameters.AddWithValue("@Black_Hole_3_Cu2", Black_Hole_3_Cu2);
					command.Parameters.AddWithValue("@Black_Hole_4_Na2S2O3", Black_Hole_4_Na2S2O3);
					command.Parameters.AddWithValue("@Black_Hole_4_Н2SO4", Black_Hole_4_Н2SO4);
					command.Parameters.AddWithValue("@Black_Hole_4_Cu2", Black_Hole_4_Cu2);
					command.Parameters.AddWithValue("@Black_Hole_4_podtrav", Black_Hole_4_podtrav);
					command.Parameters.AddWithValue("@Black_Hole_5_soder_tv_chast", Black_Hole_5_soder_tv_chast);
					command.Parameters.AddWithValue("@Black_Hole_5_pH", Black_Hole_5_pH);
					command.Parameters.AddWithValue("@Black_Hole_6_soder_tv_chast", Black_Hole_6_soder_tv_chast);
					command.Parameters.AddWithValue("@Black_Hole_6_pH", Black_Hole_6_pH);
					command.Parameters.AddWithValue("@Black_Hole_7_Na2S2O3", Black_Hole_7_Na2S2O3);
					command.Parameters.AddWithValue("@Black_Hole_8_Na2S2O3", Black_Hole_8_Na2S2O3);
					//
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}
	}
}
