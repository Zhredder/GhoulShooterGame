using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ghoul_Shooter_Game
{
    class Bullet
    {
        //variables

        public int bulletTop;
        public int bulletLeft;
        public string direction;
        private int speed = 20;
        private PictureBox bullet = new PictureBox();
        private Timer bulletTimer = new Timer(); //timer to execute specific code repeatedly


        public void CreateBullet(Form form)
        {
            //Creates and adds bullets to the game

            bullet.BackColor = Color.GhostWhite;
            bullet.Tag = "bullet";  
            bullet.Left = bulletLeft;
        
            bullet.BringToFront();
            bullet.Size = new Size(5, 5);
            //bring bullets to the front of other objects so they are visible
            bullet.Top = bulletTop; 

            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletEvent);
            bulletTimer.Start();
        }

        private void BulletEvent(object sender, EventArgs e)
        {
            // if player is facing left then shoot left
            if (direction == "left")
            {
                bullet.Left -= speed;
            }
            // if player is facing up then shoot up
            if (direction == "up")
            {
                bullet.Top -= speed;
            }
            // if player is facing down then shoot down
            if (direction == "down")
            {
                bullet.Top += speed;
            }
            // if player is facing right then shoot right
            if (direction == "right")

            {
                bullet.Left += speed;
            }

            // if bullet is less than 10 pixels to the right or
            // if the bullet is more than 840 pixels to the right or
            // if the bullet is less than 12 pixels to the top or
            // if the bullet is 590 px to the bottom or 
            
            if (bullet.Left < 10 || bullet.Left > 840 || bullet.Top < 12 || bullet.Top > 590)
            {
                //dispose the following components 
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
            }
        }
    }
}


