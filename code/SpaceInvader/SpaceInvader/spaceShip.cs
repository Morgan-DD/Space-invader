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
        List<Bullet> _bullets = new List<Bullet>();

        System.Timers.Timer BulletCooldownTimer = new System.Timers.Timer();
        bool _canShoot = true;

        private string[] _spaceShip = new string[5];


        public SpaceShip()
        {
            _spaceShip[0] = "        ▄        ";
            _spaceShip[1] = "       ███       ";
            _spaceShip[2] = "  ▄███████████▄  ";
            _spaceShip[3] = "  █████████████  ";
            _spaceShip[4] = "  █████████████  ";

            BulletCooldownTimer.Elapsed += BulletCooldownTimer_Tick;
            BulletCooldownTimer.Interval = 1500;

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


        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int GetShipLength()
        {
            return _spaceShip[0].Length;
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

        public void WriteShip()
        {
            for (int a = 0; a < _spaceShip.Length; a++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(_x, 52 + a);
                Console.Write(_spaceShip[a]);
            }
        }

        private void BulletCooldownTimer_Tick(object sender, System.EventArgs e)
        {
            if (!_canShoot)
                _canShoot = true;
            BulletCooldownTimer.Stop();
        }



        public void Shoot()
        {
            if (_canShoot)
            {
                _bullets.Add(new Bullet(_x + 8, 51, true));

                for (int a = 0; a < _bullets.Count; a++)
                {
                    _bullets.Last().Mouve();
                }
                _canShoot=false;
                BulletCooldownTimer.Start();
            }
        }
    }
}