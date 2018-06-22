using Inventory.Model;
using Inventory.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.WebApp.Controllers
{
    public class RoleInfoController : BaseController
    {
        //
        // GET: /RoleInfo/
        IBLL.IInventory_ActionInfoService ActionInfoService { get; set; }
        IBLL.IInventory_RoleInfoService RoleInfoService { get; set; }
        IBLL.IInventory_CompanyService CompanyService { get; set; }
        IBLL.IInventory_PositionService PositionService { get; set; }
        IBLL.IInventory_DepotService DepotService { get; set; }
        IBLL.IInventory_ChangKuService ChangKuService { get; set; }
        IBLL.IInventory_BumenInfoSetService BumenInfoSetService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 获取角色信息
        public ActionResult GetRoleInfo()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            short delFlag = (short)DelFlagEnum.Normarl;
           var roleInfoList=RoleInfoService.LoadPageEntities<int>(pageIndex,pageSize,out totalCount,r=>r.DelFlag==delFlag,r=>r.ID,true);
           var temp = from r in roleInfoList
                      select new {ID=r.ID,RoleName=r.RoleName,Sort=r.Sort,SubTime=r.SubTime,Remark=r.Remark};
           return Json(new {rows=temp,total=totalCount},JsonRequestBehavior.AllowGet);
         
        }
        #endregion

        #region 角色添加
        public ActionResult AddRoleInfo(Inventory_RoleInfo roleInfo)
        {
            roleInfo.DelFlag = 0;
            roleInfo.ModifiedOn = DateTime.Now;
            roleInfo.SubTime = DateTime.Now;
            RoleInfoService.AddEntity(roleInfo);
            return Content("ok");

        }
        #endregion

        #region 展示要修改的角色数据
        public ActionResult ShowEditInfo()
        {
            int id = int.Parse(Request["id"]);
           var roleInfo= ActionInfoService.LoadEntities(r=>r.ID==id).FirstOrDefault();
            
           ViewData.Model = roleInfo;
           return View();
        }
        #endregion

        #region 完成角色修改
        public ActionResult EditRoleInfo(Inventory_RoleInfo roleInfo)
        {
            if (RoleInfoService.EditEntity(roleInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

        #region 删除角色信息
        public ActionResult DeleteRoleInfo()
        {
            string strId = Request["strId"];
           string[]strIds= strId.Split(',');
           List<int> list = new List<int>();
           foreach (string id in strIds)
           {
               list.Add(int.Parse(id));
           }
           if (RoleInfoService.DeleteEntities(list))
           {
               return Content("ok");
           }
           else
           {
               return Content("no");
           }
        }
        #endregion


        public ActionResult GetItems() {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int imte=Request["imte"]!=null? int.Parse(Request["imte"]) : 0;
            int totalCount=int.MaxValue;
            short delFlag = (short)DelFlagEnum.Normarl;
            IQueryable<ThisItems> temp = null;
            //角色
            if (imte == 0)
            {
                var roleInfoList = RoleInfoService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, r => r.DelFlag == delFlag, r => r.ID, true);
                temp = from r in roleInfoList
                       select new ThisItems { ID = r.ID, RoleName = r.RoleName, Sort = r.Sort, SubTime = r.SubTime, Remark = r.Remark };
            }
            //职务
            else if (imte == 1) {
                var roleInfoList = PositionService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, r => r.Del == 0, r => r.ID, true);
                temp = from r in roleInfoList
                       select new ThisItems { ID = r.ID, Position = r.Name, Remark = r.Bak, Short = (int)r.Short, SubTime = DateTime.Now };
            }
            //产品类别
            else if (imte == 2)
            {
                var roleInfoList = CompanyService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, r => r.Del == 0, r => r.ID, true);
                temp = from r in roleInfoList
                       select new ThisItems { ID = r.ID, Text = r.Text, SubTime = DateTime.Now };
            }
            //部门
            else if (imte==5) {
                var roleInfoList = BumenInfoSetService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, r => r.DelFlag == 0, r => r.ID, true);
                temp = from r in roleInfoList
                       select new ThisItems { ID = r.ID, Text = r.Name,Remark=r.Renark, SubTime =r.SubTime };
            }
            return Json(new { rows = temp, total = totalCount }, JsonRequestBehavior.AllowGet);
        }

        #region 部门操作
        public ActionResult EditBumen(Inventory_BumenInfoSet Ibm) {
            Ibm.SubTime = DateTime.Now;
            Ibm.DelFlag = 0;
            Ibm.Gushu = 0;
            string ret = "ok";
            string mess = "";
            if (Ibm.ID == 0)
            {
                BumenInfoSetService.AddEntity(Ibm);
                
            }
            else if (Ibm.ID > 0) {
                if (!BumenInfoSetService.EditEntity(Ibm)) {
                    ret = "on";
                    mess = "修改失败";
                }
            }
            return Json(new { ret = ret,mess= mess }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
    public class ThisItems {
        public int ID { get; set; }
        public string RoleName { get; set; }

        public string Sort { get; set; }
        public int Short { get; set; }
        public string Remark { get; set; }
        public DateTime SubTime { get; set; }

        public string Position { get; set; }
        public string Text { get; set; }
    }
}
