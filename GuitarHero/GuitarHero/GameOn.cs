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
    public partial class GameOn : Form
    {
        private NotesDoc notesDoc;
        private int timerForNote;
        private Note note;
        private int tune;
        private WindowsMediaPlayer player;
        private WindowsMediaPlayer player2;
        private bool EdenDva;
        private int Speed;
        private bool Paused;

        public List<String> ChosenSongList;

        private int CurrentNote;
        private string CurrentNoteString;


        public GameOn(string SongName)
        {
            ChosenSongList = SongName.Split('.').ToList();
            CurrentNote = 0;
            CurrentNoteString = null;
            timerForNote = 0;
            EdenDva = true;
            notesDoc = new NotesDoc();
            timer1 = new Timer();
            timer1.Start();
            tune = 0;
            Paused = false;

            player = new WindowsMediaPlayer();
            player2 = new WindowsMediaPlayer();

            DoubleBuffered = true;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timerForNote % 10 == 0)
            {
                note = new Note();
                notesDoc.AddNote(note);
                if(Speed % 2 == 0)
                {
                    if (timer1.Interval > 1)
                        timer1.Interval--;
                    else timer1.Stop();

                    Speed = 0;
                }
                Speed++;
                timerForNote = 1;
                Invalidate();
            }
            timerForNote++;
            label1.Text = string.Format("HITS: {0}", notesDoc.Hits);
            label2.Text = string.Format("MISSES: {0}", notesDoc.Misses);
            notesDoc.MoveAllNotes();
            Invalidate();
            if (notesDoc.Misses == 3)
            {
                label2.Text = string.Format("MISSES: {0}", notesDoc.Misses);
                GameOver();
            }  
        }

        private void GameOver()
        {
            timer1.Stop();
            GameOver gameOver = new GameOver(notesDoc.Hits);
            DialogResult result = gameOver.ShowDialog();
            if (result == DialogResult.OK)
            {
                notesDoc = new NotesDoc();
                timer1.Interval = 80;
                CurrentNote = 0;
                timerForNote = 0;
                timer1.Start();

            }
            if (result == DialogResult.Cancel)
            {
                this.Close();
            }
        }

        private void GameOn_Paint(object sender, PaintEventArgs e)
        {
            notesDoc.DrawAllNotes(e.Graphics);
            notesDoc.DrawPlayingNotes(e.Graphics);
        }

        private void GameOn_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.H)
            {
                notesDoc.playingNotes[0].IsKeyDown = !notesDoc.playingNotes[0].IsKeyDown;
                tune = 0;
            }
            if (e.KeyCode == Keys.J)
            {
                notesDoc.playingNotes[1].IsKeyDown = !notesDoc.playingNotes[1].IsKeyDown;
                tune = 1;
            }
            if (e.KeyCode == Keys.K)
            {
                notesDoc.playingNotes[2].IsKeyDown = !notesDoc.playingNotes[2].IsKeyDown;
                tune = 2;
            }
            if (e.KeyCode == Keys.L)
            {
                notesDoc.playingNotes[3].IsKeyDown = !notesDoc.playingNotes[3].IsKeyDown;
                tune = 3;
            }

            if (e.KeyCode == Keys.P)
            {
                Paused = !Paused;
                if(Paused)
                {
                    timer1.Stop();
                    lblPaused.Visible = true;
                }
                else
                {
                    timer1.Start();
                    lblPaused.Visible = false;
                }
                
            }

            if (notesDoc.CheckPlay(tune))
            {
                if (CurrentNote < ChosenSongList.Count)
                {
                    if(EdenDva == true)
                    {
                        CurrentNoteString = ChosenSongList[CurrentNote];
                        label3.Text = CurrentNoteString;
                        player.URL = String.Format("{0}.mp3", CurrentNoteString);
                        player.controls.play();
                        CurrentNote++;
                    }

                    if (EdenDva == false)
                    {
                        CurrentNoteString = ChosenSongList[CurrentNote];
                        label3.Text = CurrentNoteString;
                        player2.URL = String.Format("{0}.mp3", CurrentNoteString);
                        player2.controls.play();
                        CurrentNote++;
                    }
                }
                else
                {
                    GameOver();
                }
                EdenDva = !EdenDva;
            }

        }

        

        private void GameOn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H)
            {
                notesDoc.playingNotes[0].IsKeyDown = false;
            }
            if (e.KeyCode == Keys.J)
            {
                notesDoc.playingNotes[1].IsKeyDown = false;
            }
            if (e.KeyCode == Keys.K)
            {
                notesDoc.playingNotes[2].IsKeyDown = false;
            }
            if (e.KeyCode == Keys.L)
            {
                notesDoc.playingNotes[3].IsKeyDown = false;
            }
        }



        private void GameOn_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void GameOn_Load(object sender, EventArgs e)
        {

        }
    }
}
