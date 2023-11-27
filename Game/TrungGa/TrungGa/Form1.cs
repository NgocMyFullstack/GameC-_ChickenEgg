using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrungGa
{
    public partial class Form1 : Form
    {
        PictureBox pdEgg = new PictureBox();
        Timer tmEgg = new Timer();
        int xEgg = 300;
        int yEgg = 0;
        int XDelta = 3;
        int yDelta = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmEgg.Interval = 10;
            tmEgg.Tick += tmEgg_Tick;
            tmEgg.Start();

            pdEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pdEgg.Size = new Size(100, 100);
            pdEgg.Location = new Point(xEgg, yEgg);
            pdEgg.BackColor = Color.Transparent;
            this.Controls.Add(pdEgg);
            pdEgg.Image = Image.FromFile("../../img/trung1.png");
        }

        void tmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDelta;
            if (yEgg > this.ClientSize.Height - pdEgg.Height || yEgg <= 0)
                pdEgg.Image = Image.FromFile("../../img/trung2.jpg");
            pdEgg.Location = new Point(xEgg, yEgg);
        }
    }
}
