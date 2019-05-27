using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IspitMaster
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        BallsDoc ballsDoc;
        Timer timer;
        int leftX;
        int topY;
        int width;
        int height;
        Random random;
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
            ballsDoc = new BallsDoc();
            this.DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            leftX = 20;
            topY = 60;
            random = new Random();
            width = this.Width - (3 * leftX);
            height = this.Height - (int)(2.5 * topY);
            ballsDoc.GenerateOne(leftX, topY, width, height);
            ballsDoc.GenerateOne(leftX, topY, width, height);

        }
        void timerstop() {
            timer.Stop();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            ballsDoc.MoveBalls(leftX, topY, width, height);
            if(counter%50 == 0) {
                ballsDoc.GenerateOne(leftX, topY, width, height);
            }
            if (ballsDoc.CheckColisions() == true) {
                timer.Stop();
                const string message = "You Lose";
                MessageBox.Show(message);
                timer.Start();
            }
            

            counter++;
            Invalidate(true);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 3);
            e.Graphics.DrawRectangle(pen, leftX, topY, width, height);
            pen.Dispose();
            ballsDoc.Draw(e.Graphics);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            width = this.Width - (3 * leftX);
            height = this.Height - (int)(2.5 * topY);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ballsDoc.clear();
            MouseBall ball = new MouseBall(e.Location);
            ballsDoc.AddMB(ball);
            Invalidate(true);
        }

    }
}
