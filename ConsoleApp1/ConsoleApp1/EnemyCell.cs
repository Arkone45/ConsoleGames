using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class EnemyCell : Cell
    {
        static Random random = new Random();
        public EnemyCell()
        {
            name = CellStates.Enemy;
            its_state = (int)name;
            emhp = emhp == 0 ? random.Next(40, 151) : emhp;
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
        }
    }
}
