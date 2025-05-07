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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Rez_Lab.Black_Hole
{
	public partial class Galvan_Line_PAL_CuEl2122_Corrector : Form
	{
		public Galvan_Line_PAL_CuEl2122_Corrector()
		{
			InitializeComponent();
			////label11.Text = "H2SO4 - 170-220 г/л        CB-203А - 0,5-2 мл/л\r\nNaCl - 66-132 мг/л            CB-203K - 6-16 мл/л\r\nСuSO4 - 60-80 г/л             CB-203М - 0,3-1,25 мл/л\r\nОБЪЕМ ВАННЫ: 4589 л";

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
				dataAdapter = new SqlDataAdapter("SELECT ID, Gal_Line_5_Correction_Mat, Gal_Line_5_Correction_Score, FIO_tech, Date_tech, FIO_Corr, Date_Corr, Сompleted,[Start_corr],[Date_start_corr],[FIO_start_corr],[Сomment] FROM Galvan_Line_PAL_CuEl2122 ORDER BY Date_Create DESC", connection);
				SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
				dataTable = new DataTable();
				dataAdapter.Fill(dataTable);
				dataGridView1.DataSource = dataTable; // Устанавливаем источник данных

				// Изменение названий столбцов
				dataGridView1.Columns["ID"].HeaderText = "Номер";
				//dataGridView1.Columns["ID"].HeaderCell.Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
				//dataGridView1.Columns["Date_Create"].HeaderText = "Дата создания";
				//dataGridView1.Columns["FIO_Lab"].HeaderText = "ФИО Создателя";
				////
				//dataGridView1.Columns["Gal_Line_5_H2SO4"].HeaderText = "H2SO4";
				//dataGridView1.Columns["Gal_Line_5_NaCl"].HeaderText = "NaCl";
				//dataGridView1.Columns["Gal_Line_5_CuSO4"].HeaderText = "CuSO4";

				dataGridView1.Columns["Gal_Line_5_Correction_Mat"].HeaderText = "Корректировка Материал";
				dataGridView1.Columns["Gal_Line_5_Correction_Score"].HeaderText = "Корректировка Количество";
				//
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

		private void Galvan_Line_PAL_CuEl2122_Corrector_Load(object sender, EventArgs e)
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

				string query = "SELECT ID, Gal_Line_5_Correction_Mat, Gal_Line_5_Correction_Score, FIO_tech, Date_tech, FIO_Corr, Date_Corr, Сompleted,[Start_corr],[Date_start_corr],[FIO_start_corr],[Сomment] FROM Galvan_Line_PAL_CuEl2122 WHERE CAST(Date_Create AS DATE) = @SelectedDate ORDER BY Date_Create DESC";
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

		private void HighlightEmptyCells(DataGridView dataGridView, int[] columnsToCheck)
		{
			// Проверяем наличие столбца "Gal_Line_4_Correction_Mat"


			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				// Пропускаем новую строку, предназначенную для ввода данных
				if (row.IsNewRow) continue;

				// Получаем значения из столбцов с индексами 1, 2 и 8
				var cell1 = row.Cells[1].Value?.ToString();
				var cell2 = row.Cells[2].Value?.ToString();
				var cell8 = row.Cells[11].Value?.ToString();

				// Получаем значение из столбца "Gal_Line_4_Correction_Mat"
				var galLine4CorrectionMat = row.Cells["Gal_Line_5_Correction_Mat"].Value?.ToString()?.Trim();

				// Проверяем, что столбцы 1, 2 и 8 не пустые
				bool areSelectedCellsNotEmpty =
					!string.IsNullOrEmpty(cell1) ||
					!string.IsNullOrEmpty(cell2) ||
					!string.IsNullOrEmpty(cell8);

				// Проверяем, что "Gal_Line_4_Correction_Mat" не содержит "NaCl" (регистронезависимо)
				bool doesNotContainNaCl =
					string.IsNullOrEmpty(galLine4CorrectionMat) ||
					galLine4CorrectionMat.IndexOf("NaCl", StringComparison.OrdinalIgnoreCase) == -1;

				// Если оба условия выполняются
				if (areSelectedCellsNotEmpty && doesNotContainNaCl)
				{
					bool hasEmptyCell = false;

					foreach (int columnIndex in columnsToCheck)
					{
						// Проверяем корректность индекса столбца
						if (columnIndex < 0 || columnIndex >= dataGridView.Columns.Count)
						{
							continue; // Пропускаем некорректные индексы
						}

						var cellValue = row.Cells[columnIndex].Value?.ToString();

						if (string.IsNullOrEmpty(cellValue))
						{
							// Устанавливаем красный цвет фона для пустой ячейки
							row.Cells[columnIndex].Style.BackColor = Color.Red;

							// Устанавливаем светло-лососевый цвет фона для всей строки
							row.DefaultCellStyle.BackColor = Color.LightSalmon;

							hasEmptyCell = true;
						}
						else
						{
							// Сбрасываем цвет фона, если ячейка не пустая
							row.Cells[columnIndex].Style.BackColor = Color.White;

							if (!hasEmptyCell)
							{
								row.DefaultCellStyle.BackColor = Color.White;
							}
						}
					}
				}
				else
				{
					// Если условия не выполняются, сбрасываем цвета фона для указанных столбцов и строки
					foreach (int columnIndex in columnsToCheck)
					{
						if (columnIndex < 0 || columnIndex >= dataGridView.Columns.Count)
						{
							continue; // Пропускаем некорректные индексы
						}

						row.Cells[columnIndex].Style.BackColor = Color.White;
					}
					row.DefaultCellStyle.BackColor = Color.White;
				}
			}
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				// Пропускаем новую строку, предназначенную для ввода данных
				if (row.IsNewRow) continue;

				// Получаем значения из столбцов с индексами 1, 2 и 8
				var cell1 = row.Cells[1].Value?.ToString();
				var cell2 = row.Cells[2].Value?.ToString();
				var cell8 = row.Cells[11].Value?.ToString();

				// Получаем значение из столбца "Gal_Line_4_Correction_Mat"
				var galLine4CorrectionMat = row.Cells["Gal_Line_5_Correction_Mat"].Value?.ToString()?.Trim();

				// Проверяем, что столбцы 1, 2 и 8 не пустые
				bool areSelectedCellsNotEmpty =
					!string.IsNullOrEmpty(cell1) ||
					!string.IsNullOrEmpty(cell2) ||
					!string.IsNullOrEmpty(cell8);

				// Проверяем, что "Gal_Line_4_Correction_Mat" не содержит "NaCl" (регистронезависимо)
				bool doesNotContainNaCl =
					string.IsNullOrEmpty(galLine4CorrectionMat) ||
					galLine4CorrectionMat.IndexOf("NaCl", StringComparison.OrdinalIgnoreCase) == -1;

				// Если оба условия выполняются
				if (areSelectedCellsNotEmpty && doesNotContainNaCl)
				{
					bool hasEmptyCell = false;

					foreach (int columnIndex in columnsToCheck)
					{
						// Проверяем корректность индекса столбца


						var cellValue1 = row.Cells[8].Value?.ToString();
						//var cellValue = row.Cells[7].Value?.ToString();

						if (string.IsNullOrEmpty(row.Cells[7].Value?.ToString()) && string.IsNullOrEmpty(row.Cells[8].Value?.ToString()))
						{
							// Устанавливаем красный цвет фона для пустой ячейки
							row.Cells[8].Style.BackColor = Color.Yellow;

							// Устанавливаем светло-лососевый цвет фона для всей строки
							//row.DefaultCellStyle.BackColor = Color.LightSalmon;

							hasEmptyCell = true;
						}

						if (!string.IsNullOrEmpty(row.Cells[8].Value?.ToString()) && string.IsNullOrEmpty(row.Cells[7].Value?.ToString()))
						{
							//row.Cells[8].Style.BackColor = Color.Yellow;
							row.DefaultCellStyle.BackColor = Color.FromArgb(217, 253, 38);
						}
					}
				}
				else
				{
					// Если условия не выполняются, сбрасываем цвета фона для указанных столбцов и строки
					foreach (int columnIndex in columnsToCheck)
					{
						if (columnIndex < 0 || columnIndex >= dataGridView.Columns.Count)
						{
							continue; // Пропускаем некорректные индексы
						}

						row.Cells[columnIndex].Style.BackColor = Color.White;
					}
					row.DefaultCellStyle.BackColor = Color.White;
				}
			}

			// Обновляем отображение DataGridView
			dataGridView.Refresh();
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
				string query = "SELECT ID, Gal_Line_5_Correction_Mat, Gal_Line_5_Correction_Score, FIO_tech, Date_tech, FIO_Corr, Date_Corr, Сompleted,[Start_corr],[Date_start_corr],[FIO_start_corr],[Сomment] FROM Galvan_Line_PAL_CuEl2122 WHERE CAST(Date_Create AS DATE) BETWEEN @StartDate AND @EndDate ORDER BY Date_Create DESC";
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
			if (e.RowIndex >= 0 && columnsToCheck.Contains(e.ColumnIndex))
			{
				// Получаем текущую строку
				DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

				// Получаем значения необходимых столбцов
				var completedValue = selectedRow.Cells["Сompleted"].Value;
				var Correction_Mat_Value = selectedRow.Cells["Gal_Line_5_Correction_Mat"].Value;
				var Correction_Score_Value = selectedRow.Cells["Gal_Line_5_Correction_Score"].Value;
				var СommentValue = selectedRow.Cells["Сomment"].Value;

				bool isCorrectionMatValid = Correction_Mat_Value != null &&
											Correction_Mat_Value != DBNull.Value &&
											(Correction_Mat_Value is string strCorrMat1 &&
											 !string.IsNullOrWhiteSpace(strCorrMat1) &&
											 strCorrMat1.IndexOf("NaCl", StringComparison.OrdinalIgnoreCase) >= 0);

				if (isCorrectionMatValid)
				{
					MessageBox.Show("Строка содержит NaCl! Редактирование недоступно.",
									"Информация",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return;
				}


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
						string query = @"UPDATE Galvan_Line_PAL_CuEl2122 SET 
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
				var Correction_Mat_Value = selectedRow.Cells["Gal_Line_5_Correction_Mat"].Value;
				var Correction_Score_Value = selectedRow.Cells["Gal_Line_5_Correction_Score"].Value;
				var СommentValue = selectedRow.Cells["Сomment"].Value;

				bool isCorrectionMatValid = Correction_Mat_Value != null &&
											Correction_Mat_Value != DBNull.Value &&
											(Correction_Mat_Value is string strCorrMat1 &&
											 !string.IsNullOrWhiteSpace(strCorrMat1) &&
											 strCorrMat1.IndexOf("NaCl", StringComparison.OrdinalIgnoreCase) >= 0);

				if (isCorrectionMatValid)
				{
					MessageBox.Show("Строка содержит NaCl! Редактирование недоступно.",
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
						string query = @"UPDATE Galvan_Line_PAL_CuEl2122 SET 
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

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			pictureBox2.Visible = !pictureBox2.Visible;
		}
	}
}
