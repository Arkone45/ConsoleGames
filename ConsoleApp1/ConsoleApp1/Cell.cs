using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum CellStates
    {
        Beginning,
        Event,
        Enemy,
        Shop,
        Boss = -1,
        Clear
    }
    public class Cell
    {
        public CellStates name;
        public int its_state = 0;
        public int emhp = 0;
        public int ehp = 0;
        public string color = "";
        public string dificulty = "";
        public int reward = 0;
        public int side = 0;
        public List <string> asortment = new List<string>();
        public Cell CellIdentifier(int type)
        {
            switch (type)
            {
                case 2:
                    return new EnemyCell();
                case 0:
                    return new ShopCell();
                case 1:
                    return new EventCell();
                case 3:
                    return new BeginningCell();
                case 4:
                    return new BossCell();
                default:
                    return new Cell();
            }
        }
        public object Sname(int f)
        {
            object[] aray = new object[2];
            switch (name)
            {
                case CellStates.Enemy:
                    if (emhp >= 130)
                    {
                        return (f == 0) ? (object)Convert.ToString(name)[0] : ConsoleColor.Red;
                    }
                    else if (emhp >= 100)
                    {
                        return (f == 0) ? (object)Convert.ToString(name)[0] : ConsoleColor.Gray;
                    }
                    else
                    {
                        return (f == 0) ? (object)char.ToLower(Convert.ToString(name)[0]) : ConsoleColor.Gray;
                    }
                case CellStates.Event:
                    return (f == 0) ? (object)Convert.ToString(name)[1] : ConsoleColor.Gray;
                case CellStates.Shop:
                    return (f == 0) ? (object)'$' : ConsoleColor.Gray;
                case CellStates.Clear:
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
                case CellStates.Boss:
                    return (f == 0) ? (object)Convert.ToString(name)[0] : ConsoleColor.Black;
                default:
                    return (f == 0) ? (object)'\uFB13' : ConsoleColor.Blue;
            }
        }
    }
}
