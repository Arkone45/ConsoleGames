using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Cell
    {
        static readonly Random Random = new Random();
        public string name = "";
        public int its_state = 0;
        public int emhp = 0;
        public int ehp = 0;
        public string color = "";
        public string dificulty = "";
        public int reward = 0;
        public int side = 0;
        public Cell(int type)
        {
            switch (type)
            {
                case 2:
                    name = "Enemy";
                    its_state = 2; // battle
                    emhp = Random.Next(40, 151);
                    ehp = emhp;
                    if (emhp >= 130)
                    {
                        dificulty = "and powerful";
                    }
                    else if (emhp >= 100)
                    {
                        dificulty = "";
                    }
                    else
                    {
                        dificulty = "and weak";
                    }
                    break;
                case 1:
                    name = "Shop";
                    its_state = 1; // trading
                    break;
                case 0:
                    name = "Event";
                    its_state = 0; //diologue
                    break;
                case -2:
                    name = "Beginning";
                    break;
            }
        }
        public object Sname(int f)
        {
            object[] aray = new object[2];
            switch (name)
            {
                case "Enemy":
                    if (emhp >= 130)
                    {
                        return (f == 0) ? (object)name[0] : ConsoleColor.Red;
                    }
                    else if (emhp >= 100)
                    {
                        return (f == 0) ? (object)name[0] : ConsoleColor.Gray;
                    }
                    else
                    {
                        return (f == 0) ? (object)char.ToLower(name[0]) : ConsoleColor.Gray;
                    }
                case "Event":
                    return (f == 0) ? (object)name[1] : ConsoleColor.Gray;
                case "Shop":
                    return (f == 0) ? (object)'$' : ConsoleColor.Gray;
                case "Clear":
                    switch (side)
                    {
                        case 11:
                            return (f == 0) ? (object)'\u2502' : ConsoleColor.Blue;
                        case 12:
                            return (f == 0) ? (object)'\u2570' : ConsoleColor.Blue;
                        case 21:
                            return (f == 0) ? (object)'\u256E' : ConsoleColor.Blue;
                        case 22:
                            return (f == 0) ? (object)'\u2500' : ConsoleColor.Blue;
                        default:
                            return (f == 0) ? (object)'\uFB13' : ConsoleColor.Blue;
                    }
                default:
                    return (f == 0) ? (object)'\uFB13' : ConsoleColor.Blue;
            }
        }
    }
}
