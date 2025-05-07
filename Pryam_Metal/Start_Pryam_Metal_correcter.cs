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
using Rez_Lab.Black_Hole;
using Rez_Lab.Himich_Podgotov;
using Rez_Lab.Himich_Podgotov;
using Rez_Lab.Himich_Podgotov;
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
	public partial class Start_Pryam_Metal_correcter : Form
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

		public Start_Pryam_Metal_correcter()
		{
			InitializeComponent();
			//TimerForButton();
			timer = new Timer();
			timer.Interval = 5000; // Интервал в миллисекундах (5000 мс = 5 секунд)
			timer.Tick += Timer_Tick; // Подписка на событие Tick
			timer.Start();

			InitializeTimer();
			InitializeTimer1();
			InitializeTimer2();
			InitializeTimer3();
			InitializeTimer4();
			


		}

		

		private void Start_Pryam_Metal_correcter_Load(object sender, EventArgs e)
		{
			label1.Text = WC.fio.ToString();
			//label2.Text = WC.fio.ToString();


			Load_Processes();


		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			Lab_Form_Corrector LFC = new Lab_Form_Corrector();
			LFC.ShowDialog();
			this.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			New_Corrector_Tasks NCT = new New_Corrector_Tasks();
			NCT.Show();
			this.Show();
		}

		private void Load_Processes()
		{
			//Load_Process1();
			//Cleaner();
			Load_Pryam_Metal_Cond();
			Load_Pryam_Metal_PredMet();
			Load_Pryam_Metal_PredMet303();
			Load_Pryam_Metal_Met();
			Load_Pryam_Metal_Uskor();


		}





		private void Load_Pryam_Metal_Cond()
		{
			string query = @"
         SELECT COUNT(*) 
FROM Pryam_Metal_Cond
WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
AND (
    ([Pr_Met_1_Correction_Mat] IS NOT NULL AND [Pr_Met_1_Correction_Mat] <> '') OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
    ([Pr_Met_1_Correction_Score] IS NOT NULL AND [Pr_Met_1_Correction_Score] <> ''));";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label3.Text = count.ToString(); // Обновление значения label11
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
			button1.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label3.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed)
				{
					button1.BackColor = Color.Blue;
				}
				else
				{
					button1.BackColor = Color.Red;
				}
				isRed = !isRed; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		




		private void Load_Pryam_Metal_PredMet()
		{
			string query = @"
         SELECT COUNT(*) 
FROM Pryam_Metal_PredMet
WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
AND (
    ([Pr_Met_2_Correction_Mat] IS NOT NULL AND [Pr_Met_2_Correction_Mat] <> '') OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
    ([Pr_Met_2_Correction_Score] IS NOT NULL AND [Pr_Met_2_Correction_Score] <> ''));";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label4.Text = count.ToString(); // Обновление значения label11
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
			button4.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick1(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label4.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed1)
				{
					button4.BackColor = Color.Blue;
				}
				else
				{
					button4.BackColor = Color.Red;
				}
				isRed1 = !isRed1; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking1(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label4_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label4.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking1();
			}
			else
			{
				StopBlinking1(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}







		private void Load_Pryam_Metal_Met()
		{
			string query = @"
         SELECT COUNT(*) 
FROM Pryam_Metal_Met
WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
AND (
    ([Pr_Met_3_Correction_Mat] IS NOT NULL AND [Pr_Met_3_Correction_Mat] <> '') OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
    ([Pr_Met_3_Correction_Score] IS NOT NULL AND [Pr_Met_3_Correction_Score] <> ''));";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label5.Text = count.ToString(); // Обновление значения label11
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
			blinkTimer2.Interval = 350; // 350 миллисекунд
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
			button5.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick2(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label5.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed2)
				{
					button5.BackColor = Color.Blue;
				}
				else
				{
					button5.BackColor = Color.Red;
				}
				isRed2 = !isRed2; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking2(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label5_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label5.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking2();
			}
			else
			{
				StopBlinking2(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}












		private void Load_Pryam_Metal_Uskor()
		{
			string query = @"
         SELECT COUNT(*) 
FROM Pryam_Metal_Uskor
WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
AND (
    ([Pr_Met_4_Correction_Mat] IS NOT NULL AND [Pr_Met_4_Correction_Mat] <> '') OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
    ([Pr_Met_4_Correction_Score] IS NOT NULL AND [Pr_Met_4_Correction_Score] <> ''));";

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
			blinkTimer3.Interval = 350; // 320 миллисекунд
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



		private void Load_Pryam_Metal_PredMet303()
		{
			string query = @"
         SELECT COUNT(*) 
FROM Pryam_Metal_PredMet303
WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
AND (
    ([Pr_Met_2_Correction_Mat] IS NOT NULL AND [Pr_Met_2_Correction_Mat] <> '') OR 
([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
    ([Pr_Met_2_Correction_Score] IS NOT NULL AND [Pr_Met_2_Correction_Score] <> ''));";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label6.Text = count.ToString(); // Обновление значения label44
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

		private void InitializeTimer4()
		{
			// Инициализация словаря связей меток и кнопок

			// Добавьте остальные пары меток и кнопок

			// Настройка таймера
			blinkTimer4 = new Timer();
			blinkTimer4.Interval = 350; // 350 миллисекунд
			blinkTimer4.Tick += BlinkTimer_Tick4;
		}


		private void StartBlinking4() // Метод для запуска мигания
		{
			isRed4 = false; // Сбросим значение isRed
			blinkTimer4.Start(); // Запускаем таймер
		}

		private void StopBlinking4() // Метод для остановки мигания
		{
			blinkTimer4.Stop(); // Останавливаем таймер
			button6.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick4(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label6.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed4)
				{
					button6.BackColor = Color.Blue;
				}
				else
				{
					button6.BackColor = Color.Red;
				}
				isRed4 = !isRed4; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking4(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label6_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label6.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking4();
			}
			else
			{
				StopBlinking4(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}
















		//private void Load_Process1()
		//{
		//	string query = @"
		//  SELECT COUNT(*)
		//  FROM Lab_Indicators
		//  WHERE [Сompleted] IS NULL AND [Сorrection] IS NOT NULL AND [Сorrection] <> '';";

		//	using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//	{
		//		try
		//		{
		//			connection.Open();
		//			SqlCommand command = new SqlCommand(query, connection);
		//			int count = (int)command.ExecuteScalar();

		//			// Обновление значения label2
		//			label2.Text = count.ToString();
		//		}
		//		catch (SqlException ex)
		//		{
		//			// Обработка ошибок подключения или выполнения запроса
		//			MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//		}
		//		finally
		//		{
		//			connection.Close();
		//		}
		//	}
		//}



		//		private void Load_Trav_Med_2()
		//		{
		//			string query = @"SELECT COUNT(*)
		//FROM Trav_Med_2 WHERE [Сompleted] IS NULL AND [Trav_Med_2_Correction] IS NOT NULL AND [Trav_Med_2_Correction] <> '';";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar();
		//					// Обновление значения label3
		//					label4.Text = count.ToString();
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Snatie_Photorez()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Snatie_Photorez 
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Sn_Photorez_1_Correction] IS NOT NULL AND [Sn_Photorez_1_Correction] <> '') OR 
		//    ([Sn_Photorez_2_Correction] IS NOT NULL AND [Sn_Photorez_2_Correction] <> '') OR 
		//    ([Sn_Photorez_3_Correction] IS NOT NULL AND [Sn_Photorez_3_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label11.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Pryam_Metal()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Pryam_Metal 
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Pr_Met_1_Correction] IS NOT NULL AND [Pr_Met_1_Correction] <> '') OR 
		//    ([Pr_Met_2_Correction] IS NOT NULL AND [Pr_Met_2_Correction] <> '') OR 
		//    ([Pr_Met_3_Correction] IS NOT NULL AND [Pr_Met_3_Correction] <> '') OR 
		//    ([Pr_Met_4_Correction] IS NOT NULL AND [Pr_Met_4_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label7.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Proyavlen_Photorez()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Proyavlen_Photorez 
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Pro_Photorez_1_Correction] IS NOT NULL AND [Pro_Photorez_1_Correction] <> '') OR 
		//    ([Pro_Photorez_2_Correction] IS NOT NULL AND [Pro_Photorez_2_Correction] <> '') OR 
		//    ([Pro_Photorez_3_Correction] IS NOT NULL AND [Pro_Photorez_3_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label15.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Proyavlen_Photomask()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Proyavlen_Photomask 
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Pro_Photomask_1_Correction] IS NOT NULL AND [Pro_Photomask_1_Correction] <> '') OR 
		//    ([Pro_Photomask_2_Correction] IS NOT NULL AND [Pro_Photomask_2_Correction] <> '') OR 
		//    ([Pro_Photomask_3_Correction] IS NOT NULL AND [Pro_Photomask_3_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label16.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Per_Obr()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Per_Obr
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Per_Obr_1_Correction] IS NOT NULL AND [Per_Obr_1_Correction] <> '') OR 
		//    ([Per_Obr_2_Correction] IS NOT NULL AND [Per_Obr_2_Correction] <> '') OR 
		//    ([Per_Obr_3_Correction] IS NOT NULL AND [Per_Obr_3_Correction] <> '') OR 
		//    ([Per_Obr_4_Correction] IS NOT NULL AND [Per_Obr_4_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label5.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Lushenie()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Lushenie
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Lushen_Correction] IS NOT NULL AND [Lushen_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label14.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}
		//		private void Load_Himich_Podgotov()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Himich_Podgotov
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Him_Podg_1_Correction] IS NOT NULL AND [Him_Podg_1_Correction] <> '') OR 
		//    ([Him_Podg_2_Correction] IS NOT NULL AND [Him_Podg_2_Correction] <> '') OR 
		//    ([Him_Podg_3_Correction] IS NOT NULL AND [Him_Podg_3_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label17.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Himich_Podgotov()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Himich_Podgotov
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Gal_Zat_1_Correction] IS NOT NULL AND [Gal_Zat_1_Correction] <> '') OR 
		//    ([Gal_Zat_2_Correction] IS NOT NULL AND [Gal_Zat_2_Correction] <> '') OR 
		//    ([Gal_Zat_3_Correction] IS NOT NULL AND [Gal_Zat_3_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label8.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Himich_Podgotov()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Himich_Podgotov
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Gal_Line_1_Correction] IS NOT NULL AND [Gal_Line_1_Correction] <> '') OR 
		//    ([Gal_Line_2_Correction] IS NOT NULL AND [Gal_Line_2_Correction] <> '') OR 
		//    ([Gal_Line_3_Cu_Correction] IS NOT NULL AND [Gal_Line_3_Cu_Correction] <> '') OR 
		//    ([Gal_Line_3_Sn_Correction] IS NOT NULL AND [Gal_Line_3_Sn_Correction] <> '') OR 
		//    ([Gal_Line_4_Correction] IS NOT NULL AND [Gal_Line_4_Correction] <> '') OR 
		//    ([Gal_Line_5_Correction] IS NOT NULL AND [Gal_Line_5_Correction] <> '') OR 
		//    ([Gal_Line_6_Correction] IS NOT NULL AND [Gal_Line_6_Correction] <> '') OR 
		//    ([Gal_Line_7_Correction] IS NOT NULL AND [Gal_Line_7_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label10.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Himich_Podgotov()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Himich_Podgotov
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Gal_Line_1_Correction] IS NOT NULL AND [Gal_Line_1_Correction] <> '') OR 
		//    ([Gal_Line_1_Correction] IS NOT NULL AND [Gal_Line_2_Correction] <> '') OR 
		//    ([Gal_Line_3_Cu_Correction] IS NOT NULL AND [Gal_Line_3_Cu_Correction] <> '') OR 
		//    ([Gal_Line_3_Sn_Correction] IS NOT NULL AND [Gal_Line_3_Sn_Correction] <> '') OR 
		//    ([Gal_Line_4_Correction] IS NOT NULL AND [Gal_Line_4_Correction] <> '') OR 
		//    ([Gal_Line_5_Correction] IS NOT NULL AND [Gal_Line_5_Correction] <> '') OR 
		//    ([Gal_Line_6_Correction] IS NOT NULL AND [Gal_Line_6_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label9.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Black_Hole()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Black_Hole
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Black_Hole_1_Correction] IS NOT NULL AND [Black_Hole_1_Correction] <> '') OR 
		//    ([Black_Hole_2_Correction] IS NOT NULL AND [Black_Hole_2_Correction] <> '') OR 
		//    ([Black_Hole_3_Correction] IS NOT NULL AND [Black_Hole_3_Correction] <> '') OR 
		//    ([Black_Hole_4_Correction] IS NOT NULL AND [Black_Hole_4_Correction] <> '') OR 
		//    ([Black_Hole_5_Correction] IS NOT NULL AND [Black_Hole_5_Correction] <> '') OR 
		//    ([Black_Hole_6_Correction] IS NOT NULL AND [Black_Hole_6_Correction] <> '') OR 
		//    ([Black_Hole_7_Correction] IS NOT NULL AND [Black_Hole_7_Correction] <> '') OR 
		//    ([Black_Hole_8_Correction] IS NOT NULL AND [Black_Hole_8_Correction] <> '')
		//);
		//";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label6.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}

		//		private void Load_Snatie_Olova()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Snatie_Olova 
		//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
		//AND (
		//    ([Sn_Olov_Correction] IS NOT NULL AND [Sn_Olov_Correction] <> ''));";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label12.Text = count.ToString(); // Обновление значения label11
		//				}
		//				catch (SqlException ex)
		//				{
		//					// Обработка ошибок подключения или выполнения запроса    
		//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
		//				}
		//				finally
		//				{
		//					connection.Close();
		//				}
		//			}
		//		}







		private void button16_Click(object sender, EventArgs e)
		{
			this.Hide();
			Trav_Med_1_Corrector tmc = new Trav_Med_1_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.Hide();
			Trav_Med_2_Corrector tmc = new Trav_Med_2_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Per_Obr_Corrector tmc = new Per_Obr_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Corrector tmc = new Black_Hole_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Hide();
			Pryam_Metal_Corrector tmc = new Pryam_Metal_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Corrector tmc = new Himich_Podgotov_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Corrector tmc = new Himich_Podgotov_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Corrector tmc = new Himich_Podgotov_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			this.Hide();
			Snatie_Photorez_Corrector tmc = new Snatie_Photorez_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			this.Hide();
			Snatie_Olova_Corrector tmc = new Snatie_Olova_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			this.Hide();
			Lushenie_Corrector tmc = new Lushenie_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			this.Hide();
			Proyavlen_Photorez_Corrector tmc = new Proyavlen_Photorez_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			this.Hide();
			Proyavlen_Photomask_Corrector tmc = new Proyavlen_Photomask_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Corrector tmc = new Himich_Podgotov_Corrector();
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





















//		private void Cleaner()
//		{
//			string query = @"
//        SELECT COUNT(*) 
//FROM Black_Hole_Cleaner
//WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
//AND (
//    ([Black_Hole_1_Correction_Mat] IS NOT NULL AND [Black_Hole_1_Correction_Mat] <> '') OR 
//    ([Black_Hole_1_Correction_Score] IS NOT NULL AND [Black_Hole_1_Correction_Score] <> ''));
//";

//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
//			{
//				try
//				{
//					connection.Open();
//					SqlCommand command = new SqlCommand(query, connection);
//					int count = (int)command.ExecuteScalar();
//					// Обновление значения label3
//					label3.Text = count.ToString();
//				}
//				catch (SqlException ex)
//				{
//					// Обработка ошибок подключения или выполнения запроса    
//					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
//				}
//				finally
//				{
//					connection.Close();
//				}
//			}
//		}

//		private void InitializeTimer()
//		{
//			// Инициализация словаря связей меток и кнопок

//			// Добавьте остальные пары меток и кнопок

//			// Настройка таймера
//			blinkTimer = new Timer();
//			blinkTimer.Interval = 350; // 350 миллисекунд
//			blinkTimer.Tick += BlinkTimer_Tick;
//		}
		

//		private void StartBlinking() // Метод для запуска мигания
//		{
//			isRed = false; // Сбросим значение isRed
//			blinkTimer.Start(); // Запускаем таймер
//		}

//		private void StopBlinking() // Метод для остановки мигания
//		{
//			blinkTimer.Stop(); // Останавливаем таймер
//			button2.BackColor = Color.Green; // Сбрасываем цвет кнопки
//		}

//		private void BlinkTimer_Tick(object sender, EventArgs e)
//		{
//			// Проверяем, больше ли значение в label, чем 0
//			if (int.TryParse(label3.Text, out int labelValue) && labelValue > 0)
//			{
//				// Меняем цвет кнопки в зависимости от isRed
//				if (isRed)
//				{
//					button2.BackColor = Color.Blue;
//				}
//				else
//				{
//					button2.BackColor = Color.Red;
//				}
//				isRed = !isRed; // Инвертируем значение isRed
//			}
//			else
//			{
//				StopBlinking(); // Останавливаем мигание, если значение в label не больше 0
//			}
//		}

//		private void label3_TextChanged(object sender, EventArgs e)
//		{
//			if (int.TryParse(label3.Text, out int labelValue) && labelValue > 0)
//			{
//				StartBlinking();
//			}
//			else
//			{
//				StopBlinking(); // Останавливаем мигание, если значение меньше или равно 0
//			}
//		}







		//private void InitializeTimer1()
		//{
		//	// Настройка таймера
		//	blinkTimer1 = new Timer();
		//	blinkTimer1.Interval = 350; // 350 миллисекунд
		//	blinkTimer1.Tick += BlinkTimer_Tick1;
		//}

		//private void StartBlinking1() // Метод для запуска мигания
		//{
		//	isRed1 = false; // Сбросим значение isRed
		//	blinkTimer1.Start(); // Запускаем таймер
		//}

		//private void StopBlinking1() // Метод для остановки мигания
		//{
		//	blinkTimer1.Stop(); // Останавливаем таймер
		//	button4.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick1(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label4.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed1)
		//		{
		//			button4.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button4.BackColor = Color.Red;
		//		}
		//		isRed1 = !isRed1; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking1(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label4_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label4.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking1();
		//	}
		//	else
		//	{
		//		StopBlinking1(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}









		//private void InitializeTimer2()
		//{
		//	// Настройка таймера
		//	blinkTimer2 = new Timer();
		//	blinkTimer2.Interval = 350; // 200 миллисекунд
		//	blinkTimer2.Tick += BlinkTimer_Tick2;
		//}

		//private void StartBlinking2() // Метод для запуска мигания
		//{
		//	isRed2 = false; // Сбросим значение isRed
		//	blinkTimer2.Start(); // Запускаем таймер
		//}

		//private void StopBlinking2() // Метод для остановки мигания
		//{
		//	blinkTimer2.Stop(); // Останавливаем таймер
		//	button5.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick2(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label5.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed2)
		//		{
		//			button5.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button5.BackColor = Color.Red;
		//		}
		//		isRed2 = !isRed2; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking2(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label5_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label5.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking2();
		//	}
		//	else
		//	{
		//		StopBlinking2(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}













		//private void InitializeTimer3()
		//{
		//	// Настройка таймера
		//	blinkTimer3 = new Timer();
		//	blinkTimer3.Interval = 350; // 300 миллисекунд
		//	blinkTimer3.Tick += BlinkTimer_Tick3;
		//}

		//private void StartBlinking3() // Метод для запуска мигания
		//{
		//	isRed3 = false; // Сбросим значение isRed
		//	blinkTimer3.Start(); // Запускаем таймер
		//}

		//private void StopBlinking3() // Метод для остановки мигания
		//{
		//	blinkTimer3.Stop(); // Останавливаем таймер
		//	button6.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick3(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label6.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed3)
		//		{
		//			button6.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button6.BackColor = Color.Red;
		//		}
		//		isRed3 = !isRed3; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking3(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label6_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label6.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking3();
		//	}
		//	else
		//	{
		//		StopBlinking3(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}



		//private void InitializeTimer4()
		//{
		//	// Настройка таймера
		//	blinkTimer4 = new Timer();
		//	blinkTimer4.Interval = 350; // 400 миллисекунд
		//	blinkTimer4.Tick += BlinkTimer_Tick4;
		//}

		//private void StartBlinking4() // Метод для запуска мигания
		//{
		//	isRed4 = false; // Сбросим значение isRed
		//	blinkTimer4.Start(); // Запускаем таймер
		//}

		//private void StopBlinking4() // Метод для остановки мигания
		//{
		//	blinkTimer4.Stop(); // Останавливаем таймер
		//	button7.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick4(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label7.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed4)
		//		{
		//			button7.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button7.BackColor = Color.Red;
		//		}
		//		isRed4 = !isRed4; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking4(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label7_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label7.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking4();
		//	}
		//	else
		//	{
		//		StopBlinking4(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}

		//private void InitializeTimer5()
		//{
		//	// Настройка таймера
		//	blinkTimer5 = new Timer();
		//	blinkTimer5.Interval = 350; // 500 миллисекунд
		//	blinkTimer5.Tick += BlinkTimer_Tick5;
		//}

		//private void StartBlinking5() // Метод для запуска мигания
		//{
		//	isRed5 = false; // Сбросим значение isRed
		//	blinkTimer5.Start(); // Запускаем таймер
		//}

		//private void StopBlinking5() // Метод для остановки мигания
		//{
		//	blinkTimer5.Stop(); // Останавливаем таймер
		//	button8.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick5(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label8.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed5)
		//		{
		//			button8.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button8.BackColor = Color.Red;
		//		}
		//		isRed5 = !isRed5; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking5(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label8_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label8.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking5();
		//	}
		//	else
		//	{
		//		StopBlinking5(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}

		//private void InitializeTimer6()
		//{
		//	// Настройка таймера
		//	blinkTimer6 = new Timer();
		//	blinkTimer6.Interval = 350; // 600 миллисекунд
		//	blinkTimer6.Tick += BlinkTimer_Tick6;
		//}

		//private void StartBlinking6() // Метод для запуска мигания
		//{
		//	isRed6 = false; // Сбросим значение isRed
		//	blinkTimer6.Start(); // Запускаем таймер
		//}

		//private void StopBlinking6() // Метод для остановки мигания
		//{
		//	blinkTimer6.Stop(); // Останавливаем таймер
		//	button9.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick6(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label9.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed6)
		//		{
		//			button9.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button9.BackColor = Color.Red;
		//		}
		//		isRed6 = !isRed6; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking6(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label9_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label9.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking6();
		//	}
		//	else
		//	{
		//		StopBlinking6(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}

		//private void InitializeTimer7()
		//{
		//	// Настройка таймера
		//	blinkTimer7 = new Timer();
		//	blinkTimer7.Interval = 350; // 700 миллисекунд
		//	blinkTimer7.Tick += BlinkTimer_Tick7;
		//}

		//private void StartBlinking7() // Метод для запуска мигания
		//{
		//	isRed7 = false; // Сбросим значение isRed
		//	blinkTimer7.Start(); // Запускаем таймер
		//}

		//private void StopBlinking7() // Метод для остановки мигания
		//{
		//	blinkTimer7.Stop(); // Останавливаем таймер
		//	button10.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick7(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label10.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed7)
		//		{
		//			button10.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button10.BackColor = Color.Red;
		//		}
		//		isRed7 = !isRed7; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking7(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label10_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label10.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking7();
		//	}
		//	else
		//	{
		//		StopBlinking7(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}

		//private void InitializeTimer8()
		//{
		//	// Настройка таймера
		//	blinkTimer8 = new Timer();
		//	blinkTimer8.Interval = 350; // 800 миллисекунд
		//	blinkTimer8.Tick += BlinkTimer_Tick8;
		//}

		//private void StartBlinking8() // Метод для запуска мигания
		//{
		//	isRed8 = false; // Сбросим значение isRed
		//	blinkTimer8.Start(); // Запускаем таймер
		//}

		//private void StopBlinking8() // Метод для остановки мигания
		//{
		//	blinkTimer8.Stop(); // Останавливаем таймер
		//	button11.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick8(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label11.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed8)
		//		{
		//			button11.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button11.BackColor = Color.Red;
		//		}
		//		isRed8 = !isRed8; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking8(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label11_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label11.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking8();
		//	}
		//	else
		//	{
		//		StopBlinking8(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}

		//private void InitializeTimer9()
		//{
		//	// Настройка таймера
		//	blinkTimer9 = new Timer();
		//	blinkTimer9.Interval = 350; // 900 миллисекунд
		//	blinkTimer9.Tick += BlinkTimer_Tick9;
		//}

		//private void StartBlinking9() // Метод для запуска мигания
		//{
		//	isRed9 = false; // Сбросим значение isRed
		//	blinkTimer9.Start(); // Запускаем таймер
		//}

		//private void StopBlinking9() // Метод для остановки мигания
		//{
		//	blinkTimer9.Stop(); // Останавливаем таймер
		//	button12.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick9(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label12.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed9)
		//		{
		//			button12.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button12.BackColor = Color.Red;
		//		}
		//		isRed9 = !isRed9; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking9(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label12_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label12.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking9();
		//	}
		//	else
		//	{
		//		StopBlinking9(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}

		//private void InitializeTimer10()
		//{
		//	// Настройка таймера
		//	blinkTimer10 = new Timer();
		//	blinkTimer10.Interval = 350; // 3500 миллисекунд
		//	blinkTimer10.Tick += BlinkTimer_Tick10;
		//}

		//private void StartBlinking10() // Метод для запуска мигания
		//{
		//	isRed10 = false; // Сбросим значение isRed
		//	blinkTimer10.Start(); // Запускаем таймер
		//}

		//private void StopBlinking10() // Метод для остановки мигания
		//{
		//	blinkTimer10.Stop(); // Останавливаем таймер
		//	button13.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick10(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label14.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed10)
		//		{
		//			button13.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button13.BackColor = Color.Red;
		//		}
		//		isRed10 = !isRed10; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking10(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label14_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label14.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking10();
		//	}
		//	else
		//	{
		//		StopBlinking10(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}

		//private void InitializeTimer11()
		//{
		//	// Настройка таймера
		//	blinkTimer11 = new Timer();
		//	blinkTimer11.Interval = 350; // 1350 миллисекунд
		//	blinkTimer11.Tick += BlinkTimer_Tick11;
		//}

		//private void StartBlinking11() // Метод для запуска мигания
		//{
		//	isRed11 = false; // Сбросим значение isRed
		//	blinkTimer11.Start(); // Запускаем таймер
		//}

		//private void StopBlinking11() // Метод для остановки мигания
		//{
		//	blinkTimer11.Stop(); // Останавливаем таймер
		//	button14.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick11(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label15.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed11)
		//		{
		//			button14.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button14.BackColor = Color.Red;
		//		}
		//		isRed11 = !isRed11; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking11(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label15_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label15.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking11();
		//	}
		//	else
		//	{
		//		StopBlinking11(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}

		//private void InitializeTimer12()
		//{
		//	// Настройка таймера
		//	blinkTimer12 = new Timer();
		//	blinkTimer12.Interval = 350; // 1200 миллисекунд
		//	blinkTimer12.Tick += BlinkTimer_Tick12;
		//}

		//private void StartBlinking12() // Метод для запуска мигания
		//{
		//	isRed12 = false; // Сбросим значение isRed
		//	blinkTimer12.Start(); // Запускаем таймер
		//}

		//private void StopBlinking12() // Метод для остановки мигания
		//{
		//	blinkTimer12.Stop(); // Останавливаем таймер
		//	button15.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick12(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label16.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed12)
		//		{
		//			button15.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button15.BackColor = Color.Red;
		//		}
		//		isRed12 = !isRed12; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking12(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label16_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label16.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking12();
		//	}
		//	else
		//	{
		//		StopBlinking12(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}

		//private void InitializeTimer13()
		//{
		//	// Настройка таймера
		//	blinkTimer13 = new Timer();
		//	blinkTimer13.Interval = 350; // 1300 миллисекунд
		//	blinkTimer13.Tick += BlinkTimer_Tick13;
		//}

		//private void StartBlinking13() // Метод для запуска мигания
		//{
		//	isRed13 = false; // Сбросим значение isRed
		//	blinkTimer13.Start(); // Запускаем таймер
		//}

		//private void StopBlinking13() // Метод для остановки мигания
		//{
		//	blinkTimer13.Stop(); // Останавливаем таймер
		//	button3.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//}

		//private void BlinkTimer_Tick13(object sender, EventArgs e)
		//{
		//	// Проверяем, больше ли значение в label, чем 0
		//	if (int.TryParse(label17.Text, out int labelValue) && labelValue > 0)
		//	{
		//		// Меняем цвет кнопки в зависимости от isRed
		//		if (isRed13)
		//		{
		//			button3.BackColor = Color.Blue;
		//		}
		//		else
		//		{
		//			button3.BackColor = Color.Red;
		//		}
		//		isRed13 = !isRed13; // Инвертируем значение isRed
		//	}
		//	else
		//	{
		//		StopBlinking13(); // Останавливаем мигание, если значение в label не больше 0
		//	}
		//}

		//private void label17_TextChanged(object sender, EventArgs e)
		//{
		//	if (int.TryParse(label17.Text, out int labelValue) && labelValue > 0)
		//	{
		//		StartBlinking13();
		//	}
		//	else
		//	{
		//		StopBlinking13(); // Останавливаем мигание, если значение меньше или равно 0
		//	}
		//}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Cleaner_Corrector tmc = new Black_Hole_Cleaner_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button4_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Conditioner_Corrector tmc = new Black_Hole_Conditioner_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Microtrav_1_Corrector tmc = new Black_Hole_Microtrav_1_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Microtrav_23_Corrector tmc = new Black_Hole_Microtrav_23_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button7_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BHC1_Corrector tmc = new Black_Hole_BHC1_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button8_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BHC2_Corrector tmc = new Black_Hole_BHC2_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button9_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK1_Corrector tmc = new Black_Hole_BAK1_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button10_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK2_Corrector tmc = new Black_Hole_BAK2_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_KisOch_Corrector tmc = new Himich_Podgotov_KisOch_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button4_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Microtrav_Corrector tmc = new Himich_Podgotov_Microtrav_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button5_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Dek_Corrector tmc = new Himich_Podgotov_Dek_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button1_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Pryam_Metal_Cond_Corrector tmc = new Pryam_Metal_Cond_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button4_Click_3(object sender, EventArgs e)
		{
			this.Hide();
			Pryam_Metal_PredMet_Corrector tmc = new Pryam_Metal_PredMet_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button5_Click_3(object sender, EventArgs e)
		{
			this.Hide();
			Pryam_Metal_Met_Corrector tmc = new Pryam_Metal_Met_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void button2_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Pryam_Metal_Uskor_Corrector tmc = new Pryam_Metal_Uskor_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		private void label3_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label3.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking();
			}
			else
			{
				StopBlinking(); // Останавливаем мигание, если значение меньше или равно 0
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

		private void button3_Click_1(object sender, EventArgs e)
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
		private List<string> filteredTableHeaders = new List<string>();
		private System.Drawing.Font dateFont = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
		private readonly string[] tableHeaders = new string[]
		{
		"!!! Кондиционер !!!",
		"!!! Предметализация 1 HCL !!!",
		"!!! Предметализация 2 ПМ 303 !!!",
		"!!! Метализация ПМ 304 !!!",
		"!!! Ускоритель !!!"
		};
		private int currentTableIndex = 0;
		private int currentRowIndex = 0;
		private readonly float[] columnWidths = { 210, 210, 290 };
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
			string query = @"
            SELECT 
                [Pr_Met_1_Correction_Mat],
                [Pr_Met_1_Correction_Score],
                [Сomment]
            FROM 
                Pryam_Metal_Cond
            WHERE 
                ([Сompleted] IS NULL OR [Сompleted] = '') 
                AND (
                    ([Pr_Met_1_Correction_Mat] IS NOT NULL AND [Pr_Met_1_Correction_Mat] <> '')  OR ([Сomment] IS NOT NULL AND [Сomment] <> '')
                    OR ([Pr_Met_1_Correction_Score] IS NOT NULL AND [Pr_Met_1_Correction_Score] <> '')
                );

            SELECT 
                [Pr_Met_2_Correction_Mat],
                [Pr_Met_2_Correction_Score],
                [Сomment]
            FROM 
                Pryam_Metal_PredMet
            WHERE 
                ([Сompleted] IS NULL OR [Сompleted] = '') 
                AND (
                    ([Pr_Met_2_Correction_Mat] IS NOT NULL AND [Pr_Met_2_Correction_Mat] <> '')  OR ([Сomment] IS NOT NULL AND [Сomment] <> '')
                    OR ([Pr_Met_2_Correction_Score] IS NOT NULL AND [Pr_Met_2_Correction_Score] <> '')
                );
 SELECT 
                [Pr_Met_2_Correction_Mat],
                [Pr_Met_2_Correction_Score],
                [Сomment]
            FROM 
                Pryam_Metal_PredMet303
            WHERE 
                ([Сompleted] IS NULL OR [Сompleted] = '') 
                AND (
                    ([Pr_Met_2_Correction_Mat] IS NOT NULL AND [Pr_Met_2_Correction_Mat] <> '')  OR ([Сomment] IS NOT NULL AND [Сomment] <> '')
                    OR ([Pr_Met_2_Correction_Score] IS NOT NULL AND [Pr_Met_2_Correction_Score] <> '')
                );

            SELECT 
                [Pr_Met_3_Correction_Mat],
                [Pr_Met_3_Correction_Score],
                [Сomment]
            FROM 
                Pryam_Metal_Met
            WHERE 
                ([Сompleted] IS NULL OR [Сompleted] = '') 
                AND (
                    ([Pr_Met_3_Correction_Mat] IS NOT NULL AND [Pr_Met_3_Correction_Mat] <> '')  OR ([Сomment] IS NOT NULL AND [Сomment] <> '')
                    OR ([Pr_Met_3_Correction_Score] IS NOT NULL AND [Pr_Met_3_Correction_Score] <> '')
                );
SELECT 
                [Pr_Met_4_Correction_Mat],
                [Pr_Met_4_Correction_Score],
                [Сomment]
            FROM 
                Pryam_Metal_Uskor
            WHERE 
                ([Сompleted] IS NULL OR [Сompleted] = '') 
                AND (
                    ([Pr_Met_4_Correction_Mat] IS NOT NULL AND [Pr_Met_4_Correction_Mat] <> '')  OR ([Сomment] IS NOT NULL AND [Сomment] <> '')
                    OR ([Pr_Met_4_Correction_Score] IS NOT NULL AND [Pr_Met_4_Correction_Score] <> '')
                );
        ";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				connection.Open();
				adapter.Fill(ds);
			}

			// Очищаем список заголовков и добавляем заголовки только для непустых таблиц
			filteredTableHeaders.Clear();
			for (int i = ds.Tables.Count - 1; i >= 0; i--)
			{
				if (ds.Tables[i].Rows.Count == 0)
				{
					ds.Tables.RemoveAt(i);
				}
				else
				{
					// Добавляем соответствующий заголовок в filteredTableHeaders
					if (i < tableHeaders.Length)
					{
						filteredTableHeaders.Insert(0, tableHeaders[i]);
					}
					else
					{
						filteredTableHeaders.Insert(0, $"Таблица {i + 1}");
					}
				}
			}

			return ds;
		}


		private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			float yPos = e.MarginBounds.Top;
			float leftMargin = e.MarginBounds.Left;
			float lineHeight = e.Graphics.MeasureString("Sample", dataFont).Height;

			string currentDateTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
			SizeF dateSize = e.Graphics.MeasureString(currentDateTime, dataFont);
			float dateX = leftMargin + (e.MarginBounds.Width - dateSize.Width) / 2;
			e.Graphics.DrawString(currentDateTime, dataFont, Brushes.Black, dateX, yPos);
			yPos += dateFont.GetHeight(e.Graphics) + 10;

			string title = "Прямая метализация";
			SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
			float titleX = leftMargin + (e.MarginBounds.Width - titleSize.Width) / 2;
			e.Graphics.DrawString(title, titleFont, Brushes.Black, titleX, yPos);
			yPos += titleSize.Height + 20;

			float rowSpacing = 8.0f;
			StringFormat stringFormat = new StringFormat
			{
				Trimming = StringTrimming.Word,
				FormatFlags = StringFormatFlags.LineLimit
			};

			while (currentTableIndex < dataSet.Tables.Count)
			{
				System.Data.DataTable table = dataSet.Tables[currentTableIndex];

				// Получаем соответствующий заголовок из filteredTableHeaders
				string header = filteredTableHeaders.Count > currentTableIndex ? filteredTableHeaders[currentTableIndex] : $"Таблица {currentTableIndex + 1}";

				// Печать заголовка таблицы
				e.Graphics.DrawString(header, headerFont, Brushes.Black, leftMargin, yPos, stringFormat);
				yPos += lineHeight + 5;

				string[] customColumnNames = { "Корр. Материал", "Корр. Количество", "Комментарии" };
				float currentLeft = leftMargin;

				for (int i = 0; i < customColumnNames.Length; i++)
				{
					RectangleF headerRect = new RectangleF(currentLeft, yPos, columnWidths[i], lineHeight);
					e.Graphics.DrawString(customColumnNames[i], columnFont, Brushes.Black, headerRect, stringFormat);
					currentLeft += columnWidths[i];
				}
				yPos += lineHeight;

				while (currentRowIndex < table.Rows.Count)
				{
					DataRow row = table.Rows[currentRowIndex];
					currentLeft = leftMargin;
					float maxHeight = 0;
					SizeF[] sizes = new SizeF[customColumnNames.Length];

					for (int i = 0; i < customColumnNames.Length; i++)
					{
						string text = row[i]?.ToString() ?? string.Empty;
						sizes[i] = e.Graphics.MeasureString(text, dataFont, (int)columnWidths[i], stringFormat);
						if (sizes[i].Height > maxHeight)
						{
							maxHeight = sizes[i].Height;
						}
					}

					if (yPos + maxHeight > e.MarginBounds.Bottom)
					{
						e.HasMorePages = true;
						return;
					}

					for (int i = 0; i < customColumnNames.Length; i++)
					{
						string text = row[i]?.ToString() ?? string.Empty;
						RectangleF cellRect = new RectangleF(currentLeft, yPos, columnWidths[i], maxHeight);
						e.Graphics.DrawString(text, dataFont, Brushes.Black, cellRect, stringFormat);
						currentLeft += columnWidths[i];
					}

					yPos += maxHeight + rowSpacing;
					currentRowIndex++;
				}

				currentRowIndex = 0;
				currentTableIndex++;
				yPos += lineHeight;

				if (yPos + lineHeight > e.MarginBounds.Bottom)
				{
					e.HasMorePages = true;
					return;
				}
			}

			e.HasMorePages = false;
			currentTableIndex = 0;
			currentRowIndex = 0;
		}






		private void button6_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Pryam_Metal_PredMet303_Corrector tmc = new Pryam_Metal_PredMet303_Corrector();
			tmc.ShowDialog();
			this.Show();
		}

		





		//private void button1_Click_1(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_KisOch_Corrector tmc = new Himich_Podgotov_KisOch_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button4_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_Microtrav_Corrector tmc = new Himich_Podgotov_Microtrav_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button5_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_Cu_Corrector tmc = new Himich_Podgotov_Cu_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button6_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_Sn_Corrector tmc = new Himich_Podgotov_Sn_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button7_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_CuEl1920_Corrector tmc = new Himich_Podgotov_CuEl1920_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button8_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_CuEl2122_Corrector tmc = new Himich_Podgotov_CuEl2122_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button9_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_SnEl_Corrector tmc = new Himich_Podgotov_SnEl_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button2_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_CuEl2324_Corrector tmc = new Himich_Podgotov_CuEl2324_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}












		// Обработка изменения текста меток

	}
}

