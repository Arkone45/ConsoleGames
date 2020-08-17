using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum States
    {
        Traveling,
        Diologue,
        Battle,
        Trading
    }
    class Player
    {
        public static States CurState = 0;
        public static int HP = 100;
        public static int MHP = 100;
        public static int AP = 50;
        public static int MAP = 50;
        public static int gold = 0;

        public static int X { get; set; }
        public static int Y { get; set; }
    }
}