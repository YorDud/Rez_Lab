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

namespace Rez_Lab.Galvan_Zat
{
	public partial class Galvan_Zat_Laborant : Form
	{
		public Galvan_Zat_Laborant()
		{
			InitializeComponent();
			label11.Text = "Декапир Сu:\r\nH2SO4 - 150-160 г/л\r\nОБЪЕМ ВАННЫ: 480 л";
			label2.Text = "Cu электролит (ваннa 1-2): H2SO4 - 180-200 г/л\r\nNaCl - 40-60 мг/л\r\nПМ 614А старт - 5-10 мл/л\r\nПМ 624А - 2-3 мл/л\r\nСuSO4 - 80-100 г/л\r\nОБЪЕМ ВАННЫ: 2000 л";
			label3.Text = "Cu электролит (ваннa 3-4): H2SO4 - 180-200 г/л\r\nNaCl - 40-60 мг/л\r\nПМ 614А старт - 5-10 мл/л\r\nПМ 624А - 2-3 мл/л\r\nСuSO4 - 80-100 г/л\r\nОБЪЕМ ВАННЫ: 2000 л";
		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Galvan_Zat ORDER BY Date_Create DESC", connection);
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
				dataGridView1.Columns["Gal_Zat_1_H2SO4"].HeaderText = "H2SO4";
				dataGridView1.Columns["Gal_Zat_1_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Gal_Zat_2_H2SO4"].HeaderText = "H2SO4";
				dataGridView1.Columns["Gal_Zat_2_NaCl"].HeaderText = "NaCl";
				dataGridView1.Columns["Gal_Zat_2_PM614Ast"].HeaderText = "PM614Ast";
				dataGridView1.Columns["Gal_Zat_2_PM614A"].HeaderText = "PM614A";
				dataGridView1.Columns["Gal_Zat_2_CuSO4"].HeaderText = "CuSO4";
				dataGridView1.Columns["Gal_Zat_2_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Gal_Zat_3_H2SO4"].HeaderText = "H2SO4";
				dataGridView1.Columns["Gal_Zat_3_NaCl"].HeaderText = "NaCl";
				dataGridView1.Columns["Gal_Zat_3_PM614Ast"].HeaderText = "PM614Ast";
				dataGridView1.Columns["Gal_Zat_3_PM614A"].HeaderText = "PM614A";
				dataGridView1.Columns["Gal_Zat_3_CuSO4"].HeaderText = "CuSO4";
				dataGridView1.Columns["Gal_Zat_3_Correction"].HeaderText = "Корректировка";
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

				dataGridView1.Columns["Gal_Zat_1_H2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_2_H2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_2_NaCl"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_2_PM614Ast"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_2_PM614A"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_2_CuSO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_3_H2SO4"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_3_NaCl"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_3_PM614Ast"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_3_PM614A"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Gal_Zat_3_CuSO4"].DefaultCellStyle.BackColor = Color.LightBlue;
			}

		}


		private void Galvan_Zat_Laborant_Load(object sender, EventArgs e)
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

				string query = "SELECT * FROM Galvan_Zat WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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
				string query = "SELECT * FROM Galvan_Zat WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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

				string sqlInsert = "INSERT INTO Galvan_Zat ([Date_Create],[FIO_Lab]) " +
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
				var Gal_Zat_1_H2SO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_1_H2SO4"].Value;

				var Gal_Zat_2_H2SO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_2_H2SO4"].Value;
				var Gal_Zat_2_NaCl = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_2_NaCl"].Value;
				var Gal_Zat_2_PM614Ast = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_2_PM614Ast"].Value;
				var Gal_Zat_2_PM614A = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_2_PM614A"].Value;
				var Gal_Zat_2_CuSO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_2_CuSO4"].Value;

				var Gal_Zat_3_H2SO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_3_H2SO4"].Value;
				var Gal_Zat_3_NaCl = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_3_NaCl"].Value;
				var Gal_Zat_3_PM614Ast = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_3_PM614Ast"].Value;
				var Gal_Zat_3_PM614A = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_3_PM614A"].Value;
				var Gal_Zat_3_CuSO4 = dataGridView1.Rows[rowIndex].Cells["Gal_Zat_3_CuSO4"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Galvan_Zat
   SET [Gal_Zat_1_H2SO4] = @Gal_Zat_1_H2SO4,
[Gal_Zat_2_H2SO4] = @Gal_Zat_2_H2SO4,
[Gal_Zat_2_NaCl] = @Gal_Zat_2_NaCl,
[Gal_Zat_2_PM614Ast] = @Gal_Zat_2_PM614Ast,
[Gal_Zat_2_PM614A] = @Gal_Zat_2_PM614A,
[Gal_Zat_2_CuSO4] = @Gal_Zat_2_CuSO4,
[Gal_Zat_3_H2SO4] = @Gal_Zat_3_H2SO4,
[Gal_Zat_3_NaCl] = @Gal_Zat_3_NaCl,
[Gal_Zat_3_PM614Ast] = @Gal_Zat_3_PM614Ast,
[Gal_Zat_3_PM614A] = @Gal_Zat_3_PM614A,
[Gal_Zat_3_CuSO4] = @Gal_Zat_3_CuSO4
      ,[Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", fioLab);
					//
					command.Parameters.AddWithValue("@Gal_Zat_1_H2SO4", Gal_Zat_1_H2SO4);
					command.Parameters.AddWithValue("@Gal_Zat_2_H2SO4", Gal_Zat_2_H2SO4);
					command.Parameters.AddWithValue("@Gal_Zat_2_NaCl", Gal_Zat_2_NaCl);
					command.Parameters.AddWithValue("@Gal_Zat_2_PM614Ast", Gal_Zat_2_PM614Ast);
					command.Parameters.AddWithValue("@Gal_Zat_2_PM614A", Gal_Zat_2_PM614A);
					command.Parameters.AddWithValue("@Gal_Zat_2_CuSO4", Gal_Zat_2_CuSO4);
					command.Parameters.AddWithValue("@Gal_Zat_3_H2SO4", Gal_Zat_3_H2SO4);
					command.Parameters.AddWithValue("@Gal_Zat_3_NaCl", Gal_Zat_3_NaCl);
					command.Parameters.AddWithValue("@Gal_Zat_3_PM614Ast", Gal_Zat_3_PM614Ast);
					command.Parameters.AddWithValue("@Gal_Zat_3_PM614A", Gal_Zat_3_PM614A);
					command.Parameters.AddWithValue("@Gal_Zat_3_CuSO4", Gal_Zat_3_CuSO4);
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
				if (column.Name != "Gal_Zat_1_H2SO4" &&
					column.Name != "Gal_Zat_2_H2SO4" &&
					column.Name != "Gal_Zat_2_NaCl" &&
					column.Name != "Gal_Zat_2_PM614Ast" &&
					column.Name != "Gal_Zat_2_PM614A" &&
					column.Name != "Gal_Zat_2_CuSO4" &&
					column.Name != "Gal_Zat_3_H2SO4" &&
					column.Name != "Gal_Zat_3_NaCl" &&
					column.Name != "Gal_Zat_3_PM614Ast" &&
					column.Name != "Gal_Zat_3_PM614A" &&
					column.Name != "Gal_Zat_3_CuSO4")
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
				var Gal_Zat_1_H2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_1_H2SO4"].Value;

				var Gal_Zat_2_H2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_H2SO4"].Value;
				var Gal_Zat_2_NaCl = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_NaCl"].Value;
				var Gal_Zat_2_PM614Ast = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_PM614Ast"].Value;
				var Gal_Zat_2_PM614A = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_PM614A"].Value;
				var Gal_Zat_2_CuSO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_2_CuSO4"].Value;

				var Gal_Zat_3_H2SO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_3_H2SO4"].Value;
				var Gal_Zat_3_NaCl = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_3_NaCl"].Value;
				var Gal_Zat_3_PM614Ast = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_3_PM614Ast"].Value;
				var Gal_Zat_3_PM614A = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_3_PM614A"].Value;
				var Gal_Zat_3_CuSO4 = dataGridView1.Rows[e.RowIndex].Cells["Gal_Zat_3_CuSO4"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Galvan_Zat
   SET [Gal_Zat_1_H2SO4] = @Gal_Zat_1_H2SO4,
[Gal_Zat_2_H2SO4] = @Gal_Zat_2_H2SO4,
[Gal_Zat_2_NaCl] = @Gal_Zat_2_NaCl,
[Gal_Zat_2_PM614Ast] = @Gal_Zat_2_PM614Ast,
[Gal_Zat_2_PM614A] = @Gal_Zat_2_PM614A,
[Gal_Zat_2_CuSO4] = @Gal_Zat_2_CuSO4,
[Gal_Zat_3_H2SO4] = @Gal_Zat_3_H2SO4,
[Gal_Zat_3_NaCl] = @Gal_Zat_3_NaCl,
[Gal_Zat_3_PM614Ast] = @Gal_Zat_3_PM614Ast,
[Gal_Zat_3_PM614A] = @Gal_Zat_3_PM614A,
[Gal_Zat_3_CuSO4] = @Gal_Zat_3_CuSO4
      ,[FIO_Lab_Update] = @FIO_Lab_Update
      ,[Date_Lab_Update] = @Date_Lab_Update
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					//
					command.Parameters.AddWithValue("@Gal_Zat_1_H2SO4", Gal_Zat_1_H2SO4);
					command.Parameters.AddWithValue("@Gal_Zat_2_H2SO4", Gal_Zat_2_H2SO4);
					command.Parameters.AddWithValue("@Gal_Zat_2_NaCl", Gal_Zat_2_NaCl);
					command.Parameters.AddWithValue("@Gal_Zat_2_PM614Ast", Gal_Zat_2_PM614Ast);
					command.Parameters.AddWithValue("@Gal_Zat_2_PM614A", Gal_Zat_2_PM614A);
					command.Parameters.AddWithValue("@Gal_Zat_2_CuSO4", Gal_Zat_2_CuSO4);
					command.Parameters.AddWithValue("@Gal_Zat_3_H2SO4", Gal_Zat_3_H2SO4);
					command.Parameters.AddWithValue("@Gal_Zat_3_NaCl", Gal_Zat_3_NaCl);
					command.Parameters.AddWithValue("@Gal_Zat_3_PM614Ast", Gal_Zat_3_PM614Ast);
					command.Parameters.AddWithValue("@Gal_Zat_3_PM614A", Gal_Zat_3_PM614A);
					command.Parameters.AddWithValue("@Gal_Zat_3_CuSO4", Gal_Zat_3_CuSO4);
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
