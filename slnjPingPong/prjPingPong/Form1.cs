using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjPingPong
{
    public partial class Form1 : Form
    {
        int ver = 20;
        int hor = 20;
        


        public Form1()
        {
            InitializeComponent();
        }


        
        private void Form1_Load(object sender, EventArgs e)
        {

            Random Rnd = new Random();
            ball.Left = Rnd.Next(10, this.ClientSize.Width - ball.Width);


            //遊戲開始時 board的位置，以及隱藏滑鼠
            bat.Top = this.ClientSize.Height - bat.Height;
            bat.Left = (this.ClientSize.Width / 2) - (bat.Width / 2);

            int startdir = Rnd.Next(1, 3);
            if (startdir == 1) hor = 0 - hor;
           


        }

        //ball在form1內反彈
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ball.Left >= bat.Left && ball.Left<= (bat.Left+bat.Width) &&
                ball.Top >= (bat.Top-ball.Height))
            {
                ver = 0-(ver+5);
            }

            if( (ball.Left+ball.Width)>bat.Left && (ball.Left + ball.Width)<= (bat.Left + bat.Width) && ball.Top >= (bat.Top - ball.Height))
            {
                ver = 0 - (ver + 5);
            }


            if (ball.Top + ball.Height >= this.ClientSize.Height)
            {
                timer1.Enabled = false;
                ball.Left = 10;
                ball.Top = 10;
                Cursor.Show();
                MessageBox.Show("Game Over");
                this.Close();
            }



            ball.Left += hor;
            ball.Top += ver;
            

            if ((ball.Top + ball.Height) >= this.ClientSize.Height || ball.Top <= 0)
            {
                ver = ver * (-1);
            }

            if ((ball.Left + ball.Width) >= this.ClientSize.Width || ball.Left <= 0)
            {
                hor = hor * (-1);
            }
        }



        //將board限制在form1裡面，靠鍵盤左右移動
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 50;

            if(e.KeyValue == 39 &&  bat.Left+bat.Width<this.ClientSize.Width)
            {
                bat.Left += speed;
            
            }else if (e.KeyValue == 37 && bat.Left > 0)
            {
                bat.Left -=speed;
            }
          
        }
    }
}
