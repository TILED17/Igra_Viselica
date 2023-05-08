//////////////////////////////////////////////////////
//
// Игра:    Виселица
// Об коде: Скажу честно, это говно код... но работает
// Автор:   T1LED7
//
//////////////////////////////////////////////////////
using System;
using System.Collections.Generic;

namespace Viselica
{
    public class Game
    {
        Random random = new Random();
        public string GameAction = "start";
        public int difficult = 0;
        string Button = null;
        private int Width = 10;

        public List<char> guessLetter = new List<char>() { };
        public List<char> missLetter = new List<char>() { };

        char[] Alphavit = new char[]
            {'а', 'б', 'в', 'г','д','е','ж','з',
            'и', 'й', 'к', 'л','м','н','о','п',
            'р', 'с', 'т', 'у','ф','х','ц','ч',
            'ш', 'щ', 'ъ', 'ы','ь','э','ю','я'};

        //Тут можно задать свои 3 темы, ИМЕННО 3 ТЕМЫ
        string[,] Themes = {
            {"Печенье","Фрукты", "Напиток"},
            {"Кухня", "Страна", "Животные"},
            {"Мебели","Школа", "Мультфильмы"},
            {"Танцы","Детство", "Техника"},
            {"Антистресс","Спорт", "Фильмы"}
        };
        //кухня - 0, страна - 1, Животные - 2
        //Мебель - 3, Школа - 4, Мультфилмы - 5
        string[,] Words = {
            { "пряник", "крекер", "галет" ,"сухари", "сушка"}, // Печенье
            { "Абрикос", "мандарин", "яблоко" ,"дыня", "персик"}, // Фрукты
            { "компот", "квас", "кефир" ,"виски", "сок"}, // Напиток
            { "чайник", "блинница", "кастрюля" ,"фольга", "духовка"}, // Кухня
            { "россия", "германия", "нидерланды", "франция", "украина" }, // Страны
            { "леопард", "крокодил", "человек" , "утканос","медведь"}, // Животные
            {"тумбочка", "табурет", "светильник", "колыбель", "кровать" }, // Мебели
            {"столовая", "математика", "ремень", "контрольная", "перемена" }, // Школа
            {"простоквашино", "смешарики", "рататуй", "тачки", "мадагаскар" }, // Мультфильмы
            { "вальс", "тектоник", "калинка" ,"балет", "полька"}, // танцы
            { "шалость", "садик", "скакалка" ,"песочница", "качели"}, // Детство
            { "микроволновка", "фотоаппарат", "геликоптер" ,"ноутбук", "холодильник"}, //Техника
            { "спиннер", "лизун", "сквиш" ,"джойстик", "массажер"}, // Антистресс
            { "теннис", "дзюдо", "фехтование" ,"скелетон", "баскетбол"}, // Спорт
            { "форсаж", "титаник", "аватар" ,"хеллбой", "бетмен"} // Фильмы
        };
        ConsoleKeyInfo pressBut = new ConsoleKeyInfo();

        public string key(Boolean strOrKey = false)
        {
            if (strOrKey)
            {
                pressBut = Console.ReadKey(true);
                return (Convert.ToString(pressBut.KeyChar)).ToLower();
            }
            else
            {
                pressBut = Console.ReadKey(true);
                return Convert.ToString(pressBut.Key);
            }
        }
        public void Astart()
        {
            Console.Clear();
            Console.ForegroundColor = (GameAction == "start" ? ConsoleColor.Green : ConsoleColor.White);
            Console.WriteLine("Начать");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = (GameAction == "exit" ? ConsoleColor.Green : ConsoleColor.White);
            Console.WriteLine("Выход");
            Console.ForegroundColor = ConsoleColor.White;
            choose();
        }
        public string rndTheme()
        {
            string thisTheme = Themes[difficult, random.Next(0, 3)];

            return thisTheme;
        }

        //Вывод массива с темами
        private string[] GetListThemes()
        {
            List<string> ListThemes = new List<string>();
            for (int i = 0; i < Themes.GetLength(1); i++)
            {
                ListThemes.Add(Themes[difficult, i]);
            }

            return ListThemes.ToArray();
        }
        public string rndWord(string guessTheme)
        {
            string thisWord = Words[(difficult * 3 + Array.IndexOf(GetListThemes(), guessTheme)), random.Next(0, Words.GetLength(1))];

            return thisWord;
        }

        //Вывод виселицы - визуал
        private void viselica(int NumAttempts)
        {
            switch (NumAttempts)
            {
                case 0:
                    Console.WriteLine("    ╒════╗");
                    Console.WriteLine("    │    ║");
                    Console.WriteLine("    0    ║");
                    Console.WriteLine("   /|\\   ║");
                    Console.WriteLine("   / \\   ║");
                    Console.WriteLine("GAME OVER║");
                    break;
                case 1:
                    Console.WriteLine("    ╒════╗");
                    Console.WriteLine("    │    ║");
                    Console.WriteLine("    O    ║");
                    Console.WriteLine("   /|\\   ║");
                    Console.WriteLine("   / \\   ║");
                    Console.WriteLine(" █▀█     ║");
                    break;
                case 2:
                    Console.WriteLine("    ╒════╗");
                    Console.WriteLine("    │    ║");
                    Console.WriteLine("    O    ║");
                    Console.WriteLine("   /|\\   ║");
                    Console.WriteLine("   / \\   ║");
                    Console.WriteLine("   █▀█   ║");
                    break;
                case 3:
                    Console.WriteLine("    ╒════╗");
                    Console.WriteLine("         ║");
                    Console.WriteLine("    O    ║");
                    Console.WriteLine("   /|\\   ║");
                    Console.WriteLine("   / \\   ║");
                    Console.WriteLine("   █▀█   ║");
                    break;
                case 4:
                    Console.WriteLine("          ");
                    Console.WriteLine("         ║");
                    Console.WriteLine("    O    ║");
                    Console.WriteLine("   /|\\   ║");
                    Console.WriteLine("   / \\   ║");
                    Console.WriteLine("   █▀█   ║");
                    break;
                case 5:
                    Console.WriteLine("          ");
                    Console.WriteLine("          ");
                    Console.WriteLine("    O     ");
                    Console.WriteLine("   /|\\    ");
                    Console.WriteLine("   / \\    ");
                    Console.WriteLine("   █▀█    ");
                    break;
                case 6:
                    Console.WriteLine("          ");
                    Console.WriteLine("          ");
                    Console.WriteLine("          ");
                    Console.WriteLine("    O     ");
                    Console.WriteLine("   /|\\    ");
                    Console.WriteLine("   / \\    ");
                    break;
                case 7:
                    Console.WriteLine("          ");
                    Console.WriteLine(" YOU WIN! ");
                    Console.WriteLine("          ");
                    Console.WriteLine("   \\O/    ");
                    Console.WriteLine("    |     ");
                    Console.WriteLine("   / \\    ");
                    break;
            }
        }
        public void choose()
        {
            Button = key();
            if (Button == "Enter" && GameAction == "start")
            {
                GameAction = "started";
            }
            else if (Button == "DownArrow" && GameAction == "start")
            {
                GameAction = "exit";
                Astart();
            }
            else if (Button == "UpArrow" && GameAction == "start")
            {
                GameAction = "exit";
                Astart();
            }
            else if (Button == "DownArrow" && GameAction == "exit")
            {
                GameAction = "start";
                Astart();
            }
            else if (Button == "UpArrow" && GameAction == "exit")
            {
                GameAction = "start";
                Astart();
            }
            else if (Button == "Enter" && GameAction == "exit")
            {
                Environment.Exit(0);
            }
            else
            {
                choose();
            }

        }
        public bool checkerWord(string CWord)
        {
            List<char> ListChar = new List<char>() { };
            foreach(char i in CWord.ToCharArray())
            {
                if (ListChar.Contains(i) == false)
                {
                    ListChar.Add(i);
                }
            }
            if(ListChar.Count == guessLetter.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void updLettersWord(string Uword)
        {
            foreach (char i in Uword.ToCharArray())
            {
                if (guessLetter.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(i.ToString().ToUpper());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write("-");
                }
            }

            Console.WriteLine();
        }
        private void AlphavitRu()
        {
            int a = 0;
            foreach (char i in Alphavit)
            {
                a++;
                //Console.ForegroundColor = (guessLetter.Contains(i)? ConsoleColor.Green :(missLetter.Contains(i)? ConsoleColor.Red: ConsoleColor.White));
                if (guessLetter.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (missLetter.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(i);
                Console.ForegroundColor = ConsoleColor.White;
                if (a == 10)
                {
                    Console.WriteLine();
                    a = 0;
                }
            }
            Console.WriteLine();
        }

        private void alertAttempts(int attempt)
        {
            Console.ForegroundColor = (attempt > 4 ? ConsoleColor.Green : (attempt > 2 ? ConsoleColor.Yellow : ConsoleColor.Red));
            Console.WriteLine(attempt);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void Update(string UTheme, string Uword, int Uattempts)
        {
            if (difficult == 5)
            {
                TheEnd();
            }
            Console.Clear();
            Console.WriteLine("Сложность: " + difficult);
            Console.WriteLine("Тема:");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(UTheme); Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Попыток: "); alertAttempts(Uattempts);
            if(checkerWord(Uword))
            {
                viselica(7);
            }
            else
            {
                viselica(Uattempts);
            }

            if (checkerWord(Uword))
            {
                GameAction = "Ended";
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(Uword.ToUpper()); Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
            }
            else if (Uattempts > 0)
            {
                updLettersWord(Uword);
                AlphavitRu();
                Console.Write("Буква: ");
            }
            else
            {
                GameAction = "Ended";
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(Uword.ToUpper()); Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
            }
        }
        public void Continue(string CWord)
        {
            Console.Clear();
            Console.WriteLine("Продолжить?");
            if (GameAction == "YesYesYes")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Да");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Нет");
            }
            else if(GameAction == "No")
            { 
                Console.WriteLine("Да");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Button = key();
            if (Button == "Enter" && GameAction == "YesYesYes")
            {
                GameAction = "again";
                if (checkerWord(CWord))
                {
                    difficult = (difficult < 5 ? difficult + 1 : difficult);
                }
            }
            else if (Button == "DownArrow" && GameAction == "YesYesYes")
            {
                GameAction = "No";
            }
            else if (Button == "UpArrow" && GameAction == "YesYesYes")
            {
                GameAction = "No";
            }
            else if (Button == "DownArrow" && GameAction == "No")
            {
                GameAction = "YesYesYes";
            }
            else if (Button == "UpArrow" && GameAction == "No")
            {
                GameAction = "YesYesYes";
            }
            else if (Button == "Enter" && GameAction == "No")
            {
                GameAction = "End";
                Environment.Exit(0);
            }
        }
        public void listLetterClear()
        {
            guessLetter.Clear();
            missLetter.Clear();
        }
        public void TheEnd()
        {
            Console.Clear();
            Console.WriteLine("          ");
            Console.WriteLine(" YOU WIN! ");
            Console.WriteLine("          ");
            Console.WriteLine("   \\☺/    ");
            Console.WriteLine("    |     ");
            Console.WriteLine("   / \\    ");
            Console.WriteLine("ПОЗДРАВЛЯЕМ!");
            Console.WriteLine("Вы выиграли.");
            Console.WriteLine("далее игра");
            Console.WriteLine("завершится");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            int attempts;
            string guessTheme;
            string guessWord;
            string yourLetter;

            game.Astart();

            void beginGame()
            {
                guessTheme = game.rndTheme();
                guessWord = game.rndWord(guessTheme);
                attempts = 6;

            }
            beginGame();

            while(game.GameAction != "End")
            {
                game.Update(guessTheme, guessWord, attempts);

                if(game.GameAction != "Ended")
                {
                    yourLetter = Console.ReadLine();
                    yourLetter = (yourLetter == "" ? "b" : yourLetter.Substring(0, 1));
                    if (guessWord.Contains(yourLetter) && !game.guessLetter.Contains(Convert.ToChar(yourLetter)))
                    {
                        game.guessLetter.Add(Convert.ToChar(yourLetter));
                    }
                    else
                    {
                        game.missLetter.Add(Convert.ToChar(yourLetter));
                        attempts--;
                    }
                }
                else
                {
                    Console.Clear();
                    game.GameAction = "YesYesYes";
                    if(game.difficult > 3 && game.checkerWord(guessWord))
                    {
                        game.TheEnd();
                    }
                    else
                    {
                        while (game.GameAction != "again")
                        {
                            game.Continue(guessWord);
                        }
                        beginGame();
                        game.listLetterClear();
                    }
                }
            }
            Environment.Exit(0);
        }
    }
}
