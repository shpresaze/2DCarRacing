using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public partial class Pocetna : Form
    {
        //object of Form1 class that will be created and shown on button1_Click(...) method
        public Form1 form;  
        //The seleced PictureBox,the image of which, will be the image of the car PictureBox of form
        PictureBox selected;
        //static integer variable that will save the number of collected coins after closing the game form(form)
        public static int totalC;
        //list of buyed and avilable cars(PictureBox-es) to select 
        public List<PictureBox> myCars;



        public Pocetna()
        {
            InitializeComponent();
            selected = yellow;
            
            form = new Form1(selected);
        }

        
        //<summary>
        //The function starts a new game with te Form1 constructor, sending the selected PictureBox as an argument
        //if the form is closed correctly from the home button, the number of total collected coins will be updated and shown 
        //<summary>
        private void button1_Click(object sender, EventArgs e)
        {
            
            
                form = new Form1(selected);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    totalC = totalC + form.Coins;
                    total.Text = totalC.ToString();
                }
            
        }

        //<summary>
        //The function select the yellow PictureBox if it's clicked, and set the car's image on
        //the new form to be the yellow's PictureBox image, deselect the other cars and
        //will enable the play button
        //<summary>
        private void yellow_Click(object sender, EventArgs e)
        {
            if (myCars.Contains(yellow))
            {
                yellow.BorderStyle = BorderStyle.Fixed3D;
                selected = yellow;
                form.car.Image = selected.Image;
                white.BorderStyle = BorderStyle.None;
                blue.BorderStyle = BorderStyle.None;
                red.BorderStyle = BorderStyle.None;
                button1.Enabled = true;
            }
        }

        //<summary>
        //The function select the white PictureBox if it's clicked, and set the car's image on
        //the new form to be the white's PictureBox image, deselect the other cars and
        //will enable the play button
        //<summary>
        private void white_Click(object sender, EventArgs e)
        {
            if (myCars.Contains(white))
            {
                white.BorderStyle = BorderStyle.Fixed3D;
                selected = white;
                form.car.Image = selected.Image;
                yellow.BorderStyle = BorderStyle.None;
                blue.BorderStyle = BorderStyle.None;
                red.BorderStyle = BorderStyle.None;
                button1.Enabled = true;
            }
        }

        //<summary>
        //The function select the blue PictureBox if it's clicked, and set the car's image on
        //the new form to be the blue's PictureBox image, deselect the other cars and
        //will enable the play button
        //<summary>
        private void blue_Click(object sender, EventArgs e)
        {
            if (myCars.Contains(blue))
            {
                blue.BorderStyle = BorderStyle.Fixed3D;
                selected = blue;
                form.car.Image = selected.Image;
                yellow.BorderStyle = BorderStyle.None;
                white.BorderStyle = BorderStyle.None;
                red.BorderStyle = BorderStyle.None;
                button1.Enabled = true;
            }
        }

        //<summary>
        //The function select the red PictureBox if it's clicked, and set the car's image on
        //the new form to be the red's PictureBox image, deselect the other cars and
        //will enable the play button
        //<summary>
        private void red_Click(object sender, EventArgs e)
        {
            if (myCars.Contains(red))
            {
                red.BorderStyle = BorderStyle.Fixed3D;
                selected = red;
                form.car.Image = selected.Image;
                yellow.BorderStyle = BorderStyle.None;
                white.BorderStyle = BorderStyle.None;
                blue.BorderStyle = BorderStyle.None;
                button1.Enabled = true;
            }
        }
        private void whiteAllow()
        {
            whiteLock.Visible = false;
            whitePrice.Visible = false;
        }
        
        private void blueAllow()
        {
            blueLock.Visible = false;
            bluePrice.Visible = false;
        }
        
        private void redAllow()
        {
            redLock.Visible = false;
            redPrice.Visible = false;
            arrow.Visible = false;
            clickToBuy.Visible = false;
        }

        //<summary>
        //If the form is being closed, this function will save the list of buyed cars
        //and collected coins, and will serialize them
        //<summary>
        private void Pocetna_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<String> names = new List<string>();
            foreach (PictureBox p in myCars)
            {
                names.Add(p.Name);
            }
            DataSave.Serialize(totalC, names);
        }

        //<summary>
        //On loading of the form, this function will initialize myCars list in order to 
        //the cars that have been stored on DataSave.Serialize, and the coins too so the game
        //will look like the moment when it's been closed
        //<summary>
        private void Pocetna_Load(object sender, EventArgs e)
        {
            DataSave data = DataSave.DeSerialize();

            totalC = data.Coins;
            myCars = new List<PictureBox>();
            foreach (string s in data.MyCars)
            {
                switch (s)
                {
                    case "yellow":
                        myCars.Add(yellow);
                        break;
                    case "white":
                        myCars.Add(white);
                        whiteAllow();
                        break;
                    case "blue":
                        myCars.Add(blue);
                        blueAllow();
                        break;
                    case "red":
                        redAllow();
                        myCars.Add(red);
                        break;
                }
                total.Text = totalC.ToString();
            }
        }

        //<summary>
        //If the player wants to reset the game and click to resetGame button, the coins will return to 0 
        //and buyed cars will have just the yellow car, in fact this function will delete the file created 
        //while serializing
        //<summary>
        private void resetGame_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to reset the game?", "Restart game", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + "\\stats.dat";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                Pocetna_Load(null, null);
                whiteLock.Visible = true;
                blueLock.Visible = true;
                redLock.Visible = true;
                whitePrice.Visible = true;
                bluePrice.Visible = true;
                redPrice.Visible = true;
                selected = yellow;
                white.BorderStyle = BorderStyle.None;
                blue.BorderStyle = BorderStyle.None;
                red.BorderStyle = BorderStyle.None;

            }
        }

        //<summary>
        //this function will add the selected PictureBox on the list myCars,and reduce the coins for 200,
        //and the PictureBox will be allowed to be selected.the function will do that only if the player has enough coins
        //<summary>
        private void redLock_Click(object sender, EventArgs e)
        {
            if (totalC >= 200)
            {
                totalC = totalC - 200;
                total.Text = totalC.ToString();
                myCars.Add(red);
                redAllow();
            }
            else
            {
                MessageBox.Show("You don't have enough coins to buy the car!");
            }
        }

        //<summary>
        //this function will add the selected PictureBox on the list myCars,and reduce the coins for 200,
        //and the PictureBox will be allowed to be selected.the function will do that only if the player has enough coins
        //<summary>
        private void blueLock_Click(object sender, EventArgs e)
        {
            if (totalC >= 100)
            {
                totalC = totalC - 100;
                total.Text = totalC.ToString();
                myCars.Add(blue);
                blueAllow();
            }
            else
            {
                MessageBox.Show("You don't have enough coins to buy the car!");
            }
        }

        //<summary>
        //this function will add the selected PictureBox on the list myCars,and reduce the coins for 200,
        //and the PictureBox will be allowed to be selected.the function will do that only if the player has enough coins
        //<summary>
        private void whiteLock_Click(object sender, EventArgs e)
        {
            if (totalC >= 50)
            {
                totalC = totalC - 50;
                total.Text = totalC.ToString();
                myCars.Add(white);
                whiteAllow();
            }
            else
            {
                MessageBox.Show("You don't have enough coins to buy the car!");
            }
        }
    }
}
