using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BeginningCell : Cell
    {
        public BeginningCell()
        {
            name = CellStates.Beginning;
            its_state = (int)name;
        }
    }
}
