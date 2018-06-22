using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    public class EqualityComparer : IEqualityComparer<Inventory_ActionInfo>
    {
        public bool Equals(Inventory_ActionInfo x, Inventory_ActionInfo y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(Inventory_ActionInfo obj)
        {
            return obj.GetHashCode();
        }
    }
  
}
