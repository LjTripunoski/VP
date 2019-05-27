using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IspitMaster
{
    public class Balls
    {
        public static readonly int RADIUS = 25;

        public Point Center { get; set; }

        public double Velocity { get; set; }
        public double Angle { get; set; }

        public int Count { get; set; }

        private float velocityX;
        private float velocityY;

        public Balls(Point center)
        {
            Count = 0;
            Center = center;
            Velocity = 10;
            Random r = new Random();
            Angle = r.NextDouble() * 2 * Math.PI;
            velocityX = (float)(Math.Cos(Angle) * Velocity);
            velocityY = (float)(Math.Sin(Angle) * Velocity);
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Red);
            g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();
        }
        public void Move(int left, int top, int width, int height)
        {
            int nextX = (int)(Center.X + velocityX);
            int nextY = (int)(Center.Y + velocityY);
            int lft = left + RADIUS;
            int rgt = left + width - RADIUS;
            int tp = top + RADIUS;
            int btm = top + height - RADIUS;

            if (nextX <= lft)
            {
                nextX = lft + (lft - nextX);
                velocityX = -velocityX;
            }
            if (nextX >= rgt)
            {
                nextX = rgt - (nextX - rgt);
                velocityX = -velocityX;

            }
            if (nextY <= tp)
            {
                nextY = tp + (tp - nextY);
                velocityY = -velocityY;
            }

            if (nextY >= btm)
            {
                nextY = btm - (nextY - btm);
                velocityY = -velocityY;
            }
            Center = new Point(nextX, nextY);
        }

        public bool Touches(int x, int y)
        {
            return (x - Center.X) * (x - Center.X) + (y - Center.Y) * (y - Center.Y) <= RADIUS * RADIUS;
        }
    }
}
