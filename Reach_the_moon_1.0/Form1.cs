using System;
using System.IO;
using System.Collections.Generic;
using System.Media;
using System.Linq;
using System.Windows.Forms;

namespace UFO_Atack
{
    public partial class Form1 : Form
    {
        Ship ship = new Main_Ship();
        Ship enemie;
        Ship shot;
        Timer TimeOne= new Timer();
        Timer TimeTwo = new Timer();
        Timer TimeThree = new Timer();
        Timer TimeFour = new Timer();
        List<Ship> ListOfMisiles = new List<Ship>();
        List<Ship> ListOfEnemies = new List<Ship>();
        SoundPlayer Mysound = new SoundPlayer(Path.GetFullPath("modern-rnb-all-your-base-15484.wav"));
        int _Cont = 0;
        private int _aux1 = -1;
        private int _aux2 = -1;
        private int _aux3 = -1;
        private object _StoreObject;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(ship.PictureDrawner());
            TimeOne.Tick += (s, a) => 
            {
                TimerEnemie();
            };
            TimeOne.Interval = 2000;
            TimeOne.Start();
            TimeTwo.Tick += (s, a) =>
            {
                TimerMisile();
            };
            TimeTwo.Interval = 1900;
            TimeThree.Tick += (s, a) =>
            {
                TimerCollision();
            };
            TimeThree.Interval = 1000;
            TimeFour.Tick += (s, a) =>
            {
                TimerUpdate();
            };
            TimeFour.Interval = 1000;
            Mysound.PlayLooping();
        }

        private void Key_detector_KeyPress(object sender, KeyPressEventArgs e)
        {
            Controller(e);
        }
        #region Controls timer to draw enemies
        private void TimerEnemie()
        {
            if (_Cont == 4)
            {
                enemie = new enemies();
                Controls.Add(enemie.PictureDrawner());
                ListOfEnemies.Add(enemie);
                _Cont = 0;
            }
            else
            {
                foreach (Ship SingleEnemie in ListOfEnemies)
                {
                    Controls.Remove(SingleEnemie.Draw);
                    SingleEnemie.PositionY += 80;
                    Controls.Add(SingleEnemie.PictureDrawner());
                }
            }
            _Cont++;
        }
        #endregion
        #region Controls timer to draw Missiles
        private void TimerMisile()
        {
            foreach (Ship SingleMisile in ListOfMisiles)
            {
                Controls.Remove(SingleMisile.Draw);
                SingleMisile.PositionY -= 80;
                Controls.Add(SingleMisile.PictureDrawner());
            }
        }
        #endregion
        #region Controls collision comprobation
        private void TimerCollision()
        {
            int v = ListOfMisiles.Count();
            int c = ListOfEnemies.Count();

            for (int i = 0; i < c; i++)
            {
                for (int a = 0; a < v; a++)
                {
                    if (ListOfMisiles[a].PositionX > ListOfEnemies[i].PositionX + ListOfEnemies[i].Draw.Width - 40)
                    {

                    }
                    else if (ListOfMisiles[a].PositionX + ListOfMisiles[a].Draw.Width - 40 < ListOfEnemies[i].PositionX)
                    {

                    }
                    else if (ListOfMisiles[a].PositionY > ListOfEnemies[i].PositionY + ListOfEnemies[i].Draw.Height - 20)
                    {

                    }
                    else if (ListOfMisiles[a].PositionY + ListOfMisiles[a].Draw.Height - 20 < ListOfEnemies[i].PositionY)
                    {

                    }
                    else
                    {      
                        ListOfEnemies[i].Picture = Path.GetFullPath("Explosion-PNG-Pic.png");
                        Controls.Remove(ListOfMisiles[a].Draw);
                        Controls.Remove(ListOfEnemies[i].Draw);
                        Controls.Add(ListOfEnemies[i].PictureDrawner());
                        _aux1 = a;
                        _aux2 = i;
                        _aux3 = i;
                        TimeFour.Start();
                    }
                }
            }
            OutOfBounds();
        }
        #endregion
        #region Updates picture from enemies to one explosion picture
        private void TimerUpdate()
        {
            Controls.Remove(ListOfEnemies[_aux3].Draw);
            _aux3 = -1;

            if (_aux1 >= 0 && _aux2 >= 0)
            {
                ListOfMisiles.RemoveAt(_aux1);
                ListOfEnemies.RemoveAt(_aux2);
                _aux1 = -1;
                _aux2 = -1;
                TimeFour.Stop();
            }
        }
        #endregion
        #region Detects if the missile is out of the screen limits
        private void OutOfBounds()
        {
            foreach (Ship SingleMisile in ListOfMisiles)
            {
                if (SingleMisile.PositionY <= 0)
                {
                    _aux1 = ListOfMisiles.IndexOf(SingleMisile);
                    _StoreObject = SingleMisile;
                    Controls.Remove(SingleMisile.Draw);
                }
            }
            if (ListOfMisiles.Contains(_StoreObject))
            {
                ListOfMisiles.RemoveAt(_aux1);
            }
        }
        #endregion
        #region Controls main space ship movements
        private void Controller(KeyPressEventArgs e)
        {
            if (Convert.ToString(Keys.D) == Convert.ToString(e.KeyChar).ToUpper() & ship.PositionX < 820)
            {
                Controls.Remove(ship.Draw);
                ship.PositionX += 20;
                Controls.Add(ship.PictureDrawner());
                Key_detector.Text = "";
            }
            else if (Convert.ToString(Keys.A) == Convert.ToString(e.KeyChar).ToUpper() & ship.PositionX > 0)
            {
                Controls.Remove(ship.Draw);
                ship.PositionX -= 20;
                Controls.Add(ship.PictureDrawner());
                Key_detector.Text = "";
            }
            else if (Convert.ToInt32(Keys.D5) == Convert.ToInt32(e.KeyChar))
            {
                shot = new Missile();
                shot.PositionX = ship.PositionX;
                shot.PositionY = ship.PositionY - 80;
                Controls.Add(shot.PictureDrawner());
                ListOfMisiles.Add(shot);
                TimeTwo.Start();
                TimeThree.Start();
            }
        }
        #endregion
    }
}
