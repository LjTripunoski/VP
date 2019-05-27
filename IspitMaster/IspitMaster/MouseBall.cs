using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IspitMaster
{
    public  class MouseBall
    {
        private static readonly int RADIUS = 25;

        public Point Position { get; set; }

        public MouseBall(Point centar)
        {
            Position = centar;
        }

        public void Draw(Graphics g)
        {
            SolidBrush br = new SolidBrush(Color.Blue);
            g.FillEllipse(br, Position.X - RADIUS, Position.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            br.Dispose();
        }
        public bool InHole(Balls hole)
        {
            float d = (Position.X - hole.Center.X+25) * (Position.X - hole.Center.X-25) + (Position.Y - hole.Center.Y+25) * (Position.Y - hole.Center.Y-25);
            return d <= RADIUS * RADIUS ;
        }
    }
}
