using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Actions
    {
        Random random = new Random();
        char input = ' ';
        int eatk = 0;
        public bool escapability = true;
        public bool entered = true;
        bool first = true;
        public int[] curpos = new int[2];
        public int[] abspos = new int[2];
        public char Inputer(int State, int y, int x)
        {
            switch (State)
            {
                case (int)States.Traveling:
                    while (true)
                    {
                        Print("Choose direction (r/right, d/down): ", 0, (ConsoleColor)7);
                        HUD(State);
                        input = Convert.ToChar(Console.ReadLine());
                        if (input == 'r' | input == 'd')
                        {
                            return input;
                        }
                        else
                        {
                            Print("Unknown command", 1, (ConsoleColor)7);
                        }
                    }
                case (int)States.Trading:
                    while (true)
                    {
                        if (entered)
                        {
                            Print("You have came across a person who wants to exchange some of his items for", 0, (ConsoleColor)7);
                            Print(" gold", 0, (ConsoleColor)14);
                            Print(".", 1, (ConsoleColor)7);
                            entered = false;
                        }
                        Print("In stock: ", 0, (ConsoleColor)7);
                        for (int i = 0; i < World.Grid[y, x].asortment.Count; i++)
                        {
                            if (i == World.Grid[y, x].asortment.Count - 1)
                            {
                                Print( "(" + World.Grid[y, x].asortment[i] + ") ", 1, (ConsoleColor)7);
                            }
                            else
                            {
                                Print("(" + World.Grid[y, x].asortment[i] + ") ", 0, (ConsoleColor)7);
                            }

                        }
                        Print("Choose next action (1..3/purchae an item, l/leave): ", 0, (ConsoleColor)7);
                        HUD(State);
                        input = Convert.ToChar(Console.ReadLine());
                        if (input == '1' | input == '2' | input == '3' | input == 'l')
                        {
                            return input;
                        }
                        else
                        {
                            Print("Unknown command", 1, (ConsoleColor)7);
                        }
                    }
                case (int)States.Battle:
                    if (entered)
                    {
                        Print("You have stumbled upon an unfriendly " + World.Grid[y, x].dificulty + " looking ", 0, (ConsoleColor)7);
                        Print("creature...", 1, (ConsoleColor)13);
                        entered = false;
                    }
                    Print("It's", 0, (ConsoleColor)13);
                    eatk = random.Next(20, World.Grid[y, x].emhp / 2);
                    if (eatk < 40)
                    {
                        Print(" preparing a light attack(", 0, (ConsoleColor)7);
                    }
                    else if (eatk < 60)
                    {
                        Print(" preparing a medium attack(", 0, (ConsoleColor)7);
                    }
                    else
                    {
                        Print(" preparing a heavy attack(", 0, (ConsoleColor)7);
                    }
                    Print(Convert.ToString(eatk), 0, (ConsoleColor)12);
                    Print(")!", 1, (ConsoleColor)7);
                    if (escapability)
                    {
                        Print("Choose next action (a/attack(", 0, (ConsoleColor)7);
                        Print("20", 0, (ConsoleColor)11);
                        Print("), b/block(", 0, (ConsoleColor)7);
                        Print("15", 0, (ConsoleColor)11);
                        Print("), e/escape(", 0, (ConsoleColor)7);
                        Print("40", 0, (ConsoleColor)11);
                        Print(")): ", 0, (ConsoleColor)7);
                    }
                    else
                    {
                        Print("Choose next action (a/attack(20), b/block(15)): ", 0, (ConsoleColor)7);
                    }
                    while (true)
                    {
                        HUD(State);
                        input = Convert.ToChar(Console.ReadLine());
                        if (input == 'a' | input == 'b' | input == 'e')
                        {
                            return input;
                        }
                        else
                        {
                            Print("Unknown command", 1, (ConsoleColor)7);
                        }
                    }
                default:
                    input = Convert.ToChar(Console.ReadLine());
                    return input;
            }
        }
        void Print(string output, int enter, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            if (enter == 1)
            {
                Console.WriteLine(output);
            }
            else
            {
                Console.Write(output);
            }
        }
        public void HUD(int State)
        {
            abspos[0] = Console.CursorTop;
            abspos[1] = Console.CursorLeft;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\u2554");
            for (int j = 0; j < World.width - 2; j++)
            {
                if (World.width - (World.horizontal * 2 + 4) == j)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\u2566");
                }
                else
                {
                    Console.Write("\u2550");
                }
            }
            Console.Write("\u2557");
            Console.ResetColor();
            Console.WriteLine();
            for (int i = 0; i < World.Grid.GetUpperBound(0) + 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\u2503");
                switch (i)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("HP: " + Player.HP + "/" + Player.MHP);
                        Console.ResetColor();
                        int indent = ("HP: " + Player.HP + "/" + Player.MHP).Length;
                        Console.Write(new string(' ', World.width - (World.horizontal * 2) - (indent + 4)));
                        break;
                    case 1:
                        Console.ForegroundColor = (ConsoleColor)11;
                        Console.Write("AP: " + Player.AP + "/" + Player.MAP);
                        Console.ResetColor();
                        indent = ("AP: " + Player.AP + "/" + Player.MAP).Length;
                        Console.Write(new string(' ', World.width - (World.horizontal * 2) - (indent + 4)));
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Gold: " + Player.gold);
                        Console.ResetColor();
                        indent = ("Gold: " + Player.gold).Length;
                        Console.Write(new string(' ', World.width - (World.horizontal * 2) - (indent + 4)));
                        break;
                    case World.vertical - 1:
                        if (State == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("It's HP: " + Convert.ToString(World.Grid[Player.Y, Player.X].ehp) + "/" + Convert.ToString(World.Grid[Player.Y, Player.X].emhp));
                            Console.ResetColor();
                            indent = ("It's HP: " + Convert.ToString(World.Grid[Player.Y, Player.X].ehp) + "/" + Convert.ToString(World.Grid[Player.Y, Player.X].emhp)).Length;
                            Console.Write(new string(' ', World.width - (World.horizontal * 2) - (indent + 4)));
                        }
                        else
                        {
                            Console.Write(new string(' ', World.width - (World.horizontal * 2) - 4));
                        }
                        break;
                    default:
                        Console.Write(new string(' ', World.width - (World.horizontal * 2) - 4));
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("\u2503 ");
                for (int j = 0; j < World.Grid.GetUpperBound(1) + 1; j++)
                {
                    if (Player.Y == i & Player.X == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("* ");
                    }
                    else if (World.Grid[i, j].side % 10 == 2)
                    {
                        Console.ForegroundColor = (ConsoleColor)World.Grid[i, j].Sname(1);
                        Console.Write(World.Grid[i, j].Sname(0) + "\u2500");
                    }
                    else
                    {
                        Console.ForegroundColor = (ConsoleColor)World.Grid[i, j].Sname(1);
                        Console.Write(World.Grid[i, j].Sname(0) + " ");
                    }

                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\u2503");
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\u255A");
            for (int l = 0; l < World.width - (World.horizontal * 2 + 4); l++)
            {
                Console.Write("\u2550");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("\u2569");
            for (int i = 0; i < World.horizontal * 2 + 1; i++)
            {
                Console.Write("\u2550");
            }
            Console.WriteLine("\u255D");
            Console.ResetColor();
            Console.CursorVisible = true;
            if (!first)
            {
                Console.SetCursorPosition(abspos[1], abspos[0]);
            }
            first = false;
        }
    }
}
