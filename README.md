# 2DCarRacing
## Опис на апликацијата ##
Апликацијата што ја развивав е класичната игра 2D Car Racing, која ја проширив со можност за купување и промена на автомобилот.
Целта на играта е да се соберат парички без да се судири со други автомобили, а со паричките да се купуваат други автомобили.
# Упатство за користење #
### Нова игра ###
На почетниот прозорец (слика 1) при стартување на апликацијата имаме можност да започнеме нова игра (Play), да го провериме бројот на паричките што ги имаме, и да купиме и селектираме соодветно автомобил со кои сакаме да играме.
Име четри можности за избор на автомобил:<br>
• Жолт автомобил<br>
• Бел автомобил<br>
• Син автомобил<br>
• Црвен автомобил<br>
од кои, првиот или жолтиот автомобил, е можно да биде селектиран без купување.
Нова игра не е можна да се започне без селектирање на автомобил.<br>
Податоците се сериализирани и се достапни и после исклучување на играта, а доколку
сакаме играта да го добије почетниот поглед можеме да го постигнеме тоа со кликнување
на копчето Reset.<br>
### Стрелките ###
На почетниот прозорец (слика 1) , со цел да им биде овозможувано на корисниците
подобро објаснување на начинот како се игра играта, се савени четрите стрелки од
тастатура:<br>
• → (go right) за корисникот да може да го придвижи автомобилот надесно.<br>
• ← (go left) за корисникот да може да го придвижи автомобилот налево.<br>
• ↑ (speed up) за корисникот да може да ја зголемува брзината на автомобилот и
играта.<br>
• ↓ (slow down) за корисникот да може да ја намалува брзината на автомобилот и
играта до 0.<br>
### Купување на автомобил ###
На почетниот прозорец (слика 1), има можност за купување и селектирање автомобил.<br>
Автомобилите кои не се отворени(купувани), во долниот дел имаат по еден клуч и цена.<br>
#### Цените на автомобилите: ####
• Жолт автомобил (0 парички)<br>
• Бел автомобил(50 парички)<br>
• Син автомобил(100 парички)<br>
• Црвен автомобил(200 парички)<br>
Доколку играчот има соберено доволно парички има можност да претисне во клучот на
автомобилот кои би сакал да го купи и со тоа клучот и цената ќе бидат отстранети, а
автомобилот ќе добије можност за селектирање.<br>
По купување на автомобил, соодветиот износ од паричките ќе биде одземен од тоталните
парички(Total coins).<br>
### Ресетирање на играта(Reset) ###
На почетниот прозорец (слика 1),има копче за ресетирање на играта, тоест при
кликнување на копчето најпрвин излегува предупредување со што се прашува играчот
дали сигурно сака да ја ресетира играта,при кликнување OK сите промени направени до
тој момент во врска со играта како зголемување на број парички и купување нови
автомобили, ќе се ресетираат како во изгледот на слика 1.<br>
<img src="2DCarRacing/Images/slika1.png"
     alt="Markdown Monster icon"
     style="float: left; margin-right: 10px;" />
![image](2DCarRacing/Images/slika1.png)
### Правила ###
•Автомобилот на играчот не треба да се судри со непријателните автомобили. <br>
### Непријатели во играта ###
При започнување на нова игра ќе се отвори прозорецот на играта (слика 2) автомобили
ставени по пат кои доаѓаат на спротивната страна од нашиот селектиран автомобил, се
всушност непријатели, од кои треба да се пазиме за да не се случи судир.<br>
### Парички (coins) ###
Во прозорецот на играта (слика 2), освен непријателните возила, по пат се ставени некои
парички , а целта на играчот е да ги собере со селектираниот автомобил. При соберење на
парички во делот Coins , во горната десна страна на прозорецот, може да се мониторира
бројот на собрани парички.<br>
### Судир (Game over) ###
Ако нашиот автомобил го допира еден од непријателните автомобили , станува судир и
прозорчето изгледа како во (слика 3). Играта застанува,се прикажува пораката Game Over,
се прикажува анимација или експлоивен gif над нашиот автомобил, и истотака се
прикажува копче за наваќање на почетниот прозорец. <br>
### Навраќање на почетниот прозорец (home icon button) ###
Во (слика 3), при притиснување на црвеното копче со нацртана куќичка, играта го затвори
тековниот прозорец и се враќа во почетниот прозорец(слика 1), со тоа што паричките
соберени за време на играта се додаваат на делот total coins од почетниот прозорец.<br>
![image](:\Users\shpre\Desktop\2D-Car-Racing-191038\Images\slika2.png)
![image](:\Users\shpre\Desktop\2D-Car-Racing-191038\Images\slika3.png)
## Опис на структури за чување на податоци ##
Апликацијата е создадена од 2 форми, почетната форма, формата која се отвара при кликнување
на Play(формата за време на играње), и DataSave сериализирана класа за чување на добијени
парички и купени автомобили и по исклучување на апликацијата.<br>
### Pocetna (Почетна форма) ###
```csharp
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
    }
```
### Form1 (Форма за време на игра)  ###
```csharp
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
    }
```
### Data Save класата ###
```csharp
[Serializable]
    public class DataSave
    {
        //total coins collected until the application will be closed
        public int Coins { get; set; }
        //total cars buyed until the application will be closed
        public List<String> MyCars { get; set; }
    }
```
## Опис на функции за развивање на апликацијата ##
Напомена: Секој од овие функции се објаснети со коментари во самиот код.<br>
• Функција за започнување на нова игра
```csharp
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
```
• Функција за ресетирање на играта
```csharp
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
```
• Една од фунцкиите за купување на нов автомобил(црвен автомобил)
```csharp
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
```
## Функциите на Form1 класата ##
```csharp
public partial class Form1 : Form
    {
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
```
