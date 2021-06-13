using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public partial class Form1 : Form
    {
        //list of coins picture boxes that will be added on start() method
        List<PictureBox> coinss = new List<PictureBox>();
        //list of enemy car picture boxes that will be added on start() method
        List<PictureBox> enemyss = new List<PictureBox>();
        //list of white strights on the road, picture boxes that will be added on start() method
        List<PictureBox> strights = new List<PictureBox>();
        //speed of movement of the cars,strights and coins in the game
        int gamespeed = 4;
        //<summary>
        //The immage of the PictureBox(the car) selected on "Pocetna" form that will be given
        //to car PictureBox in this form
        //</summary>
        PictureBox selected;
        //Number of coins collected during the game
        public int Coins = 0;
        //Random object used for positioning the cars or coins in different positions
        Random r = new Random();
        //number that represents the future horizontal position of a car or a coin
        int x;

        public Form1(PictureBox img)
        {
            InitializeComponent();
            selected = img;
            car.Image = img.Image;
            start();
        }

        //Adds all the coins,enemy and stright PictureBoxes on the coinss,enemyss and strights lists
        public void start()
        {
            coinss.Add(coin1);
            coinss.Add(coin2);
            coinss.Add(coin3);
            coinss.Add(coin4);
            enemyss.Add(enemy1);
            enemyss.Add(enemy2);
            enemyss.Add(enemy3);
            strights.Add(pictureBox1);
            strights.Add(pictureBox2);
            strights.Add(pictureBox3);
            strights.Add(pictureBox4);
            strights.Add(pictureBox6);

            Game_Over.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(gamespeed);
            enemy(gamespeed);
            gameover();
            collectionCoins(gamespeed);
        }

        //<summary>
        //the function provides the movement of the white strights on the road
        //so the player can have the perception that the road is moving
        //this perception is provided by the timer timer1
        //</summary>
        void moveLine(int speed)
        {
            foreach (PictureBox str in strights)
            {
                if (str.Top >= 600)
                {
                    str.Top = -str.Height;
                }
                else
                {
                    str.Top += speed;
                }
            }

        }

        //<summary>
        //repeated part of code for repositioning a PictureBox
        //which has reached the bottom of the form(road)
        //so the player can have the perception that there are coming new enemys or coins
        //</summary>
        void positioning(PictureBox pb, int speed)
        {
            if (pb.Top >= 600)
            {
                x = r.Next(130, 370);
                pb.Location = new Point(x, -pb.Height);
            }
            else
            {
                pb.Top += speed;
            }
        }

        //<summary>
        //the function provides the movement of the enemy cars on the road
        //so the player can have the perception that they are moving
        //this perception is provided by the timer timer1
        //</summary>
        void enemy(int speed)
        {
            foreach (PictureBox en in enemyss)
            {
                positioning(en, speed);
            }
        }

        //<summary>
        //the function provides the movement of the coins on the road
        //so the player can have the perception that they are moving
        //this perception is provided by the timer timer1
        //if the bounds of the car intersects with the bounds of one of the coins
        //the Coins will increase for one and that will be shown on Coins label
        //</summary>
        void collectionCoins(int speed)
        {
            foreach (PictureBox cn in coinss)
            {
                positioning(cn, speed);
                if (car.Bounds.IntersectsWith(cn.Bounds))
                {
                    Coins++;
                    c.Text = "Coins = " + Coins.ToString();
                    x = r.Next(130, 370);
                    cn.Location = new Point(x, -cn.Height);
                }
            }

        }

        //<summary>
        //if the bounds of the car intersects with the bounds of one of the enemy cars, the timer will stop
        //the explode gif will be visible and positioned above the car, the label game over will be visible
        //and the home button will be visible, so the player will not be able to continue the game
        //</summary>
        void gameover()
        {
            if (car.Bounds.IntersectsWith(enemy1.Bounds) || car.Bounds.IntersectsWith(enemy2.Bounds) || car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                car.Controls.Add(explode);
                explode.Location = new Point(-5, 5);
                explode.Visible = true;
                timer1.Enabled = false;
                Game_Over.Visible = true;
                home.Visible = true;
                timer1.Stop();
                explode.BackColor = Color.Transparent;

            }
        }

        //will close the actual game form and will send information to Pocetna form
        private void home_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Dispose(false);

        }

        //<summary>
        //enables the movement of the car by pressing the left and righ keyboard keys
        //but in order not to go out of bounds a condition is set that it can not move 
        //right more than 370 and left less than 130.
        //Also by pressing the up and down keys, it increases or decreases the game speed.
        //</summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (car.Left > 130)
                    car.Left += -10;

            }
            if (e.KeyCode == Keys.Right)
            {
                if (car.Left < 370)
                    car.Left += 10;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (gamespeed < 21)
                    gamespeed++;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (gamespeed > 0)
                    gamespeed--;
            }
        }
    }
}
