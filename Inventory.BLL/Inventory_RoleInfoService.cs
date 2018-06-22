using Inventory.IBLL;
using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.BLL
{
   public partial class Inventory_RoleInfoService : BaseService<Inventory_RoleInfo>, IInventory_RoleInfoService
    {
       /// <summary>
       /// 删除角色
       /// </summary>
       /// <param name="RoleIdList"></param>
       /// <returns></returns>

        public bool DeleteEntities(List<int> RoleIdList)
        {
            var roleInfoList = this.GetCurrentDbSession.Inventory_RoleInfoDal.LoadEntities(r=>RoleIdList.Contains(r.ID));
            foreach (var roleInfo in roleInfoList)
            {
                //roleInfo.UserInfo.Clear();
                //roleInfo.ActionInfo.Clear();
                this.GetCurrentDbSession.Inventory_RoleInfoDal.DeleteEntity(roleInfo);
            }
           return this.GetCurrentDbSession.SaveChanges();
        }
    }
}
