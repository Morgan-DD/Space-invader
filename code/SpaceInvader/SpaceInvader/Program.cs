using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Program
    {
        public string[,] tab_values = new string[5, 2];
        /*
        {
            {"                              _____                        _____                    _\n                             /  ___|                      |_   _|                  | |\n                             \\ `--. _ __   __ _  ___ ___    | | _ ____   ____ _  __| | ___ _ __\n                              `--. \\ '_ \\ / _` |/ __/ _ \\   | || '_ \\ \\ / / _` |/ _` |/ _ \\ '__|\n                             /\\__/ / |_) | (_| | (_|  __/  _| || | | \\ V / (_| | (_| |  __/ |\n                             \\____/| .__/ \\__,_|\\___\\___|  \\___/_| |_|\\_/ \\__,_|\\__,_|\\___|_|\n                                   | |\n                                   |_|",
             "                                                   ___\n                                                  |_  |\n                                                    | | ___  _   _  ___ _ __ \n                                                    | |/ _ \\| | | |/ _ \\ '__|\n                                                /\\__/ / (_) | |_| |  __/ |\n                                                \\____/ \\___/ \\__,_|\\___|_|",
            }
        };*/

        tab_values[0,0] = "";
        const string playTitle = "                                                   ___\n                                                  |_  |\n                                                    | | ___  _   _  ___ _ __ \n                                                    | |/ _ \\| | | |/ _ \\ '__|\n                                                /\\__/ / (_) | |_| |  __/ |\n                                                \\____/ \\___/ \\__,_|\\___|_|";
        const int playLocation = 12;

        const string settingTitle = "                                              _____       _   _\n                                             |  _  |     | | (_)\n                                             | | | |_ __ | |_ _  ___  _ __  ___\n                                             | | | | '_ \\| __| |/ _ \\| '_ \\/ __|\n                                             \\ \\_/ / |_) | |_| | (_) | | | \\__ \\\n                                              \\___/| .__/ \\__|_|\\___/|_| |_|___/\n                                                   | |\n                                                   |_|";
        const int settingsLocation = 19;

        const string hightScoreTitle = "                                      _   _ _       _     _   _____\n                                     | | | (_)     | |   | | /  ___|\n                                     | |_| |_  __ _| |__ | |_\\ `--.  ___ ___  _ __ ___\n                                     |  _  | |/ _` | '_ \\| __|`--. \\/ __/ _ \\| '__/ _ \\\n                                     | | | | | (_| | | | | |_/\\__/ / (_| (_) | | |  __/\n                                     \\_| |_/_|\\__, |_| |_|\\__\\____/ \\___\\___/|_|  \\___|\n                                               __/ |\n                                              |___/";
        const int hightLocation = 28;

        const string detailTitle = "                                             ___   ______\n                                            / _ \\  | ___ \\\n                                           / /_\\ \\ | |_/ / __ ___  _ __   ___  ___                 \n                                           |  _  | |  __/ '__/ _ \\| '_ \\ / _ \\/ __|\n                                           | | | | | |  | | | (_) | |_) | (_) \\__ \\\n                                           \\_| |_/ \\_|  |_|  \\___/| .__/ \\___/|___/\n                                                                  | |\n                                                                  |_|";
        const int detailLocation = 37;

        const string leaveTitle = "                                                _____       _ _   _\n                                               |  _  |     (_) | | |\n                                               | | | |_   _ _| |_| |_ ___ _ __\n                                               | | | | | | | | __| __/ _ \\ '__|\n                                               \\ \\/' / |_| | | |_| ||  __/ |\n                                                \\_/\\_\\__,_|_|\\__|\\__\\___|_|";
        const int leaveLocation = 46;


        static void Main(string[] args)
        {
            Console.SetWindowSize(125, 55);
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;



          //  Console.Write(tab_values[0, 0]);
            DrawMenu();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, playLocation);
            Console.Write(playTitle);

            Console.ReadLine();
        }




        static void DrawMenu()
        {
            Console.SetCursorPosition(17, 1);
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");

          //  Console.WriteLine(invaderTitle);

            Console.SetCursorPosition(17, 10);
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");

            for (int b = 2; b < 10; b++)
            {
                Console.SetCursorPosition(17, b);
                Console.Write("║");
                Console.SetCursorPosition(109, b);
                Console.Write("║");

            }

            Console.SetCursorPosition(0, 12);

            Console.WriteLine(playTitle + "\n");

            Console.WriteLine(settingTitle + "\n");

            Console.WriteLine(hightScoreTitle + "\n");

            Console.WriteLine(detailTitle + "\n");

            Console.WriteLine(leaveTitle);
        }

    }
}
