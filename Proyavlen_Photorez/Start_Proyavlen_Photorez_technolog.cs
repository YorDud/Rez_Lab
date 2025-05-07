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
using Rez_Lab.Himich_Podgotov;
using Rez_Lab.Himich_Podgotov;
using Rez_Lab.Himich_Podgotov;
using Rez_Lab.Himich_Podgotov;
using Rez_Lab.Lushenie;
using Rez_Lab.Per_Obr;
using Rez_Lab.Proyavlen_Photorez;
using Rez_Lab.Proyavlen_Photorez;
using Rez_Lab.Pryam_Metal;
using Rez_Lab.Snatie_Olova;
using Rez_Lab.Snatie_Photorez;
using Rez_Lab.Trav_Med_1;
using Rez_Lab.Trav_Med_2;

namespace Rez_Lab
{
    public partial class Start_Proyavlen_Photorez_technolog : Form
    {
		private Timer timer;
		private Timer timer1;
		private Timer timer2;
		private Timer timer3;
		private Timer timer4;
		private Timer timer5;
		private Timer timer6;
		private Timer timer7;
		private Timer timer8;
		private Timer timer9;
		private Timer timer10;
		private Timer timer11;
		private Timer timer12;
		private Timer timer13;

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



		public Start_Proyavlen_Photorez_technolog()
        {
            InitializeComponent();

			timer = new Timer();
			timer.Interval = 5000; // Интервал в миллисекундах (5000 мс = 5 секунд)
			timer.Tick += Timer_Tick; // Подписка на событие Tick
			timer.Start();

			InitializeTimer();
			InitializeTimer1();
			InitializeTimer2();

			
		}

		

		private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lab_Form_Technolog LFT= new Lab_Form_Technolog();
            LFT.ShowDialog();
            this.Show();
        }

        private void Start_Proyavlen_Photorez_technolog_Load(object sender, EventArgs e)
        {
            label1.Text = WC.fio;

			Load_Processes();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Trav_Med_1_Technolog tmd = new Trav_Med_1_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.Hide();
			Trav_Med_2_Technolog tmd = new Trav_Med_2_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Per_Obr_Technolog tmd = new Per_Obr_Technolog();
			tmd.ShowDialog();
			this.Show();

		}

		private void button6_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Technolog tmd = new Black_Hole_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Hide();
			Pryam_Metal_Technolog tmd = new Pryam_Metal_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Technolog tmd = new Himich_Podgotov_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Technolog tmd = new Himich_Podgotov_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Technolog tmd = new Himich_Podgotov_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			this.Hide();
			Snatie_Photorez_Technolog tmd = new Snatie_Photorez_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			this.Hide();
			Snatie_Olova_Technolog tmd = new Snatie_Olova_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			this.Hide();
			Lushenie_Technolog tmd = new Lushenie_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			this.Hide();
			Proyavlen_Photorez_Technolog tmd = new Proyavlen_Photorez_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			this.Hide();
			Proyavlen_Photorez_Technolog tmd = new Proyavlen_Photorez_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Technolog tmd = new Himich_Podgotov_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
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
//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
//			{
//				try
//				{
//					connection.Open();
//					SqlCommand command = new SqlCommand(query, connection);
//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
//					label.Text = count.ToString(); // Обновление значения label11
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
//			blinkTimer.Interval = 350; // 250 миллисекунд
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
//			if (int.TryParse(label.Text, out int labelValue) && labelValue > 0)
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

//		private void label_TextChanged(object sender, EventArgs e)
//		{
//			if (int.TryParse(label.Text, out int labelValue) && labelValue > 0)
//			{
//				StartBlinking();
//			}
//			else
//			{
//				StopBlinking(); // Останавливаем мигание, если значение меньше или равно 0
//			}
//		}



















		//		private void Load_Himich_Podgotov()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Himich_Podgotov 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";


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



		//		private void InitializeTimer1()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer1 = new Timer();
		//			blinkTimer1.Interval = 350; // 350 миллисекунд
		//			blinkTimer1.Tick += BlinkTimer_Tick1;
		//		}


		//		private void StartBlinking1() // Метод для запуска мигания
		//		{
		//			isRed1 = false; // Сбросим значение isRed
		//			blinkTimer1.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking1() // Метод для остановки мигания
		//		{
		//			blinkTimer1.Stop(); // Останавливаем таймер
		//			button9.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick1(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label9.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed1)
		//				{
		//					button9.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button9.BackColor = Color.Red;
		//				}
		//				isRed1 = !isRed1; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking1(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label9_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label9.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking1();
		//			}
		//			else
		//			{
		//				StopBlinking1(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}







		//		private void CCCCCleaner()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Black_Hole_Cleaner 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label.Text = count.ToString(); // Обновление значения label11
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



		//		private void InitializeTimer2()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer2 = new Timer();
		//			blinkTimer2.Interval = 350; // 350 миллисекунд
		//			blinkTimer2.Tick += BlinkTimer_Tick2;
		//		}


		//		private void StartBlinking2() // Метод для запуска мигания
		//		{
		//			isRed2 = false; // Сбросим значение isRed
		//			blinkTimer2.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking2() // Метод для остановки мигания
		//		{
		//			blinkTimer2.Stop(); // Останавливаем таймер
		//			button2.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick2(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed2)
		//				{
		//					button2.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button2.BackColor = Color.Red;
		//				}
		//				isRed2 = !isRed2; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking2(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}



		private void button2_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Cleaner_Technolog tmd = new Black_Hole_Cleaner_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button4_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Conditioner_Technolog tmd = new Black_Hole_Conditioner_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Microtrav_1_Technolog tmd = new Black_Hole_Microtrav_1_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Microtrav_23_Technolog tmd = new Black_Hole_Microtrav_23_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button7_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BHC1_Technolog tmd = new Black_Hole_BHC1_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button8_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BHC2_Technolog tmd = new Black_Hole_BHC2_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button9_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK1_Technolog tmd = new Black_Hole_BAK1_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button10_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK2_Technolog tmd = new Black_Hole_BAK2_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Proyavlen_Photorez_ProvMod_Technolog tmd = new Proyavlen_Photorez_ProvMod_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button4_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Proyavlen_Photorez_Ult1_Technolog tmd = new Proyavlen_Photorez_Ult1_Technolog();
			tmd.ShowDialog();
			this.Show();
		}

		private void button5_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Proyavlen_Photorez_Ult2_Technolog tmd = new Proyavlen_Photorez_Ult2_Technolog();
			tmd.ShowDialog();
			this.Show();
		}



















		private void Load_Processes()
		{

			//Cleaner();\
			Load_Proyavlen_Photorez_ProvMod();
			Load_Proyavlen_Photorez_Ult1();
			Load_Proyavlen_Photorez_Ult2();


		}







		private void Load_Proyavlen_Photorez_ProvMod()
		{
			string query = @"
        SELECT COUNT(*) 
FROM Proyavlen_Photorez_ProvMod 
WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label.Text = count.ToString(); // Обновление значения label11
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
			if (int.TryParse(label.Text, out int labelValue) && labelValue > 0)
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

		private void label_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking();
			}
			else
			{
				StopBlinking(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}




		private void Load_Proyavlen_Photorez_Ult1()
		{
			string query = @"
        SELECT COUNT(*) 
FROM Proyavlen_Photorez_Ult1 
WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

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





		private void Load_Proyavlen_Photorez_Ult2()
		{
			string query = @"
        SELECT COUNT(*) 
FROM Proyavlen_Photorez_Ult2 
WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

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

		//private void button1_Click_1(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_KisOch_Technolog tmd = new Himich_Podgotov_KisOch_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button4_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_Microtrav_Technolog tmd = new Himich_Podgotov_Microtrav_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button5_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_Cu_Technolog tmd = new Himich_Podgotov_Cu_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button6_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_Sn_Technolog tmd = new Himich_Podgotov_Sn_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button7_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_CuEl1920_Technolog tmd = new Himich_Podgotov_CuEl1920_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button8_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_CuEl2122_Technolog tmd = new Himich_Podgotov_CuEl2122_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button2_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_CuEl2324_Technolog tmd = new Himich_Podgotov_CuEl2324_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button9_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_SnEl_Technolog tmd = new Himich_Podgotov_SnEl_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button4_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_Microtrav_Technolog tmd = new Himich_Podgotov_Microtrav_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button5_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_Cu_Technolog tmd = new Himich_Podgotov_Cu_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button6_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_Sn_Technolog tmd = new Himich_Podgotov_Sn_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button7_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_CuEl1819_Technolog tmd = new Himich_Podgotov_CuEl1819_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button8_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_CuEl2021_Technolog tmd = new Himich_Podgotov_CuEl2021_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}

		//private void button9_Click_2(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Himich_Podgotov_SnEl_Technolog tmd = new Himich_Podgotov_SnEl_Technolog();
		//	tmd.ShowDialog();
		//	this.Show();
		//}


		//		private void Load_Trav_Med_2()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Trav_Med_2 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label4.Text = count.ToString(); // Обновление значения label11
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



		//		private void InitializeTimer3()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer3 = new Timer();
		//			blinkTimer3.Interval = 350; // 350 миллисекунд
		//			blinkTimer3.Tick += BlinkTimer_Tick3;
		//		}


		//		private void StartBlinking3() // Метод для запуска мигания
		//		{
		//			isRed3 = false; // Сбросим значение isRed
		//			blinkTimer3.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking3() // Метод для остановки мигания
		//		{
		//			blinkTimer3.Stop(); // Останавливаем таймер
		//			button4.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick3(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label4.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed3)
		//				{
		//					button4.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button4.BackColor = Color.Red;
		//				}
		//				isRed3 = !isRed3; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking3(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label4_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label4.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking3();
		//			}
		//			else
		//			{
		//				StopBlinking3(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}

		//		private void Load_Per_Obr()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Per_Obr 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

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



		//		private void InitializeTimer4()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer4 = new Timer();
		//			blinkTimer4.Interval = 350; // 450 миллисекунд
		//			blinkTimer4.Tick += BlinkTimer_Tick4;
		//		}


		//		private void StartBlinking4() // Метод для запуска мигания
		//		{
		//			isRed4 = false; // Сбросим значение isRed
		//			blinkTimer4.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking4() // Метод для остановки мигания
		//		{
		//			blinkTimer4.Stop(); // Останавливаем таймер
		//			button5.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick4(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label5.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed4)
		//				{
		//					button5.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button5.BackColor = Color.Red;
		//				}
		//				isRed4 = !isRed4; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking4(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label5_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label5.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking4();
		//			}
		//			else
		//			{
		//				StopBlinking4(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}


		//			private void Load_Pryam_Metal()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Pryam_Metal 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

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



		//		private void InitializeTimer5()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer5 = new Timer();
		//			blinkTimer5.Interval = 350; // 560 миллисекунд
		//			blinkTimer5.Tick += BlinkTimer_Tick5;
		//		}


		//		private void StartBlinking5() // Метод для запуска мигания
		//		{
		//			isRed5 = false; // Сбросим значение isRed
		//			blinkTimer5.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking5() // Метод для остановки мигания
		//		{
		//			blinkTimer5.Stop(); // Останавливаем таймер
		//			button7.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick5(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label7.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed5)
		//				{
		//					button7.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button7.BackColor = Color.Red;
		//				}
		//				isRed5 = !isRed5; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking5(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label7_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label7.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking5();
		//			}
		//			else
		//			{
		//				StopBlinking5(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}












		//		private void Load_Himich_Podgotov()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Himich_Podgotov 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

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



		//		private void InitializeTimer6()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer6 = new Timer();
		//			blinkTimer6.Interval = 350; // 660 миллисекунд
		//			blinkTimer6.Tick += BlinkTimer_Tick6;
		//		}


		//		private void StartBlinking6() // Метод для запуска мигания
		//		{
		//			isRed6 = false; // Сбросим значение isRed
		//			blinkTimer6.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking6() // Метод для остановки мигания
		//		{
		//			blinkTimer6.Stop(); // Останавливаем таймер
		//			button8.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick6(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label8.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed6)
		//				{
		//					button8.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button8.BackColor = Color.Red;
		//				}
		//				isRed6 = !isRed6; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking6(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label8_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label8.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking6();
		//			}
		//			else
		//			{
		//				StopBlinking6(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}

		//		private void Load_Himich_Podgotov()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Himich_Podgotov 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

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



		//		private void InitializeTimer7()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer7 = new Timer();
		//			blinkTimer7.Interval = 350; // 770 миллисекунд
		//			blinkTimer7.Tick += BlinkTimer_Tick7;
		//		}


		//		private void StartBlinking7() // Метод для запуска мигания
		//		{
		//			isRed7 = false; // Сбросим значение isRed
		//			blinkTimer7.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking7() // Метод для остановки мигания
		//		{
		//			blinkTimer7.Stop(); // Останавливаем таймер
		//			button10.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick7(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label10.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed7)
		//				{
		//					button10.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button10.BackColor = Color.Red;
		//				}
		//				isRed7 = !isRed7; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking7(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label10_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label10.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking7();
		//			}
		//			else
		//			{
		//				StopBlinking7(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}

		//		private void Load_Snatie_Photorez()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Snatie_Photorez 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

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



		//		private void InitializeTimer8()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer8 = new Timer();
		//			blinkTimer8.Interval = 350; // 880 миллисекунд
		//			blinkTimer8.Tick += BlinkTimer_Tick8;
		//		}


		//		private void StartBlinking8() // Метод для запуска мигания
		//		{
		//			isRed8 = false; // Сбросим значение isRed
		//			blinkTimer8.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking8() // Метод для остановки мигания
		//		{
		//			blinkTimer8.Stop(); // Останавливаем таймер
		//			button11.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick8(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label11.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed8)
		//				{
		//					button11.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button11.BackColor = Color.Red;
		//				}
		//				isRed8 = !isRed8; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking8(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label11_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label11.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking8();
		//			}
		//			else
		//			{
		//				StopBlinking8(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}













		//		private void Load_Snatie_Olova()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Snatie_Olova 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label12.Text = count.ToString(); // Обновление значения label12
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



		//		private void InitializeTimer9()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer9 = new Timer();
		//			blinkTimer9.Interval = 350; // 990 миллисекунд
		//			blinkTimer9.Tick += BlinkTimer_Tick9;
		//		}


		//		private void StartBlinking9() // Метод для запуска мигания
		//		{
		//			isRed9 = false; // Сбросим значение isRed
		//			blinkTimer9.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking9() // Метод для остановки мигания
		//		{
		//			blinkTimer9.Stop(); // Останавливаем таймер
		//			button12.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick9(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label12.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed9)
		//				{
		//					button12.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button12.BackColor = Color.Red;
		//				}
		//				isRed9 = !isRed9; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking9(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label12_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label12.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking9();
		//			}
		//			else
		//			{
		//				StopBlinking9(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}



		//		private void Load_Lushenie()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Lushenie 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label2.Text = count.ToString(); // Обновление значения label13
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



		//		private void InitializeTimer10()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer10 = new Timer();
		//			blinkTimer10.Interval = 350; // 10100 миллисекунд
		//			blinkTimer10.Tick += BlinkTimer_Tick10;
		//		}


		//		private void StartBlinking10() // Метод для запуска мигания
		//		{
		//			isRed10 = false; // Сбросим значение isRed
		//			blinkTimer10.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking10() // Метод для остановки мигания
		//		{
		//			blinkTimer10.Stop(); // Останавливаем таймер
		//			button13.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick10(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label2.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed10)
		//				{
		//					button13.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button13.BackColor = Color.Red;
		//				}
		//				isRed10 = !isRed10; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking10(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label2_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label2.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking10();
		//			}
		//			else
		//			{
		//				StopBlinking10(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}

		//		private void Load_Proyavlen_Photorez()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Proyavlen_Photorez 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label14.Text = count.ToString(); // Обновление значения label14
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



		//		private void InitializeTimer11()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer11 = new Timer();
		//			blinkTimer11.Interval = 350; // 11110 миллисекунд
		//			blinkTimer11.Tick += BlinkTimer_Tick11;
		//		}


		//		private void StartBlinking11() // Метод для запуска мигания
		//		{
		//			isRed11 = false; // Сбросим значение isRed
		//			blinkTimer11.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking11() // Метод для остановки мигания
		//		{
		//			blinkTimer11.Stop(); // Останавливаем таймер
		//			button14.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick11(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label14.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed11)
		//				{
		//					button14.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button14.BackColor = Color.Red;
		//				}
		//				isRed11 = !isRed11; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking11(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label14_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label14.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking11();
		//			}
		//			else
		//			{
		//				StopBlinking11(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}

		//		private void Load_Proyavlen_Photorez()
		//		{
		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Proyavlen_Photorez 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";


		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label15.Text = count.ToString(); // Обновление значения label15
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



		//		private void InitializeTimer12()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer12 = new Timer();
		//			blinkTimer12.Interval = 350; // 12120 миллисекунд
		//			blinkTimer12.Tick += BlinkTimer_Tick12;
		//		}


		//		private void StartBlinking12() // Метод для запуска мигания
		//		{
		//			isRed12 = false; // Сбросим значение isRed
		//			blinkTimer12.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking12() // Метод для остановки мигания
		//		{
		//			blinkTimer12.Stop(); // Останавливаем таймер
		//			button15.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick12(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label15.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed12)
		//				{
		//					button15.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button15.BackColor = Color.Red;
		//				}
		//				isRed12 = !isRed12; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking12(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label15_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label15.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking12();
		//			}
		//			else
		//			{
		//				StopBlinking12(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}

		//		private void Load_Himich_Podgotov()
		//		{

		//			string query = @"
		//        SELECT COUNT(*) 
		//FROM Himich_Podgotov 
		//WHERE ([FIO_tech] IS NULL OR [FIO_tech] = '') 
		//   OR ([Date_tech] IS NULL OR [Date_tech] = '');";

		//			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//			{
		//				try
		//				{
		//					connection.Open();
		//					SqlCommand command = new SqlCommand(query, connection);
		//					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
		//					label3.Text = count.ToString(); // Обновление значения label3
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



		//		private void InitializeTimer13()
		//		{
		//			// Инициализация словаря связей меток и кнопок

		//			// Добавьте остальные пары меток и кнопок

		//			// Настройка таймера
		//			blinkTimer13 = new Timer();
		//			blinkTimer13.Interval = 350; // 13130 миллисекунд
		//			blinkTimer13.Tick += BlinkTimer_Tick13;
		//		}


		//		private void StartBlinking13() // Метод для запуска мигания
		//		{
		//			isRed13 = false; // Сбросим значение isRed
		//			blinkTimer13.Start(); // Запускаем таймер
		//		}

		//		private void StopBlinking13() // Метод для остановки мигания
		//		{
		//			blinkTimer13.Stop(); // Останавливаем таймер
		//			button3.BackColor = Color.Green; // Сбрасываем цвет кнопки
		//		}

		//		private void BlinkTimer_Tick13(object sender, EventArgs e)
		//		{
		//			// Проверяем, больше ли значение в label, чем 0
		//			if (int.TryParse(label3.Text, out int labelValue) && labelValue > 0)
		//			{
		//				// Меняем цвет кнопки в зависимости от isRed
		//				if (isRed13)
		//				{
		//					button3.BackColor = Color.Blue;
		//				}
		//				else
		//				{
		//					button3.BackColor = Color.Red;
		//				}
		//				isRed13 = !isRed13; // Инвертируем значение isRed
		//			}
		//			else
		//			{
		//				StopBlinking13(); // Останавливаем мигание, если значение в label не больше 0
		//			}
		//		}

		//		private void label3_TextChanged(object sender, EventArgs e)
		//		{
		//			if (int.TryParse(label3.Text, out int labelValue) && labelValue > 0)
		//			{
		//				StartBlinking13();
		//			}
		//			else
		//			{
		//				StopBlinking13(); // Останавливаем мигание, если значение меньше или равно 0
		//			}
		//		}
	}
}
