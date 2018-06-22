using Inventory.IBLL;
using Inventory.Model;
using Inventory.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.BLL
{
   public partial class Inventory_UserInfoService : BaseService<Inventory_UserInfo>, IInventory_UserInfoService
    {



       /// <summary>
       /// 批量删除
       /// </summary>
       /// <param name="list">要删除的记录的编号</param>
       /// <returns></returns>
        public bool DeleteEntities(List<int> list)
        {
           
            var userInfoList = this.GetCurrentDbSession.Inventory_UserInfoDal.LoadEntities(c=>list.Contains(c.ID));
            foreach (var userInfo in userInfoList)
            {
                this.GetCurrentDbSession.Inventory_UserInfoDal.DeleteEntity(userInfo);
            }

            return this.GetCurrentDbSession.SaveChanges();
        }
        /// <summary>
        /// 删除特殊用户权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="actionID"></param>
        /// <returns></returns>
        public bool DelUserinfo_actioninfo(int userID, int actionID)
        {
            var R_userinfo_actioninfo = this.GetCurrentDbSession.Inventory_R_UserInfo_ActionInfoDal.LoadEntities(a => a.UserInfoID == userID && a.ActionInfoID == actionID).FirstOrDefault();
            if (R_userinfo_actioninfo != null)
            {
                this.GetCurrentDbSession.Inventory_R_UserInfo_ActionInfoDal.DeleteEntity(R_userinfo_actioninfo);
                return this.GetCurrentDbSession.SaveChanges();
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 多条件搜索用户信息
        /// </summary>
        /// <param name="userInfoSearchParam"></param>
        /// <returns></returns>
        public IQueryable<Inventory_UserInfo> LoadSearchEntities(Model.SearchParam.UserInfoParam userInfoSearchParam)
        {

            short delFlag=(short)DelFlagEnum.Normarl;
            var temp = this.GetCurrentDbSession.Inventory_UserInfoDal.LoadEntities(c => c.DelFlag == delFlag);
            if (userInfoSearchParam.QuXian != null)
            {
                if (userInfoSearchParam.QuXian != 999)
                {
                    temp = this.GetCurrentDbSession.Inventory_UserInfoDal.LoadEntities(c => c.DelFlag == delFlag && c.BuMenID == userInfoSearchParam.BumenID);
                }
            }
            else
            { }
         
            if (!string.IsNullOrEmpty(userInfoSearchParam.UserName))
            {
                temp = temp.Where<Inventory_UserInfo>(u=>u.UName.Contains(userInfoSearchParam.UserName));
            }
            if (!string.IsNullOrEmpty(userInfoSearchParam.Remark))
            {
                temp = temp.Where<Inventory_UserInfo>(u=>u.Remark.Contains(userInfoSearchParam.Remark));
            }
            if (!string.IsNullOrEmpty(userInfoSearchParam.Remark))
            {
                temp = temp.Where<Inventory_UserInfo>(u => u.Remark.Contains(userInfoSearchParam.Remark));
            }
            userInfoSearchParam.TotalCount = temp.Count();
            return temp.OrderBy<Inventory_UserInfo, string>(u => u.Sort).Skip<Inventory_UserInfo>((userInfoSearchParam.PageIndex - 1) * userInfoSearchParam.PageSize).Take<Inventory_UserInfo>(userInfoSearchParam.PageSize);

        }
        /// <summary>
        /// 完成对特殊用户权限的分配
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="actionId"></param>
        /// <param name="ispass"></param>
        /// <returns></returns>
        public bool SetUserActionInfo(int userId, int actionId, bool ispass)
        {
            var R_userinfo_actioninfo = this.GetCurrentDbSession.Inventory_R_UserInfo_ActionInfoDal.LoadEntities(a => a.ID == userId && a.ActionInfoID == actionId).FirstOrDefault();
            if (R_userinfo_actioninfo == null)
            {
                Inventory_R_UserInfo_ActionInfo rua = new Inventory_R_UserInfo_ActionInfo();
                rua.ActionInfoID = actionId;
                rua.UserInfoID = userId;
                rua.IsPass = ispass;
                this.GetCurrentDbSession.Inventory_R_UserInfo_ActionInfoDal.AddEntity(rua);
            }
            else
            {
                R_userinfo_actioninfo.IsPass = ispass;
            }
            return this.GetCurrentDbSession.SaveChanges();
        }

        /// <summary>
        /// 为用户分配角色
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool setuserorderidnfo(int userid, List<int> list)
        {
            var userinfo = this.GetCurrentDbSession.Inventory_UserInfoDal.LoadEntities(u
                => u.ID == userid).FirstOrDefault();//获取用户
            if (userinfo != null)
            {
                //删除用户角色
                userinfo.Inventory_RoleInfo.Clear();

                foreach (int roleid in list)
                {
                    var roleinfo = this.GetCurrentDbSession.Inventory_RoleInfoDal.LoadEntities(r => r.ID == roleid).FirstOrDefault();
                    userinfo.Inventory_RoleInfo.Add(roleinfo);//通过导航属性RoleInfo 进行修改
                }
                return this.GetCurrentDbSession.SaveChanges();//最后执行savechanges
            }
            else
            {
                return false;
            }
        }
    }
   
}
