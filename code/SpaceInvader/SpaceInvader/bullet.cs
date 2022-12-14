using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Bullet
    {

        int _x;
        int _y;
        bool _direction;

        public Bullet(int x, int y, bool direction){

            _x = x;
            _y = y;
            _direction = direction;

        }

        public int Y { get => _y; set => _y = value; }
        public int X { get => _x; set => _x = value; }

        public bool Mouve()
        {
            Console.SetCursorPosition(_x, _y);
            Console.WriteLine(" ");
            if (_direction)
            {
                _y -= 1;
            }
            else
            {
                _y += 1;
            }
            if (_y <= 4)
            {
                return true;
            }
            Console.SetCursorPosition(_x, _y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("|");
            return false;
        }
    }
}
