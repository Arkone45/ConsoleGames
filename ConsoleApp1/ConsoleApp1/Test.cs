using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Test
    {
        public static void Test1()
        {
            List<int> C = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                C.Add(i);
            }
            C.Remove(4);
            for (int i = 0; i < C.Count; i++)
            {
                Console.WriteLine(C[i]);
            }
        }

    }
}
