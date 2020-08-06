using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Actions
    {
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
                case -1: // traveling
                    Printer("Choose direction (r/right, d/down): ", 0);
                    while (true)
                    {
                        HUD(State);
                        input = Convert.ToChar(Console.ReadLine());
                        if (input == 'r' | input == 'd')
                        {
                            return input;
                        }
                        else
                        {
                            Printer("Unknown command", 1);
                        }
                    }

                case 2: // battle
                    if (entered)
                    {
                        Console.WriteLine("You have stumbled upon an unfriendly " + World.Grid[y, x].dificulty + " looking creature...");
                        entered = false;
                    }
                    Printer("It's preparing to attack(" + ")!", 1);
                    if (escapability)
                    {
                        Printer("Choose next action (a/attack(20), b/block(15), e/escape(40)): ", 0);
                    }
                    else
                    {
                        Printer("Choose next action (a/attack(20), b/block(15)): ", 0);
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
                            Printer("Unknown command", 1);
                        }
                    }
                case 0:

                    return input;
                default:
                    return Convert.ToChar(Console.ReadLine());
            }
        }
        void Printer(string output, int enter)
        {
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
                        int del = Convert.ToString(Player.HP).Length + Convert.ToString(Player.MHP).Length + 6;
                        for (int j = 0; j < World.width - (World.horizontal * 2 + 3) - del; j++)
                        {
                            Console.Write(" ");
                        }
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("AP: " + Player.AP + "/" + Player.MAP);
                        Console.ResetColor();
                        del = Convert.ToString(Player.AP).Length + Convert.ToString(Player.MAP).Length + 6;
                        for (int l = 0; l < World.width - (World.horizontal * 2 + 3) - del; l++)
                        {
                            Console.Write(" ");
                        }
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Gold: " + Player.gold);
                        Console.ResetColor();
                        del = Convert.ToString(Player.gold).Length + 7;
                        for (int l = 0; l < World.width - (World.horizontal * 2 + 3) - del; l++)
                        {
                            Console.Write(" ");
                        }
                        break;
                    case World.vertical - 1:
                        if (State == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("It's HP: " + Convert.ToString(World.Grid[Player.Y, Player.X].ehp) + "/" + Convert.ToString(World.Grid[Player.Y, Player.X].emhp));
                            Console.ResetColor();
                            del = 10 + Convert.ToString(World.Grid[Player.Y, Player.X].ehp).Length + Convert.ToString(World.Grid[Player.Y, Player.X].emhp).Length;
                            for (int l = 0; l < World.width - (World.horizontal * 2 + 4) - del; l++)
                            {
                                Console.Write(" ");
                            }
                        }
                        else
                        {
                            for (int l = 0; l < World.width - (World.horizontal * 2 + 4); l++)
                            {
                                Console.Write(" ");
                            }
                        }
                        break;
                    default:
                        for (int l = 0; l < World.width - (World.horizontal * 2 + 4); l++)
                        {
                            Console.Write(" ");
                        }
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("\u2503");
                for (int j = 0; j < World.Grid.GetUpperBound(1) + 1; j++)
                {
                    if (Player.Y == i & Player.X == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" *");
                    }
                    else
                    {
                        Console.ForegroundColor = (ConsoleColor)World.Grid[i, j].Sname(1);
                        Console.Write(" " + World.Grid[i, j].Sname(0));
                    }

                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" \u2503");
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
