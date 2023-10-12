using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Ghoul_Shooter_Game
{
    public partial class Form1 : Form
    { 
        // add new media player
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        //variables
        bool movementUp, movementDown, movementRight, movementLeft, gameOver;
        string facing = "Up"; //bullet direction guide
        int playerHealth = 100;
        int kills;
        int ammo = 10;
        int ghoulSpeed = 4;
        int playerSpeed = 11;
        Random randNum = new Random();

        List<PictureBox> ghoulList = new List<PictureBox>();


        public Form1()
        {
            InitializeComponent();
            RestartGame();
            //music address
            player.URL = "rengartheme.mp3";
        }

        private void GameLoad(object sender, EventArgs e)
        {
            // player health being assigned to progress bar
            if (playerHealth > 1)
            {
                progressHealthBar.Value = playerHealth;
            }
            else
            {
                //Player dead
                gameOver = true;
                pictureBoxPlayer.Image = Properties.Resources.dead;
                Timer.Stop();

            }
            
            // labels
            labelAmmo.Text = "Ammo: " + ammo;
            labelKills.Text = "Kills: " + kills;

            // player movement according to position of screen

            if (movementLeft == true && pictureBoxPlayer.Left > 0)
            {
                //if moving left left then move player left
                pictureBoxPlayer.Left -= playerSpeed;
            }
            if (movementRight == true && pictureBoxPlayer.Left + pictureBoxPlayer.Width < this.ClientSize.Width)
            {
                ///if moving right then move player right
                pictureBoxPlayer.Left += playerSpeed;
            }
            if (movementDown == true && pictureBoxPlayer.Top + pictureBoxPlayer.Height < this.ClientSize.Height)
            {
                //if moving down then move player down
                pictureBoxPlayer.Top += playerSpeed;
            }
            if (movementUp == true && pictureBoxPlayer.Top > 69)
            {
                //if moving top then move player top
                pictureBoxPlayer.Top -= playerSpeed;
            }

            foreach (Control x in this.Controls)
            {
                // if player comes in contact with ammo, picturebox and tag. 
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (pictureBoxPlayer.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5; // add 5 ammo
                    }


                }
                // if player comes in contact with a ghoul

                if (x is PictureBox && (string)x.Tag == "ghoul")
                {
                    // decrease health by 1
                    if (pictureBoxPlayer.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;
                    }

                    //move ghoul towards the player
                    if (x.Left < pictureBoxPlayer.Left)
                    {
                        //move ghoul right
                        x.Left += ghoulSpeed;
                        ((PictureBox)x).Image = Properties.Resources.gright;

                    }
                    if (x.Top > pictureBoxPlayer.Top)
                    {
                        //move ghoul up
                        x.Top -= ghoulSpeed;
                        ((PictureBox)x).Image = Properties.Resources.gtop;

                    }
                    if (x.Top < pictureBoxPlayer.Top)
                    {
                        //move ghoul down
                        x.Top += ghoulSpeed;
                        ((PictureBox)x).Image = Properties.Resources.gdown;

                    }
                    if (x.Left > pictureBoxPlayer.Left)
                    {
                        //move ghoul left
                        x.Left -= ghoulSpeed;
                        ((PictureBox)x).Image = Properties.Resources.gleft;

                    }
                }
                {
                    foreach (Control j in this.Controls)
                    {
                        if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "ghoul")
                        { 
                            //bullet and ghoul interaction if bullet hits ghoul
                            // add another ghoul once one dies
                            // increase kill score by 1

                            if (x.Bounds.IntersectsWith(j.Bounds))
                            {
                                kills++;

                                this.Controls.Remove(j);
                                ((PictureBox)j).Dispose();
                                this.Controls.Remove(x);
                                ((PictureBox)x).Dispose();
                                ghoulList.Remove(((PictureBox)x));
                                SpawnGhoul();
                            }
                        }
                    }
                }

            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {     
            // if game is over then do nothing
            if (gameOver == true)
            {
                return;
            }
            //key down selections - what happens if you press down a key
            if(e.KeyCode == Keys.Left)
            {
                movementLeft = true;
                facing = "left";
                pictureBoxPlayer.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.Right)
            {
                movementRight = true;
                facing = "right";
                pictureBoxPlayer.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.Up)
            {
                movementUp = true;
                facing = "up";
                   
                pictureBoxPlayer.Image = Properties.Resources.top;
            }

            if (e.KeyCode == Keys.Down)
            {
                movementDown = true;
                facing = "down";

                pictureBoxPlayer.Image = Properties.Resources.down;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            //key up selections
            if (e.KeyCode == Keys.Right)
            {
                movementRight = false;
                
            }

            if (e.KeyCode == Keys.Up)
            {
                movementUp = false;
                
            }

            if (e.KeyCode == Keys.Down)
            {
                movementDown = false;
                
            }

            if (e.KeyCode == Keys.Left)
            {
                movementLeft = false;

            }

            if (e.KeyCode == Keys.Space && ammo > 0 && gameOver == false)
            {
                ammo--;
                BulletShell(facing);

                if (ammo < 1) //if ammo is less than one then add more
                {
                    AmmoStash();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //play music
            player.controls.play();
        }

        

        private void BulletShell(string direction)
        {
            //create new bullets
            Bullet bulletShell = new Bullet();
            
            bulletShell.bulletLeft = pictureBoxPlayer.Left + (pictureBoxPlayer.Width / 2);
            bulletShell.bulletTop = pictureBoxPlayer.Top + (pictureBoxPlayer.Height / 2);
            bulletShell.direction = direction;
            bulletShell.CreateBullet(this);

        }

        private void SpawnGhoul()
        {
            //create ghouls
            PictureBox ghoul = new PictureBox();
            ghoul.Tag = "ghoul";
            ghoul.Image = Properties.Resources.gdown;
            ghoul.Left = randNum.Next(0, 900);
            ghoul.Top = randNum.Next(0, 800);
            ghoul.SizeMode = PictureBoxSizeMode.AutoSize;
            ghoulList.Add(ghoul);
            this.Controls.Add(ghoul);
            pictureBoxPlayer.BringToFront();
        }

        private void AmmoStash()
        {
            //create ammo image on the screen
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);

            ammo.BringToFront();
            pictureBoxPlayer.BringToFront();
        }

        private void RestartGame()
        {
            //restart game, assign variables to default
            pictureBoxPlayer.Image = Properties.Resources.top;

            foreach (PictureBox g in ghoulList)
            {
                this.Controls.Remove(g);
            }
            ghoulList.Clear();

            for (int g = 0; g < 3; g++)
            {
                SpawnGhoul();
            }

           

            playerHealth = 100;
            kills = 0;
            ammo = 10;

            movementUp = false;
            movementDown = false;
            movementRight = false;
            movementLeft = false;
            gameOver = false;


            Timer.Start();
        }
    }
}
