using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rez_Lab
{
    public partial class New_Corrector_Tasks : Form
    {

        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        int[] columnsToCheck = { 13 };
        //int columnsToCheck =  13;
        int targetColumnIndex = 13; // Индекс столбца, который нужно проверить на пустые значения
        string buttonText = "✔"; // Текст на кнопке

        public New_Corrector_Tasks()
        {
            InitializeComponent();
        }

        private void New_Corrector_Tasks_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //private void LoadData()
        //{
        //    using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
        //    {
        //        connection.Open();
        //        dataAdapter = new SqlDataAdapter("SELECT \r\n    [indicator_1], \r\n    [indicator_2], \r\n    [indicator_3], \r\n    [Сorrection], \r\n    [Сompleted]\r\nFROM \r\n    Lab_Indicators\r\nWHERE \r\n    [Сorrection] IS NOT NULL AND [Сorrection] <> '' AND \r\n    [Сompleted] IS NULL\r\nUNION ALL\r\nSELECT \r\n    [indicator_1_2], \r\n    [indicator_2_2], \r\n    [indicator_3_2], \r\n    [Сorrection], \r\n    [indicator_1_22], \r\n    [indicator_2_22], \r\n    [indicator_3_22], \r\n    [Сorrection_2], \r\n    [Сompleted]\r\nFROM \r\n    Lab_Indicators_2\r\nWHERE \r\n    ([Сorrection] IS NOT NULL AND [Сorrection] <> '') OR \r\n    ([Сorrection_2] IS NOT NULL AND [Сorrection_2] <> '') AND \r\n    [Сompleted] IS NULL;\r\n", connection);
        //        //SELECT [indicator_1_2],[indicator_2_2],[indicator_3_2],[Сorrection],[indicator_1_22],[indicator_2_22],[indicator_3_22],[Сorrection_2],[Сompleted] FROM [Lab_Indicators_2]
        //        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
        //        dataTable = new DataTable();
        //        dataAdapter.Fill(dataTable);
        //        dataGridView1.DataSource = dataTable; // Устанавливаем источник данных

        //        // Изменение названий столбцов
        //        //dataGridView1.Columns["ID"].HeaderText = "Номер";
        //        //dataGridView1.Columns["ID"].HeaderCell.Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
        //        //dataGridView1.Columns["Date_Create"].HeaderText = "Дата создания";
        //        //dataGridView1.Columns["FIO_Lab"].HeaderText = "ФИО Создателя";
        //        //dataGridView1.Columns["indicator_1"].HeaderText = "Значение 1";
        //        //dataGridView1.Columns["indicator_2"].HeaderText = "Значение 2";
        //        //dataGridView1.Columns["indicator_3"].HeaderText = "Значение 3";
        //        //dataGridView1.Columns["Сorrection"].HeaderText = "Корректировка";
        //        //dataGridView1.Columns["FIO_tech"].HeaderText = "ФИО Технолога";
        //        //dataGridView1.Columns["Date_tech"].HeaderText = "Дата создания корректировки";
        //        //dataGridView1.Columns["FIO_Lab_Update"].HeaderText = "ФИО Лаборанта (редакт)";
        //        //dataGridView1.Columns["Date_Lab_Update"].HeaderText = "Дата (редакт)";
        //        //dataGridView1.Columns["FIO_Corr"].HeaderText = "ФИО Корректировщика";
        //        //dataGridView1.Columns["Date_Corr"].HeaderText = "Время выполнения корректировки";
        //        //dataGridView1.Columns["Сompleted"].HeaderText = "Выполнение";

        //        // Продолжайте добавлять другие столбцы по мере необходимости

        //    }
        //}

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
            {
                connection.Open();
              
                DataTable dt1 = new DataTable("Lab_Indicators");
                DataTable dt2 = new DataTable("Lab_Indicators_2");

                // Запрос для Lab_Indicators с добавлением названия таблицы как 'Процесс1'
                string query1 = @"
            SELECT 
                'Процесс1' AS [Процесс],
                [ID],
                [indicator_1], 
                [indicator_2], 
                [indicator_3], 
                [Сorrection], 
                '-' AS [indicator_1_2],
                '-' AS [indicator_2_2],
                '-' AS [indicator_3_2],
                '-' AS [Сorrection_1],
                '-' AS [indicator_1_22],
                '-' AS [indicator_2_22],
                '-' AS [indicator_3_22],
                '-' AS [Сorrection_2],
                [Сompleted]
            FROM Lab_Indicators 
            WHERE 
                [Сorrection] IS NOT NULL AND [Сorrection] <> '' AND 
                [Сompleted] IS NULL OR [Сompleted] = '' ";

                // Запрос для Lab_Indicators_2 с добавлением названия таблицы как 'Процесс2'
                string query2 = @"
            SELECT 
    'Процесс2' AS [Процесс],
    [ID], 
    '-' AS [indicator_1],
    '-' AS [indicator_2],
    '-' AS [indicator_3],
    '-' AS [Сorrection],
    [indicator_1_2], 
    [indicator_2_2], 
    [indicator_3_2], 
    [Сorrection_1],
    [indicator_1_22],
    [indicator_2_22],
    [indicator_3_22],
    [Сorrection_2],
    [Сompleted]
FROM 
    Lab_Indicators_2 
WHERE 
    (([Сorrection_1] IS NOT NULL AND [Сorrection_1] <> '') OR 
    ([Сorrection_2] IS NOT NULL AND [Сorrection_2] <> '')) AND 
    ([Сompleted] IS NULL OR [Сompleted] = '')
";

                SqlDataAdapter adapter1 = new SqlDataAdapter(query1, connection);
                SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);

                adapter1.Fill(dt1);
                adapter2.Fill(dt2);

                // Создаем общую таблицу и объединяем данные
                DataTable combinedTable = dt1.Clone(); // Копируем структуру таблицы
                combinedTable.Merge(dt1);
                combinedTable.Merge(dt2);

                // Перемещаем столбец 'Процесс' в первую позицию, если необходимо
                combinedTable.Columns["Процесс"].SetOrdinal(1);
                combinedTable.Columns["Сompleted"].SetOrdinal(combinedTable.Columns.Count - 1); // Перемещение столбца 'Сompleted'

                // Устанавливаем DataSource для DataGridView
                dataGridView1.DataSource = combinedTable;
            }
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Сompleted" && e.Value != null)
            {
                e.CellStyle.BackColor = Color.Red;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Получите значение ID из первой колонки (например, индекс 0)
                var idValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                // Проверка на null значение
                if (idValue != null)
                {
                    // Выводим значение для отладки
                   // MessageBox.Show($"Значение ID: {idValue}");

                    // Преобразование значения и присвоение его WC.id_click
                    if (int.TryParse(idValue.ToString(), out int id))
                    {
                        WC.id_click = id; // Присваиваем значение WC.id_click
                        string completed = "Выполнено!";
                        string connectionString = WC.ConnectionString;

                        // Запрос для обновления первой таблицы 
                        string query1 = @"
                UPDATE Lab_Indicators SET
                    [Date_Corr] = @Date_Corr,
                    Сompleted = @Сompleted,
                    FIO_Corr = @FIO_Corr
                WHERE ID = @Id";

                        // Запрос для обновления второй таблицы
                        string query2 = @"
                UPDATE Lab_Indicators_2 SET
                    [Date_Corr] = @Date_Corr2,
                    Сompleted = @Сompleted2,
                    FIO_Corr = @FIO_Corr2
                WHERE ID = @Id2";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command1 = new SqlCommand(query1, connection))
                            {
                                command1.Parameters.AddWithValue("@Date_Corr", DateTime.Now);
                                command1.Parameters.AddWithValue("@Сompleted", completed);
                                command1.Parameters.AddWithValue("@FIO_Corr", WC.fio);
                                command1.Parameters.AddWithValue("@Id", WC.id_click);
                                int rowsAffected1 = command1.ExecuteNonQuery();

                                if (rowsAffected1 > 0)
                                {
                                    using (SqlCommand command2 = new SqlCommand(query2, connection))
                                    {
                                        command2.Parameters.AddWithValue("@Date_Corr2", DateTime.Now);
                                        command2.Parameters.AddWithValue("@Сompleted2", completed);
                                        command2.Parameters.AddWithValue("@FIO_Corr2", WC.fio);
                                        command2.Parameters.AddWithValue("@Id2", WC.id_click);
                                        int rowsAffected2 = command2.ExecuteNonQuery();

                                        if (rowsAffected2 > 0)
                                        {
                                            MessageBox.Show("Данные добавленны!");
                                            LoadData();
                                            // int[] columnsToCheck = { 14 };
                                            // HighlightEmptyCells(dataGridView1, columnsToCheck);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Данные добавленны!");
                                        }
                                    }
                                }
                                else
                                {
                                   MessageBox.Show("Данные добавленны!");
                                }
                            }
                        }
                    }
                    else
                    {
                    }

                }

            }
        }
    }
}