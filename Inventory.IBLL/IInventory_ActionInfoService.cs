using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.IBLL
{
   public partial  interface IInventory_ActionInfoService : IBaseService<Inventory_ActionInfo>
    {
        bool SetActionRoleInfo(int actionId, List<int> roleIdList);
    }
}
