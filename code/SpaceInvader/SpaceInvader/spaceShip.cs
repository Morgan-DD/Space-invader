using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpaceInvader
{
    public class SpaceShip
    {

        string _type;
        string _color;


        int _x;

        bool direction;

        Game _game;


        private string[] _spaceShip = new string[5];

        System.Timers.Timer shootTimer = new System.Timers.Timer();


        public SpaceShip()
        {
            
            shootTimer.Elapsed += shootTimer_Tick;


            _spaceShip[0] = "        ▄        ";
            _spaceShip[1] = "       ███       ";
            _spaceShip[2] = "  ▄███████████▄  ";
            _spaceShip[3] = "  █████████████  ";
            _spaceShip[4] = "  █████████████  ";

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


        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public Game Game { get => _game; set => _game = value; }
        public Timer GetShootTimer { get => shootTimer; set => shootTimer = value; }

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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(_x, 52 + a);
                Console.Write(_spaceShip[a]);
            }
        }

        public bool Shoot()
        {
            bool canShoot = _game.GetCanShoot;
            if (canShoot)
            {
                _game.newShoot(_x, true);
                canShoot = false;
            }
            return false;
        }

        public void shootTimer_Tick(object sender, System.EventArgs e)
        {
            shootTimer.Interval = _game.GetShootSpeed();
            bool canShoot = _game.GetCanShoot;
            if (!canShoot)
                _game.GetCanShoot = true;
        }

        public void StartShootTimer(bool option)
        {
            if (option)
            {
                shootTimer.Start();
            }
            else
            {
                shootTimer.Stop();
            }
        }
    }
}