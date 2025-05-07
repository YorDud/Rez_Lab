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

namespace Rez_Lab.Galvan_Line_MG
{
	public partial class Galvan_Line_MG_Laborant : Form
	{
		public Galvan_Line_MG_Laborant()
		{
			InitializeComponent();

			label11.Text = "Кислая очистка:\r\nAC-22C - 0,1-0,3 норм.\r\nCu 2+ < 2 г/л\r\nОБЪЕМ ВАННЫ: 630 л";
			label2.Text = "Микротравление:\r\n(NH4)2S2O8 - 90-120 г/л\r\nCu 2+ - 1-10 г/л\r\nподтрав - 0,1-0,2 мкм/мин\r\nОБЪЕМ ВАННЫ: 630 л";
			label3.Text = "Декапир Сu:   H2SO4 - 120-150 г/л\r\nДекапир Sn:   H2SO4 - 150-170 г/л\r\nОБЪЕМ ВАННЫ: 630 л";
			label4.Text = "Cu электролит (ванa 18-19):   H2SO4 - 180-200 г/л\r\nNaCl - 40-60 мг/л\r\nПМ624А - 2-3 мл/л\r\nПМ624Б - 7-11 мл/л\r\nСuSO4 - 80-100 г/л\r\nОБЪЕМ ВАННЫ: 2300 л";
			label5.Text = "Cu электролит (ванa 20-21):   H2SO4 - 180-200 г/л\r\nNaCl - 40-60 мг/л\r\nПМ624А - 2-3 мл/л\r\nПМ624Б - 7-11 мл/л\r\nСuSO4 - 80-100 г/л\r\nОБЪЕМ ВАННЫ: 2300 л";
			label6.Text = "Sn электролит:\r\nSnSO4 - 25-35 г/л;   \r\nH2SO4 - 165-200 г/л\r\nОБЪЕМ ВАННЫ: 1200 л";
		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Galvan_Line_MG ORDER BY Date_Create DESC", connection);
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
				dataGridView1.Columns["Gal_Line_1_AC_22C"].HeaderText = "AC_22C";
				dataGridView1.Columns["Gal_Line_1_Cu2"].HeaderText = "Cu2";
				dataGridView1.Columns["Gal_Line_1_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Gal_Line_2_NH4_2S2O8"].HeaderText = "NH4_2S2O8";
				dataGridView1.Columns["Gal_Line_2_Cu2"].HeaderText = "Cu2";
				dataGridView1.Columns["Gal_Line_2_podtrav"].HeaderText = "Подтрав";
				dataGridView1.Columns["Gal_Line_2_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Gal_Line_3_Cu_H2SO4"].HeaderText = "Cu_H2SO4";
				dataGridView1.Columns["Gal_Line_3_Cu_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Gal_Line_3_Sn_H2SO4"].HeaderText = "Sn_H2SO4";
				dataGridView1.Columns["Gal_Line_3_Sn_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Gal_Line_4_H2SO4"].HeaderText = "H2SO4";
				dataGridView1.Columns["Gal_Line_4_NaCl"].HeaderText = "NaCl";
				dataGridView1.Columns["Gal_Line_4_PM624A"].HeaderText = "PM624A";
				dataGridView1.Columns["Gal_Line_4_PM624b"].HeaderText = "PM624b";
				dataGridView1.Columns["Gal_Line_4_CuSO4"].HeaderText = "CuSO4";
				dataGridView1.Columns["Gal_Line_4_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Gal_Line_5_H2SO4"].HeaderText = "H2SO4";
				dataGridView1.Columns["Gal_Line_5_NaCl"].HeaderText = "NaCl";
				dataGridView1.Columns["Gal_Line_5_PM624A"].HeaderText = "PM624A";
				dataGridView1.Columns["Gal_Line_5_PM624b"].HeaderText = "PM624b";
				dataGridView1.Columns["Gal_Line_5_CuSO4"].HeaderText = "CuSO4";
				dataGridView1.Columns["Gal_Line_5_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Gal_Line_6_H2SO4"].HeaderText = "H2SO4";
				dataGridView1.Columns["Gal_Line_6_SnSO4"].HeaderText = "SnSO4";
				dataGridView1.Columns["Gal_Line_6_Correction"].HeaderText = "Корректировка";
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

				dataGridView1.Columns["Gal_Line_1_AC_22C"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_1_Cu2"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_2_NH4_2S2O8"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_2_Cu2"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_2_podtrav"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_3_Cu_H2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_3_Sn_H2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_4_H2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_4_NaCl"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_4_PM624A"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_4_PM624b"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_4_CuSO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_5_H2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_5_NaCl"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_5_PM624A"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_5_PM624b"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_5_CuSO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_6_H2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Line_6_SnSO4"].DefaultCellStyle.BackColor = Color.LightBlue;
			}

		}


		private void Galvan_Line_MG_Laborant_Load(object sender, EventArgs e)
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

				string query = "SELECT * FROM Galvan_Line_MG WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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
				string query = "SELECT * FROM Galvan_Line_MG WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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

				string sqlInsert = "INSERT INTO Galvan_Line_MG ([Date_Create],[FIO_Lab]) " +
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
				//
				var Gal_Line_1_AC_22C = dataGridView1.Rows[rowIndex].Cells["Gal_Line_1_AC_22C"].Value;
				var Gal_Line_1_Cu2 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_1_Cu2"].Value;
				var Gal_Line_2_NH4_2S2O8 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_2_NH4_2S2O8"].Value;
				var Gal_Line_2_Cu2 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_2_Cu2"].Value;
				var Gal_Line_2_podtrav = dataGridView1.Rows[rowIndex].Cells["Gal_Line_2_podtrav"].Value;
				var Gal_Line_3_Cu_H2SO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_3_Cu_H2SO4"].Value;
				var Gal_Line_3_Sn_H2SO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_3_Sn_H2SO4"].Value;
				var Gal_Line_4_H2SO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_4_H2SO4"].Value;
				var Gal_Line_4_NaCl = dataGridView1.Rows[rowIndex].Cells["Gal_Line_4_NaCl"].Value;
				var Gal_Line_4_PM624A = dataGridView1.Rows[rowIndex].Cells["Gal_Line_4_PM624A"].Value;
				var Gal_Line_4_PM624b = dataGridView1.Rows[rowIndex].Cells["Gal_Line_4_PM624b"].Value;
				var Gal_Line_4_CuSO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_4_CuSO4"].Value;
				var Gal_Line_5_H2SO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_5_H2SO4"].Value;
				var Gal_Line_5_NaCl = dataGridView1.Rows[rowIndex].Cells["Gal_Line_5_NaCl"].Value;
				var Gal_Line_5_PM624A = dataGridView1.Rows[rowIndex].Cells["Gal_Line_5_PM624A"].Value;
				var Gal_Line_5_PM624b = dataGridView1.Rows[rowIndex].Cells["Gal_Line_5_PM624b"].Value;
				var Gal_Line_5_CuSO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_5_CuSO4"].Value;
				var Gal_Line_6_H2SO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_6_H2SO4"].Value;
				var Gal_Line_6_SnSO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Line_6_SnSO4"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Galvan_Line_MG
   SET [Gal_Line_1_AC_22C] = @Gal_Line_1_AC_22C, 
[Gal_Line_1_Cu2] = @Gal_Line_1_Cu2, 
[Gal_Line_2_NH4_2S2O8] = @Gal_Line_2_NH4_2S2O8, 
[Gal_Line_2_Cu2] = @Gal_Line_2_Cu2, 
[Gal_Line_2_podtrav] = @Gal_Line_2_podtrav,
[Gal_Line_3_Cu_H2SO4] = @Gal_Line_3_Cu_H2SO4, 
[Gal_Line_3_Sn_H2SO4] = @Gal_Line_3_Sn_H2SO4, 
[Gal_Line_4_H2SO4] = @Gal_Line_4_H2SO4,
[Gal_Line_4_NaCl] = @Gal_Line_4_NaCl, 
[Gal_Line_4_PM624A] = @Gal_Line_4_PM624A, 
[Gal_Line_4_PM624b] = @Gal_Line_4_PM624b,
[Gal_Line_4_CuSO4] = @Gal_Line_4_CuSO4,  
[Gal_Line_5_H2SO4] = @Gal_Line_5_H2SO4,
[Gal_Line_5_NaCl] = @Gal_Line_5_NaCl, 
[Gal_Line_5_PM624A] = @Gal_Line_5_PM624A, 
[Gal_Line_5_PM624b] = @Gal_Line_5_PM624b,
[Gal_Line_5_CuSO4] = @Gal_Line_5_CuSO4,  
[Gal_Line_6_H2SO4] = @Gal_Line_6_H2SO4,
[Gal_Line_6_SnSO4] = @Gal_Line_6_SnSO4
      ,[Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", fioLab);
					//
					command.Parameters.AddWithValue("@Gal_Line_1_AC_22C", Gal_Line_1_AC_22C);
					command.Parameters.AddWithValue("@Gal_Line_1_Cu2", Gal_Line_1_Cu2);
					command.Parameters.AddWithValue("@Gal_Line_2_NH4_2S2O8", Gal_Line_2_NH4_2S2O8);
					command.Parameters.AddWithValue("@Gal_Line_2_Cu2", Gal_Line_2_Cu2);
					command.Parameters.AddWithValue("@Gal_Line_2_podtrav", Gal_Line_2_podtrav);
					command.Parameters.AddWithValue("@Gal_Line_3_Cu_H2SO4", Gal_Line_3_Cu_H2SO4);
					command.Parameters.AddWithValue("@Gal_Line_3_Sn_H2SO4", Gal_Line_3_Sn_H2SO4);
					command.Parameters.AddWithValue("@Gal_Line_4_H2SO4", Gal_Line_4_H2SO4);
					command.Parameters.AddWithValue("@Gal_Line_4_NaCl", Gal_Line_4_NaCl);
					command.Parameters.AddWithValue("@Gal_Line_4_PM624A", Gal_Line_4_PM624A);
					command.Parameters.AddWithValue("@Gal_Line_4_PM624b", Gal_Line_4_PM624b);
					command.Parameters.AddWithValue("@Gal_Line_4_CuSO4", Gal_Line_4_CuSO4);
					command.Parameters.AddWithValue("@Gal_Line_5_H2SO4", Gal_Line_5_H2SO4);
					command.Parameters.AddWithValue("@Gal_Line_5_NaCl", Gal_Line_5_NaCl);
					command.Parameters.AddWithValue("@Gal_Line_5_PM624A", Gal_Line_5_PM624A);
					command.Parameters.AddWithValue("@Gal_Line_5_PM624b", Gal_Line_5_PM624b);
					command.Parameters.AddWithValue("@Gal_Line_5_CuSO4", Gal_Line_5_CuSO4);
					command.Parameters.AddWithValue("@Gal_Line_6_H2SO4", Gal_Line_6_H2SO4);
					command.Parameters.AddWithValue("@Gal_Line_6_SnSO4", Gal_Line_6_SnSO4);
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
				if (column.Name != "Gal_Line_1_AC_22C" && column.Name != "Gal_Line_1_Cu2" &&
					column.Name != "Gal_Line_2_NH4_2S2O8" && column.Name != "Gal_Line_2_Cu2" &&
					column.Name != "Gal_Line_2_podtrav" && column.Name != "Gal_Line_3_Cu_H2SO4" &&
					column.Name != "Gal_Line_3_Sn_H2SO4" && column.Name != "Gal_Line_4_H2SO4" &&
					column.Name != "Gal_Line_4_NaCl" && column.Name != "Gal_Line_4_PM624A" &&
					column.Name != "Gal_Line_4_PM624b" && column.Name != "Gal_Line_4_CuSO4" &&
					column.Name != "Gal_Line_5_H2SO4" && column.Name != "Gal_Line_5_NaCl" &&
					column.Name != "Gal_Line_5_PM624A" && column.Name != "Gal_Line_5_PM624b" &&
					column.Name != "Gal_Line_5_CuSO4" && column.Name != "Gal_Line_6_H2SO4" &&
					column.Name != "Gal_Line_6_SnSO4")
				{
					// предполагается, что только указанные выше столбцы можно редактировать   
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
			if (dataGridView1.Columns[e.ColumnIndex].Name == "ID")
				return;

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				// Получаем значение первичного ключа
				var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

				// Получаем значения обновляемых столбцов

				var FIO_Lab_Update = WC.fio; // Название столбца FIO_Lab
				var Date_Lab_Update = DateTime.Now;
				//
				var Gal_Line_1_AC_22C = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_1_AC_22C"].Value;
				var Gal_Line_1_Cu2 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_1_Cu2"].Value;
				var Gal_Line_2_NH4_2S2O8 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_2_NH4_2S2O8"].Value;
				var Gal_Line_2_Cu2 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_2_Cu2"].Value;
				var Gal_Line_2_podtrav = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_2_podtrav"].Value;
				var Gal_Line_3_Cu_H2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_3_Cu_H2SO4"].Value;
				var Gal_Line_3_Sn_H2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_3_Sn_H2SO4"].Value;
				var Gal_Line_4_H2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_4_H2SO4"].Value;
				var Gal_Line_4_NaCl = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_4_NaCl"].Value;
				var Gal_Line_4_PM624A = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_4_PM624A"].Value;
				var Gal_Line_4_PM624b = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_4_PM624b"].Value;
				var Gal_Line_4_CuSO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_4_CuSO4"].Value;
				var Gal_Line_5_H2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_5_H2SO4"].Value;
				var Gal_Line_5_NaCl = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_5_NaCl"].Value;
				var Gal_Line_5_PM624A = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_5_PM624A"].Value;
				var Gal_Line_5_PM624b = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_5_PM624b"].Value;
				var Gal_Line_5_CuSO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_5_CuSO4"].Value;
				var Gal_Line_6_H2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_6_H2SO4"].Value;
				var Gal_Line_6_SnSO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Line_6_SnSO4"].Value;




				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Galvan_Line_MG
   SET [Gal_Line_1_AC_22C] = @Gal_Line_1_AC_22C, 
[Gal_Line_1_Cu2] = @Gal_Line_1_Cu2, 
[Gal_Line_2_NH4_2S2O8] = @Gal_Line_2_NH4_2S2O8, 
[Gal_Line_2_Cu2] = @Gal_Line_2_Cu2, 
[Gal_Line_2_podtrav] = @Gal_Line_2_podtrav,
[Gal_Line_3_Cu_H2SO4] = @Gal_Line_3_Cu_H2SO4, 
[Gal_Line_3_Sn_H2SO4] = @Gal_Line_3_Sn_H2SO4, 
[Gal_Line_4_H2SO4] = @Gal_Line_4_H2SO4,
[Gal_Line_4_NaCl] = @Gal_Line_4_NaCl, 
[Gal_Line_4_PM624A] = @Gal_Line_4_PM624A, 
[Gal_Line_4_PM624b] = @Gal_Line_4_PM624b,
[Gal_Line_4_CuSO4] = @Gal_Line_4_CuSO4,  
[Gal_Line_5_H2SO4] = @Gal_Line_5_H2SO4,
[Gal_Line_5_NaCl] = @Gal_Line_5_NaCl, 
[Gal_Line_5_PM624A] = @Gal_Line_5_PM624A, 
[Gal_Line_5_PM624b] = @Gal_Line_5_PM624b,
[Gal_Line_5_CuSO4] = @Gal_Line_5_CuSO4,  
[Gal_Line_6_H2SO4] = @Gal_Line_6_H2SO4,
[Gal_Line_6_SnSO4] = @Gal_Line_6_SnSO4
      ,[FIO_Lab_Update] = @FIO_Lab_Update
      ,[Date_Lab_Update] = @Date_Lab_Update
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					//
					command.Parameters.AddWithValue("@Gal_Line_1_AC_22C", Gal_Line_1_AC_22C);
					command.Parameters.AddWithValue("@Gal_Line_1_Cu2", Gal_Line_1_Cu2);
					command.Parameters.AddWithValue("@Gal_Line_2_NH4_2S2O8", Gal_Line_2_NH4_2S2O8);
					command.Parameters.AddWithValue("@Gal_Line_2_Cu2", Gal_Line_2_Cu2);
					command.Parameters.AddWithValue("@Gal_Line_2_podtrav", Gal_Line_2_podtrav);
					command.Parameters.AddWithValue("@Gal_Line_3_Cu_H2SO4", Gal_Line_3_Cu_H2SO4);
					command.Parameters.AddWithValue("@Gal_Line_3_Sn_H2SO4", Gal_Line_3_Sn_H2SO4);
					command.Parameters.AddWithValue("@Gal_Line_4_H2SO4", Gal_Line_4_H2SO4);
					command.Parameters.AddWithValue("@Gal_Line_4_NaCl", Gal_Line_4_NaCl);
					command.Parameters.AddWithValue("@Gal_Line_4_PM624A", Gal_Line_4_PM624A);
					command.Parameters.AddWithValue("@Gal_Line_4_PM624b", Gal_Line_4_PM624b);
					command.Parameters.AddWithValue("@Gal_Line_4_CuSO4", Gal_Line_4_CuSO4);
					command.Parameters.AddWithValue("@Gal_Line_5_H2SO4", Gal_Line_5_H2SO4);
					command.Parameters.AddWithValue("@Gal_Line_5_NaCl", Gal_Line_5_NaCl);
					command.Parameters.AddWithValue("@Gal_Line_5_PM624A", Gal_Line_5_PM624A);
					command.Parameters.AddWithValue("@Gal_Line_5_PM624b", Gal_Line_5_PM624b);
					command.Parameters.AddWithValue("@Gal_Line_5_CuSO4", Gal_Line_5_CuSO4);
					command.Parameters.AddWithValue("@Gal_Line_6_H2SO4", Gal_Line_6_H2SO4);
					command.Parameters.AddWithValue("@Gal_Line_6_SnSO4", Gal_Line_6_SnSO4);
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
