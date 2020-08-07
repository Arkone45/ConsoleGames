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
                    while (true)
                    {
                        Printer("Choose direction (r/right, d/down): ", 0, (ConsoleColor)7);
                        HUD(State);
                        input = Convert.ToChar(Console.ReadLine());
                        if (input == 'r' | input == 'd')
                        {
                            return input;
                        }
                        else
                        {
                            Printer("Unknown command", 1, (ConsoleColor)7);
                        }
                    }
                case 0: // diologue
                    input = Convert.ToChar(Console.ReadLine());
                    return input;
                case 1: // trading
                    while (true)
                    {
                        if (entered)
                        {
                            Printer("You have came across a person who wants to exchange some of his items for", 0, (ConsoleColor)7);
                            Printer(" gold", 0, (ConsoleColor)14);
                            Printer(".", 1, (ConsoleColor)7);
                            entered = false;
                        }
                        Printer("Choose next action (1..5/purchae an item, l/leave): ", 0, (ConsoleColor)7);
                        HUD(State);
                        input = Convert.ToChar(Console.ReadLine());
                        if (input == '1' | input == '2' | input == '3' | input == '4' | input == '5' | input == 'l')
                        {
                            return input;
                        }
                        else
                        {
                            Printer("Unknown command", 1, (ConsoleColor)7);
                        }
                    }

                case 2: // battle
                    if (entered)
                    {
                        Console.WriteLine("You have stumbled upon an unfriendly " + World.Grid[y, x].dificulty + " looking creature...");
                        entered = false;
                    }
                    Printer("It's preparing to attack(" + ")!", 1, (ConsoleColor)7);
                    if (escapability)
                    {
                        Printer("Choose next action (a/attack(20), b/block(15), e/escape(40)): ", 0, (ConsoleColor)7);
                    }
                    else
                    {
                        Printer("Choose next action (a/attack(20), b/block(15)): ", 0, (ConsoleColor)7);
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
                            Printer("Unknown command", 1, (ConsoleColor)7);
                        }
                    }
                default:
                    input = Convert.ToChar(Console.ReadLine());
                    return input;
            }
        }
        void Spaces(int indent)
        {
            for (int j = 0; j < World.width - (World.horizontal * 2) - (indent + 4); j++)
            {
                Console.Write(" ");
            }
        }
        void Printer(string output, int enter, ConsoleColor color)
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
                        Spaces(indent);
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("AP: " + Player.AP + "/" + Player.MAP);
                        Console.ResetColor();
                        indent = ("AP: " + Player.AP + "/" + Player.MAP).Length;
                        Spaces(indent);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Gold: " + Player.gold);
                        Console.ResetColor();
                        indent = ("Gold: " + Player.gold).Length;
                        Spaces(indent);
                        break;
                    case World.vertical - 1:
                        if (State == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("It's HP: " + Convert.ToString(World.Grid[Player.Y, Player.X].ehp) + "/" + Convert.ToString(World.Grid[Player.Y, Player.X].emhp));
                            Console.ResetColor();
                            indent = ("It's HP: " + Convert.ToString(World.Grid[Player.Y, Player.X].ehp) + "/" + Convert.ToString(World.Grid[Player.Y, Player.X].emhp)).Length;
                            Spaces(indent);
                        }
                        else
                        {
                            Spaces(0);
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
