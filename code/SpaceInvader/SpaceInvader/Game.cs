using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpaceInvader
{
    public class Game
    {
        short _difficulty;
        bool _music;

        bool _positionAlien = true;
        bool _error = false;
        bool _moove = true;
        System.Timers.Timer alienTimer = new System.Timers.Timer();

        private bool _alienDirection = true;
        List<Alien> _alienList = new List<Alien>();

        SpaceShip Ship = new SpaceShip();



         Menu menu = new Menu(3);


        public Game()
        {
            _difficulty = menu.Difficulty;
            _music = menu.Music;

        }

        public void gameStart()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 50);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int d = 0; d < 120; d++)
            {
                Console.Write("-");
            }


            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 5; b++)
                {
                    _alienList.Add(new Alien(a % 2 == 0, b * 15 + 20, a * 7 + 8));
                }
            }

            if (_difficulty == 0)
            {
                alienTimer.Interval = 500;

            }
            else if (_difficulty == 1)
            {
                alienTimer.Interval = 250;
            }
            else
            {
                alienTimer.Interval = 100;
            }




            //-----------------------------------------------------------------------------//
            alienTimer.Interval = 50;
            //-----------------------------------------------------------------------------//

            alienTimer.Elapsed += alienTimer_Tick;
            _alienList[0].writeAlienShip();
            alienTimer.Start();
            Ship.WriteShip();



            do
            {
                ConsoleKeyInfo arrow = Console.ReadKey();
                if (_moove)
                {
                    switch (arrow.Key)
                    {
                        case ConsoleKey.RightArrow:
                            if (Ship.X < 120 -  1 - Ship.GetShipLength())
                                Ship.X += 1;
                            break;

                        case ConsoleKey.LeftArrow:
                            if (Ship.X > 1)
                                Ship.X -= 1;
                            break;
                        case ConsoleKey.Spacebar:
                            Ship.Shoot();
                            break;
                        case ConsoleKey.Escape:
                            gamePause();
                            break;
                    }
                    Ship.WriteShip();
                }

            } while (true);

        }

        public void gamePause()
        {
            alienTimer.Stop();
            Ship.shipPause();

            menu.menuAffiche();
        }


        private void alienTimer_Tick(object sender, System.EventArgs e)
        {
            _error = false;
            for (int c = 0; c < _alienList.Count; c++)
            {
                if (_positionAlien)
                {
                    _positionAlien = false;
                }
                else
                {
                    _positionAlien = true;
                }

                if (_alienDirection)
                {
                    if (_alienList[c].X >= 104)
                    {
                        _error = true;
                        _alienDirection = false;
                        alienDown();
                    }
                    else
                    {
                        _error = false;
                    }
                }
                else
                {
                    if (_alienList[c].X <= 1)
                    {
                        _error = true;
                        _alienDirection = true;
                        alienDown();
                    }
                    else
                    {
                        _error = false;
                    }
                }
                _moove = false;
                _moove = _alienList[c].writeAliens(_positionAlien);
            }
            if (_error)
            {
                _alienDirection = !_alienDirection;
                alienDown();
            }
            else
            {
                for (int d = 0; d < _alienList.Count; d++)
                {
                    if (_alienDirection)
                    {
                        _alienList[d].X += 1;
                    }
                    else
                    {
                        _alienList[d].X -= 1;
                    }
                }
            }



        }

        public void alienDown()
        {
            for (int c = 0; c < _alienList.Count; c++)
            {
                _alienList[c].Y += 1;
            }
            for (int d = 0; d < 120; d++)
            {
                Console.SetCursorPosition(d, _alienList[0].Y - 1);
                Console.Write(" ");

                Console.SetCursorPosition(d, _alienList[5].Y - 1);
                Console.Write(" ");

                Console.SetCursorPosition(d, _alienList[10].Y - 1);
                Console.Write(" ");
            }
            if (_alienList[14].Y == 45)
            {
                gameEnd(0);
            }
        }


        public void gameEnd(int end)
        {
            alienTimer.Stop();
            switch (end)
            {
                case 0:
                    gameLoose();
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }


        }

        public void gameLoose()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Perdu");
        }
    }
}
