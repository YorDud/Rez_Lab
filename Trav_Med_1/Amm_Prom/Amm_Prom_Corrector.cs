using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Rez_Lab.Amm_Prom
{
	public partial class Amm_Prom_Corrector : Form
	{

		private Button printButton;
		private PrintDocument printDocument;
		public Amm_Prom_Corrector()
		{
			InitializeComponent();
			label3.Text = "NH4OH - 25% - 500 мл/л\r\nОБЪЕМ ВАННЫ: 120 л";

			printDocument = new PrintDocument();
			printDocument.PrintPage += PrintDocument_PrintPage;

			Controls.Add(printButton);

		}

		private SqlDataAdapter dataAdapter;
		private DataTable dataTable;
		int[] columnsToCheck = { 7 };

		private void LoadData()
		{
			// SQL-запрос для получения данных из таблицы Users
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				dataAdapter = new SqlDataAdapter("SELECT ID, Trav_Med_Correction_Mat, Trav_Med_Correction_Score, FIO_tech, Date_tech, FIO_Corr, Date_Corr, Сompleted,[Start_corr],[Date_start_corr],[FIO_start_corr],[Сomment] FROM Amm_Prom ORDER BY Date_Create DESC", connection);
				SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
				dataTable = new DataTable();
				dataAdapter.Fill(dataTable);
				dataGridView1.DataSource = dataTable; // Устанавливаем источник данных

				// Изменение названий столбцов
				dataGridView1.Columns["ID"].HeaderText = "Номер";
				//dataGridView1.Columns["ID"].HeaderCell.Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
				//dataGridView1.Columns["Date_Create"].HeaderText = "Дата создания";
				//dataGridView1.Columns["FIO_Lab"].HeaderText = "ФИО Создателя";
				//dataGridView1.Columns["Trav_Med_NH4C"].HeaderText = "Травление меди NH4Cl";
				//dataGridView1.Columns["Trav_Med_SO42"].HeaderText = "Травление меди SO4 2-";
				//dataGridView1.Columns["Trav_Med_Сu2"].HeaderText = "Травление меди Сu2+";
				dataGridView1.Columns["Trav_Med_Correction_Mat"].HeaderText = "Корректировка Материал";
				dataGridView1.Columns["Trav_Med_Correction_Score"].HeaderText = "Корректировка Количество";
				dataGridView1.Columns["FIO_tech"].HeaderText = "ФИО Технолога";
				dataGridView1.Columns["Date_tech"].HeaderText = "Дата создания корректировки";
				//dataGridView1.Columns["FIO_Lab_Update"].HeaderText = "ФИО Лаборанта (редакт)";
				//dataGridView1.Columns["Date_Lab_Update"].HeaderText = "Дата (редакт)";
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
				HighlightEmptyCells(dataGridView1, columnsToCheck);

			}
			
		}
		


		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void Amm_Prom_Corrector_Load(object sender, EventArgs e)
		{
			LoadData();
			label8.Text = WC.fio.ToString();
			//this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			HighlightEmptyCells(dataGridView1, columnsToCheck);
			NotClickOnTable();
		}
		private void NotClickOnTable()
		{
			foreach (DataGridViewColumn column in dataGridView1.Columns)
			{
				if (column.Name != "R") // предполагается, что "ID" - это столбец, который можно редактировать
				{
					column.ReadOnly = true;
				}
			}
		}

		private void LoadDataDateTimePicker(DateTime date)
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();

				string query = "SELECT ID, Trav_Med_Correction_Mat, Trav_Med_Correction_Score, FIO_tech, Date_tech, FIO_Corr, Date_Corr, Сompleted,[Start_corr],[Date_start_corr],[FIO_start_corr],[Сomment] FROM Amm_Prom WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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
			HighlightEmptyCells(dataGridView1, columnsToCheck);
		}

		private void HighlightEmptyCells(DataGridView dataGridView, int[] columns)
{
	foreach (DataGridViewRow row in dataGridView.Rows)
	{
		// Проверяем, что значение в 6-м столбике (индекс 5) не пустое
		if (!string.IsNullOrEmpty(row.Cells[1].Value?.ToString()) || !string.IsNullOrEmpty(row.Cells[2].Value?.ToString()) || !string.IsNullOrEmpty(row.Cells[11].Value?.ToString()))
		{
			foreach (int columnIndex in columns)
			{
				if (string.IsNullOrEmpty(row.Cells[columnIndex].Value?.ToString()))
				{
					row.Cells[columnIndex].Style.BackColor = Color.Red;
					row.DefaultCellStyle.BackColor = Color.LightSalmon;
				}
				if (string.IsNullOrEmpty(row.Cells[7].Value?.ToString()) && string.IsNullOrEmpty(row.Cells[8].Value?.ToString()))
				{
					row.Cells[8].Style.BackColor = Color.Yellow;
					//row.DefaultCellStyle.BackColor = Color.LightSalmon;
				}
				if (!string.IsNullOrEmpty(row.Cells[8].Value?.ToString()) && string.IsNullOrEmpty(row.Cells[7].Value?.ToString()))
				{
					//row.Cells[8].Style.BackColor = Color.Yellow;
					row.DefaultCellStyle.BackColor = Color.FromArgb(217, 253, 38);
				}
			}
		}
	}
}


		int clickCount = 0;
		private void button3_Click(object sender, EventArgs e)
		{
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
			HighlightEmptyCells(dataGridView1, columnsToCheck);
		}

		private void LoadDataByDateRange(DateTime startDate, DateTime endDate)
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				connection.Open();
				string query = "SELECT ID, Trav_Med_Correction_Mat, Trav_Med_Correction_Score, FIO_tech, Date_tech, FIO_Corr, Date_Corr, Сompleted,[Start_corr],[Date_start_corr],[FIO_start_corr],[Сomment] FROM Amm_Prom WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			// Проверяем, что клик был совершен по существующей строке и по 15-му столбцу (индекс 14)
			if (e.RowIndex >= 0 && e.ColumnIndex == 7)
			{
				// Получаем текущую строку
				DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

				// Получаем значения необходимых столбцов
				var completedValue = selectedRow.Cells["Сompleted"].Value;
				var Correction_Mat_Value = selectedRow.Cells["Trav_Med_Correction_Mat"].Value;
				var Correction_Score_Value = selectedRow.Cells["Trav_Med_Correction_Score"].Value;
				var СommentValue = selectedRow.Cells["Сomment"].Value;

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

				// Проверяем, что "Completed" пустой (null, DBNull или пустая строка)
				bool isCompletedEmpty = completedValue == null ||
										 completedValue == DBNull.Value ||
										 (completedValue is string strCompleted && string.IsNullOrWhiteSpace(strCompleted));

				// Проверяем, что "Date_tech" не пустой
				bool isCorrection_MathNotEmpty = Correction_Mat_Value != null &&
										  Correction_Mat_Value != DBNull.Value &&
										  !(Correction_Mat_Value is string strCorrMat && string.IsNullOrWhiteSpace(strCorrMat));

				// Проверяем, что "FIO_tech" не пустой
				bool isCorrection_ScoreNotEmpty = Correction_Score_Value != null &&
										 Correction_Score_Value != DBNull.Value &&
										 !(Correction_Score_Value is string strCorrScore && string.IsNullOrWhiteSpace(strCorrScore));

				bool isСommentNotEmpty = СommentValue != null &&
										 СommentValue != DBNull.Value &&
										 !(СommentValue is string strComm && string.IsNullOrWhiteSpace(strComm));

				// Если "Completed" не пустой, показать сообщение и выйти из метода
				if (!isCompletedEmpty)
				{
					MessageBox.Show("Эта корректировка уже выполнена! Редактирование недоступно.",
									"Информация",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return;
				}

				// Если "Date_tech" пустой, показать сообщение и выйти из метода
				if (!isCorrection_MathNotEmpty && !isCorrection_ScoreNotEmpty && !isСommentNotEmpty)
				{
					MessageBox.Show("Выполнение без корректироки и комментария невозможно! Редактирование недоступно.",
									"Предупреждение",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
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
						string query = @"UPDATE Amm_Prom SET 
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
			else if (e.RowIndex >= 0 && e.ColumnIndex == 8)
			{
				// Получаем текущую строку
				DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

				// Получаем значения необходимых столбцов
				var completedValue = selectedRow.Cells["Start_corr"].Value;
				var Correction_Mat_Value = selectedRow.Cells["Trav_Med_Correction_Mat"].Value;
				var Correction_Score_Value = selectedRow.Cells["Trav_Med_Correction_Score"].Value;
				var СommentValue = selectedRow.Cells["Сomment"].Value;

				// Проверяем, что "Completed" пустой (null, DBNull или пустая строка)
				bool isCompletedEmpty = completedValue == null ||
										 completedValue == DBNull.Value ||
										 (completedValue is string strCompleted && string.IsNullOrWhiteSpace(strCompleted));

				// Проверяем, что "Date_tech" не пустой
				bool isCorrection_MathNotEmpty = Correction_Mat_Value != null &&
										  Correction_Mat_Value != DBNull.Value &&
										  !(Correction_Mat_Value is string strCorrMat && string.IsNullOrWhiteSpace(strCorrMat));

				// Проверяем, что "FIO_tech" не пустой
				bool isCorrection_ScoreNotEmpty = Correction_Score_Value != null &&
										 Correction_Score_Value != DBNull.Value &&
										 !(Correction_Score_Value is string strCorrScore && string.IsNullOrWhiteSpace(strCorrScore));

				bool isСommentNotEmpty = СommentValue != null &&
										 СommentValue != DBNull.Value &&
										 !(СommentValue is string strComm && string.IsNullOrWhiteSpace(strComm));

				// Если "Completed" не пустой, показать сообщение и выйти из метода
				// Если "Completed" не пустой, показать сообщение и выйти из метода
				if (!isCompletedEmpty)
				{
					MessageBox.Show("Эта корректировка уже выполняется! Редактирование недоступно.",
									"Информация",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return;
				}

				// Если "Date_tech" пустой, показать сообщение и выйти из метода
				if (!isCorrection_MathNotEmpty && !isCorrection_ScoreNotEmpty && !isСommentNotEmpty)
				{
					MessageBox.Show("Выполнение без корректироки и комментария невозможно! Редактирование недоступно.",
									"Предупреждение",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
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
						string query = @"UPDATE Amm_Prom SET 
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




		//private DataTable dataTable; // Переменная на уровне класса для хранения данных

		//private DataTable dataTable; // Переменная на уровне класса для хранения данных

		private void button1_Click_1(object sender, EventArgs e)
		{
			// Получить данные из базы данных
			dataSet = GetAllDataFromDatabase();
			PrintDocument printDoc = new PrintDocument();

			printDoc.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
			PrintDialog printDialog = new PrintDialog
			{
				Document = printDoc
			};

			if (printDialog.ShowDialog() == DialogResult.OK)
			{
				printDoc.Print();
			}
		}



		private DataSet dataSet;
		private readonly string[] tableHeaders = new string[]
		{
		"Травление меди - 1"
		};
		private int currentTableIndex = 0;
		private int currentRowIndex = 0;
		private readonly float[] columnWidths = { 180, 180, 180, 180 };
		private System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 16, FontStyle.Bold);
		private System.Drawing.Font headerFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
		private System.Drawing.Font columnFont = new System.Drawing.Font("Arial", 8, FontStyle.Bold);
		private System.Drawing.Font dataFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

		public void Print()
		{
			dataSet = GetAllDataFromDatabase();
			PrintDocument printDoc = new PrintDocument();

			printDoc.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
			PrintDialog printDialog = new PrintDialog
			{
				Document = printDoc
			};

			if (printDialog.ShowDialog() == DialogResult.OK)
			{
				printDoc.Print();
			}
		}

		private DataSet GetAllDataFromDatabase()
		{
			DataSet ds = new DataSet();
			string query = @"SELECT [Trav_Med_Correction_Mat], [Trav_Med_Correction_Score], [Date_tech], [Сomment] 
                     FROM Amm_Prom 
                     WHERE ([Сompleted] IS NULL OR [Сompleted] = '') AND ( 
                         ([Trav_Med_Correction_Mat] IS NOT NULL AND [Trav_Med_Correction_Mat] <> '') OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR  
                         ([Trav_Med_Correction_Score] IS NOT NULL AND [Trav_Med_Correction_Score] <> '') 
                     );";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				connection.Open();
				adapter.Fill(ds);
			}

			return ds;
		}

		private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			float yPos = e.MarginBounds.Top;
			float leftMargin = e.MarginBounds.Left;
			float lineHeight = e.Graphics.MeasureString("Sample", dataFont).Height;

			// Отступ между строками данных (можно настроить по вашему усмотрению)
			

			// 1. Печать заголовка "MENYAY" по центру верхней части страницы
			string title = "Аммиачная промывка";
			SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
			float titleX = leftMargin + (e.MarginBounds.Width - titleSize.Width) / 2;
			e.Graphics.DrawString(title, titleFont, Brushes.Black, titleX, yPos);
			yPos += titleSize.Height + 20; // Отступ после заголовка


			float rowSpacing = 8.0f;
			// Объект StringFormat с настройками переноса текста
			StringFormat stringFormat = new StringFormat();
			stringFormat.Trimming = StringTrimming.Word; // Обрезка по словам
			stringFormat.FormatFlags = StringFormatFlags.LineLimit; // Ограничение числа строк

			while (currentTableIndex < dataSet.Tables.Count)
			{
				System.Data.DataTable table = dataSet.Tables[currentTableIndex];
				string header = tableHeaders.Length > currentTableIndex ? tableHeaders[currentTableIndex] : $"Таблица {currentTableIndex + 1}";

				// Печать заголовка таблицы
				e.Graphics.DrawString(header, headerFont, Brushes.Black, leftMargin, yPos, stringFormat);
				yPos += lineHeight + 5;

				// Пользовательские названия столбцов
				string[] customColumnNames = { "Корр. Материал", "Корр. Количество", "Дата", "Комментарии" };
				float currentLeft = leftMargin;

				// Печать заголовков столбцов
				for (int i = 0; i < customColumnNames.Length; i++)
				{
					RectangleF headerRect = new RectangleF(currentLeft, yPos, columnWidths[i], lineHeight);
					e.Graphics.DrawString(customColumnNames[i], columnFont, Brushes.Black, headerRect, stringFormat);
					currentLeft += columnWidths[i];
				}
				yPos += lineHeight;

				// Печать строк данных
				while (currentRowIndex < table.Rows.Count)
				{
					DataRow row = table.Rows[currentRowIndex];
					currentLeft = leftMargin;

					// Определяем максимальную высоту для текущей строки
					float maxHeight = 0;
					SizeF[] sizes = new SizeF[customColumnNames.Length];

					for (int i = 0; i < customColumnNames.Length; i++)
					{
						string text = row[i]?.ToString() ?? string.Empty;
						// Вычисляем размер текста с учетом переноса
						sizes[i] = e.Graphics.MeasureString(text, dataFont, (int)columnWidths[i], stringFormat);
						if (sizes[i].Height > maxHeight)
						{
							maxHeight = sizes[i].Height;
						}
					}

					// Проверка границ страницы перед печатью строки
					if (yPos + maxHeight > e.MarginBounds.Bottom)
					{
						e.HasMorePages = true;
						return;
					}

					// Печать каждой ячейки в строке с переносом текста
					for (int i = 0; i < customColumnNames.Length; i++)
					{
						string text = row[i]?.ToString() ?? string.Empty;
						RectangleF cellRect = new RectangleF(currentLeft, yPos, columnWidths[i], maxHeight);
						e.Graphics.DrawString(text, dataFont, Brushes.Black, cellRect, stringFormat);
						currentLeft += columnWidths[i];
					}

					// Увеличиваем yPos на высоту строки плюс отступ
					yPos += maxHeight + rowSpacing;
					currentRowIndex++;
				}

				// Завершение текущей таблицы
				currentRowIndex = 0;
				currentTableIndex++;
				yPos += lineHeight; // Пустая строка между таблицами

				// Проверка границ страницы после добавления пустой строки
				if (yPos + lineHeight > e.MarginBounds.Bottom)
				{
					e.HasMorePages = true;
					return;
				}
			}

			// Все таблицы напечатаны
			e.HasMorePages = false;

			// Сброс индексов для следующей печати
			currentTableIndex = 0;
			currentRowIndex = 0;
		}




	}

}
