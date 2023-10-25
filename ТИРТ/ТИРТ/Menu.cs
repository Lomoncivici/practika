using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Timers;

namespace ТИРТ
{
    internal class Menu
    {
        public static void Control()
        {
            Console.CursorVisible = false;
            string menu0 = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "txt\\фоны\\меню0.txt"));
            string menu1 = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "txt\\фоны\\меню1.txt"));
            string Menu = menu0;
            ConsoleKeyInfo key;
            bool work_menu = true;
            bool bb = false;
            int pos = 19;
            while (work_menu)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(Menu);

                    if (bb == true)
                    {
                        Console.SetCursorPosition(64, 21);
                        Console.WriteLine("какие настройки ?");
                        Menu = menu1;
                    }

                    Console.SetCursorPosition(54 + 5, pos);
                    Console.WriteLine("->");
                    Console.SetCursorPosition(54 + 30, pos);
                    Console.WriteLine("<-");

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (pos != 19)
                            {
                                Console.SetCursorPosition(0, pos);
                                pos -= 2;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (pos != 23)
                            {
                                Console.SetCursorPosition(0, pos);
                                pos += 2;
                            }
                            break;
                        case ConsoleKey.Enter:
                            if (pos == 23)
                            {
                                Environment.Exit(0);
                            }

                            else if (pos == 21)
                            {
                                bb = true;
                            }

                            else if (pos == 19)
                            {
                                Console.Clear();
                                work_menu = false;
                            }
                            break;

                    }
            }
        }
    }
}
