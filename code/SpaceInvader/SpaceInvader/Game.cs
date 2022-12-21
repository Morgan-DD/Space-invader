using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.IO;



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


        int _nbDie = 0;

        int _gameScore = 0;

        bool _canShoot = true;

        int _endPassage = 0;
        int _endPassageLimit = 5;

        int _test = 0;

        string _cheminscore = "Scores.txt";


        //Menu menu = new Menu(3);

        System.Timers.Timer alienTimer = new System.Timers.Timer();
        System.Timers.Timer _endTimer = new System.Timers.Timer();

        List<Bullet> _shoot = new List<Bullet>();

        public bool GetCanShoot { get => _canShoot; set => _canShoot = value; }
        public short Difficulty { get => _difficulty; set => _difficulty = value; }
        public bool Music { get => _music; set => _music = value; }

        public Game(SpaceShip ship)
        {
            _ship = ship;

            if (_difficulty == 0)
            {
                alienTimer.Interval = 250;

            }
            else if (_difficulty == 1)
            {
                alienTimer.Interval = 100;
            }
            else
            {
                alienTimer.Interval = 50;
            }

            _endTimer.Interval = 50;
            alienTimer.Interval = 5;

            alienTimer.Elapsed += alienTimer_Tick;
            _endTimer.Elapsed += _endTimer_Tick;



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
            _nbDie = 0;
            if (_alienList.Count > 0)
            {
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
                for (int x = 0; x < _shoot.Count; x++)
                {
                    delet = _shoot[x].Mouve();
                    if (delet)
                    {
                        Console.SetCursorPosition(_shoot[x].X, _shoot[x].Y);
                        Console.Write(" ");
                        _shoot.Remove(_shoot[x]);
                    }
                    else
                    {
                        if (x > 0)
                        {
                            for (int v = 0; v < _alienList.Count - 1; v++)
                            {
                                if (_shoot[x - 1].Y >= _alienList[v].Y && _shoot[x - 1].Y <= _alienList[v].Y + 5)
                                {
                                    if (_shoot[x - 1].X > _alienList[v].X + 3 && _shoot[x - 1].X < _alienList[v].X + 14)
                                    {
                                        Die(v);
                                        _nbDie++;
                                        Console.SetCursorPosition(_shoot[x].X, _shoot[x].Y);
                                        Console.Write(" ");
                                        _shoot.RemoveAt(x);
                                    }
                                }
                            }
                        }
                    }

                }
                if (_nbDie > 0)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine((_gameScore) + " points");
                    _gameScore += 100 * _nbDie;
                }

            }
        }

        public void Die(int alienId)
        {
            for (int a = 0; a < 5; a++)
            {
                Console.SetCursorPosition(_alienList[alienId].X, _alienList[alienId].Y + a);
                Console.Write("              ");
            }
            _alienList.RemoveAt(alienId);
        }

        public void giveGameToShip(Game game)
        {
            _ship.Game = game;
        }

        public void gameStart()
        {


            alienTimer.Start();
            _ship.StartShootTimer(true);

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
            _alienList[0].writeAlienShip();
            _ship.WriteShip();

            do
            {
                if (_test != 1)
                {
                    ConsoleKeyInfo arrow = Console.ReadKey();
                    if (_moove)
                    {
                        if (_test == 2)
                        {
                            gameRestart();
                            _test = 0;
                        }
                        switch (arrow.Key)
                        {
                            case ConsoleKey.RightArrow:
                                if (_ship.X < 120 - 1 - _ship.GetShipLength())
                                    _ship.X += 1;
                                _ship.WriteShip();
                                break;

                            case ConsoleKey.LeftArrow:
                                if (_ship.X > 1)
                                    _ship.X -= 1;
                                _ship.WriteShip();
                                break;
                            case ConsoleKey.Spacebar:
                                _canShoot = _ship.Shoot();

                                break;
                            case ConsoleKey.Escape:
                                _test = gamePause();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(1, 0);
                                Console.Write(_test);
                                break;
                        }
                    }
                }

            } while (_test != 1);
            Console.Clear();
        }

        public void newShoot(int x, bool direction)
        {
            _shoot.Add(new Bullet(x + 8, 51, direction));
        }




        public int menuPauseAffiche()
        {
            int diffrence = 15;
            int yLimit = _titleContinueLocation[1] + 5;
            int xLimit = 27;
            for (int b = 0; b < yLimit; b++)
            {
                Console.ForegroundColor = ConsoleColor.White;
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
            int continuer = 0;
            do
            {
                continuer = MenuPauseMove(_menuLocation);
            } while (continuer == 0);
            return continuer;
        }

        public int MenuPauseMove(bool rubric)
        {
            ConsoleKeyInfo arrow = Console.ReadKey();
            int value = 0;
            switch (arrow.Key)
            {
                case ConsoleKey.UpArrow:
                    MenuPauseWritter(rubric);
                    this._menuLocation = !rubric;
                    break;
                case ConsoleKey.DownArrow:
                    MenuPauseWritter(rubric);
                    this._menuLocation = !rubric;
                    break;

                case ConsoleKey.Enter:

                    if (rubric)
                    {
                        value = 2;
                    }
                    else
                    {
                        value = 1;
                    }

                    break;
            }
            return value;

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
                Console.SetCursorPosition(_alienList[c].X, _alienList[c].Y - 1);
                Console.WriteLine("                     ");
            }
            if (_alienList[_alienList.Count - 1].Y == 45)
            {
                gameEnd(0);
            }
        }

        public void gameEnd(int end)
        {
            alienTimer.Stop();
            _endTimer.Start();
        }

        public int gamePause()
        {
            alienTimer.Stop();
            _ship.StartShootTimer(false);
            return menuPauseAffiche();

        }

        public void gameLoose()
        {
            Console.Clear();
            string toWrite = "Perdu";
            Console.SetCursorPosition(60, 20);
            Console.Write(toWrite);

            Console.SetCursorPosition(50, 20);
            Console.Write("Choissisez un pseudo : ");

            string pseudo = Console.ReadLine();
            if (!File.Exists(_cheminscore))
            {
                using (FileStream fs = File.Create(_cheminscore)) {
                    Byte[] title = new UTF8Encoding(true).GetBytes(pseudo + " : " + _gameScore);
                    fs.Write(title, 0, title.Length);
                }
            }
            else
            {
                if(_gameScore > 0)
                File.WriteAllText(_cheminscore, File.ReadAllText(_cheminscore) + "\n" + pseudo + " : " + _gameScore);
            }
        }

        public void _endTimer_Tick(object sender, System.EventArgs e)
        {
            Console.Clear();
            _endPassage++;
            if(_endPassage <= _endPassageLimit)
            {
                _endTimer.Stop();
                gameClear();
                gameLoose();
            }
            this._test = 1;
        }

        public void gameClear()
        {
            _alienList.Clear();
            _nbDie = 0;
            _gameScore = 0;
            _shoot.Clear();

        }

        public void gameRestart()
        {
            MenuPauseClear();

            for (int c = 0; c < _alienList.Count; c++)
            {
                _alienList[c].writeAliens(_positionAlien);
            }


            alienTimer.Start();
            _ship.StartShootTimer(true);
        }

        public void MenuPauseClear()
        {
            int yLimit = _titleContinueLocation[1] + 5;
            int xLimit = 27;
            int diffrence = 15;
            for (int b = 0; b < yLimit; b++)
            {
                Console.SetCursorPosition(_titlepauseLocation[0] - diffrence, _titlepauseLocation[1] - (diffrence / 4) + b);

                for (int a = 0; a < xLimit * 2 + 5; a++)
                {
                    Console.Write(" ");
                }
            }
        }

        public int GetShootSpeed()
        {
            int speed = 0;
            if (_difficulty == 0)
            {

                speed = 2 * 500;
            }
            else if (_difficulty == 1)
            {
                speed = 750;

            }
            else if (_difficulty == 2)
            {    
                speed =  700;
            }

            return speed;
        }
    }
}
