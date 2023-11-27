﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManHinh
{
    public partial class Form1 : Form
    {
        PictureBox pd = new PictureBox();
        Timer tmGame = new Timer();
        int xBall = 0;
        int yBall = 0;
        int xDelta = 5;
        int yDelta = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmGame.Interval = 10;
            tmGame.Tick += tmGame_Tick;
            tmGame.Start();
            pd.SizeMode = PictureBoxSizeMode.StretchImage;
            pd.Size = new Size(100, 100);
            pd.Location = new Point(xBall, yBall);
            this.Controls.Add(pd);
            pd.ImageLocation = @"D:\C#\Game\img\ga.jpg";
        }

        void tmGame_Tick(object sender, EventArgs e)
        {
            xBall += xDelta;
            yBall += yDelta;
            if (xBall > this.ClientSize.Width - pd.Width || xBall <= 0)
                xDelta = -xDelta;
            if (yBall > this.ClientSize.Height - pd.Height || yBall <= 0)
                yDelta = -yDelta;
            pd.Location = new Point(xBall, yBall);
        }
    }
}