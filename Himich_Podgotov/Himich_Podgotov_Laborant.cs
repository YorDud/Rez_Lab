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

namespace Rez_Lab.Himich_Podgotov
{
	public partial class Himich_Podgotov_Laborant : Form
	{
		public Himich_Podgotov_Laborant()
		{
			InitializeComponent();
			label11.Text = "Кислая очистка АС-23:\r\nкислотность - 0,3-0,8\r\nСи2+ - \r\nОБЪЕМ ВАННЫ: 120 - 175 л";
			label2.Text = "Микротравление:\r\nСи2+ - 15-35 г/л\r\nподтрав - 07-1,6 мкм\r\nкислотность > 1,3 моль/л\r\npH - 2-5\r\nОБЪЕМ ВАННЫ: 290 - 385 л";
			label3.Text = "Декапир:\r\nHCl - 1-1,5 моль/л\r\nСи2+ < 2 г/л\r\nОБЪЕМ ВАННЫ: 95 - 165 л";
		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Himich_Podgotov ORDER BY Date_Create DESC", connection);
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
				dataGridView1.Columns["Him_Podg_1_kislot"].HeaderText = "Кислотность";
				dataGridView1.Columns["Him_Podg_1_Ci2"].HeaderText = "Cи 2+";
				dataGridView1.Columns["Him_Podg_1_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Him_Podg_2_Ci2"].HeaderText = "Cи 2+";
				dataGridView1.Columns["Him_Podg_2_podtrav"].HeaderText = "Подтрав";
				dataGridView1.Columns["Him_Podg_2_kislot"].HeaderText = "Кислотность";
				dataGridView1.Columns["Him_Podg_2_pH"].HeaderText = "pH";
				dataGridView1.Columns["Him_Podg_2_Correction"].HeaderText = "Корректировка";
				dataGridView1.Columns["Him_Podg_3_plotnost1"].HeaderText = "Плотность 1";
				dataGridView1.Columns["Him_Podg_3_plotnost2"].HeaderText = "Плотность 2";
				dataGridView1.Columns["Him_Podg_3_Correction"].HeaderText = "Корректировка";
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

				dataGridView1.Columns["Him_Podg_1_kislot"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Him_Podg_1_Ci2"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Him_Podg_2_Ci2"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Him_Podg_2_podtrav"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Him_Podg_2_kislot"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Him_Podg_2_pH"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Him_Podg_3_plotnost1"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Him_Podg_3_plotnost2"].DefaultCellStyle.BackColor = Color.LightBlue;
			}

		}


		private void Himich_Podgotov_Laborant_Load(object sender, EventArgs e)
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

				string query = "SELECT * FROM Himich_Podgotov WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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
				string query = "SELECT * FROM Himich_Podgotov WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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

				string sqlInsert = "INSERT INTO Himich_Podgotov ([Date_Create],[FIO_Lab]) " +
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


				var Him_Podg_1_kislot = dataGridView1.Rows[rowIndex].Cells["Him_Podg_1_kislot"].Value;
				var Him_Podg_1_Ci2 = dataGridView1.Rows[rowIndex].Cells["Him_Podg_1_Ci2"].Value;
				var Him_Podg_2_Ci2 = dataGridView1.Rows[rowIndex].Cells["Him_Podg_2_Ci2"].Value;
				var Him_Podg_2_podtrav = dataGridView1.Rows[rowIndex].Cells["Him_Podg_2_podtrav"].Value;
				var Him_Podg_2_kislot = dataGridView1.Rows[rowIndex].Cells["Him_Podg_2_kislot"].Value;
				var Him_Podg_2_pH = dataGridView1.Rows[rowIndex].Cells["Him_Podg_2_pH"].Value;
				var Him_Podg_3_plotnost1 = dataGridView1.Rows[rowIndex].Cells["Him_Podg_3_plotnost1"].Value;
				var Him_Podg_3_plotnost2 = dataGridView1.Rows[rowIndex].Cells["Him_Podg_3_plotnost2"].Value;




				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Himich_Podgotov
   SET [Him_Podg_1_kislot] = @Him_Podg_1_kislot,
    [Him_Podg_1_Ci2] = @Him_Podg_1_Ci2,
    [Him_Podg_2_Ci2] = @Him_Podg_2_Ci2,
    [Him_Podg_2_podtrav] = @Him_Podg_2_podtrav,
    [Him_Podg_2_kislot] = @Him_Podg_2_kislot,
    [Him_Podg_2_pH] = @Him_Podg_2_pH,
    [Him_Podg_3_plotnost1] = @Him_Podg_3_plotnost1,
    [Him_Podg_3_plotnost2] = @Him_Podg_3_plotnost2
      ,[Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", fioLab);
					//
					command.Parameters.AddWithValue("@Him_Podg_1_kislot", Him_Podg_1_kislot);
					command.Parameters.AddWithValue("@Him_Podg_1_Ci2", Him_Podg_1_Ci2);
					command.Parameters.AddWithValue("@Him_Podg_2_Ci2", Him_Podg_2_Ci2);
					command.Parameters.AddWithValue("@Him_Podg_2_podtrav", Him_Podg_2_podtrav);
					command.Parameters.AddWithValue("@Him_Podg_2_kislot", Him_Podg_2_kislot);
					command.Parameters.AddWithValue("@Him_Podg_2_pH", Him_Podg_2_pH);
					command.Parameters.AddWithValue("@Him_Podg_3_plotnost1", Him_Podg_3_plotnost1);
					command.Parameters.AddWithValue("@Him_Podg_3_plotnost2", Him_Podg_3_plotnost2);

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
				if (column.Name != "Him_Podg_1_kislot" && column.Name != "Him_Podg_1_Ci2" &&
					column.Name != "Him_Podg_2_Ci2" && column.Name != "Him_Podg_2_podtrav" &&
					column.Name != "Him_Podg_2_kislot" && column.Name != "Him_Podg_2_pH" &&
					column.Name != "Him_Podg_3_plotnost1" && column.Name != "Him_Podg_3_plotnost2")
				{
					// Предполагается, что только указанные выше столбцы можно редактировать
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

				var Him_Podg_1_kislot = dataGridView1.Rows[e.RowIndex].Cells["Him_Podg_1_kislot"].Value;
				var Him_Podg_1_Ci2 = dataGridView1.Rows[e.RowIndex].Cells["Him_Podg_1_Ci2"].Value;
				var Him_Podg_2_Ci2 = dataGridView1.Rows[e.RowIndex].Cells["Him_Podg_2_Ci2"].Value;
				var Him_Podg_2_podtrav = dataGridView1.Rows[e.RowIndex].Cells["Him_Podg_2_podtrav"].Value;
				var Him_Podg_2_kislot = dataGridView1.Rows[e.RowIndex].Cells["Him_Podg_2_kislot"].Value;
				var Him_Podg_2_pH = dataGridView1.Rows[e.RowIndex].Cells["Him_Podg_2_pH"].Value;
				var Him_Podg_3_plotnost1 = dataGridView1.Rows[e.RowIndex].Cells["Him_Podg_3_plotnost1"].Value;
				var Him_Podg_3_plotnost2 = dataGridView1.Rows[e.RowIndex].Cells["Him_Podg_3_plotnost2"].Value;




				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Himich_Podgotov
   SET [Him_Podg_1_kislot] = @Him_Podg_1_kislot,
    [Him_Podg_1_Ci2] = @Him_Podg_1_Ci2,
    [Him_Podg_2_Ci2] = @Him_Podg_2_Ci2,
    [Him_Podg_2_podtrav] = @Him_Podg_2_podtrav,
    [Him_Podg_2_kislot] = @Him_Podg_2_kislot,
    [Him_Podg_2_pH] = @Him_Podg_2_pH,
    [Him_Podg_3_plotnost1] = @Him_Podg_3_plotnost1,
    [Him_Podg_3_plotnost2] = @Him_Podg_3_plotnost2
      ,[FIO_Lab_Update] = @FIO_Lab_Update
      ,[Date_Lab_Update] = @Date_Lab_Update
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					//
					command.Parameters.AddWithValue("@Him_Podg_1_kislot", Him_Podg_1_kislot);
					command.Parameters.AddWithValue("@Him_Podg_1_Ci2", Him_Podg_1_Ci2);
					command.Parameters.AddWithValue("@Him_Podg_2_Ci2", Him_Podg_2_Ci2);
					command.Parameters.AddWithValue("@Him_Podg_2_podtrav", Him_Podg_2_podtrav);
					command.Parameters.AddWithValue("@Him_Podg_2_kislot", Him_Podg_2_kislot);
					command.Parameters.AddWithValue("@Him_Podg_2_pH", Him_Podg_2_pH);
					command.Parameters.AddWithValue("@Him_Podg_3_plotnost1", Him_Podg_3_plotnost1);
					command.Parameters.AddWithValue("@Him_Podg_3_plotnost2", Him_Podg_3_plotnost2);

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
