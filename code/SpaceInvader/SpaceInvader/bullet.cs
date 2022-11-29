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
        int speed;

        System.Timers.Timer BulletTimer = new System.Timers.Timer();


        public Bullet(int x, int y, bool direction){

            _x = x;
            _y = y;
            _direction = direction;

        }

        public void Mouve()
        {
            BulletTimer.Elapsed += BulletTimer_Tick;
            BulletTimer.Interval = 100;
            BulletTimer.Start();
        }



        private void BulletTimer_Tick(object sender, System.EventArgs e)
        {
            if(_y > 1)
            {
                Console.SetCursorPosition(_x, _y);
                Console.WriteLine("     ");
            }

            if (_direction)
            {
                _y -= 1;
            }
            else
            {
                _y += 1;
            }

            if(_y > 1)
            {

                Console.SetCursorPosition(_x, _y);
                Console.WriteLine("  |  ");
            }
            else
            {
                BulletTimer.Stop();
            }

        }




    }
}
