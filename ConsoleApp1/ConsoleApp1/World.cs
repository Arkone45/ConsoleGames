﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class World
    {
        readonly Random Random = new Random();
        public const int vertical = 8;
        public const int horizontal = 8;
        public static int width = 110;
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
                for (int j = (int)(Grid.Length * Propors[i]); j > 0 & k > 1; j--)
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
                            if (i == 0 & j == 0)
                            {
                                Grid[i, j] = new Cell(-1);
                                continue;
                            }
                            rng = Random.Next(list.Count);
                            Grid[i, j] = new Cell(list[rng]);
                            list.RemoveAt(rng);
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
            Grid[_Y, _X].name = "Clear";
            Grid[_Y, _X].its_state = -3;
            _Y = Y;
            _X = X;
            return Grid[Y, X].its_state;
        }
    }
}