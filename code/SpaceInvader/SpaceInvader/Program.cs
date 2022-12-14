using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpaceInvader
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(0);

            Console.SetWindowSize(120, 58);
            Console.CursorVisible = false;


            


            
                menu.MainMenuDrawer();
            do
            {
                menu.MainMenuNavigation();
            }while (true);
            

            


            Console.ReadLine();


        }
    }
}