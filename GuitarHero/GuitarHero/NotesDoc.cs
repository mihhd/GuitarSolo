using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHero
{
    public class NotesDoc
    {
        public List <Note> Notes { get; set; }
        public List<PlayingNote> playingNotes { get; set; }
        public int Hits { get; set; }
        public int Misses { get; set; }

        public NotesDoc()
        {
            Notes = new List<Note>();
            playingNotes = new List<PlayingNote>();
            Hits = 0;
            Misses = 0;
            playingNotes.Add(new PlayingNote(0));
            playingNotes.Add(new PlayingNote(1));
            playingNotes.Add(new PlayingNote(2));
            playingNotes.Add(new PlayingNote(3));
        }

        public void AddNote(Note N)
        {
            Notes.Add(N);
        }

        public void DrawAllNotes(Graphics g)
        {
            foreach(Note N in Notes)
            {
                N.DrawNote(g);
            }
        }

        public void DrawPlayingNotes(Graphics g)
        {
            foreach (PlayingNote PN in playingNotes)
            {
                PN.DrawPlayingNote(g);
            }
        }

        public void MoveAllNotes()
        {
            for (int i = 0; i < Notes.Count; i++)
            {
                Notes[i].MoveNote();
                if (Notes[i].Center.Y > 720)
                {
                    Misses++;
                    Notes.RemoveAt(i);
                }
            }
        }

        public bool CheckPlay(int tune)
        {
            bool hit = false;
            for (int i = 0; i < Notes.Count; i++)
            {
                if (playingNotes[tune].CheckHit(Notes[i]))
                {
                    Hits++;
                    Notes[i].IsHit = true;
                    hit = true;
                }
            }

            for (int i = 0; i < Notes.Count; i++)
            {
                if (Notes[i].IsHit == true)
                {
                    Notes.RemoveAt(i);
                }
            }

            return hit;
        }
    }
}
