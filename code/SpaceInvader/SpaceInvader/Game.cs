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
        public Game()
        {

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

    }
}
