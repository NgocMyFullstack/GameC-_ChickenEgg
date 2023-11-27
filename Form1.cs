using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ega
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight;
        int speed = 8;
        int score =0;
        int missed =0;
        int Level = 0;
        Random randY = new Random(); //this will be used to generate a random Y location
        Random randX = new Random(); // this will be used to generate a random X location
        PictureBox splash = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            Restargame();
        }

        private void timer(object sender, EventArgs e)
        {
            level.Text = "Level:" + Level;
            Score1.Text = "Saved:" + score;
            miss.Text = "Missed:" + missed;
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= 12;
                player.Image = Properties.Resources.chicken_normal2;
            }
            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += 12;
                player.Image = Properties.Resources.chicken_normal;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ega")
                {
                    x.Top += speed;


                    if (x.Top + x.Height > this.ClientSize.Height)
                    {
                        splash.Image = Properties.Resources.splash;
                        splash.Location = x.Location;
                        splash.Height = 60;
                        splash.Width = 60;
                        splash.BackColor = Color.Transparent;
                        this.Controls.Add(splash);
                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randX.Next(5, this.ClientSize.Width);
                        missed += 1;
                        player.Image = Properties.Resources.chicken_hurt;
                    }
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randX.Next(5, this.ClientSize.Width - x.Width);
                        //score += 1;
                        // Check if score is greater than 10, then add 2 points to the score
                        if (score > 10)
                        {
                            score += 2;
                        }
                        else
                        {
                            score += 1;
                        }
                        if (score > 30)
                        {
                            score += 1;
                        }
                        if (score > 60)
                        {
                            score += 1;
                        }
                        if (score > 100)
                        {
                            score += 5;
                        }
                    }
                }
                if (x is PictureBox && (string)x.Tag == "star")
                {
                    x.Top += 6; if
                        (x.Top + x.Height > this.ClientSize.Height)
                    {
                        splash.Image = Properties.Resources.splash;
                        splash.Location = x.Location;
                        splash.Height = 60;
                        splash.Width = 60;
                        splash.BackColor = Color.Transparent;
                        this.Controls.Add(splash);
                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randX.Next(5, this.ClientSize.Width);
                        missed += 1;
                    }
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randX.Next(5, this.ClientSize.Width - x.Width);
                        //score += 1;
                        // Check if score is greater than 10, then add 2 points to the score
                        if (missed > 1)
                        {
                            missed += -1;
                        }
                    }
                }
                if (score > 10)
                {
                    speed = 10;
                    Level = 2;

                }
                if (score > 30)
                {
                    speed = 12;
                    Level = 3;
                }
                if (score > 60)
                {
                    speed = 14;
                    Level = 4;
                }
                if (score > 100)
                {
                    speed = 16;
                    Level = 5;
                }
                if (missed > 5)
                {
                    timer1.Stop();
                    MessageBox.Show("gameover!" + Environment.NewLine + "we've lost good age!" + Environment.NewLine + "click ok to rety");
                    Restargame();
                }
                //////////////////////
                //if (score > 60)
                //{
                //    // Hiển thị hình ảnh bonus khi score > 60
                //    foreach (Control x in this.Controls)
                //    {
                //        if (x is PictureBox && (string)x.Tag == "bonus")
                //        {
                //            x.Left = randX.Next(5, this.ClientSize.Width - x.Width);
                //            x.Visible = true;
                //        }
                //    }
                //}
                //else
                //{
                //    // Ẩn hình ảnh bonus khi điều kiện không thỏa mãn
                //    foreach (Control x in this.Controls)
                //    {
                //        if (x is PictureBox && (string)x.Tag == "bonus")
                //        {
                //            x.Visible = false;
                //        }
                //    }
                //}
                ////////////////////////////
            }
        }
            
            
    

        private void KeyIsDows(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }
        private void Restargame()
        {
            foreach(Control x in this.Controls)
            {
                if( x is PictureBox && (string)x.Tag == "ega")
                    {
                    x.Top = randY.Next(80,300) * -1;
                    x.Left = randX.Next(5, this.ClientSize.Width - x.Width);
                }
            }
            player.Left = this.ClientSize.Width / 2;
            player.Image = Properties.Resources.chicken_normal;
            score = 0;
            speed = 8;
            missed = 0;
            Level = 1;
            goLeft = false;
            goRight = false;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tạo một PictureBox mới để hiển thị hình ảnh khi score > 60
            PictureBox newPictureBox = new PictureBox();
            newPictureBox.Image = Properties.Resources.star; // Thay your_image_name bằng tên hình ảnh của bạn
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.Width = 50; // Thiết lập kích thước ảnh bạn muốn hiển thị
            newPictureBox.Height = 50;
            newPictureBox.Tag = "bonus"; // Đặt Tag để phân biệt với các PictureBox khác
            newPictureBox.Visible = false; // Ban đầu ẩn PictureBox này

            this.Controls.Add(newPictureBox);   
        }

        private void Score1_Click(object sender, EventArgs e)
        {

        }

        private void level_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

    }
}

