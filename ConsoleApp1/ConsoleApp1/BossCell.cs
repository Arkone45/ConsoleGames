using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BossCell : Cell
    {
        public BossCell()
        {
            name = CellStates.Boss;
            its_state = (int)name;
        }
    }
}
