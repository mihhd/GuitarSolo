using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.IO;

namespace GuitarHero
{
    public partial class Form1 : Form
    {
        public GameOn gameOn;
        public string SongName;
        private string LedZeppelinSTH;
        private string VlatkoStefanovskiGS;
        private string GunsNRosesSCOM;

        private int PictureNumber;
        public Form1()
        {
            LedZeppelinSTH = "A4.C5.E5.A5.B5.E5.C5.B5.C6.E5.C5.C6.F5#.D5.A4.F5.E5.C5.A4.C5.C5.E5.C5.A4.B4.C5.C5.P.P.A3.F4.E4.A3.A4.C5.E5.B5.E5.C5.B5.C6.E5.C5.C6.F5#.D5.A4.F5.E5.C5.A4.C5.C5.E5.C5.A4.B4.C5.C5.P.P.A3.B3.C4.E4.G4.E5.F5#.D5.A4.F5.E5.C5.A4.E5.B4.A4.A3.B3.C5.G4.E4.C5.G5.B4.G4.G5.G5.F5.F5.P.P.A3.B3.C4.E4.G4.E5.F5#.D5.A4.F5.E5.C5.A4.E5.B4.A4.A3.B3.C5.G4.E4.C5.G5.B4.G4.G5.G5.F5.F5.P.P";
            VlatkoStefanovskiGS = "B5.G5.F5#.E5.D6.C6.B5.A5#.B5.G5.F5#.E5.D5#.E5.F5#.G5.B5.G5.F5#.E5.D6.C6.B5.A5#.B5.A5#.B5.A5#.B5.A5#.B5.A5#.B5.G5.F5#.E5.D6.C6.B5.A5#.B5.G5.F5#.E5.D5#.E5.F5#.G5.B5.G5.F5#.E5.D6.C6.B5.A5#.B5.A5#.B5.A5#.B5.A5#.B5.A5#.P.B5.B5.C6.B5.A5#.B5.P.B5.B5.G5.A5.G5.F5#.E5.P.P.B5.C6.D6.C6.B5.C6.A5.P.P.B5.B5.C6.B5.A5#.B5.P.B5.B5.G5.A5.G5.F5#.E5.P.P.E5.E5.E5.F5#G5.E5.F5#.P.P";
            GunsNRosesSCOM = "D5.D6.A5.G5.G6.A5.F6#.A5.D5.D6.A5.G5.G6.A5.F6#.A5.E5.D6.A5.G5.G6.A5.F6#.A5.E5.D6.A5.G5.G6.A5.F6#.A5.G5.D6.A5.G5.G6.A5.F6#.A5.G5.D6.A5.G5.G6.A5.F6#.A5.D5.D6.A5.G5.G6.A5.F6#.A5.D5.D6.A5.G5.G6.A5.F6#.A5.D5.D6.A5.G5.G6.A5.F6#.A5.D5.D6.A5.G5.G6.A5.F6#.A5.E5.D6.A5.G5.G6.A5.F6#.A5.E5.D6.A5.G5.G6.A5.F6#.A5.G5.D6.A5.G5.G6.A5.F6#.A5.G5.D6.A5.G5.G6.A5.F6#.A5.D5.D6.A5.G5.G6.A5.F6#.A5.D5.D6.A5.G5.G6.A5.F6#.A5";
            SongName = LedZeppelinSTH;
            PictureNumber = 1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameOn = new GameOn(SongName);

            if(PictureNumber == 1)
            {
                gameOn.BackgroundImage = Properties.Resources._1GipsySongTheme;
            }

            if (PictureNumber == 2)
            {
                gameOn.BackgroundImage = Properties.Resources._3SweetChildOMine;
            }

            if (PictureNumber == 3)
            {
                gameOn.BackgroundImage = Properties.Resources._2StairwayToHeaven;
            }
            gameOn.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Point p = new Point(287, 130);
            button4.Location = p;
            p = new Point(150, 130);
            button3.Location = p;
            button2.Size = new Size(120, 120);
            button3.Size = new Size(100, 100);
            button4.Size = new Size(100, 100);
            SongName = VlatkoStefanovskiGS;
            PictureNumber = 1;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Point p = new Point(287, 130);
            button4.Location = p;
            p = new Point(140, 130);
            button3.Location = p;
            button3.Size = new Size(120, 120);
            button2.Size = new Size(100, 100);
            button4.Size = new Size(100, 100);
            SongName = GunsNRosesSCOM;
            PictureNumber = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Point p = new Point(267, 130);
            button4.Location = p;
            p = new Point(150, 130);
            button3.Location = p;
            button4.Size = new Size(120, 120);
            button3.Size = new Size(100, 100);
            button2.Size = new Size(100, 100);
            SongName = LedZeppelinSTH;
            PictureNumber = 3;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Scores scoresForm = new Scores();
            if (scoresForm.ShowDialog() == DialogResult.OK)
            {
                scoresForm.Close();
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
