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
    public partial class Start_Black_Hole_Cleaner_laborant : Form
    {
        public Start_Black_Hole_Cleaner_laborant()
        {
            InitializeComponent();
            //this.MaximizeBox = false;
        }

        private void StartWindow_worker_Load(object sender, EventArgs e)
        {
            //LoadUserData();
            label1.Text = WC.fio;
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
			Galvan_Line_MG_Laborant tmc = new Galvan_Line_MG_Laborant();
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

		private void button12_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK1012_Laborant tmc = new Black_Hole_BAK1012_Laborant();
			tmc.ShowDialog();
			this.Show();
		}

		private void button22_Click(object sender, EventArgs e)
		{
			this.Hide();
			Black_Hole_BAK1022_Laborant tmc = new Black_Hole_BAK1022_Laborant();
			tmc.ShowDialog();
			this.Show();
		}
	}
}
