using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    internal class Menu
    {





        bool up = false;
        short Main_actualRubric = 1;


        Game game = new Game(new SpaceShip());



        public string[] titles = new string[6];
 
        short[] titlesLocation = new short[6];

        short Setting_actualRubric = 0;

        short _difficulty = 0;
        bool _music = true;

        public short Difficulty { get => _difficulty; set => _difficulty = value; }
        public bool Music { get => _music; set => _music = value; }

        public Menu(int type)
        {
            game.giveGameToShip(game);
                

            
                titles[0] = "                               _____                        _____                    _  	   \n                              /  ___|                      |_   _|                  | |	   \n                              \\ `--. _ __   __ _  ___ ___    | | _ ____   ____ _  __| | ___ _ __ \n                               `--. \\ '_ \\ / _` |/ __/ _ \\   | || '_ \\ \\ / / _` |/ _` |/ _ \\ '__|\n                              /\\__/ / |_) | (_| | (_|  __/  _| || | | \\ V / (_| | (_| |  __/ |   \n                              \\____/| .__/ \\__,_|\\___\\___|  \\___/_| |_|\\_/ \\__,_|\\__,_|\\___|_|   \n                                    | |                                                          \n                                    |_|                                                          \n";
                titles[1] = "                                                   ___                                         \n                                                  |_  |                                        \n                                                    | | ___  _   _  ___ _ __                   \n                                                    | |/ _ \\| | | |/ _ \\ '__|                  \n                                                /\\__/ / (_) | |_| |  __/ |                     \n                                                \\____/ \\___/ \\__,_|\\___|_|                     \n";
                titles[2] = "                                              _____       _   _\n                                             |  _  |     | | (_)\n                                             | | | |_ __ | |_ _  ___  _ __  ___\n                                             | | | | '_ \\| __| |/ _ \\| '_ \\/ __|\n                                             \\ \\_/ / |_) | |_| | (_) | | | \\__ \\\n                                              \\___/| .__/ \\__|_|\\___/|_| |_|___/\n                                                   | |\n                                                   |_|";
                titles[3] = "                                      _   _ _       _     _   _____\n                                     | | | (_)     | |   | | /  ___|\n                                     | |_| |_  __ _| |__ | |_\\ `--.  ___ ___  _ __ ___\n                                     |  _  | |/ _` | '_ \\| __|`--. \\/ __/ _ \\| '__/ _ \\\n                                     | | | | | (_| | | | | |_/\\__/ / (_| (_) | | |  __/\n                                     \\_| |_/_|\\__, |_| |_|\\__\\____/ \\___\\___/|_|  \\___|\n                                               __/ |\n                                              |___/";
                titles[4] = "                                             ___   ______\n                                            / _ \\  | ___ \\\n                                           / /_\\ \\ | |_/ / __ ___  _ __   ___  ___                 \n                                           |  _  | |  __/ '__/ _ \\| '_ \\ / _ \\/ __|\n                                           | | | | | |  | | | (_) | |_) | (_) \\__ \\\n                                           \\_| |_/ \\_|  |_|  \\___/| .__/ \\___/|___/\n                                                                  | |\n                                                                  |_|";
                titles[5] = "                                                _____       _ _   _\n                                               |  _  |     (_) | | |\n                                               | | | |_   _ _| |_| |_ ___ _ __\n                                               | | | | | | | | __| __/ _ \\ '__|\n                                               \\ \\/' / |_| | | |_| ||  __/ |\n                                                \\_/\\_\\__,_|_|\\__|\\__\\___|_|";

                titlesLocation[0] = 2;
                titlesLocation[1] = 12;
                titlesLocation[2] = 20;
                titlesLocation[3] = 29;
                titlesLocation[4] = 38;
                titlesLocation[5] = 47;

            /*
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
            */


        }



        public void TitleWritter()
        {
            Console.SetCursorPosition(17, 1);
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════╗");

            Console.WriteLine(titles[0]);

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

        public void MainMenuDrawer()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 12);
            for (int a = 1; a < titles.Length; a++)
            {
                Console.Write(titles[a] + "\n\n");
            }
            TitleWritter();
            MainMenuWritter();

        }

        public void MainMenuWritter()
        {

            if (up == true && this.Main_actualRubric > 0 && Main_actualRubric < 5)
            {
                Console.SetCursorPosition(0, titlesLocation[Main_actualRubric + 1]);
                Console.Write(titles[Main_actualRubric + 1]);
            }
            else if (up == false && Main_actualRubric < 6 && Main_actualRubric > 1)
            {
                Console.SetCursorPosition(0, titlesLocation[Main_actualRubric - 1]);
                Console.Write(titles[Main_actualRubric - 1]);
                
            }
            else if (up == false && Main_actualRubric == 1)
            {
                Console.SetCursorPosition(0, titlesLocation[5]);
                Console.Write(titles[5]);

            }
            else if (up == true && Main_actualRubric == 5)
            {
                Console.SetCursorPosition(0, titlesLocation[1]);
                Console.Write(titles[1]);

            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(0, titlesLocation[Main_actualRubric]);
            Console.Write(titles[Main_actualRubric]);
            Console.ForegroundColor = ConsoleColor.White;

        }
        public short MainMenuNavigation()
        {
            ConsoleKeyInfo arrow = Console.ReadKey();

            switch (arrow.Key)
            {
                case ConsoleKey.UpArrow:
                    Main_actualRubric--;
                    up = true;
                    if (Main_actualRubric <= 0)
                    {
                        Main_actualRubric = 5;
                    }
                    MainMenuWritter();
                    break;

                case ConsoleKey.DownArrow:
                    Main_actualRubric++;
                    up = false;
                    if (Main_actualRubric >= 6)
                    {
                        Main_actualRubric = 1;
                    }
                    MainMenuWritter();
                    break;
                case ConsoleKey.Enter:
                    MainMenuActions();
                    break;
            }

            return Main_actualRubric;
        }

        public void MainMenuActions()
        {
            switch (Main_actualRubric)
            {
                case 1:
                  game.gameStart(_difficulty, _music);
                    break;

                case 2:
                    SettingMenu();
                    MainMenuDrawer();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;
            }
        }



        //-------------------------------------- settings --------------------------------------//


        public void SettingMenu()
        {
            bool end = true;

            short dificulty = Difficulty;
            bool _music = true;

            SettingMenuDrawer();
            SettingMenuWritter();
            bool test = true;
            do
            {
                SettingMenuNavigation();
                if(Setting_actualRubric == 2)
                   test = false;
            } while (test);
            Setting_actualRubric = 0;
        }
        public short SettingMenuDrawer()
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

            int vb = Convert.ToInt32(Music);

            Console.SetCursorPosition(0, 5);
            TitleWritter();
            Console.SetCursorPosition(0, 15);

            for (int a = 0; a < settings.Length; a++)
            {
                if (a == 0 || a == 3)
                {
                    Console.WriteLine(settings[a]);
                }

                if (a == Difficulty + 3 || a == Convert.ToInt32(Music) + 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine(settings[a]);
                }
                Console.ForegroundColor = ConsoleColor.White;

            }
            Console.SetCursorPosition(55, 50);
            Console.WriteLine("Press [Esc] to exit");
            return 2;
        }
        public void SettingMenuWritter()
        {
            short dificulty = Difficulty;
            bool music = Music;

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
            if (Setting_actualRubric == 0)
            {
                Console.SetCursorPosition(0, songLocation);
                Console.WriteLine(songs[Convert.ToInt32(Music)]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, dificultyLocation);
                Console.WriteLine(dificultyTitle[dificulty]);
            }
            else if (Setting_actualRubric == 1)
            {
                Console.SetCursorPosition(0, dificultyLocation);
                Console.WriteLine(dificultyTitle[dificulty]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, songLocation);
                Console.WriteLine(songs[Convert.ToInt32(Music)]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void SettingMenuNavigation()
        {
            ConsoleKeyInfo arrow = Console.ReadKey();

            switch (arrow.Key)
            {
                case ConsoleKey.UpArrow:
                    if (this.Setting_actualRubric == 0)
                        this.Setting_actualRubric = 1;
                    else if (Setting_actualRubric == 1)
                        this.Setting_actualRubric = 0;
                        SettingMenuWritter();
                    break;

                case ConsoleKey.DownArrow:
                    if (this.Setting_actualRubric == 0)
                        this.Setting_actualRubric = 1;
                    else if (this.Setting_actualRubric == 1)
                        this.Setting_actualRubric = 0;
                        SettingMenuWritter();
                    break;
                case ConsoleKey.Enter:
                    SettingMenuActions();
                    break;
                case ConsoleKey.Escape:
                    this.Setting_actualRubric = 2;
                    break;
            }
        }
        public void SettingMenuActions()
        {


            switch (Setting_actualRubric)
            {
                case 0:
                    Music = !Music;
                    SettingMenuWritter();
                    break;

                case 1:
                    if (Difficulty == 2)
                    {
                        Difficulty = 0;
                    }
                    else
                        Difficulty++;
                    SettingMenuWritter();
                    break;

            }



        }


    }
}
