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
using Rez_Lab.Black_Hole;
using Rez_Lab.Galvan_Line_MG;
using Rez_Lab.Galvan_Line_PAL;
using Rez_Lab.Galvan_Zat;
using Rez_Lab.Himich_Podgotov;
using Rez_Lab.Lushenie;
using Rez_Lab.Per_Obr;
using Rez_Lab.Proyavlen_Photomask;
using Rez_Lab.Proyavlen_Photorez;
using Rez_Lab.Pryam_Metal;
using Rez_Lab.Snatie_Olova;
using Rez_Lab.Snatie_Photorez;
using Rez_Lab.Trav_Med_1;
using Rez_Lab.Trav_Med_2;

namespace Rez_Lab
{
    public partial class StartWindow_laborant : Form
    {
		private Timer timer;

		private Timer blinkTimer;
		private Timer blinkTimer1;
		private Timer blinkTimer2;
		private Timer blinkTimer3;
		private Timer blinkTimer4;
		private Timer blinkTimer5;
		private Timer blinkTimer6;
		private Timer blinkTimer7;
		private Timer blinkTimer8;
		private Timer blinkTimer9;
		private Timer blinkTimer10;
		private Timer blinkTimer11;
		private Timer blinkTimer12;
		private Timer blinkTimer13;
		private Timer blinkTimer14;
		private bool isRed = false;
		private bool isRed1 = false;
		private bool isRed2 = false;
		private bool isRed3 = false;
		private bool isRed4 = false;
		private bool isRed5 = false;
		private bool isRed6 = false;
		private bool isRed7 = false;
		private bool isRed8 = false;
		private bool isRed9 = false;
		private bool isRed10 = false;
		private bool isRed11 = false;
		private bool isRed12 = false;
		private bool isRed13 = false;
		private bool isRed14 = false;
		public StartWindow_laborant()
        {
            InitializeComponent();
			//this.MaximizeBox = false;
			timer = new Timer();
			timer.Interval = 5000; // Интервал в миллисекундах (5000 мс = 5 секунд)
			timer.Tick += Timer_Tick; // Подписка на событие Tick
			timer.Start();

			InitializeTimer();
			InitializeTimer1();
			InitializeTimer2();
		}

        private void StartWindow_worker_Load(object sender, EventArgs e)
        {
            //LoadUserData();
            label1.Text = WC.fio;
			Load_Processes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lab_Form_worker lfw = new Lab_Form_worker();
            lfw.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lab_Form_Laborant lfl = new Lab_Form_Laborant();
            lfl.ShowDialog();
            this.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

		private void button16_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Amm_Prom_laborant TM1L = new Start_Amm_Prom_laborant();
			TM1L.ShowDialog();
			this.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.Hide();
			Trav_Med_2_Laborant tmc = new Trav_Med_2_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Perm_Obra_laborant tmc = new Start_Perm_Obra_laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Black_Hole_Cleaner_laborant tmc = new Start_Black_Hole_Cleaner_laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Pryam_Metal_laborant tmc = new Start_Pryam_Metal_laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Galvan_Zat_Cleaner_laborant tmc = new Start_Galvan_Zat_Cleaner_laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Galvan_Line_MG_Cleaner_laborant tmc = new Start_Galvan_Line_MG_Cleaner_laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Galvan_Line_PAL_Cleaner_laborant tmc = new Start_Galvan_Line_PAL_Cleaner_laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			this.Hide();
			Snatie_Photorez_Laborant tmc = new Snatie_Photorez_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			this.Hide();
			Snatie_Olova_Laborant tmc = new Snatie_Olova_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			this.Hide();
			Lushenie_Laborant tmc = new Lushenie_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Proyavlen_Photorez_laborant tmc = new Start_Proyavlen_Photorez_laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Proyavlen_Photomask_laborant tmc = new Start_Proyavlen_Photomask_laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Himich_Podgotov_Cleaner_laborant tmc = new Start_Himich_Podgotov_Cleaner_laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Trav_Podv_Laborant tmc = new Trav_Podv_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			Load_Processes();// Вызов вашей функции
		}
		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
			timer.Stop(); // Остановка таймера при закрытии формы
			timer.Dispose(); // Освобождение ресурсов
		}
		private void Load_Processes()
		{
			//Load_Process1();
			//Cleaner();
			Load_Galvan_Zat();
			Load_Galvan_Line_MG();
			Load_Galvan_Line_PAL();

		}


		private void Load_Galvan_Zat()
		{
			string query = @"
    SELECT
        (SELECT COUNT(*)
         FROM Galvan_Zat_CuEl12
         WHERE ([Сompleted] IS NULL OR [Сompleted] = '')
           AND [Gal_Zat_2_Correction_Mat] LIKE '%NaCl%') +
        (SELECT COUNT(*)
         FROM Galvan_Zat_CuEl34
         WHERE ([Сompleted] IS NULL OR [Сompleted] = '')
           AND [Gal_Zat_3_Correction_Mat] LIKE '%NaCl%') AS TotalCount;
";


			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label8.Text = count.ToString(); // Обновление значения label11
				}
				catch (SqlException ex)
				{
					// Обработка ошибок подключения или выполнения запроса    
					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
				}
				finally
				{
					connection.Close();
				}
			}
		}

		private void InitializeTimer()
		{
			// Инициализация словаря связей меток и кнопок

			// Добавьте остальные пары меток и кнопок

			// Настройка таймера
			blinkTimer = new Timer();
			blinkTimer.Interval = 350; // 250 миллисекунд
			blinkTimer.Tick += BlinkTimer_Tick;
		}


		private void StartBlinking() // Метод для запуска мигания
		{
			isRed = false; // Сбросим значение isRed
			blinkTimer.Start(); // Запускаем таймер
		}

		private void StopBlinking() // Метод для остановки мигания
		{
			blinkTimer.Stop(); // Останавливаем таймер
			button8.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label8.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed)
				{
					button8.BackColor = Color.Blue;
				}
				else
				{
					button8.BackColor = Color.Red;
				}
				isRed = !isRed; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label8_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label8.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking();
			}
			else
			{
				StopBlinking(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void Load_Galvan_Line_MG()
		{
			string query = @"
    SELECT
        (SELECT COUNT(*)
         FROM Galvan_Line_MG_CuEl1819
         WHERE ([Сompleted] IS NULL OR [Сompleted] = '')
           AND [Gal_Line_4_Correction_Mat] LIKE '%NaCl%') +
        (SELECT COUNT(*)
         FROM Galvan_Line_MG_CuEl2021
         WHERE ([Сompleted] IS NULL OR [Сompleted] = '')
           AND [Gal_Line_5_Correction_Mat] LIKE '%NaCl%') AS TotalCount;
";


			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label9.Text = count.ToString(); // Обновление значения label11
				}
				catch (SqlException ex)
				{
					// Обработка ошибок подключения или выполнения запроса    
					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
				}
				finally
				{
					connection.Close();
				}
			}
		}

		private void InitializeTimer1()
		{
			// Инициализация словаря связей меток и кнопок

			// Добавьте остальные пары меток и кнопок

			// Настройка таймера
			blinkTimer1 = new Timer();
			blinkTimer1.Interval = 350; // 250 миллисекунд
			blinkTimer1.Tick += BlinkTimer_Tick1;
		}


		private void StartBlinking1() // Метод для запуска мигания
		{
			isRed1 = false; // Сбросим значение isRed
			blinkTimer1.Start(); // Запускаем таймер
		}

		private void StopBlinking1() // Метод для остановки мигания
		{
			blinkTimer1.Stop(); // Останавливаем таймер
			button9.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick1(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label9.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed1)
				{
					button9.BackColor = Color.Blue;
				}
				else
				{
					button9.BackColor = Color.Red;
				}
				isRed1 = !isRed1; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label9_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label9.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking1();
			}
			else
			{
				StopBlinking1(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void Load_Galvan_Line_PAL()
		{
			string query = @"
    SELECT
        (SELECT COUNT(*)
         FROM Galvan_Line_PAL_CuEl1920
         WHERE ([Сompleted] IS NULL OR [Сompleted] = '')
           AND [Gal_Line_4_Correction_Mat] LIKE '%NaCl%') +
(SELECT COUNT(*)
         FROM Galvan_Line_PAL_CuEl2122
         WHERE ([Сompleted] IS NULL OR [Сompleted] = '')
           AND [Gal_Line_5_Correction_Mat] LIKE '%NaCl%') +
        (SELECT COUNT(*)
         FROM Galvan_Line_PAL_CuEl2324
         WHERE ([Сompleted] IS NULL OR [Сompleted] = '')
           AND [Gal_Line_6_Correction_Mat] LIKE '%NaCl%') AS TotalCount;
";


			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label10.Text = count.ToString(); // Обновление значения label11
				}
				catch (SqlException ex)
				{
					// Обработка ошибок подключения или выполнения запроса    
					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
				}
				finally
				{
					connection.Close();
				}
			}
		}

		private void InitializeTimer2()
		{
			// Инициализация словаря связей меток и кнопок

			// Добавьте остальные пары меток и кнопок

			// Настройка таймера
			blinkTimer2 = new Timer();
			blinkTimer2.Interval = 350; // 250 миллисекунд
			blinkTimer2.Tick += BlinkTimer_Tick2;
		}


		private void StartBlinking2() // Метод для запуска мигания
		{
			isRed2 = false; // Сбросим значение isRed
			blinkTimer2.Start(); // Запускаем таймер
		}

		private void StopBlinking2() // Метод для остановки мигания
		{
			blinkTimer2.Stop(); // Останавливаем таймер
			button10.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick2(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label10.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed2)
				{
					button10.BackColor = Color.Blue;
				}
				else
				{
					button10.BackColor = Color.Red;
				}
				isRed2 = !isRed2; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label10_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label10.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking2();
			}
			else
			{
				StopBlinking2(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void button28_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Photorez_laborant poa = new Start_Photorez_laborant();
			poa.ShowDialog();
			this.Show();
		}

		private void button26_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Zolot_laborant poa = new Start_Zolot_laborant();
			poa.ShowDialog();
			this.Show();
		}

		private void button25_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_DES_laborant poa = new Start_DES_laborant();
			poa.ShowDialog();
			this.Show();
		}

		private void button24_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Oxide_laborant poa = new Start_Oxide_laborant();
			poa.ShowDialog();
			this.Show();
		}
	}
}
