using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    public class SpaceShip
    {

        string _type;
        string _color;

        int _fireTime = 1000;

        int _x;

        bool direction;


        public SpaceShip()
        {


        }

        public SpaceShip(string type, string color)
        {
            _type = type;
            _color = color;


        }

        public string GetShipType
        {
            get { return _type; }
            set { _type = value; }
        }

        public bool GetShipDirection
        {
            get { return direction; }
            set { direction = value; }
        }

        public int GetShipFireTime
        {
            get { return _fireTime; }
            set { _fireTime = value; }
        }

        public int GetShipX
        {
            get { return _x; }
            set { _x = value; }
        }

        public void shoot(int x, int y, bool direction)
        {

            Bullet shoot = new Bullet(x, y, direction);

        }


        public void mouvement()
        {
            if (direction)
            {
                _x++;
            }
            else
            {
                _x--;
            }
        }

    }
}
