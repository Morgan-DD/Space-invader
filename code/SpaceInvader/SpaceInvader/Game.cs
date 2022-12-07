using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace SpaceInvader
{
    public class Game
    {
        short _difficulty = 0;
        bool _music = true;

        bool _positionAlien = true;
        bool _error = false;
        bool _moove = true;

        private bool _alienDirection = true;
        List<Alien> _alienList = new List<Alien>();

        SpaceShip _ship;

        string[] _titlepause = new string[6];
        int[] _titlepauseLocation = new int[2];

        string[] _titleLeave = new string[6];
        int[] _titleLeaveLocation = new int[2];

        string[] _titleContinue = new string[8];
        int[] _titleContinueLocation = new int[2];

        bool _menuLocation = true;
        int space = 6;
        int _type;

        bool _pauseMenu = true;


        //Menu menu = new Menu(3);

        System.Timers.Timer alienTimer = new System.Timers.Timer();

        List<Bullet> _shoot = new List<Bullet>();


        public Game(SpaceShip ship)
        {
            _ship = ship;
            //-----------------------------------------------------------------------------//
            alienTimer.Interval = 50;
            //-----------------------------------------------------------------------------//

            alienTimer.Elapsed += alienTimer_Tick;




            _titlepause[0] = " _____";
            _titlepause[1] = "|  __ \\";
            _titlepause[2] = "| |__) |_ _ _   _ ___  ___";
            _titlepause[3] = "|  ___/ _` | | | / __|/ _ \\";
            _titlepause[4] = "| |  | (_| | |_| \\__ \\  __/";
            _titlepause[5] = "|_|   \\__,_|\\__,_|___/\\___|";

            _titlepauseLocation[0] = 45;
            _titlepauseLocation[1] = 10;


            _titleLeave[0] = " _____       _ _   _";
            _titleLeave[1] = "|  _  |     (_) | | |";
            _titleLeave[2] = "| | | |_   _ _| |_| |_ ___ _ __";
            _titleLeave[3] = "| | | | | | | | __| __/ _ \\ '__|";
            _titleLeave[4] = "\\ \\/' / |_| | | |_| ||  __/ |";
            _titleLeave[5] = " \\_/\\\\_\\__,_|_|\\__|\\__\\___|_|";

            _titleLeaveLocation[0] = 44;
            _titleLeaveLocation[1] = _titlepauseLocation[1] + Convert.ToString(_titlepauseLocation[1]).Count() + space;


            _titleContinue[0] = "______                              _";
            _titleContinue[1] = "| ___ \\                            | |";
            _titleContinue[2] = "| |_/ /___ _ __  _ __ ___ _ __   __| |_ __ ___";
            _titleContinue[3] = "|    // _ \\ '_ \\| '__/ _ \\ '_ \\ / _` | '__/ _ \\";
            _titleContinue[4] = "| |\\ \\  __/ |_) | | |  __/ | | | (_| | | |  __/";
            _titleContinue[5] = "\\_| \\_\\___| .__/|_|  \\___|_| |_|\\__,_|_|  \\___|";
            _titleContinue[6] = "          | |";
            _titleContinue[7] = "          |_|";

            _titleContinueLocation[0] = 37;
            _titleContinueLocation[1] = _titleLeaveLocation[1] + Convert.ToString(_titleLeaveLocation[1]).Count() + space;

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
            bool delet = false;
            for(int x = 0; x < _shoot.Count; x++)
            {
                delet = _shoot[x].Mouve();
                if (delet)
                {
                    _shoot.Remove(_shoot[x]);
                }

                for (int v = 0; v < _alienList.Count; v++)
                {
                    if (_shoot[x].Y > _alienList[v].Y && _shoot[x].Y < _alienList[v].Y + 5)
                    {
                        if(_shoot[x].X > _alienList[v].X && _shoot[x].X < _alienList[v].X + 5)
                        {
                            Die(v);
                            _shoot.RemoveAt(x);
                        }


                        Console.SetCursorPosition(0, 0);
                        Console.Write("a");
                    }
                }

            }

        }



        public void Die(int alienId)
        {
            for(int a = 0; a < 5; a++)
            {
                Console.SetCursorPosition(_alienList[alienId].X, _alienList[alienId].Y + a);
                Console.Write("                    ");
            }

            _alienList.RemoveAt(alienId);
        }

        public void giveGameToShip(Game game)
        {
            _ship.Game = game;
        }

        public void gameStart(short difficulty,bool music)
        {
            _difficulty = difficulty;
            _music = music;

            alienTimer.Start();
            _ship.WriteShip();

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

            bool test = true;

            do
            {
                ConsoleKeyInfo arrow = Console.ReadKey();
                if (_moove)
                {
                    switch (arrow.Key)
                    {
                        case ConsoleKey.RightArrow:
                            if (_ship.X < 120 -  1 - _ship.GetShipLength())
                                _ship.X += 1;
                            break;

                        case ConsoleKey.LeftArrow:
                            if (_ship.X > 1)
                                _ship.X -= 1;
                            break;
                        case ConsoleKey.Spacebar:
                            _ship.Shoot();
                            break;
                        case ConsoleKey.Escape:
                            test = gamePause();
                            break;
                    }
                    _ship.WriteShip();
                }

            } while (test);

        }

        public void newShoot(int x, bool direction)
        {
            _shoot.Add(new Bullet(x + 8, 51, direction));
        }


        public void menuAffiche()
        {
            int diffrence = 15;
            int yLimit = _titleContinueLocation[1] + 5;
            int xLimit = 27;
            for (int b = 0; b < yLimit; b++)
            {
                Console.SetCursorPosition(_titlepauseLocation[0] - diffrence, _titlepauseLocation[1] - (diffrence / 4) + b);
                if (b == 0)
                {
                    Console.Write("┌");
                }
                else if (b == yLimit - 1)
                {
                    Console.Write("└");
                }
                else
                {
                    Console.Write("│");
                }

                for (int c = 0; c < xLimit + (diffrence * 2); c++)
                {
                    if (b == 0 || b == yLimit - 1)
                    {
                        Console.Write("─");
                    }


                }
                Console.SetCursorPosition(_titlepauseLocation[0] + diffrence + xLimit, _titlepauseLocation[1] - (diffrence / 4) + b);
                if (b == 0)
                {
                    Console.Write("┐");
                }
                else if (b == yLimit - 1)
                {
                    Console.Write("┘");
                }
                else
                {
                    Console.Write("│");
                }
            }

           
                for (int a = 0; a < _titlepause.Count(); a++)
                {

                    Console.SetCursorPosition(_titlepauseLocation[0], _titlepauseLocation[1] + a);
                    Console.WriteLine(_titlepause[a]);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int b = 0; b < _titleLeave.Count(); b++)
                {

                    Console.SetCursorPosition(_titleLeaveLocation[0], _titleLeaveLocation[1] + b);
                    Console.WriteLine(_titleLeave[b]);
                }

                for (int c = 0; c < _titleContinue.Count(); c++)
                {
                    Console.SetCursorPosition(_titleContinueLocation[0], _titleContinueLocation[1] + c);
                    Console.WriteLine(_titleContinue[c]);
                }
            
            Console.SetCursorPosition(0, 34);
            Console.Write(" ");

            MenuPauseWritter(_menuLocation);

            do
            {
                _menuLocation = MenuPauseMove(_menuLocation);
            } while (_pauseMenu);

        }

        public bool MenuPauseMove(bool rubric)
        {
            ConsoleKeyInfo arrow = Console.ReadKey();

            switch (arrow.Key)
            {
                case ConsoleKey.UpArrow:
                    MenuPauseWritter(rubric);
                    rubric = !rubric;
                    break;
                case ConsoleKey.DownArrow:
                    MenuPauseWritter(rubric);
                    rubric = !rubric;
                    break;

                case ConsoleKey.Enter:

                    if (rubric)
                        _pauseMenu = false;


                    break;
            }
            return rubric;

        }

        public void MenuPauseWritter(bool rubric)
        {
            for (int a = 0; a < 10; a++)
            {
                if (rubric)
                {
                    if (a < _titleContinue.Count())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(_titleContinueLocation[0], _titleContinueLocation[1] + a);
                        Console.WriteLine(_titleContinue[a]);
                    }
                    if (a < _titleLeave.Count())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.SetCursorPosition(_titleLeaveLocation[0], _titleLeaveLocation[1] + a);
                        Console.WriteLine(_titleLeave[a]);
                    }
                }
                else
                {
                    if (a < _titleContinue.Count())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.SetCursorPosition(_titleContinueLocation[0], _titleContinueLocation[1] + a);
                        Console.WriteLine(_titleContinue[a]);
                    }
                    if (a < _titleLeave.Count())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(_titleLeaveLocation[0], _titleLeaveLocation[1] + a);
                        Console.WriteLine(_titleLeave[a]);
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

        public bool gamePause()
        {
            alienTimer.Stop();

            menuAffiche();
            return false;
        }

        public void gameLoose()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Perdu");
        }
    }
}
