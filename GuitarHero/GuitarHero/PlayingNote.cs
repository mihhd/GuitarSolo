using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHero
{
    public class PlayingNote
    {
        public Point Center { get; set; }
        public int Tune { get; set; }
        public int Radius { get; set; }
        public bool IsKeyDown { get; set; }

        public PlayingNote(int tune)
        {
            IsKeyDown = false;
            Radius = 50;
            Tune = tune;
            if(Tune == 0)
            {
                Center = new Point(153, 617);
            }
            if (Tune == 1)
            {
                Center = new Point(265, 617);
            }
            if (Tune == 2)
            {
                Center = new Point(376, 617);
            }
            if (Tune == 3)
            {
                Center = new Point(487, 617);
            }
        }

        public void DrawPlayingNote(Graphics g)
        {
            if (Tune == 0)
            {
                Brush b = new SolidBrush(Color.LightGreen);

                if (IsKeyDown == true)
                    b = new SolidBrush(Color.Green);

                g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                b.Dispose();
                Pen p = new Pen(Color.DarkGreen, 6);
                g.DrawEllipse(p, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                p.Dispose();
            }

            if (Tune == 1)
            {
                Brush b = new SolidBrush(Color.PaleVioletRed);
                if (IsKeyDown == true)
                    b = new SolidBrush(Color.Red);
                g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                b.Dispose();
                Pen p = new Pen(Color.DarkRed, 6);
                g.DrawEllipse(p, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                p.Dispose();
            }

            if (Tune == 2)
            {
                Brush b = new SolidBrush(Color.LightGoldenrodYellow);
                if (IsKeyDown == true)
                    b = new SolidBrush(Color.Yellow);
                g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                b.Dispose();
                Pen p = new Pen(Color.GreenYellow, 6);
                g.DrawEllipse(p, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                p.Dispose();
            }

            if (Tune == 3)
            {
                Brush b = new SolidBrush(Color.SkyBlue);
                if (IsKeyDown == true)
                    b = new SolidBrush(Color.Blue);
                g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                b.Dispose();
                Pen p = new Pen(Color.DarkBlue, 6);
                g.DrawEllipse(p, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                p.Dispose();
            }
        }

        public bool CheckHit(Note N)
        {
            decimal diff = (Center.X - N.Center.X) * (Center.X - N.Center.X) + (Center.Y - N.Center.Y) * (Center.Y - N.Center.Y);
            return diff <= Radius * Radius;
        }

    }
}
