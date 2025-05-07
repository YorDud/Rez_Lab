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
using Rez_Lab.Black_Hole_BAK1012;
using Rez_Lab.Black_Hole_BAK1022;
using Rez_Lab.Black_Hole_Cleaner;
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
    public partial class Start_Black_Hole_Cleaner_admin : Form
    {

        
        public Start_Black_Hole_Cleaner_admin()
        {
            InitializeComponent();
            //this.MaximizeBox = false;


        }
        public Start_Black_Hole_Cleaner_admin(Avtorize aavtorize)
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Start_Black_Hole_Cleaner_admin_Load(object sender, EventArgs e)
        {
            

            label1.Text = WC.fio;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lab_Form_admin lfa = new Lab_Form_admin();
            lfa.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_LogsCheck_Form alf = new Admin_LogsCheck_Form();
            alf.ShowDialog();
            this.Show();
        }

		private void button2_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Cleaner_Admin TM1A = new Black_Hole_Cleaner_Admin();
			TM1A.ShowDialog();
			this.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Conditioner_Admin TM2A = new Black_Hole_Conditioner_Admin();
			TM2A.ShowDialog();
			this.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Microtrav_1_Admin poa = new Black_Hole_Microtrav_1_Admin();
			poa.ShowDialog();
			this.Show();

			
		}

		private void button6_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_Microtrav_23_Admin poa = new Black_Hole_Microtrav_23_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BHC1_Admin poa = new Black_Hole_BHC1_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BHC2_Admin poa = new Black_Hole_BHC2_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK1_Admin poa = new Black_Hole_BAK1_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK2_Admin poa = new Black_Hole_BAK2_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			this.Hide();
			Snatie_Photorez_Admin poa = new Snatie_Photorez_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			this.Hide();
			Snatie_Olova_Admin poa = new Snatie_Olova_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			this.Hide();
			Lushenie_Admin poa = new Lushenie_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			this.Hide();
			Proyavlen_Photorez_Admin poa = new Proyavlen_Photorez_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			this.Hide();
			Proyavlen_Photomask_Admin poa = new Proyavlen_Photomask_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Himich_Podgotov_Admin poa = new Himich_Podgotov_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			this.Hide();
			New_Worker poa = new New_Worker();
			poa.ShowDialog();
			this.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
			//Avtorize av = new Avtorize();
			
			
		}

		private void button12_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK1012_Admin poa = new Black_Hole_BAK1012_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button22_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK1022_Admin poa = new Black_Hole_BAK1022_Admin();
			poa.ShowDialog();
			this.Show();
		}
	}
}
