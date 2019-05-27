using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IspitMaster
{
    public class BallsDoc
    {

        public List<Balls> Ball { get; set; }
        public List<MouseBall> Mball { get; set; }
        Random random;

        public BallsDoc() {
            Ball = new List<Balls>();
            Mball = new List<MouseBall>();
            random = new Random();
        }
        public void Draw(Graphics g) {
            foreach (Balls ball in Ball) {
                ball.Draw(g);
            }
            foreach (MouseBall mb in Mball)
            {
                mb.Draw(g);
            }

        }
        public void AddMB(MouseBall Ball)
        {
            Mball.Add(Ball);
        }
        public void clear()
        {
            Mball.Clear();
        }


        public void AddBall(Balls ball)
        {
            Ball.Add(ball);
        }

        public void MoveBalls(int left, int top, int width, int height)
        {
            foreach (Balls ball in Ball)
            {
                ball.Move(left, top, width, height);
            }
        }
        public void GenerateOne(int left, int top, int width, int height)
        {
            int x = random.Next(left + Balls.RADIUS, (left + width) - Balls.RADIUS);
            int y = random.Next(top + Balls.RADIUS, (top + height) - Balls.RADIUS);
            bool touches = false;
            foreach (Balls h in Ball)
            {
                touches = h.Touches(x, y);
                if (touches) break;
            }
            Balls b = new Balls(new Point(x, y));
            Ball.Add(b);
        }


        public bool CheckColisions()
        {
            for (int i = 0; i < Ball.Count; ++i)
            {
                for (int j = 0; j < Mball.Count; ++j)
                {
                    if (Mball[j].InHole(Ball[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
    }
