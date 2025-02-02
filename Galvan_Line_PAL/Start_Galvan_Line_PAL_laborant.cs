﻿using System;
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
using Rez_Lab.Galvan_Line_PAL;
using Rez_Lab.Galvan_Line_PAL;
using Rez_Lab.Galvan_Line_PAL_Microtrav;
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
    public partial class Start_Galvan_Line_PAL_Cleaner_laborant : Form
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
		public Start_Galvan_Line_PAL_Cleaner_laborant()
        {
            InitializeComponent();
			//this.MaximizeBox = false;

			timer = new Timer();
			timer.Interval = 5000; // Интервал в миллисекундах (5000 мс = 5 секунд)
			timer.Tick += Timer_Tick; // Подписка на событие Tick
			timer.Start();

			InitializeTimer1();
			InitializeTimer2();
			InitializeTimer3();
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
			Trav_Med_1_Laborant TM1L = new Trav_Med_1_Laborant();
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
			Per_Obr_Laborant tmc = new Per_Obr_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Laborant tmc = new Black_Hole_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Hide();
			Pryam_Metal_Laborant tmc = new Pryam_Metal_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Zat_Laborant tmc = new Galvan_Zat_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_PAL_Laborant tmc = new Galvan_Line_PAL_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_PAL_Laborant tmc = new Galvan_Line_PAL_Laborant();
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
			Proyavlen_Photorez_Laborant tmc = new Proyavlen_Photorez_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			this.Hide();
			Proyavlen_Photomask_Laborant tmc = new Proyavlen_Photomask_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Laborant tmc = new Himich_Podgotov_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Cleaner_Laborant tmc = new Black_Hole_Cleaner_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button4_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Conditioner_Laborant tmc = new Black_Hole_Conditioner_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Microtrav_1_Laborant tmc = new Black_Hole_Microtrav_1_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Microtrav_23_Laborant tmc = new Black_Hole_Microtrav_23_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button7_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BHC1_Laborant tmc = new Black_Hole_BHC1_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button8_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BHC2_Laborant tmc = new Black_Hole_BHC2_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button9_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK1_Laborant tmc = new Black_Hole_BAK1_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button10_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK2_Laborant tmc = new Black_Hole_BAK2_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_PAL_KisOch_Laborant tmc = new Galvan_Line_PAL_KisOch_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button4_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_PAL_Microtrav_Laborant tmc = new Galvan_Line_PAL_Microtrav_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button5_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_PAL_Cu_Laborant tmc = new Galvan_Line_PAL_Cu_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button6_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_PAL_Sn_Laborant tmc = new Galvan_Line_PAL_Sn_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button7_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_PAL_CuEl1920_Laborant tmc = new Galvan_Line_PAL_CuEl1920_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button8_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_PAL_CuEl2122_Laborant tmc = new Galvan_Line_PAL_CuEl2122_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button2_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_PAL_CuEl2324_Laborant tmc = new Galvan_Line_PAL_CuEl2324_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button9_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_PAL_SnEl_Laborant tmc = new Galvan_Line_PAL_SnEl_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Trav_Podv_PAL_Laborant tmc = new Trav_Podv_PAL_Laborant();
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
			Load_Galvan_Zat_CuEl12();
			Load_Galvan_Zat_CuEl34();
			Galvan_Line_PAL_CuEl2324();

		}
		private void Load_Galvan_Zat_CuEl12()
		{
			string query = @"
    SELECT COUNT(*)
    FROM Galvan_Line_PAL_CuEl1920
    WHERE ([Сompleted] IS NULL OR [Сompleted] = '')
      AND [Gal_Line_4_Correction_Mat] LIKE '%NaCl%';
";



			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label7.Text = count.ToString(); // Обновление значения label11
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
			blinkTimer1.Interval = 350; // 350 миллисекунд
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
			button7.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick1(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label7.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed1)
				{
					button7.BackColor = Color.Blue;
				}
				else
				{
					button7.BackColor = Color.Red;
				}
				isRed1 = !isRed1; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking1(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label7_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label7.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking1();
			}
			else
			{
				StopBlinking1(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void Load_Galvan_Zat_CuEl34()
		{
			string query = @"
    SELECT COUNT(*)
    FROM Galvan_Line_PAL_CuEl2122
    WHERE ([Сompleted] IS NULL OR [Сompleted] = '')
      AND [Gal_Line_5_Correction_Mat] LIKE '%NaCl%';
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

		private void InitializeTimer2()
		{
			// Инициализация словаря связей меток и кнопок

			// Добавьте остальные пары меток и кнопок

			// Настройка таймера
			blinkTimer2 = new Timer();
			blinkTimer2.Interval = 350; // 380 миллисекунд
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
			button8.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick2(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label8.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed2)
				{
					button8.BackColor = Color.Blue;
				}
				else
				{
					button8.BackColor = Color.Red;
				}
				isRed2 = !isRed2; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking2(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label8_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label8.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking2();
			}
			else
			{
				StopBlinking2(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void Galvan_Line_PAL_CuEl2324()
		{
			string query = @"
    SELECT COUNT(*)
    FROM Galvan_Line_PAL_CuEl2324
    WHERE ([Сompleted] IS NULL OR [Сompleted] = '')
      AND [Gal_Line_6_Correction_Mat] LIKE '%NaCl%';
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label2.Text = count.ToString(); // Обновление значения label11
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

		private void InitializeTimer3()
		{
			// Инициализация словаря связей меток и кнопок

			// Добавьте остальные пары меток и кнопок

			// Настройка таймера
			blinkTimer3 = new Timer();
			blinkTimer3.Interval = 350; // 330 миллисекунд
			blinkTimer3.Tick += BlinkTimer_Tick3;
		}


		private void StartBlinking3() // Метод для запуска мигания
		{
			isRed3 = false; // Сбросим значение isRed
			blinkTimer3.Start(); // Запускаем таймер
		}

		private void StopBlinking3() // Метод для остановки мигания
		{
			blinkTimer3.Stop(); // Останавливаем таймер
			button2.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick3(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label2.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed3)
				{
					button2.BackColor = Color.Blue;
				}
				else
				{
					button2.BackColor = Color.Red;
				}
				isRed3 = !isRed3; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking3(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label2_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label2.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking3();
			}
			else
			{
				StopBlinking3(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		//private void button4_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Galvan_Line_PAL_Microtrav_Laborant tmc = new Galvan_Line_PAL_Microtrav_Laborant();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button5_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Galvan_Line_PAL_Cu_Laborant tmc = new Galvan_Line_PAL_Cu_Laborant();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button6_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Galvan_Line_PAL_Sn_Laborant tmc = new Galvan_Line_PAL_Sn_Laborant();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button7_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Galvan_Line_PAL_CuEl1819_Laborant tmc = new Galvan_Line_PAL_CuEl1819_Laborant();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button8_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Galvan_Line_PAL_CuEl2021_Laborant tmc = new Galvan_Line_PAL_CuEl2021_Laborant();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button9_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Galvan_Line_PAL_SnEl_Laborant tmc = new Galvan_Line_PAL_SnEl_Laborant();
		//	tmc.ShowDialog();
		//	this.Show();
		//}
	}
}
