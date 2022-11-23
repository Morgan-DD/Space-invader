using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    public class Game
    {
        short _difficulty = 0;
        bool _music = true;

        bool _positionAlien = true;
        System.Timers.Timer aTimer = new System.Timers.Timer();

        private bool _alienDirection = true;
        List<Alien> _alienList = new List<Alien>();


        public Game()
        {

        }

        public void gameStart()
        {
            Console.Clear();

            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 5; b++)
                {
                    if (a % 2 == 0)
                    {
                        _alienList.Add(new Alien(true, b * 15 + 20, a * 7 + 8));
                    }
                    else
                    {
                        _alienList.Add(new Alien(false, b * 15 + 20, a * 7 + 8));
                    }
                }
            }

            if (_difficulty == 0)
            {
                aTimer.Interval = 500;

            }
            else if (_difficulty == 1)
            {
                aTimer.Interval = 250;
            }
            else
            {
                aTimer.Interval = 100;
            }
            aTimer.Interval = 50;

            aTimer.Elapsed += aTimer_Tick;
            _alienList[0].writeAlienShip();
            // Console.ReadKey();
            aTimer.Start();







        }


        public short Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }

        public bool Music
        {
            get { return _music; }
            set { _music = value; }
        }


        private void aTimer_Tick(object sender, System.EventArgs e)
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
                    if (_alienList[4].X >= 104)
                    {
                        _alienDirection = false;
                        alienDown();
                    }
                    else
                    {
                        _alienList[c].X += 1;
                    }
                }
                else
                {
                    if (_alienList[c].X <= 0)
                    {
                        _alienDirection = true;
                        alienDown();
                    }
                    else
                    {
                        _alienList[c].X -= 1;
                    }
                }

                _alienList[c].writeAliens(_positionAlien);
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
                gameEnd();
            }
        }


        public void gameEnd()
        {
            Console.Clear();
        }
    }
}
