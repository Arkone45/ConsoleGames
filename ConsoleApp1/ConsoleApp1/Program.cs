using System;
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
            Player Player1 = new Player();
            Actions Actions = new Actions();
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetBufferSize(111, 30);
            int lvl = 1;
            my_world.Mapgen(lvl);
            Actions.HUD(Player1.State);
            while (lvl > 0)
            {
                bool got_out = false;
                Player.AP += 12;
                if (Player.AP > Player.MAP)
                {
                    Player.AP = Player.MAP;
                }
                switch (Actions.Inputer(Player1.State, Player.Y, Player.X))
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
                            Player1.State = -1;
                            Actions.entered = true;
                            got_out = true;
                        }
                        break;
                    case 'l':
                        Player1.State = -1;
                        got_out = true;
                        break;
                }
                if (Player1.State == -1 & !got_out) 
                {
                    Player1.State = my_world.NewState(Player.Y, Player.X);
                    Player.AP = Player.MAP;
                    Actions.escapability = true;
                }
                if (World.Grid[Player.Y, Player.X].ehp <= 0 & Player1.State == 2)
                {
                    Player1.State = -1; //traveling
                    Actions.entered = true;
                    Player.gold += random.Next(10, 26);
                }
                Actions.HUD(Player1.State);
            }
        }
    }
}