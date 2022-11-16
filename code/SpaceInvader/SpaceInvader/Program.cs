using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Program
    {
        static Game game = new Game();
        static void Main(string[] args)
        {
            bool up = false;
            short MainactualRubric = 1;
            bool SettingactualRubric = false;


            short actualMenu = 1;

            Console.SetWindowSize(120, 58);
            Console.SetWindowPosition(0, 0);
            string[] titles = new string[6];
            titles[0] = "                               _____                        _____                    _  	   \n                              /  ___|                      |_   _|                  | |	   \n                              \\ `--. _ __   __ _  ___ ___    | | _ ____   ____ _  __| | ___ _ __ \n                               `--. \\ '_ \\ / _` |/ __/ _ \\   | || '_ \\ \\ / / _` |/ _` |/ _ \\ '__|\n                              /\\__/ / |_) | (_| | (_|  __/  _| || | | \\ V / (_| | (_| |  __/ |   \n                              \\____/| .__/ \\__,_|\\___\\___|  \\___/_| |_|\\_/ \\__,_|\\__,_|\\___|_|   \n                                    | |                                                          \n                                    |_|                                                          \n";
            titles[1] = "                                                   ___                                         \n                                                  |_  |                                        \n                                                    | | ___  _   _  ___ _ __                   \n                                                    | |/ _ \\| | | |/ _ \\ '__|                  \n                                                /\\__/ / (_) | |_| |  __/ |                     \n                                                \\____/ \\___/ \\__,_|\\___|_|                     \n";
            titles[2] = "                                              _____       _   _\n                                             |  _  |     | | (_)\n                                             | | | |_ __ | |_ _  ___  _ __  ___\n                                             | | | | '_ \\| __| |/ _ \\| '_ \\/ __|\n                                             \\ \\_/ / |_) | |_| | (_) | | | \\__ \\\n                                              \\___/| .__/ \\__|_|\\___/|_| |_|___/\n                                                   | |\n                                                   |_|";
            titles[3] = "                                      _   _ _       _     _   _____\n                                     | | | (_)     | |   | | /  ___|\n                                     | |_| |_  __ _| |__ | |_\\ `--.  ___ ___  _ __ ___\n                                     |  _  | |/ _` | '_ \\| __|`--. \\/ __/ _ \\| '__/ _ \\\n                                     | | | | | (_| | | | | |_/\\__/ / (_| (_) | | |  __/\n                                     \\_| |_/_|\\__, |_| |_|\\__\\____/ \\___\\___/|_|  \\___|\n                                               __/ |\n                                              |___/";
            titles[4] = "                                             ___   ______\n                                            / _ \\  | ___ \\\n                                           / /_\\ \\ | |_/ / __ ___  _ __   ___  ___                 \n                                           |  _  | |  __/ '__/ _ \\| '_ \\ / _ \\/ __|\n                                           | | | | | |  | | | (_) | |_) | (_) \\__ \\\n                                           \\_| |_/ \\_|  |_|  \\___/| .__/ \\___/|___/\n                                                                  | |\n                                                                  |_|";
            titles[5] = "                                                _____       _ _   _\n                                               |  _  |     (_) | | |\n                                               | | | |_   _ _| |_| |_ ___ _ __\n                                               | | | | | | | | __| __/ _ \\ '__|\n                                               \\ \\/' / |_| | | |_| ||  __/ |\n                                                \\_/\\_\\__,_|_|\\__|\\__\\___|_|";
            short[] titlesLocation = new short[6];
            titlesLocation[0] = 2;
            titlesLocation[1] = 12;
            titlesLocation[2] = 20;
            titlesLocation[3] = 29;
            titlesLocation[4] = 38;
            titlesLocation[5] = 47;
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;







            MainMenuDrawer(titles);
            MainMenuWritter(titles, titlesLocation, MainactualRubric, up);




            do
            {
                Console.SetCursorPosition(10, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(actualMenu);
                Console.ForegroundColor = ConsoleColor.White;


                    MainactualRubric = MainMenuNavigation(titles, titlesLocation, MainactualRubric, up);


             


               



            } while (titles[0] != "");





            Console.ReadLine();
        }
        static void TitleWritter(string title)
        {
            Console.SetCursorPosition(17, 1);
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");

            Console.WriteLine(title);

            Console.SetCursorPosition(17, 10);
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════╝");

            for (int b = 2; b < 10; b++)
            {
                Console.SetCursorPosition(17, b);
                Console.Write("║");
                Console.SetCursorPosition(109, b);
                Console.Write("║");
            }
        }




        static void MainMenuDrawer(string[] title)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 12);
            for (int a = 1; a < title.Length; a++)
            {
                Console.Write(title[a] + "\n\n");
            }
            TitleWritter(title[0]);

        }

        static void MainMenuWritter(string[] rubric, short[] localistaion, short actualRubric, bool up)
        {

            if (up == true && actualRubric > 0 && actualRubric < 5)
            {
                Console.SetCursorPosition(0, localistaion[actualRubric + 1]);
                Console.Write(rubric[actualRubric + 1]);
            }
            else if (up == false && actualRubric < 6 && actualRubric > 1)
            {
                Console.SetCursorPosition(0, localistaion[actualRubric - 1]);
                Console.Write(rubric[actualRubric - 1]);

            }
            else if (up == false && actualRubric == 1)
            {
                Console.SetCursorPosition(0, localistaion[5]);
                Console.Write(rubric[5]);

            }
            else if (up == true && actualRubric == 5)
            {
                Console.SetCursorPosition(0, localistaion[1]);
                Console.Write(rubric[1]);

            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(0, localistaion[actualRubric]);
            Console.Write(rubric[actualRubric]);
            Console.ForegroundColor = ConsoleColor.White;

        }
        static short MainMenuNavigation(string[] titles, short[] titlesLocation, short actualRubric, bool up)
        {
            ConsoleKeyInfo arrow = Console.ReadKey();

            switch (arrow.Key)
            {
                case ConsoleKey.UpArrow:
                    actualRubric--;
                    up = true;
                    if (actualRubric <= 0)
                    {
                        actualRubric = 5;
                    }
                    MainMenuWritter(titles, titlesLocation, actualRubric, up);
                    break;

                case ConsoleKey.DownArrow:
                    actualRubric++;
                    up = false;
                    if (actualRubric >= 6)
                    {
                        actualRubric = 1;
                    }
                    MainMenuWritter(titles, titlesLocation, actualRubric, up);
                    break;
                case ConsoleKey.Enter:
                    MainMenuActions(titles, actualRubric, titlesLocation, up);
                    break;
            }

            return actualRubric;
        }

        static short MainMenuActions(string[] title, short actualRubric, short[] titlesLocation, bool up)
        {
            switch (actualRubric)
            {
                case 5:
                    Environment.Exit(0);

                    break;

                case 2:
                    SettingMenu(title[2], title, titlesLocation, actualRubric, up);
                    break;
                
            }
            return actualRubric;
        }



        //-------------------------------------- settings --------------------------------------//


        static void SettingMenu(string title, string[] titles, short[] titlesLocation, short mainactualRubric, bool up)
        {
            bool end = true;
            short actualRubric = 0;

            short dificulty = game.Difficulty;
            bool music = true;

            SettingMenuDrawer(title, music, dificulty);
            SettingMenuWritter(actualRubric);

            do
            {
                actualRubric = SettingMenuNavigation(actualRubric, titles);
                if (actualRubric == 2)
                        end = false;

            }while (end);

            MainMenuDrawer(titles);
            MainMenuWritter(titles, titlesLocation, mainactualRubric, up);

        }




        static short SettingMenuDrawer(string title, bool music, short dificulty)
        {
            Console.Clear();
            string[] settings = new string[8];
            settings[0] = "                                                       _____\n                                                      /  ___|\n                                                      \\ `--.  ___  _ __\n                                                       `--. \\/ _ \\| '_ \\\n                                                      /\\__/ / (_) | | | |\n                                                      \\____/ \\___/|_| |_|\n";
            settings[1] = "                                                         _____       _\n                                                        |  _  |     (_)\n                                                        | | | |_   _ _ \n                                                        | | | | | | | |\n                                                        \\ \\_/ / |_| | |\n                                                         \\___/ \\__,_|_|\n";
            settings[2] = "                                                       _   _\n                                                      | \\ | |\n                                                      |  \\| | ___  _ __\n                                                      | . ` |/ _ \\| '_ \\\n                                                      | |\\  | (_) | | | |\n                                                      \\_| \\_/\\___/|_| |_|\n";
            settings[3] = "                                              ______ _  __ _            _ _\n                                              |  _  (_)/ _(_)          | | |\n                                              | | | |_| |_ _  ___ _   _| | |_ ___\n                                              | | | | |  _| |/ __| | | | | __/ _ \\\n                                              | |/ /| | | | | (__| |_| | | ||  __/\n                                              |___/ |_|_| |_|\\___|\\__,_|_|\\__\\___|\n";
            settings[4] = "                                               _   _                            _\n                                              | \\ | |                          | |\n                                              |  \\| | ___  _ __ _ __ ___   __ _| |\n                                              | . ` |/ _ \\| '__| '_ ` _ \\ / _` | |\n                                              | |\\  | (_) | |  | | | | | | (_| | |\n                                              \\_| \\_/\\___/|_|  |_| |_| |_|\\__,_|_|\n";
            settings[5] = "                                                ______ _  __  __ _      _ _\n                                                |  _  (_)/ _|/ _(_)    (_) |\n                                                | | | |_| |_| |_ _  ___ _| | ___\n                                                | | | | |  _|  _| |/ __| | |/ _ \\\n                                                | |/ /| | | | | | | (__| | |  __/\n                                                |___/ |_|_| |_| |_|\\___|_|_|\\___|\n";
            settings[6] = "                                           ______         _\n                                           | |_/ /_ _  __| | __ ___      ____ _ _ __\n                                           |  __/ _` |/ _` |/ _` \\ \\ /\\ / / _` | '_ \\\n                                           | | | (_| | (_| | (_| |\\ V  V / (_| | | | |\n                                           \\_|  \\__,_|\\__,_|\\__,_| \\_/\\_/ \\__,_|_| |_|\n";

            

            const short songHeight = 22;
            const short dificutyHeight = 36;

            int vb = Convert.ToInt32(music);

            Console.SetCursorPosition(0,5);
            TitleWritter(title);
            Console.SetCursorPosition(0,15);

            for(int a = 0;a < settings.Length;a++)
            {
                if(a == 0 || a == 3)
                {
                    Console.WriteLine(settings[a]);
                }
                
                if (a == dificulty + 3 || a == Convert.ToInt32(music) + 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    Console.WriteLine(settings[a]);
                }
                Console.ForegroundColor = ConsoleColor.White;

            }
            return 2;
        }
        static void SettingMenuWritter(short actualRubric)
        {
            short dificulty = game.Difficulty;
            bool music = game.Music;

            string[] songs = new string[2];
            songs[1] = "                                                          _____       _                   \n                                                         |  _  |     (_)     \n                                                         | | | |_   _ _      \n                                                         | | | | | | | |     \n                                                         \\ \\_/ / |_| | |     \n                                                          \\___/ \\__,_|_|     \n";
            songs[0] = "                                                       _   _                           \n                                                      | \\ | |                           \n                                                      |  \\| | ___  _ __                           \n                                                      | . ` |/ _ \\| '_ \\     \n                                                      | |\\  | (_) | | | |     \n                                                      \\_| \\_/\\___/|_| |_|     \n";
            const short songLocation = 22;

            string[] dificultyTitle = new string[3];
            dificultyTitle[0] = "                                               _   _                            _                              \n                                              | \\ | |                          | |                              \n                                              |  \\| | ___  _ __ _ __ ___   __ _| |                              \n                                              | . ` |/ _ \\| '__| '_ ` _ \\ / _` | |                              \n                                              | |\\  | (_) | |  | | | | | | (_| | |                              \n                                              \\_| \\_/\\___/|_|  |_| |_| |_|\\__,_|_|                              \n";
            dificultyTitle[1] = "                                                ______ _  __  __ _      _ _                              \n                                                |  _  (_)/ _|/ _(_)    (_) |                              \n                                                | | | |_| |_| |_ _  ___ _| | ___                              \n                                                | | | | |  _|  _| |/ __| | |/ _ \\                              \n                                                | |/ /| | | | | | | (__| | |  __/                              \n                                                |___/ |_|_| |_| |_|\\___|_|_|\\___|                              \n";
            dificultyTitle[2] = "                                            _____          _                                                         \n                                           |  __ \\        | |                    \n                                           | |__) |_ _  __| | __ ___      ____ _ _ __\n                                           |  ___/ _` |/ _` |/ _` \\ \\ /\\ / / _` | '_ \\\n                                           | |  | (_| | (_| | (_| |\\ V  V / (_| | | | |\n                                           |_|   \\__,_|\\__,_|\\__,_| \\_/\\_/ \\__,_|_| |_|\n";
            const short dificultyLocation = 36;


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (actualRubric == 0)
            {
                Console.SetCursorPosition(0, songLocation);
                Console.WriteLine(songs[Convert.ToInt32(music)]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, dificultyLocation);
                Console.WriteLine(dificultyTitle[dificulty]);
            }
            else if (actualRubric == 1)
            {
                Console.SetCursorPosition(0, dificultyLocation);
                Console.WriteLine(dificultyTitle[dificulty]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, songLocation);
                Console.WriteLine(songs[Convert.ToInt32(music)]);
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        static short SettingMenuNavigation(short actualRubric, string[] titres)
        {
            ConsoleKeyInfo arrow = Console.ReadKey();

            switch (arrow.Key)
            {
                case ConsoleKey.UpArrow:
                    if(actualRubric == 0)
                        actualRubric = 1;
                    else if (actualRubric == 1)
                        actualRubric = 0;
                    SettingMenuWritter(actualRubric);
                    break;

                case ConsoleKey.DownArrow:
                    if (actualRubric == 0)
                        actualRubric = 1;
                    else if (actualRubric == 1)
                        actualRubric = 0;
                    SettingMenuWritter(actualRubric);
                    break;
                case ConsoleKey.Enter:
                    SettingMenuActions(actualRubric);
                    break;
                case ConsoleKey.Escape:
                    actualRubric = 2;
                    break;
            }

            return actualRubric;
        }
        static void SettingMenuActions(short actualRubric)
        {
            

            switch (actualRubric)
            {
                case 0:
                    game.Music = !game.Music;
                    SettingMenuWritter(actualRubric);
                    break;

                case 1:
                    if (game.Difficulty == 2)
                    {
                        game.Difficulty = 0;
                    }
                    else
                        game.Difficulty++;
                        SettingMenuWritter(actualRubric);
                    break;

            }



        }










    }

}
