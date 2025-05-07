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
using Rez_Lab.Black_Hole_Cleaner;
using Rez_Lab.Galvan_Line_MG;
using Rez_Lab.Galvan_Line_MG_Cu;
using Rez_Lab.Galvan_Line_MG_CuEl1819;
using Rez_Lab.Galvan_Line_MG_CuEl2021;
using Rez_Lab.Galvan_Line_MG_KisOch;
using Rez_Lab.Galvan_Line_MG_Microtrav;
using Rez_Lab.Galvan_Line_MG_Sn;
using Rez_Lab.Galvan_Line_MG_SnEl;
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
    public partial class Start_Galvan_Line_MG_Cleaner_admin : Form
    {

        
        public Start_Galvan_Line_MG_Cleaner_admin()
        {
            InitializeComponent();
            //this.MaximizeBox = false;


        }
        public Start_Galvan_Line_MG_Cleaner_admin(Avtorize aavtorize)
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Start_Galvan_Line_MG_Cleaner_admin_Load(object sender, EventArgs e)
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
			Galvan_Line_MG_Microtrav_Admin TM2A = new Galvan_Line_MG_Microtrav_Admin();
			TM2A.ShowDialog();
			this.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_MG_Cu_Admin poa = new Galvan_Line_MG_Cu_Admin();
			poa.ShowDialog();
			this.Show();

			
		}

		private void button6_Click(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_MG_Sn_Admin poa = new Galvan_Line_MG_Sn_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_MG_CuEl1819_Admin poa = new Galvan_Line_MG_CuEl1819_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_MG_CuEl2021_Admin poa = new Galvan_Line_MG_CuEl2021_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_MG_SnEl_Admin poa = new Galvan_Line_MG_SnEl_Admin();
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

		private void button1_Click_1(object sender, EventArgs e)
		{
			this.Hide();
			Galvan_Line_MG_KisOch_Admin poa = new Galvan_Line_MG_KisOch_Admin();
			poa.ShowDialog();
			this.Show();
		}

		private void button2_Click_2(object sender, EventArgs e)
		{
			this.Hide();
			Trav_Podv_Admin poa = new Trav_Podv_Admin();
			poa.ShowDialog();
			this.Show();
		}
	}
}
