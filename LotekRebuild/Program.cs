using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace LotekRebuild
{
    class Program
    {
        public int[] liczby;
        public int[] index;
        public List<Losowanie> listaLosowan;
        public Losowanie losowanie;

        public static void Czyszczenie()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
        public static void zlyPrzycisk()
        {
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Thread.Sleep(70);

            Console.Beep();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Thread.Sleep(70);

            Console.Beep();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Thread.Sleep(70);

            Console.Beep();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Thread.Sleep(70);
        }
        public static void wyswietlMenu(String[] textArray, int pozycja)
        {
            int maxLength = textArray[0].Length;

            for (int i = 1; i < textArray.Length; i++)
            {
                if (textArray[i].Length > maxLength)
                {
                    maxLength = textArray[i].Length;
                }
            }
            //left + top
            Console.CursorLeft = Console.WindowWidth / 2 - (maxLength / 2) - 1;
            Console.CursorTop = Console.WindowHeight / 2 - 1;
            Console.Write("\u2554");

            //right + top
            Console.CursorLeft = Console.WindowWidth / 2 + (maxLength / 2) + 3;
            Console.Write("\u2557");

            //left + bot
            Console.CursorLeft = Console.WindowWidth / 2 - (maxLength / 2) - 1;
            Console.CursorTop = Console.WindowHeight / 2 + (textArray.Length);
            Console.Write("\u255A");

            //right + bot
            Console.CursorLeft = Console.WindowWidth / 2 + (maxLength / 2) + 3;
            Console.Write("\u255D");

            //top + bot
            for (int i = Console.WindowWidth / 2 - (maxLength / 2); i <= (Console.WindowWidth / 2 + (maxLength / 2) + 2); i++)
            {
                Console.CursorLeft = i;
                Console.CursorTop = Console.WindowHeight / 2 - 1;
                Console.Write("\u2550");

                Console.CursorLeft = i;
                Console.CursorTop = Console.WindowHeight / 2 + (textArray.Length);
                Console.Write("\u2550");
            }
            // teft + text + right
            Console.CursorLeft = Console.WindowWidth / 2 - (maxLength / 2);
            Console.CursorTop = Console.WindowHeight / 2;

            int spaces,
                k = 0;
            do
            {
                Console.CursorLeft = Console.WindowWidth / 2 - (maxLength / 2) - 1;
                Console.CursorTop = Console.WindowHeight / 2 + (k);
                Console.Write("\u2551 " + textArray[k]);

                spaces = maxLength - textArray[k].Length;

                for (int j = 0; j < spaces; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(" \u2551");

                k++;
            } while (k < textArray.Length);

            // tło 
            Console.CursorLeft = Console.WindowWidth / 2 - (maxLength / 2) + 1;
            Console.CursorTop = Console.WindowHeight / 2 + pozycja;

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(textArray[pozycja]);
        }



        public static List<Losowanie> wczytanieLiczb()
        {
            List<Losowanie> listaLosowan = new List<Losowanie>();

            int[] tab = new int[49];

            for (int i = 0; i < 49; i++)
            {
                tab[i] = 0;
            }

            foreach (string linia in File.ReadLines(@"dl.txt", Encoding.UTF8))
            {
                try
                {
                    Losowanie losowanie = new Losowanie();

                    string[] czesci = linia.Split(' ');
                    losowanie.Indeks = Convert.ToInt32(czesci[0].Trim('.'));
                    losowanie.Data = Convert.ToDateTime(czesci[1]);

                    int[] wyniki = new int[6];
                    var temp = czesci[2].Split(',');
                    for (int i = 0; i < 6; i++)
                    {
                        losowanie.Wyniki[i] = Convert.ToInt32(temp[i]);
                    }
                    listaLosowan.Add(losowanie);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Niewłaściwy format pliku. Linia '{0}' jest niepoprawna", linia);
                }
            }
            return listaLosowan;
        }

        public static void wypiszWszystkie()
        {
            List<Losowanie> listaLosowan;
            listaLosowan = wczytanieLiczb();

            foreach (Losowanie losowanie in listaLosowan)
            {
                Console.WriteLine("{0} -> {1} -> {2},{3},{4},{5},{6},{7},", losowanie.Indeks, losowanie.Data, losowanie.Wyniki[0], losowanie.Wyniki[1], losowanie.Wyniki[2], losowanie.Wyniki[3], losowanie.Wyniki[4], losowanie.Wyniki[5]);
            }
            Console.ReadKey();
        }

        public static void iloscWystapien()
        {
            List<Losowanie> listaLosowan;
            listaLosowan = wczytanieLiczb();
            int[] tab = new int[49];
            for (int i = 0; i < 49; i++)
            {
                tab[i] = 0;
            }
            foreach (Losowanie losowanie in listaLosowan)
            {
                for (int i = 0; i < 6; i++)
                {
                    tab[(losowanie.Wyniki[i]) - 1]++;
                }
            }

            for (int i = 1; i < 50; i++)
            {
                Console.WriteLine("{0} -> {1}", i, tab[i - 1]);
            }
            Console.ReadKey();

        }
        public static void najczesciejLosowana()
        {
            List<Losowanie> listaLosowan;
            listaLosowan = wczytanieLiczb();
            int[] tab = new int[49];
            for (int i = 0; i < 49; i++)
            {
                tab[i] = 0;
            }
            foreach (Losowanie losowanie in listaLosowan)
            {
                for (int i = 0; i < 6; i++)
                {
                    tab[(losowanie.Wyniki[i]) - 1]++;
                }
            }

            int max = tab.Max();
            int gdziemax = 0;

            for (int i = 1; i < 50; i++)
            {
                if (tab[i - 1] == max)
                {
                    gdziemax = i;
                }
            }
            Console.WriteLine("{0} wystąpiło {1} razy", gdziemax, max);
            Console.ReadKey();
        }

        public static void najrzadziejjLosowana()
        {
            List<Losowanie> listaLosowan;
            listaLosowan = wczytanieLiczb();
            int[] tab = new int[49];
            for (int i = 0; i < 49; i++)
            {
                tab[i] = 0;
            }
            foreach (Losowanie losowanie in listaLosowan)
            {
                for (int i = 0; i < 6; i++)
                {
                    tab[(losowanie.Wyniki[i]) - 1]++;
                }
            }

            int[] aa = new int[49];
            tab.CopyTo(aa, 0);
            Array.Sort(aa);

            int[] pom2 = new int[6];
            int[] pom = new int[6];

            for (int i = 0; i < 6; i++)
            {
                pom[i] = aa[i];
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 49; j++)
                {
                    if (tab[j] == pom[i])
                    {
                        pom2[i] = j;
                    }
                }
                Console.WriteLine(pom2[i]+1);
            }

            Console.ReadKey();
        }

        public static void ileRazyWystapiloPowtorzenie()
        {
            List<Losowanie> listaLosowan;
            listaLosowan = wczytanieLiczb();
            foreach (Losowanie los1 in listaLosowan)
            {
                foreach (Losowanie los2 in listaLosowan)
                {
                    if (los1.Indeks != los2.Indeks && los1.Wyniki[0] == los2.Wyniki[0] && los1.Wyniki[1] == los2.Wyniki[1] && los1.Wyniki[2] == los2.Wyniki[2]
                                                   && los1.Wyniki[3] == los2.Wyniki[3] && los1.Wyniki[4] == los2.Wyniki[4] && los1.Wyniki[5] == los2.Wyniki[5])
                    {
                        Console.WriteLine("Powtórzenie wystąpiło w losowaniu nr: {0} oraz: {1}.", los1.Indeks, los2.Indeks);
                        Console.ReadKey();
                        return;
                    }
                }
            }
            Console.WriteLine("Nigdy nie wystąpiło powtórzenie");
            Console.ReadKey();
        }



        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int poz = 0;
            String[] textArray = new String[] {
                "        Wszystkie losowania        ",
                "          Ilość wystąpień          ",
                "    Liczba najczęściej losowana    ",
                "Sześć najrzadziej losowanych liczb ",
                "  Ile razy wystąpiło powtórzenie   ",
                "              Wyjście              "
            };

            while (true)
            {
                Czyszczenie();
                wyswietlMenu(textArray, poz);

                ConsoleKeyInfo klawisz = Console.ReadKey();
                switch (klawisz.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (poz != 0)
                            --poz;
                        break;
                    case ConsoleKey.DownArrow:
                        if (poz != textArray.Length - 1)
                            ++poz;
                        break;
                    case ConsoleKey.Escape:
                        return;

                    case ConsoleKey.Enter:
                        switch (poz)
                        {
                            case 0:
                                Czyszczenie();
                                wypiszWszystkie();
                                Czyszczenie();
                                break;
                            case 1:
                                Czyszczenie();
                                iloscWystapien();
                                Czyszczenie();
                                break;
                            case 2:
                                Czyszczenie();
                                najczesciejLosowana();
                                Czyszczenie();
                                break;
                            case 3:
                                Czyszczenie();
                                najrzadziejjLosowana();
                                Czyszczenie();

                                break;
                            case 4:
                                Czyszczenie();
                                ileRazyWystapiloPowtorzenie();
                                Czyszczenie();
                                break;
                            case 5:
                                return;
                        }
                        break;
                        default:
                        zlyPrzycisk();
                        break;
                }
            }
        }
    }
}

