using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GuitarHero
{
    public partial class GameOver : Form
    {
        public string toSave { get; set; }
        public int Score { get; set; }
        public GameOver(int score)
        {
            Score = score;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            lblScore.Text = Score.ToString();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toSave = string.Format("{0}:{1}", txtName.Text, lblScore.Text);
            lblSaved.Visible = true;
            SaveScore();
        }

        private void SaveScore()
        {
            string path = "Scores.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(toSave);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(toSave);
                }
            }
            
        }
    }
}
