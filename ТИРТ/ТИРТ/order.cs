using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ТИРТ
{
    internal class Make_an_order
    {
        public static void Order()
        {
            Console.CursorVisible = false;
            string Fon1 = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "txt\\фоны\\Fon.txt"));
            string[] Fon_spisok = {
                "1) Форма торта",
                "2) Размер торта",
                "3) Вкус коржей",
                "4) Коло-во коржей",
                "5) Глазурь",
                "6) Декор",
                "7) Конец заказа"
            };
            string[] Fon_Info0 = {
                "квадратный  .",
                "круглый  .",
            };
            string[] Fon_Info1 = {
                "100см 200р  .",
                "50 см 150р  .",
                "25 см 100р  .",
            };int[] Fon_Info1_1 = {200,150,100};
            string[] Fon_Info2 = {
                "Безвкусный :) 0р  .",
                "Сладкий 25р  .",
                "Солённый 15р  .",
                "Со вкусом IT 500р  .",
                "Со вкусом яблока 150р  .",
                "Со вкусом вишни 157р  .",
                "Вкус грусти :( -500р  .",
            }; int[] Fon_Info2_1 = { 0, 25, 15,500,150,157,-500};
            string[] Fon_Info3 = {
                "Один корж 50р  .",
                "Два коржа 100р  .",
                "Три коржа 150р  .",
            }; int[] Fon_Info3_1 = { 50, 100, 150};
            string[] Fon_Info4 = {
                "Внильная 15р  .",
                "Клубничная 50р  .",
                "Без глазури 0р  .",
            }; int[] Fon_Info4_1 = { 15, 50, 0};
            string[] Fon_Info5 = {
                "Без декора 0р  .",
                "С декором 500р  .",
            }; int[] Fon_Info5_1 = { 0, 500};

            string[] Fon_Text = Fon_spisok;
            ConsoleKeyInfo key;

            int pos_0 = 8;
            int pos_1 = 20;
            string a0 = null;
            string a1 = null;
            string a2 = null;
            string a3 = null;
            string a4 = null;
            string a5 = null;
            int b1 = 0;
            int b2 = 0;
            int b3 = 0;
            int b4 = 0;
            int b5 = 0;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(Fon1);
                int symma = b1 + b2 + b3 + b4 + b5;
                Console.SetCursorPosition(127, 23);
                Console.WriteLine(symma);

                for (int i = 0; i < Fon_Text.Length; i++)
                {
                    Console.SetCursorPosition(8, 8 + i * 2);
                    Console.WriteLine(Fon_Text[i]);
                }
                string[] tirt0 = {
                    "         ,__________________________________________,         ",
                    "        /_-+-__-+-__-+-__-+-__-+-__-+-___-+-___-+-___\\        ",
                    "       |\\____________________________________________/|       ",
                    "     __\\_|__________________________________________|_/__     ",
                    "   _/ /|=|==========================================|=|\\ \\_   ",
                    "_/  / |_|__________________________________________|_| \\   \\_",
                    "|    \\ | |+  +  +  +  +  +  +  +  +  +  +  +  +  +  | | /    |",
                    "\\|\\_  \\_\\|__________________________________________|/_/  _/|/",
                    "|\\| \\____________________________________________________/ |/|",
                    "| |\\|____________________________________________________|/| |",
                    " \\| |                                                    | |/ ",
                    "   \\|____________________________________________________|/   "
                };
                string[] tirt1 = {
                    "      ,____________________________________________,",
                    "      |__-+-__-+-__-+-__-+-__-+-__-+-___-+-___-+-__|",
                    "      |--------------------------------------------|",
                    "     .|____________________________________________|.",
                    ",___/|==============================================|\\___,",
                    "|___\\|______________________________________________|/___|",
                    "|________________________________________________________|",
                    "|\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'\"'|",
                    "'--------------------------------------------------------'"
                };
                if (a0 == Fon_Info0[1])
                {
                    for (int i = 0; i < tirt0.Length; i++)
                    {
                        Console.SetCursorPosition(43, 21 + i);
                        Console.WriteLine(tirt0[i]);
                    }
                }
                else if (a0 == Fon_Info0[0])
                {
                    for (int i = 0; i < tirt1.Length; i++)
                    {
                        Console.SetCursorPosition(43, 22 + i);
                        Console.WriteLine(tirt1[i]);
                    }
                }

                Console.SetCursorPosition(6, pos_0);
                Console.WriteLine("->");

                Console.SetCursorPosition(115, 11);
                Console.WriteLine(a0);
                Console.SetCursorPosition(115, 13);
                Console.WriteLine(a1);
                Console.SetCursorPosition(115, 15);
                Console.WriteLine(a2);
                Console.SetCursorPosition(115, 17);
                Console.WriteLine(a3);
                Console.SetCursorPosition(115, 19);
                Console.WriteLine(a4);
                Console.SetCursorPosition(115, 21);
                Console.WriteLine(a5);

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && pos_0 != 8)
                {
                    Console.SetCursorPosition(6, pos_0);
                    pos_0 -= 2;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos_0 != pos_1)
                {
                    Console.SetCursorPosition(6, pos_0);
                    pos_0 += 2;
                }

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        if (pos_0 == 8 && Fon_Text == Fon_spisok)
                        {
                            Fon_Text = Fon_Info0;
                            pos_0 = 8;
                            pos_1 = 10;
                        }
                        else if (pos_0 == 10 && Fon_Text == Fon_spisok)
                        {
                            Fon_Text = Fon_Info1;
                            pos_0 = 8;
                            pos_1 = 12;
                        }
                        else if (pos_0 == 12 && Fon_Text == Fon_spisok)
                        {
                            Fon_Text = Fon_Info2;
                            pos_0 = 8;
                        }
                        else if (pos_0 == 14 && Fon_Text == Fon_spisok)
                        {
                            Fon_Text = Fon_Info3;
                            pos_0 = 8;
                            pos_1 = 12;
                        }
                        else if (pos_0 == 16 && Fon_Text == Fon_spisok)
                        {
                            Fon_Text = Fon_Info4;
                            pos_0 = 8;
                            pos_1 = 12;
                        }
                        else if (pos_0 == 18 && Fon_Text == Fon_spisok)
                        {
                            Fon_Text = Fon_Info5;
                            pos_0 = 8;
                            pos_1 = 10;
                        }
                        else if (pos_0 == 20 && Fon_Text == Fon_spisok)
                        {
                            DateTime today = DateTime.Today;
                            string todayString = today.ToString("dd.MM.yyyy");
                            string zakaz = a0 + a1 + a2 + a3 + a4 + a5;
                            string txt = "02.10.2023";
                            string symmaStr = symma.ToString();
                            File.AppendAllText("txt\\заказы\\Чек_лист.txt", "\n\nЗаказ от: ");
                            File.AppendAllText("txt\\заказы\\Чек_лист.txt", todayString);
                            File.AppendAllText("txt\\заказы\\Чек_лист.txt", "\n     Список заказа: ");
                            File.AppendAllText("txt\\заказы\\Чек_лист.txt", zakaz);
                            File.AppendAllText("txt\\заказы\\Чек_лист.txt", "\n     Цена заказа: ");
                            File.AppendAllText("txt\\заказы\\Чек_лист.txt", symmaStr);
                            a0 = null;
                            a1 = null;
                            a2 = null;
                            a3 = null;
                            a4 = null;
                            a5 = null;
                            b1 = 0;
                            b2 = 0;
                            b3 = 0;
                            b4 = 0;
                            b5 = 0;
                        }
                        else if (Fon_Text == Fon_Info0 && pos_0 == 8)
                        {
                            a0 = Fon_Info0[0];
                        }
                        else if (Fon_Text == Fon_Info0 && pos_0 == 10)
                        {
                            a0 = Fon_Info0[1];
                        }
                        else if (Fon_Text == Fon_Info1 && pos_0 == 8)
                        {
                            a1 = Fon_Info1[0];
                            b1 = Fon_Info1_1[0];
                        }
                        else if (Fon_Text == Fon_Info1 && pos_0 == 10)
                        {
                            a1 = Fon_Info1[1];
                            b1 = Fon_Info1_1[1];
                        }
                        else if (Fon_Text == Fon_Info1 && pos_0 == 12)
                        {
                            a1 = Fon_Info1[2];
                            b1 = Fon_Info1_1[2];
                        }
                        else if (Fon_Text == Fon_Info2 && pos_0 == 8)
                        {
                            a2 = Fon_Info2[0];
                            b2 = Fon_Info2_1[0];
                        }
                        else if (Fon_Text == Fon_Info2 && pos_0 == 10)
                        {
                            a2 = Fon_Info2[1];
                            b2 = Fon_Info2_1[1];
                        }
                        else if (Fon_Text == Fon_Info2 && pos_0 == 12)
                        {
                            a2 = Fon_Info2[2];
                            b2 = Fon_Info2_1[2];
                        }
                        else if (Fon_Text == Fon_Info2 && pos_0 == 14)
                        {
                            a2 = Fon_Info2[3];
                            b2 = Fon_Info2_1[3];
                        }
                        else if (Fon_Text == Fon_Info2 && pos_0 == 16)
                        {
                            a2 = Fon_Info2[4];
                            b2 = Fon_Info2_1[4];
                        }
                        else if (Fon_Text == Fon_Info2 && pos_0 == 18)
                        {
                            a2 = Fon_Info2[5];
                            b2 = Fon_Info2_1[5];
                        }
                        else if (Fon_Text == Fon_Info2 && pos_0 == 20)
                        {
                            a2 = Fon_Info2[6];
                            b2 = Fon_Info2_1[6];
                        }
                        else if (Fon_Text == Fon_Info3 && pos_0 == 8)
                        {
                            a3 = Fon_Info3[0];
                            b3 = Fon_Info3_1[0];
                        }
                        else if (Fon_Text == Fon_Info3 && pos_0 == 10)
                        {
                            a3 = Fon_Info3[1];
                            b3 = Fon_Info3_1[1];
                        }
                        else if (Fon_Text == Fon_Info3 && pos_0 == 12)
                        {
                            a3 = Fon_Info3[2];
                            b3 = Fon_Info3_1[2];
                        }
                        else if (Fon_Text == Fon_Info4 && pos_0 == 8)
                        {
                            a4 = Fon_Info4[0];
                            b4 = Fon_Info4_1[0];
                        }
                        else if (Fon_Text == Fon_Info4 && pos_0 == 10)
                        {
                            a4 = Fon_Info4[1];
                            b4 = Fon_Info4_1[1];
                        }
                        else if (Fon_Text == Fon_Info4 && pos_0 == 12)
                        {
                            a4 = Fon_Info4[2];
                            b4 = Fon_Info4_1[2];
                        }
                        else if (Fon_Text == Fon_Info5 && pos_0 == 8)
                        {
                            a5 = Fon_Info5[0];
                            b5 = Fon_Info5_1[0];
                        }
                        else if (Fon_Text == Fon_Info5 && pos_0 == 10)
                        {
                            a5 = Fon_Info5[1];
                            b5 = Fon_Info5_1[1];
                        }
                        break;
                    case ConsoleKey.Escape:
                        if (Fon_Text != Fon_spisok)
                        {
                            Fon_Text = Fon_spisok;
                            pos_0 = 8;
                            pos_1 = 20;
                        }
                        else if (Fon_Text == Fon_spisok)
                        {
                            Menu.Control();
                        }
                        break;
                }
            }
        }
    }
}
