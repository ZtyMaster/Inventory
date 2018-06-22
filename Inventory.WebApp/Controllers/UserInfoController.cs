using Inventory.Model;
using Inventory.Model.Enum;
using Inventory.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.WebApp.Controllers
{
    public class UserInfoController :BaseController //Controller
    {
        //
        // GET: /UserInfo/
        IBLL.IInventory_UserInfoService UserInfoService {get;set;}
        IBLL.IInventory_RoleInfoService RoleInfoService { get; set; }
        IBLL.IInventory_ActionInfoService ActionInfoService { get; set; }
        IBLL.IInventory_BumenInfoSetService BumenInfoSetService { get; set; }
        IBLL.IInventory_PositionService PositionService { get; set; }
       // short Delflag = (short)DelFlagEnum.Normarl;
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult GetJson()
        {
            //var City = T_CityService.LoadEntities(x => x.DelFlag == Delflag).DefaultIfEmpty();
            //var temp = from u in City
            //           select new
            //           {
            //               ID = u.ID,
            //               city = u.City                                                  
            //           };
            return Json(new {  }, JsonRequestBehavior.AllowGet);
        }
        #region 企业用户账号管理
        public ActionResult Zhgl()
        {
           return View();
        }
       
        #endregion

        #region 获取用户数据
        public ActionResult GetUserInfo()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            string name = Request["name"];
            string remark = Request["remark"];
            string zhgl = Request["zhgl"] != null ? Request["zhgl"] : string.Empty;
            //构建搜索条件
            int totalCount=0;
            UserInfoParam userInfoParam = new UserInfoParam() {               
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount,
                UserName = name,
                Remark = remark,
                BumenID=LoginUser.BuMenID
                
                //IsMaster = true,
                //C_id = zhgl != null ? zhgl != string.Empty ? LoginUser.ID : 0 : 0
            };                     
            var userInfoList = UserInfoService.LoadSearchEntities(userInfoParam);
           var temp = from u in userInfoList
                      select new {
                          ID = u.ID,
                          UserName = u.UName,
                          UserPass = u.UPwd,
                          Remark = u.Remark,
                          RegTime = u.SubTime,                         
                          PerSonName=u.PerSonName,
                          BuMenID = u.BuMenID,
                          BuMen=u.Inventory_BumenInfoSet.Name,
                          UPwd =u.UPwd,
                          BumenName=u.Inventory_BumenInfoSet.Name,
                          UserNumber=u.UserNumber,
                          DingDingNumber=u.DingDingNumber,
                          Position_ID= u.Position_ID,
                          Position=u.Inventory_Position.Name,
                          Sex=u.Sex,
                          SexStr=u.Sex==0?"男":u.Sex==1?"女":"未知",
                          Photo=u.Photo,
                          Bak=u.Bak
                      };
           return Json(new { rows = temp, total = userInfoParam.TotalCount }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除用户数据
        public ActionResult DeleteUserInfo()
        {
            string strId=Request["strId"];
           string[]strIds=strId.Split(',');
           List<int> list = new List<int>();
           foreach (string id in strIds)
           {
               list.Add(int.Parse(id));
           }
           if (UserInfoService.DeleteEntities(list))
           {
               return Content("ok");
           }
           else
           {
               return Content("no");
           }
              
        }
        #endregion

        #region 添加用户信息
        public ActionResult AddUserInfo(Inventory_UserInfo userInfo)
        {
            //检查用户是否重复
            
            userInfo.DelFlag = 0;
            userInfo.ModifiedOn = DateTime.Now;
            userInfo.SubTime = DateTime.Now;
            userInfo.UPwd = Model.Enum.AddMD5.GaddMD5(userInfo.UPwd);
            UserInfoService.AddEntity(userInfo);
            var ucinfo = UserInfoService.LoadEntities(x => x.UName == userInfo.UName).FirstOrDefault();
            //UserInfo_City uc = new UserInfo_City();
            //uc.UserInfo_ID = ucinfo.ID;
            //uc.T_City_ID = (Int32)userInfo.CityID;
            //UserInfo_CityService.AddEntity(uc);
            return Json(new { ret = "ok" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 查询要修改的数据
        public ActionResult GetUserInfoModel()
        {
            int id = int.Parse(Request["id"]);
            Inventory_UserInfo userInfo =UserInfoService.LoadEntities(u=>u.ID==id).FirstOrDefault();
            
           if (userInfo != null)
           {
              // return Json(new{serverData=userInfo,msg="ok"}, JsonRequestBehavior.AllowGet);
               return Content(Common.SerializerHelper.SerializeToString(new { serverData = userInfo, msg = "ok" }));
           }
           else
           {
               return Content(Common.SerializerHelper.SerializeToString(new { msg = "no" }));
           }
        }
        #endregion

        #region 完成用户信息的修改
        public ActionResult EditUserInfo(Inventory_UserInfo userInfo)
        {

            userInfo.ModifiedOn = DateTime.Now;                    
            if (UserInfoService.EditEntity(userInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        
        #endregion

        #region 为用户分配角色
        public ActionResult SetUserRoleInfo()
        {
            int userId = int.Parse(Request["userId"]);
            Inventory_UserInfo userInfo =UserInfoService.LoadEntities(u=>u.ID==userId).FirstOrDefault();
           ViewBag.UserInfo = userInfo;
            //查询所有的角色信息
           short delFlag = (short)DelFlagEnum.Normarl;
           var roleInfoList = RoleInfoService.LoadEntities(r=>r.DelFlag==delFlag).ToList();
            //找出用户已经有的角色的编号
           var userRoleIdList = (from r in userInfo.Inventory_RoleInfo
                                 select r.ID).ToList();
           ViewBag.AllRoleInfo = roleInfoList;
           ViewBag.AllExtRoleId = userRoleIdList;
           return View();
        }
        #endregion
        /// <summary>
        /// 完成对用户角色的分配
        /// </summary>
        /// <returns></returns>
        public ActionResult SetuserRole()
        {
            int userid = int.Parse(Request["userId"]);
            //接受表单中所用的KEY  所用表单NAME属性的值
            //Request.Form[]接受NAME的值

            string[] allkeys= Request.Form.AllKeys;
            List<int> list = new List<int>();
            //只要前缀只包含CBA_
            foreach (string key in allkeys)
            {
                if (key.StartsWith("cba_"))
                {
                    string K = key.Replace("cba_","");
                    list.Add(int.Parse(K));
                }
            }
            if (UserInfoService.setuserorderidnfo(userid, list))
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }
        }
        #region 为特殊用户分配权限

        public ActionResult SetUserAction() {
            int userid = int.Parse(Request["UserId"]);
            //查询要分配权限的用户信息
            var userinfo = UserInfoService.LoadEntities(u => u.ID == userid).FirstOrDefault();
            //获取所有权限信息
            short delflag = (short)DelFlagEnum.Normarl;
            var allActionList = ActionInfoService.LoadEntities(a => a.DelFlag == delflag).ToList();
            //获取用户已有权限
            var allUserActionIDlist = userinfo.Inventory_R_UserInfo_ActionInfo.ToList();

            ViewBag.userinfo = userinfo;
            ViewBag.allActionList = allActionList;
            ViewBag.allUserActionIDlist = allUserActionIDlist;
            return View();
        }
        #endregion
        #region //异步处理特殊权限信息
        public ActionResult SetActionUser()
        {
            int userId = int.Parse(Request["userId"]);
            int actionId = int.Parse(Request["actionId"]);
            bool ispass = Request["value"] == "true" ? true:false;
            if (UserInfoService.SetUserActionInfo(userId, actionId, ispass))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion
        #region 清除用户特殊权限信息
        public ActionResult deleteActionUser()
        {
            int userID = int.Parse(Request["userId"]);
            int actionID = int.Parse(Request["action"]);
            if (UserInfoService.DelUserinfo_actioninfo(userID, actionID))
            {
                return Content("ok:"+ actionID);
            }
            else
            {
                return Content("no");
            }
        }
        #endregion


        //获取部门信息
        public ActionResult GetBuMen() {

            var sbm = BumenInfoSetService.LoadEntities(x => x.DelFlag == 0 && x.Gushu < 99).DefaultIfEmpty();
            var temp = from a in sbm
                       select new
                       {
                           ID = a.ID,
                           MyTexts = a.Name
                       };
            return Json(temp, JsonRequestBehavior.AllowGet);
        }
        //获取职位信息
        public ActionResult GetPosition() {
            var sbm = PositionService.LoadEntities(x => x.Del == 0 ).DefaultIfEmpty();
            var temp = from a in sbm
                       select new
                       {
                           ID = a.ID,
                           MyTexts = a.Name
                       };
            return Json(temp, JsonRequestBehavior.AllowGet);
        }
    }
}
