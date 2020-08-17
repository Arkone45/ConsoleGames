using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class World
    {
        static Random Random = new Random();
        Cell cell = new Cell();
        public const int vertical = 8;
        public const int horizontal = 8;
        public static int width = 111;
        public static Cell[,] Grid { get; set; } = new Cell[vertical, horizontal];
        private float[] Propors { get; set; } = new float[3] { 0.2F, 0.3F, 0.5F };
        int[] Nums { get; set; } = new int[3] { 0, 1, 2 };
        int _X = 0;
        int _Y = 0;
        int rng = 0;
        public void Mapgen(int lvl)
        {
            int k = Grid.Length;
            List<int> list = new List<int>();
            for (int i = Nums.Length - 1; i >= 0; i--)
            {
                for (int j = (int)(Grid.Length * Propors[i]) + 3; j > 0 & k > 0; j--)
                {
                    k -= 1;
                    list.Add(i);
                }
            }
            switch (lvl)
            {
                case 1:
                    for (int i = Grid.GetUpperBound(0); i >= 0; i--)
                    {
                        for (int j = Grid.GetUpperBound(1); j >= 0; j--)
                        {
                            switch (i)
                            {
                                case 0 when j == 0:
                                    Grid[i, j] = cell.CellIdentifier(0);
                                    break;
                                case 0 when j == 1:
                                    Grid[i, j] = cell.CellIdentifier(2);
                                    Grid[i, j].emhp = 88;
                                    Grid[i, j].ehp = Grid[i, j].emhp;
                                    break;
                                case 1 when j == 0:
                                    Grid[i, j] = cell.CellIdentifier(2);
                                    Grid[i, j].emhp = 88;
                                    Grid[i, j].ehp = Grid[i, j].emhp;
                                    break;
                                case vertical - 1 when j == horizontal - 1:
                                    Grid[i, j] = cell.CellIdentifier(4);
                                    break;
                                default:
                                    rng = Random.Next(list.Count);
                                    Grid[i, j] = cell.CellIdentifier(list[rng]);
                                    list.RemoveAt(rng);
                                    break;
                            }
                        }
                    }
                    break;
            }
        }
        public int NewState(int Y, int X)
        {
            if (_Y < Y)
            {
                Grid[Y, X].side += 10;
                Grid[_Y, _X].side += 1;
            }
            else
            {
                Grid[Y, X].side += 20;
                Grid[_Y, _X].side += 2;
            }
            Grid[_Y, _X].name = CellStates.Clear;
            Grid[_Y, _X].its_state = (int)CellStates.Clear;
            _Y = Y;
            _X = X;
            return Grid[Y, X].its_state;
        }
    }
}
