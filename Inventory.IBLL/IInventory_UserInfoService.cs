using Inventory.Model;
using Inventory.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.IBLL
{
   public partial interface IInventory_UserInfoService : IBaseService<Inventory_UserInfo>
    {
       bool DeleteEntities(List<int>list);
       IQueryable<Inventory_UserInfo> LoadSearchEntities(UserInfoParam userInfoSearchParam);
        bool setuserorderidnfo(int userid, List<int> list);
        bool SetUserActionInfo(int userId, int actionId, bool ispass);
        bool DelUserinfo_actioninfo(int userID, int actionID);
    }
}
