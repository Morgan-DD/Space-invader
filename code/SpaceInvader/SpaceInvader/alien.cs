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




        private string[] _anlienSkinGigA = new string[5];
        private string[] _anlienSkinGigB = new string[5];

        private string[] _anlienSkinSmallA = new string[5];
        private string[] _anlienSkinSmallB = new string[5];

        private string[] spaceShip = new string[4];

        private int _spaceShipX = 28;
        private int _spaceShipY = 1;

        private int _nbSpaceShip = 2;
        public Alien(bool type, int x, int y)
        {
            _type = type;
            X = x;
            _y = y;

            _anlienSkinGigA[0] = "     ▀▄   ▄▀     ";
            _anlienSkinGigA[1] = "    ▄█▀███▀█▄    ";
            _anlienSkinGigA[2] = "   █▀███████▀█   ";
            _anlienSkinGigA[3] = "   █ █▀▀▀▀▀█ █   ";
            _anlienSkinGigA[4] = "      ▀▀ ▀▀      ";

            _anlienSkinGigB[0] = "   ▄ ▀▄   ▄▀ ▄ ";
            _anlienSkinGigB[1] = "   █▄███████▄█ ";
            _anlienSkinGigB[2] = "   ███▄███▄███ ";
            _anlienSkinGigB[3] = "   ▀█████████▀ ";
            _anlienSkinGigB[4] = "    ▄▀     ▀▄  ";

            _anlienSkinSmallA[0] = "      ▄██▄       ";
            _anlienSkinSmallA[1] = "    ▄██████▄     ";
            _anlienSkinSmallA[2] = "   ███▄██▄███    ";
            _anlienSkinSmallA[3] = "     ▄▀▄▄▀▄      ";
            _anlienSkinSmallA[4] = "    ▀ ▀  ▀ ▀     ";

            _anlienSkinSmallB[0] = "      ▄██▄       ";
            _anlienSkinSmallB[1] = "    ▄██████▄     ";
            _anlienSkinSmallB[2] = "   ███▄██▄███    ";
            _anlienSkinSmallB[3] = "    ▄▀▄▀▀▄▀▄     ";
            _anlienSkinSmallB[4] = "   ▀        ▀    ";


            spaceShip[0] = "    ▄▄████▄▄    ";
            spaceShip[1] = "  ▄██████████▄  ";
            spaceShip[2] = "▄██▄██▄██▄██▄██▄";
            spaceShip[3] = "  ▀█▀  ▀▀  ▀█▀  ";
        }

        public bool Type { get => _type; set => _type = value; }
        public int Y { get => _y; set => _y = value; }
        public int X { get => _x; set => _x = value; }

        public void writeAliens(bool position)
        {
            if (_type)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                if (position)
                {
                    for (int a = 0; a < _anlienSkinGigA.Length; a++)
                    {
                        Console.SetCursorPosition(X, _y + a);
                        Console.WriteLine(_anlienSkinGigA[a]);
                    }
                }
                else
                {
                    for (int a = 0; a < _anlienSkinGigB.Length; a++)
                    {
                        Console.SetCursorPosition(X, _y + a);
                        Console.WriteLine(_anlienSkinGigB[a]);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;

                if (position)
                {
                    for (int a = 0; a < _anlienSkinSmallA.Length; a++)
                    {
                        Console.SetCursorPosition(X, _y + a);
                        Console.WriteLine(_anlienSkinSmallA[a]);
                    }
                }
                else
                {
                    for (int a = 0; a < _anlienSkinSmallB.Length; a++)
                    {
                        Console.SetCursorPosition(X, _y + a);
                        Console.WriteLine(_anlienSkinSmallB[a]);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void writeAlienShip()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(_spaceShipX, _spaceShipY);
            for (int a = 0; a < _nbSpaceShip; a++)
            {
                for (int b = 0; b < spaceShip.Length; b++)
                {
                    if (a == 1)
                    {
                        Console.SetCursorPosition(_spaceShipX, _spaceShipY + b);
                    }
                    else
                    {
                        Console.SetCursorPosition((_spaceShipX * 2) + spaceShip[0].Length, _spaceShipY + b);
                    }
                    Console.WriteLine(spaceShip[b]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }


        
    }
}
