using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tui
{
    public partial class Form1 : Form
    {
        PictureBox pdBasket = new PictureBox();
        int xBasket = 300;
        int yBasket = 500;
        int xDelta = 30;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pdBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pdBasket.Size = new Size(100, 100);
            pdBasket.Location = new Point(xBasket, yBasket);
            pdBasket.BackColor = Color.Transparent;
            this.Controls.Add(pdBasket);
            pdBasket.Image = Image.FromFile("../../img/tui.jpg");
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            // Thêm sự kiện KeyDown vào form
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            // Cho phép form nhận các sự kiện từ bàn phím trước
            this.KeyPreview = true;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 39 & (xBasket < this.ClientSize.Width - pdBasket.Width))
                xBasket += xDelta;
            if (e.KeyValue == 37 & xBasket > 0)
                xBasket -= xDelta;
            pdBasket.Location = new Point(xBasket, yBasket);
        }
    }
}
