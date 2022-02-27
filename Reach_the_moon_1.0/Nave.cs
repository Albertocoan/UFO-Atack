using System.Windows.Forms;
using System;
using System.Drawing;
using System.IO;

namespace UFO_Atack
{
    #region // Parent class to make a ship
    public class Ship
    {
        private string picture;
        private int positionX;
        private int positionY;
        public PictureBox Draw;
        public string Picture
        {
            set { picture = value; }
            get { return picture; }
        }
        public int PositionX
        {
            set { positionX = value; }
            get { return positionX; }
        }
        public int PositionY
        {
            set { positionY = value; }
            get { return positionY; }
        }
        public virtual void Explotar()
        {
            // Do nothing
        }
        public void PathFinder(string Document)
        {
            Picture = Path.GetFullPath(Document);
        }
        public PictureBox PictureDrawner()
        {
            Draw = new PictureBox(); // 820 como maximo & 0 el minimo
            Draw.Location = new Point(PositionX,PositionY);
            Draw.Size = new Size(80,80);
            Draw.SizeMode = PictureBoxSizeMode.StretchImage;
            Draw.Image = Image.FromFile(Picture);

            return Draw;
        }

    }
    #endregion
    #region //Child class to make the main ship
    class Main_Ship : Ship
    {
        public Main_Ship()
        {
            PositionX = 300;
            PositionY = 600;
            PathFinder("SHIP.png");
        }

    }
    #endregion
    #region // Child class to make the missiles
    class Missile : Ship
    {
        public Missile()
        {
            PathFinder("Vector-Realistic-Rocket-PNG-File.png");
        }
    }
    #endregion
    #region // Child class to make enemies
    class enemies : Ship
    {
        Random XpositionRandom = new Random();
        public enemies()
        {
            PositionX = Convert.ToInt32(XpositionRandom.Next(0, 820));
            PositionY = 0;
            PathFinder("Alien-Spaceship-PNG-Image.png");
        }

    }
    #endregion
}
