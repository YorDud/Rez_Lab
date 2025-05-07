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

namespace Rez_Lab.Per_Obr
{
	public partial class Per_Obr_Laborant : Form
	{
		public Per_Obr_Laborant()
		{
			InitializeComponent();
			//dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
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

				dataGridView1.Columns["Per_Obr_1_401A"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_1_401b"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_obshee"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_avtiv_okis"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_pokaz_avtiv"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_NaMnO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_Na2MnO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_402b"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_2_NaOH"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_3_Н2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_3_DES430"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_4_Н2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Per_Obr_4_DES430"].DefaultCellStyle.BackColor = Color.LightBlue;
			}

		}


		private void Per_Obr_Laborant_Load(object sender, EventArgs e)
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


		private void Add_Row()
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();

				string sqlInsert = "INSERT INTO Per_Obr ([Date_Create],[FIO_Lab]) " +
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
			int rowIndex = 0; // Убедитесь, что редактируемая ячейка находится в первой строке

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				// Получаем значение первичного ключа
				var id = dataGridView1.Rows[rowIndex].Cells["ID"].Value;

				// Получаем значения обновляемых столбцов
				var fioLab = WC.fio;
				var Date_Create = DateTime.Now;
				var Per_Obr_1_401A = dataGridView1.Rows[rowIndex].Cells["Per_Obr_1_401A"].Value;
				var Per_Obr_1_401b = dataGridView1.Rows[rowIndex].Cells["Per_Obr_1_401b"].Value;
				var Per_Obr_2_obshee = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_obshee"].Value);
				var Per_Obr_2_avtiv_okis = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_avtiv_okis"].Value);

				// Рассчитываем Per_Obr_2_pokaz_avtiv
				decimal Per_Obr_2_pokaz_avtiv = (Per_Obr_2_obshee != 0) ? (Per_Obr_2_avtiv_okis / Per_Obr_2_obshee) : 0;

				var Per_Obr_2_NaMnO4 = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_NaMnO4"].Value;
				var Per_Obr_2_Na2MnO4 = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_Na2MnO4"].Value;
				var Per_Obr_2_402b = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_402b"].Value;
				var Per_Obr_2_NaOH = dataGridView1.Rows[rowIndex].Cells["Per_Obr_2_NaOH"].Value;
				var Per_Obr_3_Н2SO4 = dataGridView1.Rows[rowIndex].Cells["Per_Obr_3_Н2SO4"].Value;
				var Per_Obr_3_DES430 = dataGridView1.Rows[rowIndex].Cells["Per_Obr_3_DES430"].Value;
				var Per_Obr_4_Н2SO4 = dataGridView1.Rows[rowIndex].Cells["Per_Obr_4_Н2SO4"].Value;
				var Per_Obr_4_DES430 = dataGridView1.Rows[rowIndex].Cells["Per_Obr_4_DES430"].Value;

				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Per_Obr
            SET [Per_Obr_1_401A] = @Per_Obr_1_401A,
                [Per_Obr_1_401b] = @Per_Obr_1_401b,
                [Per_Obr_2_obshee] = @Per_Obr_2_obshee,
                [Per_Obr_2_avtiv_okis] = @Per_Obr_2_avtiv_okis,
                [Per_Obr_2_pokaz_avtiv] = @Per_Obr_2_pokaz_avtiv,
                [Per_Obr_2_NaMnO4] = @Per_Obr_2_NaMnO4,
                [Per_Obr_2_Na2MnO4] = @Per_Obr_2_Na2MnO4,
                [Per_Obr_2_402b] = @Per_Obr_2_402b,
                [Per_Obr_2_NaOH] = @Per_Obr_2_NaOH,
                [Per_Obr_3_Н2SO4] = @Per_Obr_3_Н2SO4,
                [Per_Obr_3_DES430] = @Per_Obr_3_DES430,
                [Per_Obr_4_Н2SO4] = @Per_Obr_4_Н2SO4,
                [Per_Obr_4_DES430] = @Per_Obr_4_DES430,
                [Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab
            WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", fioLab);
					command.Parameters.AddWithValue("@Per_Obr_1_401A", Per_Obr_1_401A);
					command.Parameters.AddWithValue("@Per_Obr_1_401b", Per_Obr_1_401b);
					command.Parameters.AddWithValue("@Per_Obr_2_obshee", Per_Obr_2_obshee);
					command.Parameters.AddWithValue("@Per_Obr_2_avtiv_okis", Per_Obr_2_avtiv_okis);
					command.Parameters.AddWithValue("@Per_Obr_2_pokaz_avtiv", Per_Obr_2_pokaz_avtiv);
					command.Parameters.AddWithValue("@Per_Obr_2_NaMnO4", Per_Obr_2_NaMnO4);
					command.Parameters.AddWithValue("@Per_Obr_2_Na2MnO4", Per_Obr_2_Na2MnO4);

					command.Parameters.AddWithValue("@Per_Obr_2_402b", Per_Obr_2_402b);
					command.Parameters.AddWithValue("@Per_Obr_2_NaOH", Per_Obr_2_NaOH);
					command.Parameters.AddWithValue("@Per_Obr_3_Н2SO4", Per_Obr_3_Н2SO4);
					command.Parameters.AddWithValue("@Per_Obr_3_DES430", Per_Obr_3_DES430);
					command.Parameters.AddWithValue("@Per_Obr_4_Н2SO4", Per_Obr_4_Н2SO4);
					command.Parameters.AddWithValue("@Per_Obr_4_DES430", Per_Obr_4_DES430);
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}

				MessageBox.Show("Данные успешно обновлены!");
			}
		}




		private void NotClickOnTable()
		{
			foreach (DataGridViewColumn column in dataGridView1.Columns)
			{
				if (column.Name != "Per_Obr_1_401A" && column.Name != "Per_Obr_1_401b" && column.Name != "Per_Obr_2_obshee" && column.Name != "Per_Obr_2_avtiv_okis" && column.Name != "Per_Obr_2_NaMnO4" && column.Name != "Per_Obr_2_Na2MnO4" && column.Name != "Per_Obr_2_402b" && column.Name != "Per_Obr_2_NaOH" && column.Name != "Per_Obr_3_Н2SO4" && column.Name != "Per_Obr_3_DES430" && column.Name != "Per_Obr_4_Н2SO4" && column.Name != "Per_Obr_4_DES430") // предполагается, что "ID" - это столбец, который можно редактировать
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

			if (isCellEndEditEnabled)
			{
				// Удаляем обработчик события
				dataGridView1.CellEndEdit -= dataGridView1_CellEndEdit;
				isCellEndEditEnabled = false;
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{
			UpdateRow();

			if (!isCellEndEditEnabled)
			{
				// Добавляем обработчик события
				dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
				isCellEndEditEnabled = true;
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.Columns[e.ColumnIndex].Name == "ID") return;

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				// Получаем значение первичного ключа
				var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

				// Получаем значения обновляемых столбцов
				var FIO_Lab_Update = WC.fio; // Название столбца FIO_Lab 
				var Date_Lab_Update = DateTime.Now;

				var Per_Obr_1_401A = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_1_401A"].Value;
				var Per_Obr_1_401b = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_1_401b"].Value;

				var Per_Obr_2_obshee = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_obshee"].Value;
				var Per_Obr_2_avtiv_okis = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_avtiv_okis"].Value;

				// Проверка на DBNull перед приведением типов
				decimal perObr2Obshee = Per_Obr_2_obshee != DBNull.Value ? Convert.ToDecimal(Per_Obr_2_obshee) : 0;
				decimal perObr2AvtivOkis = Per_Obr_2_avtiv_okis != DBNull.Value ? Convert.ToDecimal(Per_Obr_2_avtiv_okis) : 0;

				decimal Per_Obr_2_pokaz_avtiv = (perObr2Obshee != 0) ? (perObr2AvtivOkis / perObr2Obshee) : 0;

				var Per_Obr_2_NaMnO4 = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_NaMnO4"].Value;
				var Per_Obr_2_Na2MnO4 = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_Na2MnO4"].Value;
				var Per_Obr_2_402b = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_402b"].Value;
				var Per_Obr_2_NaOH = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_2_NaOH"].Value;
				var Per_Obr_3_Н2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_3_Н2SO4"].Value;
				var Per_Obr_3_DES430 = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_3_DES430"].Value;
				var Per_Obr_4_Н2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_4_Н2SO4"].Value;
				var Per_Obr_4_DES430 = dataGridView1.Rows[e.RowIndex].Cells["Per_Obr_4_DES430"].Value;

				// Создаем команду обновления с несколькими столбцами 
				string updateQuery = @"
            UPDATE Per_Obr SET 
                [Per_Obr_1_401A] = @Per_Obr_1_401A,
                [Per_Obr_1_401b] = @Per_Obr_1_401b,
                [Per_Obr_2_obshee] = @Per_Obr_2_obshee,
                [Per_Obr_2_avtiv_okis] = @Per_Obr_2_avtiv_okis,
                [Per_Obr_2_pokaz_avtiv] = @Per_Obr_2_pokaz_avtiv,
                [Per_Obr_2_NaMnO4] = @Per_Obr_2_NaMnO4,
                [Per_Obr_2_Na2MnO4] = @Per_Obr_2_Na2MnO4,
                [Per_Obr_2_402b] = @Per_Obr_2_402b,
                [Per_Obr_2_NaOH] = @Per_Obr_2_NaOH,
                [Per_Obr_3_Н2SO4] = @Per_Obr_3_Н2SO4,
                [Per_Obr_3_DES430] = @Per_Obr_3_DES430,
                [Per_Obr_4_Н2SO4] = @Per_Obr_4_Н2SO4,
                [Per_Obr_4_DES430] = @Per_Obr_4_DES430,
                [FIO_Lab_Update] = @FIO_Lab_Update,
                [Date_Lab_Update] = @Date_Lab_Update
            WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца 
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					command.Parameters.AddWithValue("@Per_Obr_1_401A", Per_Obr_1_401A);
					command.Parameters.AddWithValue("@Per_Obr_1_401b", Per_Obr_1_401b);
					command.Parameters.AddWithValue("@Per_Obr_2_obshee", Per_Obr_2_obshee);
					command.Parameters.AddWithValue("@Per_Obr_2_avtiv_okis", Per_Obr_2_avtiv_okis);

					command.Parameters.AddWithValue("@Per_Obr_2_pokaz_avtiv", Per_Obr_2_pokaz_avtiv);
					command.Parameters.AddWithValue("@Per_Obr_2_NaMnO4", Per_Obr_2_NaMnO4);
					command.Parameters.AddWithValue("@Per_Obr_2_Na2MnO4", Per_Obr_2_Na2MnO4);
					command.Parameters.AddWithValue("@Per_Obr_2_402b", Per_Obr_2_402b);
					command.Parameters.AddWithValue("@Per_Obr_2_NaOH", Per_Obr_2_NaOH);
					command.Parameters.AddWithValue("@Per_Obr_3_Н2SO4", Per_Obr_3_Н2SO4);
					command.Parameters.AddWithValue("@Per_Obr_3_DES430", Per_Obr_3_DES430);
					command.Parameters.AddWithValue("@Per_Obr_4_Н2SO4", Per_Obr_4_Н2SO4);
					command.Parameters.AddWithValue("@Per_Obr_4_DES430", Per_Obr_4_DES430);
					command.Parameters.AddWithValue("@ID", id); // ID - это первичный ключ

					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Проверяем, в какой ячейке в данный момент происходит ввод
			var currentCell = dataGridView1.CurrentCell;

			// Убедимся, что активна нужная ячейка
			if (currentCell.ColumnIndex == dataGridView1.Columns["Per_Obr_2_obshee"].Index ||
				currentCell.ColumnIndex == dataGridView1.Columns["Per_Obr_2_avtiv_okis"].Index)
			{

				// Позволяем вводить только цифры, точку и управление
				if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
				{
					e.Handled = true; // Отменяем ввод
				}

				// Можно добавить проверку для исключения повторного ввода точки
				if (e.KeyChar == '.')
				{
					if (currentCell.Value != null && currentCell.Value.ToString().Contains("."))
					{
						e.Handled = true; // Отменяем ввод, если есть уже точка
					}
				}
			}
		}

		private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.ColumnIndex == dataGridView1.Columns["Per_Obr_2_obshee"].Index ||
				e.ColumnIndex == dataGridView1.Columns["Per_Obr_2_avtiv_okis"].Index)
			{

				// Получаем введенное значение
				string userInput = e.FormattedValue.ToString();

				// Проверяем, является ли введенное значение числом
				if (!string.IsNullOrWhiteSpace(userInput))
				{
					if (!decimal.TryParse(userInput, out decimal n))
					{
						// Если не удалось преобразовать, отменяем введение и выдаем сообщение
						MessageBox.Show("Введите корректное числовое значение.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
						e.Cancel = true; // Отменяем изменение в ячейке
					}
				}
			}
		}

		






	}
}
