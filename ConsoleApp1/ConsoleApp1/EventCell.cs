using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class EventCell : Cell
    {
        public EventCell()
        {
            name = CellStates.Event;
            its_state = (int)name;
        }
    }
}
