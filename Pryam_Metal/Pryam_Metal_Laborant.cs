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

namespace Rez_Lab.Pryam_Metal
{
	public partial class Pryam_Metal_Laborant : Form
	{
		public Pryam_Metal_Laborant()
		{
			InitializeComponent();

			label11.Text = "Кондиционер:\r\nПМ 302 - 90-110 мл/л\r\nCu 2+ < 1 г/л\r\nОБЪЕМ ВАННЫ: 234 л";
			label2.Text = "Предметализация ПМ 303:\r\nHCl -  2-4 г/л\r\npH - < 1\r\nCu 2+ < 1 г/л\r\nОБЪЕМ ВАННЫ: 185 л";
			label3.Text = "Метализация ПМ 304:\r\nPdCl2 - 0,4 - 0,5 г/л\r\nSnCl2 - 10 - 18 г/л\r\nHCl -\r\nCu 2+ < 1 г/л\r\nОБЪЕМ ВАННЫ: 224 л";
			label4.Text = "Ускоритель:\r\nПМ 305 А - 90 - 100 %\r\nПМ 305 Б - 90 - 100 %\r\nПМ 305 В -  190 - 220 г/л\r\nОБЪЕМ ВАННЫ: 205 л";
		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT * FROM Pryam_Metal ORDER BY Date_Create DESC", connection);
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
				dataGridView1.Columns["Pr_Met_1_PM302"].HeaderText = "PM302";
				dataGridView1.Columns["Pr_Met_1_Cu2"].HeaderText = "Cu^2+";
				dataGridView1.Columns["Pr_Met_1_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Pr_Met_2_HCl"].HeaderText = "HCl";
				dataGridView1.Columns["Pr_Met_2_pH"].HeaderText = "pH";
				dataGridView1.Columns["Pr_Met_2_Cu2"].HeaderText = "Cu^2+";
				dataGridView1.Columns["Pr_Met_2_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Pr_Met_3_PdCl2"].HeaderText = "PdCl2";
				dataGridView1.Columns["Pr_Met_3_HCl"].HeaderText = "HCl";
				dataGridView1.Columns["Pr_Met_3_SnCl2"].HeaderText = "SnCl2";
				dataGridView1.Columns["Pr_Met_3_Cu2"].HeaderText = "Cu^2+";
				dataGridView1.Columns["Pr_Met_3_Correction"].HeaderText = "Корректировка";

				dataGridView1.Columns["Pr_Met_4_PM305A"].HeaderText = "PM305A";
				dataGridView1.Columns["Pr_Met_4_PM305b"].HeaderText = "PM305b";
				dataGridView1.Columns["Pr_Met_4_PM305V"].HeaderText = "PM305V";
				dataGridView1.Columns["Pr_Met_4_Correction"].HeaderText = "Корректировка";
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

				dataGridView1.Columns["Pr_Met_1_PM302"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Pr_Met_1_Cu2"].DefaultCellStyle.BackColor = Color.LightBlue;

				dataGridView1.Columns["Pr_Met_2_HCl"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Pr_Met_2_pH"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Pr_Met_2_Cu2"].DefaultCellStyle.BackColor = Color.LightBlue;

				dataGridView1.Columns["Pr_Met_3_PdCl2"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Pr_Met_3_HCl"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Pr_Met_3_SnCl2"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Pr_Met_3_Cu2"].DefaultCellStyle.BackColor = Color.LightBlue;

				dataGridView1.Columns["Pr_Met_4_PM305A"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Pr_Met_4_PM305b"].DefaultCellStyle.BackColor = Color.LightBlue;
				dataGridView1.Columns["Pr_Met_4_PM305V"].DefaultCellStyle.BackColor = Color.LightBlue;

			}

		}


		private void Pryam_Metal_Laborant_Load(object sender, EventArgs e)
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

				string query = "SELECT * FROM Pryam_Metal WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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
				string query = "SELECT * FROM Pryam_Metal WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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

				string sqlInsert = "INSERT INTO Pryam_Metal ([Date_Create],[FIO_Lab]) " +
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
				var Pr_Met_1_PM302 = dataGridView1.Rows[rowIndex].Cells["Pr_Met_1_PM302"].Value;
				var Pr_Met_1_Cu2 = dataGridView1.Rows[rowIndex].Cells["Pr_Met_1_Cu2"].Value;

				var Pr_Met_2_HCl = dataGridView1.Rows[rowIndex].Cells["Pr_Met_2_HCl"].Value;
				var Pr_Met_2_pH = dataGridView1.Rows[rowIndex].Cells["Pr_Met_2_pH"].Value;
				var Pr_Met_2_Cu2 = dataGridView1.Rows[rowIndex].Cells["Pr_Met_2_Cu2"].Value;

				var Pr_Met_3_PdCl2 = dataGridView1.Rows[rowIndex].Cells["Pr_Met_3_PdCl2"].Value;
				var Pr_Met_3_HCl = dataGridView1.Rows[rowIndex].Cells["Pr_Met_3_HCl"].Value;
				var Pr_Met_3_SnCl2 = dataGridView1.Rows[rowIndex].Cells["Pr_Met_3_SnCl2"].Value;
				var Pr_Met_3_Cu2 = dataGridView1.Rows[rowIndex].Cells["Pr_Met_3_Cu2"].Value;

				var Pr_Met_4_PM305A = dataGridView1.Rows[rowIndex].Cells["Pr_Met_4_PM305A"].Value;
				var Pr_Met_4_PM305b = dataGridView1.Rows[rowIndex].Cells["Pr_Met_4_PM305b"].Value;
				var Pr_Met_4_PM305V = dataGridView1.Rows[rowIndex].Cells["Pr_Met_4_PM305V"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Pryam_Metal
   SET [Pr_Met_1_PM302] = @Pr_Met_1_PM302,
[Pr_Met_1_Cu2] = @Pr_Met_1_Cu2,
[Pr_Met_2_HCl] = @Pr_Met_2_HCl,
[Pr_Met_2_pH] = @Pr_Met_2_pH,
[Pr_Met_2_Cu2] = @Pr_Met_2_Cu2,
[Pr_Met_3_PdCl2] = @Pr_Met_3_PdCl2,
[Pr_Met_3_HCl] = @Pr_Met_3_HCl,
[Pr_Met_3_SnCl2] = @Pr_Met_3_SnCl2,
[Pr_Met_3_Cu2] = @Pr_Met_3_Cu2,
[Pr_Met_4_PM305A] = @Pr_Met_4_PM305A,
[Pr_Met_4_PM305b] = @Pr_Met_4_PM305b,
[Pr_Met_4_PM305V] = @Pr_Met_4_PM305V
      ,[Date_Create] = @Date_Create,
                [FIO_Lab] = @FIO_Lab
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Create", Date_Create);
					command.Parameters.AddWithValue("@FIO_Lab", fioLab);
					//
					command.Parameters.AddWithValue("@Pr_Met_1_PM302", Pr_Met_1_PM302);
					command.Parameters.AddWithValue("@Pr_Met_1_Cu2", Pr_Met_1_Cu2);
					command.Parameters.AddWithValue("@Pr_Met_2_HCl", Pr_Met_2_HCl);
					command.Parameters.AddWithValue("@Pr_Met_2_pH", Pr_Met_2_pH);
					command.Parameters.AddWithValue("@Pr_Met_2_Cu2", Pr_Met_2_Cu2);
					command.Parameters.AddWithValue("@Pr_Met_3_PdCl2", Pr_Met_3_PdCl2);
					command.Parameters.AddWithValue("@Pr_Met_3_HCl", Pr_Met_3_HCl);
					command.Parameters.AddWithValue("@Pr_Met_3_SnCl2", Pr_Met_3_SnCl2);
					command.Parameters.AddWithValue("@Pr_Met_3_Cu2", Pr_Met_3_Cu2);
					command.Parameters.AddWithValue("@Pr_Met_4_PM305A", Pr_Met_4_PM305A);
					command.Parameters.AddWithValue("@Pr_Met_4_PM305b", Pr_Met_4_PM305b);
					command.Parameters.AddWithValue("@Pr_Met_4_PM305V", Pr_Met_4_PM305V);
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
				if (column.Name != "Pr_Met_1_PM302" && column.Name != "Pr_Met_1_Cu2" &&
					column.Name != "Pr_Met_2_HCl" && column.Name != "Pr_Met_2_pH" &&
					column.Name != "Pr_Met_2_Cu2" && column.Name != "Pr_Met_3_PdCl2" &&
					column.Name != "Pr_Met_3_HCl" && column.Name != "Pr_Met_3_SnCl2" &&
					column.Name != "Pr_Met_3_Cu2" && column.Name != "Pr_Met_4_PM305A" &&
					column.Name != "Pr_Met_4_PM305b" && column.Name != "Pr_Met_4_PM305V")
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
				var Pr_Met_1_PM302 = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_1_PM302"].Value;
				var Pr_Met_1_Cu2 = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_1_Cu2"].Value;

				var Pr_Met_2_HCl = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_2_HCl"].Value;
				var Pr_Met_2_pH = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_2_pH"].Value;
				var Pr_Met_2_Cu2 = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_2_Cu2"].Value;

				var Pr_Met_3_PdCl2 = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_3_PdCl2"].Value;
				var Pr_Met_3_HCl = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_3_HCl"].Value;
				var Pr_Met_3_SnCl2 = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_3_SnCl2"].Value;
				var Pr_Met_3_Cu2 = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_3_Cu2"].Value;

				var Pr_Met_4_PM305A = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_4_PM305A"].Value;
				var Pr_Met_4_PM305b = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_4_PM305b"].Value;
				var Pr_Met_4_PM305V = dataGridView1.Rows[e.RowIndex].Cells["Pr_Met_4_PM305V"].Value;



				// Создаем команду обновления с несколькими столбцами
				string updateQuery = @"
            UPDATE Pryam_Metal
   SET [Pr_Met_1_PM302] = @Pr_Met_1_PM302,
[Pr_Met_1_Cu2] = @Pr_Met_1_Cu2,
[Pr_Met_2_HCl] = @Pr_Met_2_HCl,
[Pr_Met_2_pH] = @Pr_Met_2_pH,
[Pr_Met_2_Cu2] = @Pr_Met_2_Cu2,
[Pr_Met_3_PdCl2] = @Pr_Met_3_PdCl2,
[Pr_Met_3_HCl] = @Pr_Met_3_HCl,
[Pr_Met_3_SnCl2] = @Pr_Met_3_SnCl2,
[Pr_Met_3_Cu2] = @Pr_Met_3_Cu2,
[Pr_Met_4_PM305A] = @Pr_Met_4_PM305A,
[Pr_Met_4_PM305b] = @Pr_Met_4_PM305b,
[Pr_Met_4_PM305V] = @Pr_Met_4_PM305V
      ,[FIO_Lab_Update] = @FIO_Lab_Update
      ,[Date_Lab_Update] = @Date_Lab_Update
	WHERE ID = @ID";

				using (SqlCommand command = new SqlCommand(updateQuery, connection))
				{
					// Добавляем параметры для каждого столбца
					command.Parameters.AddWithValue("@Date_Lab_Update", Date_Lab_Update);
					command.Parameters.AddWithValue("@FIO_Lab_Update", FIO_Lab_Update);
					//
					command.Parameters.AddWithValue("@Pr_Met_1_PM302", Pr_Met_1_PM302);
					command.Parameters.AddWithValue("@Pr_Met_1_Cu2", Pr_Met_1_Cu2);
					command.Parameters.AddWithValue("@Pr_Met_2_HCl", Pr_Met_2_HCl);
					command.Parameters.AddWithValue("@Pr_Met_2_pH", Pr_Met_2_pH);
					command.Parameters.AddWithValue("@Pr_Met_2_Cu2", Pr_Met_2_Cu2);
					command.Parameters.AddWithValue("@Pr_Met_3_PdCl2", Pr_Met_3_PdCl2);
					command.Parameters.AddWithValue("@Pr_Met_3_HCl", Pr_Met_3_HCl);
					command.Parameters.AddWithValue("@Pr_Met_3_SnCl2", Pr_Met_3_SnCl2);
					command.Parameters.AddWithValue("@Pr_Met_3_Cu2", Pr_Met_3_Cu2);
					command.Parameters.AddWithValue("@Pr_Met_4_PM305A", Pr_Met_4_PM305A);
					command.Parameters.AddWithValue("@Pr_Met_4_PM305b", Pr_Met_4_PM305b);
					command.Parameters.AddWithValue("@Pr_Met_4_PM305V", Pr_Met_4_PM305V);
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
