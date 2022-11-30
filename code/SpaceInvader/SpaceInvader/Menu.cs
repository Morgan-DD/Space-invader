using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    internal class Menu
    {
        int _type;


        string[] _titlepause = new string[6];
        int[] _titlepauseLocation = new int[2];

        string[] _titleLeave = new string[6];
        int[] _titleLeaveLocation = new int[2];

        string[] _titleContinue = new string[8];
        int[] _titleContinueLocation = new int[2];

        bool _menuLocation = true;

        bool up = false;
        short MainactualRubric = 1;



        Game game = new Game();

        public string[] titles = new string[6];
 
        short[] titlesLocation = new short[6];

        short actualRubric = 1;

        short _difficulty = 0;
        bool _music = true;

        public short Difficulty { get => _difficulty; set => _difficulty = value; }
        public bool Music { get => _music; set => _music = value; }

        public Menu(int type)
        {
            int space = 6;
            _type = type;
            if (type == 3)
            {
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
            else
            {
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

            }
        }

        //MainMenuDrawer(titles, titlesLocation, MainactualRubric, up);




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


            if (_type == 3)
            {
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
            }
            Console.SetCursorPosition(0, 34);
            Console.Write(" ");

            MenuPauseWritter(_menuLocation);

            do
            {
                _menuLocation = MenuPauseMove(_menuLocation);
            } while (true);

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
/*
                case ConsoleKey.Enter:
                    if (rubric)
                        Game.restart();
                    else

                    break;*/
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

            if (up == true && actualRubric > 0 && actualRubric < 5)
            {
                Console.SetCursorPosition(0, titlesLocation[actualRubric + 1]);
                Console.Write(titles[actualRubric + 1]);
            }
            else if (up == false && actualRubric < 6 && actualRubric > 1)
            {
                Console.SetCursorPosition(0, titlesLocation[actualRubric - 1]);
                Console.Write(titles[actualRubric - 1]);

            }
            else if (up == false && actualRubric == 1)
            {
                Console.SetCursorPosition(0, titlesLocation[5]);
                Console.Write(titles[5]);

            }
            else if (up == true && actualRubric == 5)
            {
                Console.SetCursorPosition(0, titlesLocation[1]);
                Console.Write(titles[1]);

            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(0, titlesLocation[actualRubric]);
            Console.Write(titles[actualRubric]);
            Console.ForegroundColor = ConsoleColor.White;

        }
        public short MainMenuNavigation()
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
                    MainMenuWritter();
                    break;

                case ConsoleKey.DownArrow:
                    actualRubric++;
                    up = false;
                    if (actualRubric >= 6)
                    {
                        actualRubric = 1;
                    }
                    MainMenuWritter();
                    break;
                case ConsoleKey.Enter:
                    MainMenuActions();
                    break;
            }

            return actualRubric;
        }

        public short MainMenuActions()
        {
            switch (actualRubric)
            {
                case 1:
                    game.gameStart();
                    break;

                case 2:
                    SettingMenu();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;
            }
            return actualRubric;
        }



        //-------------------------------------- settings --------------------------------------//


        public void SettingMenu()
        {
            bool end = true;
            short actualRubric = 0;

            short dificulty = Difficulty;
            bool _music = true;

            SettingMenuDrawer();
            SettingMenuWritter();

            do
            {
                actualRubric = SettingMenuNavigation();
                if (actualRubric == 2)
                    end = false;

            } while (end);
            MainMenuDrawer();
            MainMenuWritter();
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
            if (actualRubric == 0)
            {
                Console.SetCursorPosition(0, songLocation);
                Console.WriteLine(songs[Convert.ToInt32(Music)]);
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
                Console.WriteLine(songs[Convert.ToInt32(Music)]);
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
        public short SettingMenuNavigation()
        {
            ConsoleKeyInfo arrow = Console.ReadKey();

            switch (arrow.Key)
            {
                case ConsoleKey.UpArrow:
                    if (actualRubric == 0)
                        actualRubric = 1;
                    else if (actualRubric == 1)
                        actualRubric = 0;
                    SettingMenuWritter();
                    break;

                case ConsoleKey.DownArrow:
                    if (actualRubric == 0)
                        actualRubric = 1;
                    else if (actualRubric == 1)
                        actualRubric = 0;
                    SettingMenuWritter();
                    break;
                case ConsoleKey.Enter:
                    SettingMenuActions();
                    break;
                case ConsoleKey.Escape:
                    actualRubric = 2;
                    break;
            }

            return actualRubric;
        }
        public void SettingMenuActions()
        {


            switch (actualRubric)
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
