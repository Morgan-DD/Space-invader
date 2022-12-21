using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SpaceInvader
{
    internal class Menu
    {




        short _difficulty = 0;

        bool up = false;
        short Main_actualRubric = 1;



        bool _writeMenu = false;

        public string[] titles = new string[6];

        short[] titlesLocation = new short[6];

        short Setting_actualRubric = 0;

        bool _music = true;

        string _cheminsettings = "Settings.txt";
        string _cheminscore = "Scores.txt";

        Game game = new Game(new SpaceShip());

        public string[] _hightScoreTitle = new string[8];

        public short Difficulty { get => _difficulty; set => _difficulty = value; }
        public bool Music { get => _music; set => _music = value; }

        public Menu(int type)
        {
            string[] value = new string[2];
            game.giveGameToShip(game);
            game.Cheminscore = _cheminscore;


            titles[0] = "                               _____                        _____                    _  	   \n                              /  ___|                      |_   _|                  | |	   \n                              \\ `--. _ __   __ _  ___ ___    | | _ ____   ____ _  __| | ___ _ __ \n                               `--. \\ '_ \\ / _` |/ __/ _ \\   | || '_ \\ \\ / / _` |/ _` |/ _ \\ '__|\n                              /\\__/ / |_) | (_| | (_|  __/  _| || | | \\ V / (_| | (_| |  __/ |   \n                              \\____/| .__/ \\__,_|\\___\\___|  \\___/_| |_|\\_/ \\__,_|\\__,_|\\___|_|   \n                                    | |                                                          \n                                    |_|                                                          \n";
            titles[1] = "                                                   ___                                         \n                                                  |_  |                                        \n                                                    | | ___  _   _  ___ _ __                   \n                                                    | |/ _ \\| | | |/ _ \\ '__|                  \n                                                /\\__/ / (_) | |_| |  __/ |                     \n                                                \\____/ \\___/ \\__,_|\\___|_|                     \n";
            titles[2] = "                                              _____       _   _\n                                             |  _  |     | | (_)\n                                             | | | |_ __ | |_ _  ___  _ __  ___\n                                             | | | | '_ \\| __| |/ _ \\| '_ \\/ __|\n                                             \\ \\_/ / |_) | |_| | (_) | | | \\__ \\\n                                              \\___/| .__/ \\__|_|\\___/|_| |_|___/\n                                                   | |\n                                                   |_|";
            titles[3] = "                                         _   _ _       _     _____\n                                        | | | (_)     | |   /  ___|\n                                        | |_| |_  __ _| |__ \\ `--.  ___ ___  _ __ ___\n                                        |  _  | |/ _` | '_ \\ `--. \\/ __/ _ \\| '__/ _ \\\n                                        | | | | | (_| | | | /\\__/ / (_| (_) | | |  __/\n                                        \\_| |_/_|\\__, |_| |_\\____/ \\___\\___/|_|  \\___|\n                                                  __/ |\n                                                 |___/";
            titles[4] = "                                             ___   ______\n                                            / _ \\  | ___ \\\n                                           / /_\\ \\ | |_/ / __ ___  _ __   ___  ___                 \n                                           |  _  | |  __/ '__/ _ \\| '_ \\ / _ \\/ __|\n                                           | | | | | |  | | | (_) | |_) | (_) \\__ \\\n                                           \\_| |_/ \\_|  |_|  \\___/| .__/ \\___/|___/\n                                                                  | |\n                                                                  |_|";
            titles[5] = "                                                _____       _ _   _\n                                               |  _  |     (_) | | |\n                                               | | | |_   _ _| |_| |_ ___ _ __\n                                               | | | | | | | | __| __/ _ \\ '__|\n                                               \\ \\/' / |_| | | |_| ||  __/ |\n                                                \\_/\\_\\__,_|_|\\__|\\__\\___|_|";

            titlesLocation[0] = 2;
            titlesLocation[1] = 12;
            titlesLocation[2] = 20;
            titlesLocation[3] = 29;
            titlesLocation[4] = 38;
            titlesLocation[5] = 47;

            _hightScoreTitle[0] = "                               _   _ _       _     _____\n                              | | | (_)     | |   /  ___|\n                              | | _ | | _  __ _| | __ \\ `--.___ ___ _ __ ___\n                              |  _  | |/ _` | '_ \\ `--. \\/ __/ _ \\| '__/ _ \\\n                              | | | | | (_| | | | /\\__/ / (_| (_) | | |  __/\n                              \\_| |_/_|\\__, |_| |_\\____/ \\___\\___/|_|  \\___|\n                                        __/ |\n                                       |___/";
            _hightScoreTitle[1] = "| | | (_)     | |   /  ___|\n";
            _hightScoreTitle[2] = "| |_| |_  __ _| |__ \\ `--.  ___ ___  _ __ ___\n";
            _hightScoreTitle[3] = "|  _  | |/ _` | '_ \\ `--. \\/ __/ _ \\| '__/ _ \\\n";
            _hightScoreTitle[4] = "| | | | | (_| | | | /\\__/ / (_| (_) | | |  __/\n";
            _hightScoreTitle[5] = "\\_| |_/_|\\__, |_| |_\\____/ \\___\\___/|_|  \\___|\n";
            _hightScoreTitle[6] = "          __/ |\n";
            _hightScoreTitle[7] = "         |___/";

            value = File.ReadAllLines(_cheminsettings);

            _difficulty = Convert.ToInt16(value[1]);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(value[0]);
            if (value[0] == "True")
            {
                _music = true;
            }
            else
            {
                _music = false;
            }

            game.Difficulty = _difficulty;
            game.Music = _music;


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
            Console.ForegroundColor = ConsoleColor.White;
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
            if (_writeMenu)
            {
                game.gameClear();
                MainMenuDrawer();
                _writeMenu = false;
            }

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
                    _writeMenu = true;
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }

            return Main_actualRubric;
        }

        public void MainMenuActions()
        {
            switch (Main_actualRubric)
            {
                case 1:
                    game.gameStart();
                    break;

                case 2:
                    SettingMenu();
                    MainMenuDrawer();
                    ActualizeSettings();
                    break;

                case 3:
                    ScoreMenu();
                    break;
                case 4:
                    DetaiMenuDrawer();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;
            }
        }


        public void ActualizeSettings()
        {
            if (!File.Exists(_cheminsettings))
            {
                using (FileStream fs = File.Create(_cheminsettings))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes(Convert.ToString(_music));
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes(Convert.ToString(_difficulty));
                    fs.Write(author, 0, author.Length);
                }
            }
            else
            {
                File.WriteAllText(_cheminsettings, _music + "\n" + _difficulty);
            }

            game.Difficulty = _difficulty;
            game.Music = _music;
        }


        //-------------------------------------- settings --------------------------------------//


        public void SettingMenu()
        {

            short dificulty = Difficulty;
            bool _music = true;

            SettingMenuDrawer();
            SettingMenuWritter();
            bool test = true;
            do
            {
                SettingMenuNavigation();
                if (Setting_actualRubric == 2)
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
            Console.SetCursorPosition(0, 50);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Press [Esc] to exit".Length / 2)) + "}", "Press [Esc] to exit"));
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
        //--------------------------------------------------------------------------------------//

        public void ScoreMenu()
        {
            ScoreMenuDrawer();
        }

        public void ScoreMenuDrawer()
        {
            Console.Clear();
            string[] hightScoreTitle = new string[8];
            string[] Scores = new string[2];


            hightScoreTitle[0] = @" _   _ _       _     _____";
            hightScoreTitle[1] = @"| | | (_)     | |   /  ___|";
            hightScoreTitle[2] = @"| |_| |_  __ _| |__ \ `--.  ___ ___  _ __ ___";
            hightScoreTitle[3] = @"|  _  | |/ _` | '_ \ `--. \/ __/ _ \| '__/ _ \";
            hightScoreTitle[4] = @"| | | | | (_| | | | /\__/ / (_| (_) | | |  __/";
            hightScoreTitle[5] = @"\_| |_/_|\__, |_| |_\____/ \___\___/|_|  \___|";
            hightScoreTitle[6] = @"          __/ | ";
            hightScoreTitle[7] = @"         |___/  ";



            for (int a = 0; a < hightScoreTitle.Length; a++)
            {
                Console.SetCursorPosition(40, 5 + a);
                Console.WriteLine(hightScoreTitle[a]);

            }

            Scores = File.ReadAllLines(_cheminscore);

            int valuDepartY = 18;
            int limite = Scores.Length;

            for (int c = limite; c > 0; c--)
            {
                Console.SetCursorPosition(0, (valuDepartY + (limite * 2)) - (c * 2));
                //Console.WriteLine(Scores[b]);
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Scores[c - 1].Length / 2)) + "}", Scores[c - 1]));
            }


            int hauteur = (limite * 2) + (2 * 2) - 1;
            int longeur = 30;
            int departX = (120 - longeur) / 2;
            int departY = valuDepartY - 2;
            for (int b = 0; b < hauteur; b++)
            {
                Console.SetCursorPosition(departX, departY + b);
                if (b == 0)
                {
                    Console.Write("┌");
                }
                else if (b == hauteur - 1)
                {
                    Console.Write("└");
                }
                else
                {
                    Console.Write("│");
                }

                for (int c = 0; c < longeur; c++)
                {
                    if (b == 0 || b == hauteur - 1)
                    {
                        Console.Write("─");
                    }


                }
                Console.SetCursorPosition(departX + longeur, departY + b);
                if (b == 0)
                {
                    Console.Write("┐");
                }
                else if (b == hauteur - 1)
                {
                    Console.Write("┘");
                }
                else
                {
                    Console.Write("│");
                }
            }

            Console.SetCursorPosition(0, hauteur + departY + 1);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Press [Esc] to exit".Length / 2)) + "}", "Press [Esc] to exit"));

            ConsoleKeyInfo arrow;
            bool verif = true;
                do
                {
                    arrow = Console.ReadKey();

                    switch (arrow.Key)
                    {
                        case ConsoleKey.Escape:
                            verif = false;
                            break;
                    }
                } while (verif);

            
        }

        public void DetailMenu()
        {
            DetaiMenuDrawer();
        }

        public void DetaiMenuDrawer()
        {
            Console.Clear();
            int nbLigneText = 6;
            string[] detailTitle = new string[8];
            string[] textDetail = new string[nbLigneText];
            int taille = 10;
            int valuDepartY = 16;



            detailTitle[0] = @"  ___   ______";
            detailTitle[1] = @" / _ \  | ___ \";
            detailTitle[2] = @"/ /_\ \ | |_/ / __ ___  _ __   ___  ___ ";
            detailTitle[3] = @"|  _  | |  __/ '__/ _ \| '_ \ / _ \/ __|";
            detailTitle[4] = @"| | | | | |  | | | (_) | |_) | (_) \__ \";
            detailTitle[5] = @"\_| |_/ \_|  |_|  \___/| .__/ \___/|___/";
            detailTitle[6] = @"                       | |";
            detailTitle[7] = @"                       |_|";

            textDetail[0] = "Ce jeux space invader à été crée dans le cadre du projet P_Dev";
            textDetail[1] = "à l'ETML durant ma deuxieme année lors du premier semestre.";
            textDetail[2] = "----------------------------------------------------";
            textDetail[3] = "Le but est de tirer sur les aliens afin de les tuers pour recolter des points";
            textDetail[4] = "afin de se classer le plus haut possible dans le classement.";
            textDetail[5] = "Il faut aussi éviter de recevoir des tirs enemis.";


            for (int a = 0; a < detailTitle.Length; a++)
            {
                Console.SetCursorPosition(41, 5 + a);
                Console.Write(detailTitle[a]);
            }

            int longeur = 0;
            int hauteur = nbLigneText + 4;
            int departY = valuDepartY - 2;
            for (int c = 0; c < nbLigneText; c++)
            {
                Console.SetCursorPosition(0, valuDepartY + c);
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textDetail[c].Length / 2)) + "}", textDetail[c]));
                if (textDetail[c].Length > longeur)
                {
                    longeur = textDetail[c].Length;
                }

            }
            longeur += 8;

            int departX = (120 - longeur) / 2;
            for (int b = 0; b < hauteur; b++)
            {
                Console.SetCursorPosition(departX, departY + b);
                if (b == 0)
                {
                    Console.Write("┌");
                }
                else if (b == hauteur - 1)
                {
                    Console.Write("└");
                }
                else
                {
                    Console.Write("│");
                }

                for (int c = 0; c < longeur; c++)
                {
                    if (b == 0 || b == hauteur - 1)
                    {
                        Console.Write("─");
                    }


                }
                Console.SetCursorPosition(departX + longeur, departY + b);
                if (b == 0)
                {
                    Console.Write("┐");
                }
                else if (b == hauteur - 1)
                {
                    Console.Write("┘");
                }
                else
                {
                    Console.Write("│");
                }
            }

           
            Console.SetCursorPosition(0, hauteur + departY + 1);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Press [Esc] to exit".Length / 2)) + "}", "Press [Esc] to exit"));

            bool verif = true;
            ConsoleKeyInfo arrow;
            do
            {
                arrow = Console.ReadKey();

                switch (arrow.Key)
                {
                    case ConsoleKey.Escape:
                        verif = false;
                        break;
                }
            } while (verif);


        }
    }
}
