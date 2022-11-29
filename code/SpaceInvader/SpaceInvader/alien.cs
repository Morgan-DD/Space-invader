using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Alien
    {
        private bool _type;
        private int _x;
        private int _y;
        private int _speed;




        private string[] _alienSkinGigA = new string[5];
        private string[] _alienSkinGigB = new string[5];

        private string[] _alienSkinSmallA = new string[5];
        private string[] _alienSkinSmallB = new string[5];

        private string[] spaceShip = new string[4];

        private int _alienSpaceShipX = 28;
        private int _alienSpaceShipY = 1;

        private int _nbAlienSpaceShip = 2;
        public Alien(bool type, int x, int y)
        {
            _type = type;
            X = x;
            _y = y;

            _alienSkinGigA[0] = "     ▀▄   ▄▀     ";
            _alienSkinGigA[1] = "    ▄█▀███▀█▄    ";
            _alienSkinGigA[2] = "   █▀███████▀█   ";
            _alienSkinGigA[3] = "   █ █▀▀▀▀▀█ █   ";
            _alienSkinGigA[4] = "      ▀▀ ▀▀      ";

            _alienSkinGigB[0] = "   ▄ ▀▄   ▄▀ ▄   ";
            _alienSkinGigB[1] = "   █▄███████▄█   ";
            _alienSkinGigB[2] = "   ███▄███▄███   ";
            _alienSkinGigB[3] = "   ▀█████████▀   ";
            _alienSkinGigB[4] = "    ▄▀     ▀▄    ";

            _alienSkinSmallA[0] = "      ▄██▄     ";
            _alienSkinSmallA[1] = "    ▄██████▄   ";
            _alienSkinSmallA[2] = "   ███▄██▄███  ";
            _alienSkinSmallA[3] = "     ▄▀▄▄▀▄    ";
            _alienSkinSmallA[4] = "    ▀ ▀  ▀ ▀   ";

            _alienSkinSmallB[0] = "      ▄██▄     ";
            _alienSkinSmallB[1] = "    ▄██████▄   ";
            _alienSkinSmallB[2] = "   ███▄██▄███  ";
            _alienSkinSmallB[3] = "    ▄▀▄▀▀▄▀▄   ";
            _alienSkinSmallB[4] = "   ▀        ▀  ";


            spaceShip[0] = "    ▄▄████▄▄    ";
            spaceShip[1] = "  ▄██████████▄  ";
            spaceShip[2] = "▄██▄██▄██▄██▄██▄";
            spaceShip[3] = "  ▀█▀  ▀▀  ▀█▀  ";
        }

        public bool Type { get => _type; set => _type = value; }
        public int Y { get => _y; set => _y = value; }
        public int X { get => _x; set => _x = value; }

        public bool writeAliens(bool position)
        {
            if (_type)
            {
                if (position)
                {
                    for (int a = 0; a < _alienSkinGigA.Length; a++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(X, _y + a);
                        Console.WriteLine(_alienSkinGigA[a]);
                    }
                }
                else
                {
                    for (int a = 0; a < _alienSkinGigB.Length; a++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(X, _y + a);
                        Console.WriteLine(_alienSkinGigB[a]);
                    }
                }
            }
            else
            {
                if (position)
                {
                    for (int a = 0; a < _alienSkinSmallA.Length; a++)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.SetCursorPosition(X, _y + a);
                        Console.WriteLine(_alienSkinSmallA[a]);
                    }
                }
                else
                {
                    for (int a = 0; a < _alienSkinSmallB.Length; a++)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.SetCursorPosition(X, _y + a);
                        Console.WriteLine(_alienSkinSmallB[a]);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }
        public void writeAlienShip()
        {

            Console.SetCursorPosition(_alienSpaceShipX, _alienSpaceShipY);
            for (int a = 0; a < _nbAlienSpaceShip; a++)
            {
                for (int b = 0; b < spaceShip.Length; b++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (a == 1)
                    {
                        Console.SetCursorPosition(_alienSpaceShipX, _alienSpaceShipY + b);
                    }
                    else
                    {
                        Console.SetCursorPosition((_alienSpaceShipX * 2) + spaceShip[0].Length, _alienSpaceShipY + b);
                    }
                    Console.WriteLine(spaceShip[b]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }


        
    }
}
