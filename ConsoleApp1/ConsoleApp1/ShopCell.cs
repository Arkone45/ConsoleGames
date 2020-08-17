using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ShopCell : Cell
    {
        public ShopCell()
        {
            name = CellStates.Shop;
            its_state = (int)name;
            asortment.Add("+ATK");
            asortment.Add("full heal");
            asortment.Add("+maxHP");
            for (int i = 0; i < 3; i++)
            {
            }
        }
    }
}
