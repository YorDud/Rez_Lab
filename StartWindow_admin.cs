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
using Rez_Lab.Trav_Podv;

namespace Rez_Lab
{
    public partial class StartWindow_admin : Form
    {

        
        public StartWindow_admin()
        {
            InitializeComponent();
            //this.MaximizeBox = false;


        }
        public StartWindow_admin(Avtorize aavtorize)
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StartWindow_admin_Load(object sender, EventArgs e)
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
			Start_Amm_Prom_admin TM1A = new Start_Amm_Prom_admin();
			TM1A.ShowDialog();
			this.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.Hide();
			Trav_Med_2_Admin TM2A = new Trav_Med_2_Admin();
			TM2A.ShowDialog();
			this.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Perm_Obra_admin poa = new Start_Perm_Obra_admin();
			poa.ShowDialog();
			this.Show();

			
		}

		private void button6_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Black_Hole_Cleaner_admin TM1A = new Start_Black_Hole_Cleaner_admin();
			TM1A.ShowDialog();
			this.Show();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Pryam_Metal_admin poa = new Start_Pryam_Metal_admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Galvan_Zat_Cleaner_admin poa = new Start_Galvan_Zat_Cleaner_admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Galvan_Line_MG_Cleaner_admin poa = new Start_Galvan_Line_MG_Cleaner_admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Galvan_Line_PAL_Cleaner_admin poa = new Start_Galvan_Line_PAL_Cleaner_admin();
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
			Start_Proyavlen_Photorez_admin poa = new Start_Proyavlen_Photorez_admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Proyavlen_Photomask_admin poa = new Start_Proyavlen_Photomask_admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Himich_Podgotov_Cleaner_admin poa = new Start_Himich_Podgotov_Cleaner_admin();
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

		

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			Save_Excel poa = new Save_Excel();
			poa.ShowDialog();
			this.Show();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Trav_Podv_Admin poa = new Trav_Podv_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button28_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Photorez_admin poa = new Start_Photorez_admin();
			poa.ShowDialog();
			this.Show();

		}

		private void button26_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Zolot_admin poa = new Start_Zolot_admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button25_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_DES_admin poa = new Start_DES_admin();
			poa.ShowDialog();
			this.Show();

		}

		private void button24_Click(object sender, EventArgs e)
		{
			this.Hide();
			Start_Oxide_admin poa = new Start_Oxide_admin();
			poa.ShowDialog();
			this.Show();
		}
	}
}
