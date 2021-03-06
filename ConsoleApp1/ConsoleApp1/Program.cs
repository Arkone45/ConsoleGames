﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            World my_world = new World();
            Actions Actions = new Actions();
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetBufferSize(111, 30);
            int lvl = 1;
            my_world.Mapgen(lvl);
            Actions.HUD((int)Player.CurState);
            while (lvl > 0)
            {
                bool got_out = false;
                Player.AP += 12;
                if (Player.AP > Player.MAP)
                {
                    Player.AP = Player.MAP;
                }
                switch (Actions.Inputer((int)Player.CurState, Player.Y, Player.X))
                {
                    case 'd':
                        Player.Y += 1;
                        if (Player.Y > World.horizontal - 1)
                        {
                            Player.Y = World.horizontal - 1;
                            Console.Beep();
                        }
                        break;
                    case 'r':
                        Player.X += 1;
                        if (Player.X > World.horizontal - 1)
                        {
                            Player.X = World.horizontal - 1;
                            Console.Beep();
                        }
                        break;
                    case 'a':
                        Player.AP -= 20;
                        if (Player.AP <= 0)
                        {
                            Player.AP += 20;
                            Console.Beep();
                        }
                        World.Grid[Player.Y, Player.X].ehp -= 100;
                        break;
                    case 'b':
                        Player.AP -= 15;
                        if (Player.AP <= 0)
                        {
                            Player.AP += 15;
                            Console.Beep();
                        }
                        break;
                    case 'e':
                        Actions.escapability = false;
                        if (random.Next(1, 101) <= 30)
                        {
                            Player.CurState = States.Traveling;
                            Actions.entered = true;
                            got_out = true;
                        }
                        break;
                    case 'l':
                        Player.CurState = States.Traveling;
                        got_out = true;
                        break;
                    case '1':
                        World.Grid[Player.Y, Player.X].asortment.RemoveAt(0);
                        World.Grid[Player.Y, Player.X].asortment.Reverse();
                        World.Grid[Player.Y, Player.X].asortment.Add("Sold out");
                        World.Grid[Player.Y, Player.X].asortment.Reverse();
                        break;
                    case '2':
                        World.Grid[Player.Y, Player.X].asortment.RemoveAt(1);
                        World.Grid[Player.Y, Player.X].asortment.Reverse();
                        World.Grid[Player.Y, Player.X].asortment.Add("Sold out");
                        World.Grid[Player.Y, Player.X].asortment.Reverse();
                        break;
                    case '3':
                        World.Grid[Player.Y, Player.X].asortment.RemoveAt(2);
                        World.Grid[Player.Y, Player.X].asortment.Reverse();
                        World.Grid[Player.Y, Player.X].asortment.Add("Sold out");
                        World.Grid[Player.Y, Player.X].asortment.Reverse();
                        break;
                }
                if (Player.CurState == States.Traveling & !got_out) 
                {
                    Player.CurState = (States)my_world.NewState(Player.Y, Player.X);
                    Player.AP = Player.MAP;
                    Actions.escapability = true;
                }
                if (World.Grid[Player.Y, Player.X].ehp <= 0 & Player.CurState == States.Battle)
                {
                    Player.CurState = States.Traveling;
                    Actions.entered = true;
                    Player.gold += random.Next(10, 26);
                }
                Actions.HUD((int)Player.CurState);
            }
        }
    }
}