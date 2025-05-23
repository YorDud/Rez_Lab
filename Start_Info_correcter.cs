﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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
	public partial class Start_Info_correcter : Form
	{

		private Timer timer;
		private Timer timer2;

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
		private Timer blinkTimer15;
		private Timer blinkTimer16;
		private Timer blinkTimer17;
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
		private bool isRed15 = false;
		private bool isRed16 = false;
		private bool isRed17 = false;

		public Start_Info_correcter()
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
			InitializeTimer5();
			InitializeTimer6();
			InitializeTimer7();
			InitializeTimer8();
			InitializeTimer9();
			InitializeTimer10();
			InitializeTimer11();
			InitializeTimer12();
			InitializeTimer13();
			InitializeTimer14();
			InitializeTimer15();
			InitializeTimer16();
			InitializeTimer17();

			// Cирена новый анализ
			timer2 = new Timer();
			timer2.Interval = 180000; // Интервал в миллисекундах (10 секунд)
			timer2.Tick += Timer_Tick_Sirena; // Подписка на событие Tick
			timer2.Start();



		}

		private void Timer_Tick_Sirena(object sender, EventArgs e)
		{
			// Вызов вашей функции
			Load_All_Sirens();
		}

		private SoundPlayer sirenPlayer;
		private void Load_All_Sirens()
		{
			string query = @"
    SELECT (
    (SELECT COUNT(*) 
    FROM Snatie_Olova 
    WHERE ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '')
    AND (
        ([Sn_Olov_Correction] IS NOT NULL AND [Sn_Olov_Correction] <> '') 
        OR ([Сomment] IS NOT NULL AND [Сomment] <> '')
    )
) + (
    SELECT COUNT(*) 
    FROM Trav_Med_1
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '')
        AND (
            ([Trav_Med_Correction_Mat] IS NOT NULL AND [Trav_Med_Correction_Mat] <> '')
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '')
            OR ([Trav_Med_Correction_Score] IS NOT NULL AND [Trav_Med_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Amm_Prom
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Trav_Med_Correction_Mat] IS NOT NULL AND [Trav_Med_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Trav_Med_Correction_Score] IS NOT NULL AND [Trav_Med_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Trav_Med_2 
    WHERE ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '')
    AND (
        ([Trav_Med_2_Correction_Mat] IS NOT NULL AND [Trav_Med_2_Correction_Mat] <> '') 
        OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
        OR ([Trav_Med_2_Correction_Score] IS NOT NULL AND [Trav_Med_2_Correction_Score] <> '')
    )
) + (
    SELECT COUNT(*) 
    FROM Snatie_Photorez_2 
    WHERE ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '')
    AND (
        ([Sn_Photorez_1_Correction] IS NOT NULL AND [Sn_Photorez_1_Correction] <> '') 
        OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
        OR ([Sn_Photorez_2_Correction] IS NOT NULL AND [Sn_Photorez_2_Correction] <> '') 
        OR ([Sn_Photorez_3_Correction] IS NOT NULL AND [Sn_Photorez_3_Correction] <> '')
    )
) + (
    SELECT COUNT(*) 
    FROM Pryam_Metal_Cond
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pr_Met_1_Correction_Mat] IS NOT NULL AND [Pr_Met_1_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pr_Met_1_Correction_Score] IS NOT NULL AND [Pr_Met_1_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Pryam_Metal_PredMet
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pr_Met_2_Correction_Mat] IS NOT NULL AND [Pr_Met_2_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pr_Met_2_Correction_Score] IS NOT NULL AND [Pr_Met_2_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Pryam_Metal_PredMet303
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pr_Met_2_Correction_Mat] IS NOT NULL AND [Pr_Met_2_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pr_Met_2_Correction_Score] IS NOT NULL AND [Pr_Met_2_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Pryam_Metal_Met
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pr_Met_3_Correction_Mat] IS NOT NULL AND [Pr_Met_3_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pr_Met_3_Correction_Score] IS NOT NULL AND [Pr_Met_3_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Pryam_Metal_Uskor
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pr_Met_4_Correction_Mat] IS NOT NULL AND [Pr_Met_4_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pr_Met_4_Correction_Score] IS NOT NULL AND [Pr_Met_4_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Proyavlen_Photorez_ProvMod
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pro_Photorez_1_Correction_Mat] IS NOT NULL AND [Pro_Photorez_1_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pro_Photorez_1_Correction_Score] IS NOT NULL AND [Pro_Photorez_1_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Proyavlen_Photorez_Ult1
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pro_Photorez_2_Correction_Mat] IS NOT NULL AND [Pro_Photorez_2_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pro_Photorez_2_Correction_Score] IS NOT NULL AND [Pro_Photorez_2_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Proyavlen_Photorez_Ult2
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pro_Photorez_3_Correction_Mat] IS NOT NULL AND [Pro_Photorez_3_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pro_Photorez_3_Correction_Score] IS NOT NULL AND [Pro_Photorez_3_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Proyavlen_Photomask_ProvMod
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pro_Photorez_1_Correction_Mat] IS NOT NULL AND [Pro_Photorez_1_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pro_Photorez_1_Correction_Score] IS NOT NULL AND [Pro_Photorez_1_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Proyavlen_Photomask_Ult1
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pro_Photomask_2_Correction_Mat] IS NOT NULL AND [Pro_Photomask_2_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pro_Photomask_2_Correction_Score] IS NOT NULL AND [Pro_Photomask_2_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Proyavlen_Photomask_Ult2
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Pro_Photomask_3_Correction_Mat] IS NOT NULL AND [Pro_Photomask_3_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Pro_Photomask_3_Correction_Score] IS NOT NULL AND [Pro_Photomask_3_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Perm_Obra_Sens
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Per_Obr_1_Correction_Mat] IS NOT NULL AND [Per_Obr_1_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Per_Obr_1_Correction_Score] IS NOT NULL AND [Per_Obr_1_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Perm_Obra_RasOkis
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Per_Obr_2_Correction_Mat] IS NOT NULL AND [Per_Obr_2_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Per_Obr_2_Correction_Score] IS NOT NULL AND [Per_Obr_2_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Perm_Obra_PredNe
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Per_Obr_3_Correction_Mat] IS NOT NULL AND [Per_Obr_3_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Per_Obr_3_Correction_Score] IS NOT NULL AND [Per_Obr_3_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Perm_Obra_PredNe2
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Per_Obr_4_Correction_Mat] IS NOT NULL AND [Per_Obr_4_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Per_Obr_4_Correction_Score] IS NOT NULL AND [Per_Obr_4_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Lushenie 
    WHERE ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
    AND (
        ([Lushen_Correction_Mat] IS NOT NULL AND [Lushen_Correction_Mat] <> '') 
        OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
        OR ([Lushen_Correction_Score] IS NOT NULL AND [Lushen_Correction_Score] <> '')
    )
) + (
    SELECT COUNT(*) 
    FROM Himich_Podgotov_KisOch
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Him_Podg_1_Correction_Mat] IS NOT NULL AND [Him_Podg_1_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Him_Podg_1_Correction_Score] IS NOT NULL AND [Him_Podg_1_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Himich_Podgotov_Microtrav
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Him_Podg_2_Correction_Mat] IS NOT NULL AND [Him_Podg_2_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Him_Podg_2_Correction_Score] IS NOT NULL AND [Him_Podg_2_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Himich_Podgotov_Dek
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Him_Podg_3_Correction_Mat] IS NOT NULL AND [Him_Podg_3_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Him_Podg_3_Correction_Score] IS NOT NULL AND [Him_Podg_3_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Zat_Cu
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Zat_1_Cu_Correction_Mat] IS NOT NULL AND [Gal_Zat_1_Cu_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Zat_1_Cu_Correction_Score] IS NOT NULL AND [Gal_Zat_1_Cu_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Zat_CuEl12
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND ([Gal_Zat_2_Correction_Mat] <> 'NaCl' OR [Gal_Zat_2_Correction_Mat] IS NULL)
        AND (
            ([Gal_Zat_2_Correction_Mat] IS NOT NULL AND [Gal_Zat_2_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Zat_2_Correction_Score] IS NOT NULL AND [Gal_Zat_2_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Zat_CuEl34
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND ([Gal_Zat_3_Correction_Mat] <> 'NaCl' OR [Gal_Zat_3_Correction_Mat] IS NULL)
        AND (
            ([Gal_Zat_3_Correction_Mat] IS NOT NULL AND [Gal_Zat_3_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Zat_3_Correction_Score] IS NOT NULL AND [Gal_Zat_3_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_PAL_Cu
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Line_3_Cu_Correction_Mat] IS NOT NULL AND [Gal_Line_3_Cu_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_3_Cu_Correction_Score] IS NOT NULL AND [Gal_Line_3_Cu_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_PAL_KisOch
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Line_1_Correction_Mat] IS NOT NULL AND [Gal_Line_1_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_1_Correction_Score] IS NOT NULL AND [Gal_Line_1_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Trav_Podv_PAL
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Trav_Podv_PAL_Correction_Mat] IS NOT NULL AND [Trav_Podv_PAL_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Trav_Podv_PAL_Correction_Score] IS NOT NULL AND [Trav_Podv_PAL_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_PAL_Microtrav
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Line_2_Correction_Mat] IS NOT NULL AND [Gal_Line_2_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_2_Correction_Score] IS NOT NULL AND [Gal_Line_2_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_PAL_CuEl1920
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND ([Gal_Line_4_Correction_Mat] <> 'NaCl' OR [Gal_Line_4_Correction_Mat] IS NULL)
        AND (
            ([Gal_Line_4_Correction_Mat] IS NOT NULL AND [Gal_Line_4_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_4_Correction_Score] IS NOT NULL AND [Gal_Line_4_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_PAL_CuEl2122
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND ([Gal_Line_5_Correction_Mat] <> 'NaCl' OR [Gal_Line_5_Correction_Mat] IS NULL)
        AND (
            ([Gal_Line_5_Correction_Mat] IS NOT NULL AND [Gal_Line_5_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_5_Correction_Score] IS NOT NULL AND [Gal_Line_5_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_PAL_CuEl2324
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND ([Gal_Line_6_Correction_Mat] <> 'NaCl' OR [Gal_Line_6_Correction_Mat] IS NULL)
        AND (
            ([Gal_Line_6_Correction_Mat] IS NOT NULL AND [Gal_Line_6_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_6_Correction_Score] IS NOT NULL AND [Gal_Line_6_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_PAL_SnEl
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Line_7_Correction_Mat] IS NOT NULL AND [Gal_Line_7_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_7_Correction_Score] IS NOT NULL AND [Gal_Line_7_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_PAL_Sn
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Line_3_Sn_Correction_Mat] IS NOT NULL AND [Gal_Line_3_Sn_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_3_Sn_Correction_Score] IS NOT NULL AND [Gal_Line_3_Sn_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_MG_Cu
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Line_3_Cu_Correction_Mat] IS NOT NULL AND [Gal_Line_3_Cu_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_3_Cu_Correction_Score] IS NOT NULL AND [Gal_Line_3_Cu_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_MG_KisOch
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Line_1_Correction_Mat] IS NOT NULL AND [Gal_Line_1_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_1_Correction_Score] IS NOT NULL AND [Gal_Line_1_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_MG_Microtrav
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Line_2_Correction_Mat] IS NOT NULL AND [Gal_Line_2_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_2_Correction_Score] IS NOT NULL AND [Gal_Line_2_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Trav_Podv
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Trav_Podv_Correction_Mat] IS NOT NULL AND [Trav_Podv_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Trav_Podv_Correction_Score] IS NOT NULL AND [Trav_Podv_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_MG_CuEl1819
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND ([Gal_Line_4_Correction_Mat] <> 'NaCl' OR [Gal_Line_4_Correction_Mat] IS NULL)
        AND (
            ([Gal_Line_4_Correction_Mat] IS NOT NULL AND [Gal_Line_4_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_4_Correction_Score] IS NOT NULL AND [Gal_Line_4_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_MG_CuEl2021
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND ([Gal_Line_5_Correction_Mat] <> 'NaCl' OR [Gal_Line_5_Correction_Mat] IS NULL)
        AND (
            ([Gal_Line_5_Correction_Mat] IS NOT NULL AND [Gal_Line_5_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_5_Correction_Score] IS NOT NULL AND [Gal_Line_5_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_MG_SnEl
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Line_6_Correction_Mat] IS NOT NULL AND [Gal_Line_6_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_6_Correction_Score] IS NOT NULL AND [Gal_Line_6_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Galvan_Line_MG_Sn
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Gal_Line_3_Sn_Correction_Mat] IS NOT NULL AND [Gal_Line_3_Sn_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Gal_Line_3_Sn_Correction_Score] IS NOT NULL AND [Gal_Line_3_Sn_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Black_Hole_Cleaner
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Black_Hole_1_Correction_Mat] IS NOT NULL AND [Black_Hole_1_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Black_Hole_1_Correction_Score] IS NOT NULL AND [Black_Hole_1_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Black_Hole_BAK1012
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Black_Hole_1_Correction_Mat] IS NOT NULL AND [Black_Hole_1_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Black_Hole_1_Correction_Score] IS NOT NULL AND [Black_Hole_1_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Black_Hole_BAK1022
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Black_Hole_1_Correction_Mat] IS NOT NULL AND [Black_Hole_1_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Black_Hole_1_Correction_Score] IS NOT NULL AND [Black_Hole_1_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Black_Hole_Conditioner
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Black_Hole_2_Correction_Mat] IS NOT NULL AND [Black_Hole_2_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Black_Hole_2_Correction_Score] IS NOT NULL AND [Black_Hole_2_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Black_Hole_Microtrav_1
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Black_Hole_3_Correction_Mat] IS NOT NULL AND [Black_Hole_3_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Black_Hole_3_Correction_Score] IS NOT NULL AND [Black_Hole_3_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Black_Hole_Microtrav_23
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Black_Hole_4_Correction_Mat] IS NOT NULL AND [Black_Hole_4_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Black_Hole_4_Correction_Score] IS NOT NULL AND [Black_Hole_4_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Black_Hole_BHC1
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Black_Hole_5_Correction_Mat] IS NOT NULL AND [Black_Hole_5_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Black_Hole_5_Correction_Score] IS NOT NULL AND [Black_Hole_5_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Black_Hole_BHC2
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Black_Hole_6_Correction_Mat] IS NOT NULL AND [Black_Hole_6_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Black_Hole_6_Correction_Score] IS NOT NULL AND [Black_Hole_6_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Black_Hole_BAK1
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Black_Hole_7_Correction_Mat] IS NOT NULL AND [Black_Hole_7_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Black_Hole_7_Correction_Score] IS NOT NULL AND [Black_Hole_7_Correction_Score] <> '')
        )
) + (
    SELECT COUNT(*) 
    FROM Black_Hole_BAK2
    WHERE 
        ([Start_corr] IS NULL OR [Start_corr] = '') AND ([Сompleted] IS NULL OR [Сompleted] = '') 
        AND (
            ([Black_Hole_8_Correction_Mat] IS NOT NULL AND [Black_Hole_8_Correction_Mat] <> '') 
            OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
            OR ([Black_Hole_8_Correction_Score] IS NOT NULL AND [Black_Hole_8_Correction_Score] <> '')
        )
)
) AS TotalCount;
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar();

					DayOfWeek today = DateTime.Today.DayOfWeek;

					if (count > 0 && today != DayOfWeek.Saturday && today != DayOfWeek.Sunday)
					{
						StartSiren();
					}
					else
					{
						StopSiren();
					}
				}
				catch (SqlException ex)
				{
					MessageBox.Show("Произошла ошибка при обращении к базе данных: " + ex.Message);
				}
				finally
				{
					connection.Close();
				}
			}
		}




		private void StartSiren()
		{
			if (sirenPlayer == null)
			{
				sirenPlayer = new SoundPlayer(Path.Combine(Application.StartupPath, "Resources", "NewCorr.wav"));
				// Укажите путь к вашему звуковому файлу
			}
			sirenPlayer.Play(); //Звук зацикливается PlayLooping
		}

		private void StopSiren()
		{
			if (sirenPlayer != null)
			{
				sirenPlayer.Stop();
			}
		}



		private void Start_Info_correcter_Load(object sender, EventArgs e)
		{
			//label1.Text = WC.fio.ToString();
			//label2.Text = WC.fio.ToString();
			Load_All_Sirens();

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
			Load_Trav_Med_1();
			Load_Trav_Med_2();
			Load_Snatie_Photorez();
			Load_Snatie_Olova();
			Load_Pryam_Metal();
			Load_Proyavlen_Photorez();
			Load_Proyavlen_Photomask();
			Load_Per_Obr();
			Load_Lushenie();
			Load_Himich_Podgotov();
			Load_Galvan_Zat();
			Load_Galvan_Zat();
			Load_Galvan_Line_MG();
			Load_Galvan_Line_PAL();
			Load_Black_Hole();
			Load_Himich_Photorez();
			Load_Zolot();
			Load_DES();
			Load_Oxide();
		}


		private void Load_Himich_Photorez()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Himich_Photorez_KisOch
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Him_Podg_1_Correction_Mat] IS NOT NULL AND [Him_Podg_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Him_Podg_1_Correction_Score] IS NOT NULL AND [Him_Podg_1_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Himich_Photorez_Microtrav
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Him_Podg_2_Correction_Mat] IS NOT NULL AND [Him_Podg_2_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Him_Podg_2_Correction_Score] IS NOT NULL AND [Him_Podg_2_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Himich_Photorez_Dek
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Him_Podg_3_Correction_Mat] IS NOT NULL AND [Him_Podg_3_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Him_Podg_3_Correction_Score] IS NOT NULL AND [Him_Podg_3_Correction_Score] <> '')
            )
    ) AS CombinedCounts;
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label18.Text = count.ToString(); // Обновление значения label11
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

		private void Load_Trav_Med_1()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT COUNT(*) AS Counts
        FROM Trav_Med_1
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '')
            AND (
                ([Trav_Med_Correction_Mat] IS NOT NULL AND [Trav_Med_Correction_Mat] <> '')
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '')
                OR ([Trav_Med_Correction_Score] IS NOT NULL AND [Trav_Med_Correction_Score] <> '')
            )
        UNION ALL
        SELECT COUNT(*) AS Counts
        FROM Amm_Prom
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Trav_Med_Correction_Mat] IS NOT NULL AND [Trav_Med_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') 
                OR ([Trav_Med_Correction_Score] IS NOT NULL AND [Trav_Med_Correction_Score] <> '')
            )
    ) AS CombinedCounts; 
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar();
					// Обновление значения label3
					label3.Text = count.ToString();
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

		private void Load_Trav_Med_2()
		{
			string query = @"
        SELECT COUNT(*) 
FROM Trav_Med_2 
WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
AND (
    ([Trav_Med_2_Correction_Mat] IS NOT NULL AND [Trav_Med_2_Correction_Mat] <> '') OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
    ([Trav_Med_2_Correction_Score] IS NOT NULL AND [Trav_Med_2_Correction_Score] <> '')
);
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar();
					// Обновление значения label3
					label4.Text = count.ToString();
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

		private void Load_Snatie_Photorez()
		{
			string query = @"
        SELECT COUNT(*) 
FROM Snatie_Photorez_2 
WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
AND (
    ([Sn_Photorez_1_Correction] IS NOT NULL AND [Sn_Photorez_1_Correction] <> '') OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
    ([Sn_Photorez_2_Correction] IS NOT NULL AND [Sn_Photorez_2_Correction] <> '') OR 
    ([Sn_Photorez_3_Correction] IS NOT NULL AND [Sn_Photorez_3_Correction] <> '')
);
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label11.Text = count.ToString(); // Обновление значения label11
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

		private void Load_Pryam_Metal()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Pryam_Metal_Cond
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pr_Met_1_Correction_Mat] IS NOT NULL AND [Pr_Met_1_Correction_Mat] <> '') 
                 OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pr_Met_1_Correction_Score] IS NOT NULL AND [Pr_Met_1_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Pryam_Metal_PredMet
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pr_Met_2_Correction_Mat] IS NOT NULL AND [Pr_Met_2_Correction_Mat] <> '') 
                 OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pr_Met_2_Correction_Score] IS NOT NULL AND [Pr_Met_2_Correction_Score] <> '')
            )
UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Pryam_Metal_PredMet303
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pr_Met_2_Correction_Mat] IS NOT NULL AND [Pr_Met_2_Correction_Mat] <> '') 
                OR 
([Сomment] IS NOT NULL AND [Сomment] <> '') 
                OR 
                ([Pr_Met_2_Correction_Score] IS NOT NULL AND [Pr_Met_2_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Pryam_Metal_Met
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pr_Met_3_Correction_Mat] IS NOT NULL AND [Pr_Met_3_Correction_Mat] <> '') 
                 OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pr_Met_3_Correction_Score] IS NOT NULL AND [Pr_Met_3_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Pryam_Metal_Uskor
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pr_Met_4_Correction_Mat] IS NOT NULL AND [Pr_Met_4_Correction_Mat] <> '') 
                 OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pr_Met_4_Correction_Score] IS NOT NULL AND [Pr_Met_4_Correction_Score] <> '')
            )
    ) AS CombinedCounts; 
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

		private void Load_Proyavlen_Photorez()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Proyavlen_Photorez_ProvMod
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pro_Photorez_1_Correction_Mat] IS NOT NULL AND [Pro_Photorez_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pro_Photorez_1_Correction_Score] IS NOT NULL AND [Pro_Photorez_1_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Proyavlen_Photorez_Ult1
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pro_Photorez_2_Correction_Mat] IS NOT NULL AND [Pro_Photorez_2_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pro_Photorez_2_Correction_Score] IS NOT NULL AND [Pro_Photorez_2_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Proyavlen_Photorez_Ult2
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pro_Photorez_3_Correction_Mat] IS NOT NULL AND [Pro_Photorez_3_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pro_Photorez_3_Correction_Score] IS NOT NULL AND [Pro_Photorez_3_Correction_Score] <> '')
            )
    ) AS CombinedCounts;
";



			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label15.Text = count.ToString(); // Обновление значения label11
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

		private void Load_Proyavlen_Photomask()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Proyavlen_Photomask_ProvMod
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pro_Photorez_1_Correction_Mat] IS NOT NULL AND [Pro_Photorez_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pro_Photorez_1_Correction_Score] IS NOT NULL AND [Pro_Photorez_1_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Proyavlen_Photomask_Ult1
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pro_Photomask_2_Correction_Mat] IS NOT NULL AND [Pro_Photomask_2_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pro_Photomask_2_Correction_Score] IS NOT NULL AND [Pro_Photomask_2_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Proyavlen_Photomask_Ult2
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pro_Photomask_3_Correction_Mat] IS NOT NULL AND [Pro_Photomask_3_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pro_Photomask_3_Correction_Score] IS NOT NULL AND [Pro_Photomask_3_Correction_Score] <> '')
            )
    ) AS CombinedCounts;
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label16.Text = count.ToString(); // Обновление значения label11
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

		private void Load_Per_Obr()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Perm_Obra_Sens
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Per_Obr_1_Correction_Mat] IS NOT NULL AND [Per_Obr_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Per_Obr_1_Correction_Score] IS NOT NULL AND [Per_Obr_1_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Perm_Obra_RasOkis
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Per_Obr_2_Correction_Mat] IS NOT NULL AND [Per_Obr_2_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Per_Obr_2_Correction_Score] IS NOT NULL AND [Per_Obr_2_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Perm_Obra_PredNe
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Per_Obr_3_Correction_Mat] IS NOT NULL AND [Per_Obr_3_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Per_Obr_3_Correction_Score] IS NOT NULL AND [Per_Obr_3_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Perm_Obra_PredNe2
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Per_Obr_4_Correction_Mat] IS NOT NULL AND [Per_Obr_4_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Per_Obr_4_Correction_Score] IS NOT NULL AND [Per_Obr_4_Correction_Score] <> '')
            )
    ) AS CombinedCounts; 
";

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

		private void Load_Lushenie()
		{
			string query = @"
        SELECT COUNT(*) 
FROM Lushenie 
WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
AND (
    ([Lushen_Correction_Mat] IS NOT NULL AND [Lushen_Correction_Mat] <> '') OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
    ([Lushen_Correction_Score] IS NOT NULL AND [Lushen_Correction_Score] <> '')
);
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label14.Text = count.ToString(); // Обновление значения label11
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
		private void Load_Himich_Podgotov()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Himich_Podgotov_KisOch
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Him_Podg_1_Correction_Mat] IS NOT NULL AND [Him_Podg_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Him_Podg_1_Correction_Score] IS NOT NULL AND [Him_Podg_1_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Himich_Podgotov_Microtrav
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Him_Podg_2_Correction_Mat] IS NOT NULL AND [Him_Podg_2_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Him_Podg_2_Correction_Score] IS NOT NULL AND [Him_Podg_2_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Himich_Podgotov_Dek
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Him_Podg_3_Correction_Mat] IS NOT NULL AND [Him_Podg_3_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Him_Podg_3_Correction_Score] IS NOT NULL AND [Him_Podg_3_Correction_Score] <> '')
            )
    ) AS CombinedCounts;
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label17.Text = count.ToString(); // Обновление значения label11
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

		private void Load_Galvan_Zat()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Zat_Cu
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Zat_1_Cu_Correction_Mat] IS NOT NULL AND [Gal_Zat_1_Cu_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Zat_1_Cu_Correction_Score] IS NOT NULL AND [Gal_Zat_1_Cu_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Zat_CuEl12
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') and ([Gal_Zat_2_Correction_Mat] <> 'NaCl' or [Gal_Zat_2_Correction_Mat] is null)
            AND (
                ([Gal_Zat_2_Correction_Mat] IS NOT NULL AND [Gal_Zat_2_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Zat_2_Correction_Score] IS NOT NULL AND [Gal_Zat_2_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Zat_CuEl34
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') and ([Gal_Zat_3_Correction_Mat] <> 'NaCl' or [Gal_Zat_3_Correction_Mat] is null) 
            AND (
                ([Gal_Zat_3_Correction_Mat] IS NOT NULL AND [Gal_Zat_3_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Zat_3_Correction_Score] IS NOT NULL AND [Gal_Zat_3_Correction_Score] <> '')
            )
    ) AS CombinedCounts;
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

		private void Load_Galvan_Line_PAL()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_PAL_Cu
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Line_3_Cu_Correction_Mat] IS NOT NULL AND [Gal_Line_3_Cu_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_3_Cu_Correction_Score] IS NOT NULL AND [Gal_Line_3_Cu_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_PAL_KisOch
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Line_1_Correction_Mat] IS NOT NULL AND [Gal_Line_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_1_Correction_Score] IS NOT NULL AND [Gal_Line_1_Correction_Score] <> '')
            )
UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Trav_Podv_PAL
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Trav_Podv_PAL_Correction_Mat] IS NOT NULL AND [Trav_Podv_PAL_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Trav_Podv_PAL_Correction_Score] IS NOT NULL AND [Trav_Podv_PAL_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_PAL_Microtrav
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Line_2_Correction_Mat] IS NOT NULL AND [Gal_Line_2_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_2_Correction_Score] IS NOT NULL AND [Gal_Line_2_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_PAL_CuEl1920
        WHERE 
           ([Сompleted] IS NULL OR [Сompleted] = '') and ([Gal_Line_4_Correction_Mat] <> 'NaCl' or [Gal_Line_4_Correction_Mat] is null) 
            AND (
                ([Gal_Line_4_Correction_Mat] IS NOT NULL AND [Gal_Line_4_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_4_Correction_Score] IS NOT NULL AND [Gal_Line_4_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_PAL_CuEl2122
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') and ([Gal_Line_5_Correction_Mat] <> 'NaCl' or [Gal_Line_5_Correction_Mat] is null) 
            AND (
                ([Gal_Line_5_Correction_Mat] IS NOT NULL AND [Gal_Line_5_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_5_Correction_Score] IS NOT NULL AND [Gal_Line_5_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_PAL_CuEl2324
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') and ([Gal_Line_6_Correction_Mat] <> 'NaCl' or [Gal_Line_6_Correction_Mat] is null) 
            AND (
                ([Gal_Line_6_Correction_Mat] IS NOT NULL AND [Gal_Line_6_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_6_Correction_Score] IS NOT NULL AND [Gal_Line_6_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_PAL_SnEl
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Line_7_Correction_Mat] IS NOT NULL AND [Gal_Line_7_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_7_Correction_Score] IS NOT NULL AND [Gal_Line_7_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_PAL_Sn
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Line_3_Sn_Correction_Mat] IS NOT NULL AND [Gal_Line_3_Sn_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_3_Sn_Correction_Score] IS NOT NULL AND [Gal_Line_3_Sn_Correction_Score] <> '')
            )
    ) AS CombinedCounts;
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

		private void Load_Galvan_Line_MG()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_MG_Cu
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Line_3_Cu_Correction_Mat] IS NOT NULL AND [Gal_Line_3_Cu_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_3_Cu_Correction_Score] IS NOT NULL AND [Gal_Line_3_Cu_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_MG_KisOch
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Line_1_Correction_Mat] IS NOT NULL AND [Gal_Line_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_1_Correction_Score] IS NOT NULL AND [Gal_Line_1_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_MG_Microtrav
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Line_2_Correction_Mat] IS NOT NULL AND [Gal_Line_2_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_2_Correction_Score] IS NOT NULL AND [Gal_Line_2_Correction_Score] <> '')
            )
 UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Trav_Podv
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Trav_Podv_Correction_Mat] IS NOT NULL AND [Trav_Podv_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Trav_Podv_Correction_Score] IS NOT NULL AND [Trav_Podv_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_MG_CuEl1819
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') and ([Gal_Line_4_Correction_Mat] <> 'NaCl' or [Gal_Line_4_Correction_Mat] is null) 
            AND (
                ([Gal_Line_4_Correction_Mat] IS NOT NULL AND [Gal_Line_4_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_4_Correction_Score] IS NOT NULL AND [Gal_Line_4_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_MG_CuEl2021
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') and ([Gal_Line_5_Correction_Mat] <> 'NaCl' or [Gal_Line_5_Correction_Mat] is null) 
            AND (
                ([Gal_Line_5_Correction_Mat] IS NOT NULL AND [Gal_Line_5_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_5_Correction_Score] IS NOT NULL AND [Gal_Line_5_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_MG_SnEl
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Line_6_Correction_Mat] IS NOT NULL AND [Gal_Line_6_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_6_Correction_Score] IS NOT NULL AND [Gal_Line_6_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Galvan_Line_MG_Sn
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Gal_Line_3_Sn_Correction_Mat] IS NOT NULL AND [Gal_Line_3_Sn_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Gal_Line_3_Sn_Correction_Score] IS NOT NULL AND [Gal_Line_3_Sn_Correction_Score] <> '')
            )
    ) AS CombinedCounts;
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

		private void Load_Black_Hole()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Black_Hole_Cleaner
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Black_Hole_1_Correction_Mat] IS NOT NULL AND [Black_Hole_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Black_Hole_1_Correction_Score] IS NOT NULL AND [Black_Hole_1_Correction_Score] <> '')
            )

        UNION ALL
SELECT 
            COUNT(*) AS Counts
        FROM 
            Black_Hole_BAK1012
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Black_Hole_1_Correction_Mat] IS NOT NULL AND [Black_Hole_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Black_Hole_1_Correction_Score] IS NOT NULL AND [Black_Hole_1_Correction_Score] <> '')
            )
UNION ALL
SELECT 
            COUNT(*) AS Counts
        FROM 
            Black_Hole_BAK1022
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Black_Hole_1_Correction_Mat] IS NOT NULL AND [Black_Hole_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Black_Hole_1_Correction_Score] IS NOT NULL AND [Black_Hole_1_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Black_Hole_Conditioner
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Black_Hole_2_Correction_Mat] IS NOT NULL AND [Black_Hole_2_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Black_Hole_2_Correction_Score] IS NOT NULL AND [Black_Hole_2_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Black_Hole_Microtrav_1
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Black_Hole_3_Correction_Mat] IS NOT NULL AND [Black_Hole_3_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Black_Hole_3_Correction_Score] IS NOT NULL AND [Black_Hole_3_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Black_Hole_Microtrav_23
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Black_Hole_4_Correction_Mat] IS NOT NULL AND [Black_Hole_4_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Black_Hole_4_Correction_Score] IS NOT NULL AND [Black_Hole_4_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Black_Hole_BHC1
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Black_Hole_5_Correction_Mat] IS NOT NULL AND [Black_Hole_5_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Black_Hole_5_Correction_Score] IS NOT NULL AND [Black_Hole_5_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Black_Hole_BHC2
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Black_Hole_6_Correction_Mat] IS NOT NULL AND [Black_Hole_6_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Black_Hole_6_Correction_Score] IS NOT NULL AND [Black_Hole_6_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Black_Hole_BAK1
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Black_Hole_7_Correction_Mat] IS NOT NULL AND [Black_Hole_7_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Black_Hole_7_Correction_Score] IS NOT NULL AND [Black_Hole_7_Correction_Score] <> '')
            )


        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Black_Hole_BAK2
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Black_Hole_8_Correction_Mat] IS NOT NULL AND [Black_Hole_8_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Black_Hole_8_Correction_Score] IS NOT NULL AND [Black_Hole_8_Correction_Score] <> '')
            )
    ) AS CombinedCounts;
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label6.Text = count.ToString(); // Обновление значения label11
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

		private void Load_Snatie_Olova()
		{
			string query = @"
        SELECT COUNT(*) 
FROM Snatie_Olova 
WHERE ([Сompleted] IS NULL OR [Сompleted] = '') 
AND (
    ([Sn_Olov_Correction] IS NOT NULL AND [Sn_Olov_Correction] <> '') OR ([Сomment] IS NOT NULL AND [Сomment] <> ''));";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label12.Text = count.ToString(); // Обновление значения label11
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





		private void label2_TextChanged(object sender, EventArgs e)
		{
			//if (int.TryParse(label2.Text, out int value) && value > 0)
			//         {
			//             // Запускаем таймер, если значение в label1 больше 0
			//             blinkTimer.Start();
			//         }
			//         else
			//         {
			//             // Останавливаем таймер и сбрасываем цвет кнопки, если значение меньше или равно 0
			//             blinkTimer.Stop();
			//             button2.BackColor = Color.Green;
			//         }

		}

		//		private void button16_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Trav_Med_1_Corrector tmc = new Trav_Med_1_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button4_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Trav_Med_2_Corrector tmc = new Trav_Med_2_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button5_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Start_Perm_Obra_correcter tmc = new Start_Perm_Obra_correcter();
		//																	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button6_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Start_Black_Hole_Cleaner_correcter tmc = new Start_Black_Hole_Cleaner_correcter();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button7_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Start_Pryam_Metal_correcter tmc = new Start_Pryam_Metal_correcter();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button8_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Start_Galvan_Zat_Cleaner_correcter tmc = new Start_Galvan_Zat_Cleaner_correcter();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button9_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Start_Galvan_Line_MG_Cleaner_correcter tmc = new Start_Galvan_Line_MG_Cleaner_correcter();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button10_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Start_Galvan_Line_PAL_Cleaner_correcter tmc = new Start_Galvan_Line_PAL_Cleaner_correcter();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button11_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Snatie_Photorez_Corrector tmc = new Snatie_Photorez_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button12_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Snatie_Olova_Corrector tmc = new Snatie_Olova_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button13_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Lushenie_Corrector tmc = new Lushenie_Corrector();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button14_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Start_Proyavlen_Photorez_correcter tmc = new Start_Proyavlen_Photorez_correcter();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button15_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Start_Proyavlen_Photomask_correcter tmc = new Start_Proyavlen_Photomask_correcter();
		//	tmc.ShowDialog();
		//	this.Show();
		//}

		//private void button3_Click(object sender, EventArgs e)
		//{
		//	this.Hide();
		//	Start_Himich_Podgotov_Cleaner_correcter tmc = new Start_Himich_Podgotov_Cleaner_correcter();
		//	tmc.ShowDialog();
		//	this.Show();
		//}																	




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























		private void InitializeTimer()
		{
			// Инициализация словаря связей меток и кнопок

			// Добавьте остальные пары меток и кнопок

			// Настройка таймера
			blinkTimer = new Timer();
			blinkTimer.Interval = 350; // 350 миллисекунд
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
			button16.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label3.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed)
				{
					button16.BackColor = Color.Blue;
				}
				else
				{
					button16.BackColor = Color.Red;
				}
				isRed = !isRed; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking(); // Останавливаем мигание, если значение в label не больше 0
			}
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







		private void InitializeTimer1()
		{
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









		private void InitializeTimer2()
		{
			// Настройка таймера
			blinkTimer2 = new Timer();
			blinkTimer2.Interval = 350; // 200 миллисекунд
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













		private void InitializeTimer3()
		{
			// Настройка таймера
			blinkTimer3 = new Timer();
			blinkTimer3.Interval = 350; // 300 миллисекунд
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
			button6.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick3(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label6.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed3)
				{
					button6.BackColor = Color.Blue;
				}
				else
				{
					button6.BackColor = Color.Red;
				}
				isRed3 = !isRed3; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking3(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label6_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label6.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking3();
			}
			else
			{
				StopBlinking3(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}



		private void InitializeTimer4()
		{
			// Настройка таймера
			blinkTimer4 = new Timer();
			blinkTimer4.Interval = 350; // 400 миллисекунд
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
			button7.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick4(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label7.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed4)
				{
					button7.BackColor = Color.Blue;
				}
				else
				{
					button7.BackColor = Color.Red;
				}
				isRed4 = !isRed4; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking4(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label7_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label7.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking4();
			}
			else
			{
				StopBlinking4(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void InitializeTimer5()
		{
			// Настройка таймера
			blinkTimer5 = new Timer();
			blinkTimer5.Interval = 350; // 500 миллисекунд
			blinkTimer5.Tick += BlinkTimer_Tick5;
		}

		private void StartBlinking5() // Метод для запуска мигания
		{
			isRed5 = false; // Сбросим значение isRed
			blinkTimer5.Start(); // Запускаем таймер
		}

		private void StopBlinking5() // Метод для остановки мигания
		{
			blinkTimer5.Stop(); // Останавливаем таймер
			button8.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick5(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label8.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed5)
				{
					button8.BackColor = Color.Blue;
				}
				else
				{
					button8.BackColor = Color.Red;
				}
				isRed5 = !isRed5; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking5(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label8_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label8.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking5();
			}
			else
			{
				StopBlinking5(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void InitializeTimer6()
		{
			// Настройка таймера
			blinkTimer6 = new Timer();
			blinkTimer6.Interval = 350; // 600 миллисекунд
			blinkTimer6.Tick += BlinkTimer_Tick6;
		}

		private void StartBlinking6() // Метод для запуска мигания
		{
			isRed6 = false; // Сбросим значение isRed
			blinkTimer6.Start(); // Запускаем таймер
		}

		private void StopBlinking6() // Метод для остановки мигания
		{
			blinkTimer6.Stop(); // Останавливаем таймер
			button9.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick6(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label9.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed6)
				{
					button9.BackColor = Color.Blue;
				}
				else
				{
					button9.BackColor = Color.Red;
				}
				isRed6 = !isRed6; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking6(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label9_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label9.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking6();
			}
			else
			{
				StopBlinking6(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void InitializeTimer7()
		{
			// Настройка таймера
			blinkTimer7 = new Timer();
			blinkTimer7.Interval = 350; // 700 миллисекунд
			blinkTimer7.Tick += BlinkTimer_Tick7;
		}

		private void StartBlinking7() // Метод для запуска мигания
		{
			isRed7 = false; // Сбросим значение isRed
			blinkTimer7.Start(); // Запускаем таймер
		}

		private void StopBlinking7() // Метод для остановки мигания
		{
			blinkTimer7.Stop(); // Останавливаем таймер
			button10.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick7(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label10.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed7)
				{
					button10.BackColor = Color.Blue;
				}
				else
				{
					button10.BackColor = Color.Red;
				}
				isRed7 = !isRed7; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking7(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label10_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label10.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking7();
			}
			else
			{
				StopBlinking7(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void InitializeTimer8()
		{
			// Настройка таймера
			blinkTimer8 = new Timer();
			blinkTimer8.Interval = 350; // 800 миллисекунд
			blinkTimer8.Tick += BlinkTimer_Tick8;
		}

		private void StartBlinking8() // Метод для запуска мигания
		{
			isRed8 = false; // Сбросим значение isRed
			blinkTimer8.Start(); // Запускаем таймер
		}

		private void StopBlinking8() // Метод для остановки мигания
		{
			blinkTimer8.Stop(); // Останавливаем таймер
			button11.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick8(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label11.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed8)
				{
					button11.BackColor = Color.Blue;
				}
				else
				{
					button11.BackColor = Color.Red;
				}
				isRed8 = !isRed8; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking8(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label11_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label11.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking8();
			}
			else
			{
				StopBlinking8(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void InitializeTimer9()
		{
			// Настройка таймера
			blinkTimer9 = new Timer();
			blinkTimer9.Interval = 350; // 900 миллисекунд
			blinkTimer9.Tick += BlinkTimer_Tick9;
		}

		private void StartBlinking9() // Метод для запуска мигания
		{
			isRed9 = false; // Сбросим значение isRed
			blinkTimer9.Start(); // Запускаем таймер
		}

		private void StopBlinking9() // Метод для остановки мигания
		{
			blinkTimer9.Stop(); // Останавливаем таймер
			button12.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick9(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label12.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed9)
				{
					button12.BackColor = Color.Blue;
				}
				else
				{
					button12.BackColor = Color.Red;
				}
				isRed9 = !isRed9; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking9(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label12_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label12.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking9();
			}
			else
			{
				StopBlinking9(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void InitializeTimer10()
		{
			// Настройка таймера
			blinkTimer10 = new Timer();
			blinkTimer10.Interval = 350; // 3500 миллисекунд
			blinkTimer10.Tick += BlinkTimer_Tick10;
		}

		private void StartBlinking10() // Метод для запуска мигания
		{
			isRed10 = false; // Сбросим значение isRed
			blinkTimer10.Start(); // Запускаем таймер
		}

		private void StopBlinking10() // Метод для остановки мигания
		{
			blinkTimer10.Stop(); // Останавливаем таймер
			button13.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick10(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label14.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed10)
				{
					button13.BackColor = Color.Blue;
				}
				else
				{
					button13.BackColor = Color.Red;
				}
				isRed10 = !isRed10; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking10(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label14_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label14.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking10();
			}
			else
			{
				StopBlinking10(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void InitializeTimer11()
		{
			// Настройка таймера
			blinkTimer11 = new Timer();
			blinkTimer11.Interval = 350; // 1350 миллисекунд
			blinkTimer11.Tick += BlinkTimer_Tick11;
		}

		private void StartBlinking11() // Метод для запуска мигания
		{
			isRed11 = false; // Сбросим значение isRed
			blinkTimer11.Start(); // Запускаем таймер
		}

		private void StopBlinking11() // Метод для остановки мигания
		{
			blinkTimer11.Stop(); // Останавливаем таймер
			button14.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick11(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label15.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed11)
				{
					button14.BackColor = Color.Blue;
				}
				else
				{
					button14.BackColor = Color.Red;
				}
				isRed11 = !isRed11; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking11(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label15_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label15.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking11();
			}
			else
			{
				StopBlinking11(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void InitializeTimer12()
		{
			// Настройка таймера
			blinkTimer12 = new Timer();
			blinkTimer12.Interval = 350; // 1200 миллисекунд
			blinkTimer12.Tick += BlinkTimer_Tick12;
		}

		private void StartBlinking12() // Метод для запуска мигания
		{
			isRed12 = false; // Сбросим значение isRed
			blinkTimer12.Start(); // Запускаем таймер
		}

		private void StopBlinking12() // Метод для остановки мигания
		{
			blinkTimer12.Stop(); // Останавливаем таймер
			button15.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick12(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label16.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed12)
				{
					button15.BackColor = Color.Blue;
				}
				else
				{
					button15.BackColor = Color.Red;
				}
				isRed12 = !isRed12; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking12(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label16_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label16.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking12();
			}
			else
			{
				StopBlinking12(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void InitializeTimer13()
		{
			// Настройка таймера
			blinkTimer13 = new Timer();
			blinkTimer13.Interval = 350; // 1300 миллисекунд
			blinkTimer13.Tick += BlinkTimer_Tick13;
		}

		private void StartBlinking13() // Метод для запуска мигания
		{
			isRed13 = false; // Сбросим значение isRed
			blinkTimer13.Start(); // Запускаем таймер
		}

		private void StopBlinking13() // Метод для остановки мигания
		{
			blinkTimer13.Stop(); // Останавливаем таймер
			button3.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick13(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label17.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed13)
				{
					button3.BackColor = Color.Blue;
				}
				else
				{
					button3.BackColor = Color.Red;
				}
				isRed13 = !isRed13; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking13(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label17_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label17.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking13();
			}
			else
			{
				StopBlinking13(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}


		private void InitializeTimer14()
		{
			// Настройка таймера
			blinkTimer14 = new Timer();
			blinkTimer14.Interval = 350; // 1300 миллисекунд
			blinkTimer14.Tick += BlinkTimer_Tick14;
		}

		private void StartBlinking14() // Метод для запуска мигания
		{
			isRed14 = false; // Сбросим значение isRed
			blinkTimer14.Start(); // Запускаем таймер
		}

		private void StopBlinking14() // Метод для остановки мигания
		{
			blinkTimer14.Stop(); // Останавливаем таймер
			button28.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick14(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label18.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed14)
				{
					button28.BackColor = Color.Blue;
				}
				else
				{
					button28.BackColor = Color.Red;
				}
				isRed14 = !isRed14; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking14(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label18_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label18.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking14();
			}
			else
			{
				StopBlinking14(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}



















		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}



		private void Load_Zolot()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Zolot_KisOch
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Zolot_Correction_Mat] IS NOT NULL AND [Zolot_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Zolot_Correction_Score] IS NOT NULL AND [Zolot_Correction_Score] <> '')
            )

        UNION ALL
SELECT 
            COUNT(*) AS Counts
        FROM 
            Zolot_Microtrav
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Zolot_Correction_Mat] IS NOT NULL AND [Zolot_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Zolot_Correction_Score] IS NOT NULL AND [Zolot_Correction_Score] <> '')
            )
UNION ALL
SELECT 
            COUNT(*) AS Counts
        FROM 
            Zolot_PredActiv
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Zolot_Correction_Mat] IS NOT NULL AND [Zolot_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Zolot_Correction_Score] IS NOT NULL AND [Zolot_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Zolot_Activ
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Zolot_Correction_Mat] IS NOT NULL AND [Zolot_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Zolot_Correction_Score] IS NOT NULL AND [Zolot_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Zolot_PostActiv
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Zolot_Correction_Mat] IS NOT NULL AND [Zolot_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Zolot_Correction_Score] IS NOT NULL AND [Zolot_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Zolot_HimNik
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Zolot_Correction_Mat] IS NOT NULL AND [Zolot_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Zolot_Correction_Score] IS NOT NULL AND [Zolot_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Zolot_Azot
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Zolot_Correction_Mat] IS NOT NULL AND [Zolot_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Zolot_Correction_Score] IS NOT NULL AND [Zolot_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Zolot_ImerZolot
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Zolot_Correction_Mat] IS NOT NULL AND [Zolot_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Zolot_Correction_Score] IS NOT NULL AND [Zolot_Correction_Score] <> '')
            )
    ) AS CombinedCounts;
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label19.Text = count.ToString(); // Обновление значения label11
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

		private void InitializeTimer15()
		{
			// Настройка таймера
			blinkTimer15 = new Timer();
			blinkTimer15.Interval = 350; // 1300 миллисекунд
			blinkTimer15.Tick += BlinkTimer_Tick15;
		}

		private void StartBlinking15() // Метод для запуска мигания
		{
			isRed15 = false; // Сбросим значение isRed
			blinkTimer15.Start(); // Запускаем таймер
		}

		private void StopBlinking15() // Метод для остановки мигания
		{
			blinkTimer15.Stop(); // Останавливаем таймер
			button26.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick15(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label19.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed15)
				{
					button26.BackColor = Color.Blue;
				}
				else
				{
					button26.BackColor = Color.Red;
				}
				isRed15 = !isRed15; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking15(); // Останавливаем мигание, если значение в label не больше 0
			}
		}

		private void label19_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label19.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking15();
			}
			else
			{
				StopBlinking15(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}


		private void InitializeTimer16()
		{
			// Настройка таймера
			blinkTimer16 = new Timer();
			blinkTimer16.Interval = 350; // 1300 миллисекунд
			blinkTimer16.Tick += BlinkTimer_Tick16;
		}

		private void StartBlinking16() // Метод для запуска мигания
		{
			isRed16 = false; // Сбросим значение isRed
			blinkTimer16.Start(); // Запускаем таймер
		}

		private void StopBlinking16() // Метод для остановки мигания
		{
			blinkTimer16.Stop(); // Останавливаем таймер
			button25.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick16(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label20.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed16)
				{
					button25.BackColor = Color.Blue;
				}
				else
				{
					button25.BackColor = Color.Red;
				}
				isRed16 = !isRed16; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking16(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label20_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label20.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking16();
			}
			else
			{
				StopBlinking16(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		private void Load_DES()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            DES_ProvMod
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pro_Photorez_1_Correction_Mat] IS NOT NULL AND [Pro_Photorez_1_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pro_Photorez_1_Correction_Score] IS NOT NULL AND [Pro_Photorez_1_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            DES_Ult1
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pro_Photorez_2_Correction_Mat] IS NOT NULL AND [Pro_Photorez_2_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pro_Photorez_2_Correction_Score] IS NOT NULL AND [Pro_Photorez_2_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            DES_KisTrav
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Pro_Photorez_3_Correction_Mat] IS NOT NULL AND [Pro_Photorez_3_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Pro_Photorez_3_Correction_Score] IS NOT NULL AND [Pro_Photorez_3_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            DES_Snatie_Photorez
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Sn_Photorez_1_Correction] IS NOT NULL AND [Sn_Photorez_1_Correction] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Sn_Photorez_2_Correction] IS NOT NULL AND [Sn_Photorez_2_Correction] <> '') 
                OR ([Sn_Photorez_3_Correction] IS NOT NULL AND [Sn_Photorez_3_Correction] <> '')
            )
    ) AS CombinedCounts;
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label20.Text = count.ToString(); // Обновление значения label11
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






		private void Load_Oxide()
		{
			string query = @"
    SELECT 
        SUM(Counts) AS TotalCount
    FROM (
        SELECT 
            COUNT(*) AS Counts
        FROM 
            Oxide_ShelOch
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Oxide_Correction_Mat] IS NOT NULL AND [Oxide_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Oxide_Correction_Score] IS NOT NULL AND [Oxide_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Oxide_PredActiv
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Oxide_Correction_Mat] IS NOT NULL AND [Oxide_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Oxide_Correction_Score] IS NOT NULL AND [Oxide_Correction_Score] <> '')
            )

        UNION ALL

        SELECT 
            COUNT(*) AS Counts
        FROM 
            Oxide_Oxidir
        WHERE 
            ([Сompleted] IS NULL OR [Сompleted] = '') 
            AND (
                ([Oxide_Correction_Mat] IS NOT NULL AND [Oxide_Correction_Mat] <> '') 
                OR ([Сomment] IS NOT NULL AND [Сomment] <> '') OR 
                ([Oxide_Correction_Score] IS NOT NULL AND [Oxide_Correction_Score] <> '')
            )
    ) AS CombinedCounts;
";

			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					int count = (int)command.ExecuteScalar(); // Получение количества выполненных условий
					label21.Text = count.ToString(); // Обновление значения label11
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




		private void InitializeTimer17()
		{
			// Настройка таймера
			blinkTimer17 = new Timer();
			blinkTimer17.Interval = 350; // 1300 миллисекунд
			blinkTimer17.Tick += BlinkTimer_Tick17;
		}

		private void StartBlinking17() // Метод для запуска мигания
		{
			isRed17 = false; // Сбросим значение isRed
			blinkTimer17.Start(); // Запускаем таймер
		}

		private void StopBlinking17() // Метод для остановки мигания
		{
			blinkTimer17.Stop(); // Останавливаем таймер
			button24.BackColor = Color.Green; // Сбрасываем цвет кнопки
		}

		private void BlinkTimer_Tick17(object sender, EventArgs e)
		{
			// Проверяем, больше ли значение в label, чем 0
			if (int.TryParse(label21.Text, out int labelValue) && labelValue > 0)
			{
				// Меняем цвет кнопки в зависимости от isRed
				if (isRed17)
				{
					button24.BackColor = Color.Blue;
				}
				else
				{
					button24.BackColor = Color.Red;
				}
				isRed17 = !isRed17; // Инвертируем значение isRed
			}
			else
			{
				StopBlinking17(); // Останавливаем мигание, если значение в label не больше 0
			}
		}
		private void label21_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(label21.Text, out int labelValue) && labelValue > 0)
			{
				StartBlinking17();
			}
			else
			{
				StopBlinking17(); // Останавливаем мигание, если значение меньше или равно 0
			}
		}

		








		// Обработка изменения текста меток

	}
}

