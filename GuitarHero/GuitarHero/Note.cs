using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHero
{
    public class Note
    {
        public Point Center { get; set; }
        public int Radius { get; set; }
        public int NoteType { get; set; }
        public int count { get; set; }
        public bool IsHit { get; set; }

        public Note()
        {
            Radius = 25;
            Random r = new Random();
            NoteType = r.Next(4);
            if (NoteType == 0)
                Center = new Point(241, 117);
            if (NoteType == 1)
                Center = new Point(293, 117);
            if (NoteType == 2)
                Center = new Point(347, 117);
            if (NoteType == 3)
                Center = new Point(399, 117);

            count = 0;
            IsHit = false;

        }

        public void DrawNote(Graphics g)
        {
            if (NoteType == 0)
            {
                Brush b = new SolidBrush(Color.Green);
                g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2*Radius, 2*Radius);
                b.Dispose();
            }

            if (NoteType == 1)
            {
                Brush b = new SolidBrush(Color.Red);
                g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                b.Dispose();
            }

            if (NoteType == 2)
            {
                Brush b = new SolidBrush(Color.Yellow);
                g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                b.Dispose();
            }

            if (NoteType == 3)
            {
                Brush b = new SolidBrush(Color.Blue);
                g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                b.Dispose();
            }
        }

        public void MoveNote()
        {
            if (NoteType == 0)
            {
                Point p = new Point(Center.X - 3, Center.Y + 20);
                if (count % 2 == 0)
                {
                    p.X = p.X - 1;
                    count = 0;
                }
                Center = new Point(p.X, p.Y);
                Radius += 1;
                count++;
            }

            if (NoteType == 1)
            {
                Center = new Point(Center.X - 1, Center.Y + 20);
                Radius += 1;
                count++;
            }

            if (NoteType == 2)
            {
                Center = new Point(Center.X + 1, Center.Y + 20);
                Radius += 1;
                count++;
            }

            if (NoteType == 3)
            {
                Point p = new Point(Center.X + 3, Center.Y + 20);
                if (count % 2 == 0)
                {
                    p.X = p.X + 1;
                    count = 0;
                }
                Center = new Point(p.X, p.Y);
                Radius += 1;
                count++;
            }

        }
    }
}
