﻿using Inventory.Model;
using Inventory.Model.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.WebApp.Controllers
{
    public class ActionInfoController : BaseController
    {
        //
        // GET: /ActionInfo/
        IBLL.IInventory_ActionInfoService ActionInfoService  { get; set; }
        IBLL.IInventory_RoleInfoService RoleInfoService { get; set; }


        public ActionResult Index()
        {
            return View();
        }
        #region 获取权限信息
        public ActionResult GetActionInfo()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            short delFlag = (short)DelFlagEnum.Normarl;
           var actioninfolist= ActionInfoService.LoadPageEntities<string>(pageIndex, pageSize, out totalCount, a => a.DelFlag == delFlag, a => a.Sort, true);
            var temp = from a in actioninfolist
                       select new
                       {
                           ID = a.ID,
                           ActionInfoName = a.ActionInfoName,
                           Sort = a.Sort,
                           Remark = a.Remark,
                           Url = a.Url,
                           HttpMethod = a.HttpMethod,
                           ActionTypeEnum = a.ActionTypeEnum,
                           SubTime = a.SubTime
                       };
            return Json(new { rows=temp,total=totalCount},JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 获取上传图片
        public ActionResult FileUpload()
        {
            HttpPostedFileBase file = Request.Files["fileIconUp"];
            if (file != null)
            {
                string filename = Path.GetFileName(file.FileName);//获取上传的文件名
                string fileExt = Path.GetExtension(filename);//获取扩展名
                if (fileExt == ".jpg"|| fileExt == ".png")
                {
                    string dir = "/MenuIcon/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    Directory.CreateDirectory(Path.GetDirectoryName(Request.MapPath(dir)));
                    string filenewName = Guid.NewGuid().ToString();
                    string fulldir = dir + filenewName + fileExt;
                    file.SaveAs(Request.MapPath(fulldir));
                    return Content("yes:" + fulldir);
                }
                else
                {
                    return Content("no:文件类型错误，文件扩展名错误！");
                }
            }
            else
            {
                return Content("no:请上传图片文件");
            }
        }
        #endregion
        #region 展示要修改的角色数据
        public ActionResult ShowEditInfo()
        {
            int id = int.Parse(Request["id"]);

            var roleInfo = ActionInfoService.LoadEntities(r => r.ID == id).FirstOrDefault();

            Inventory_ActionInfo ai = new Inventory_ActionInfo();
            ai.ActionInfoName = roleInfo.ActionInfoName;
            ai.Url = roleInfo.Url;
            ai.ID = roleInfo.ID;
            ai.HttpMethod = roleInfo.HttpMethod;
            ai.Sort = roleInfo.Sort;

            if (ai != null)
            {               
                return Content(Common.SerializerHelper.SerializeToString(new { serverData = ai, msg = "ok" }));
            }
            else
            {
                return Content(Common.SerializerHelper.SerializeToString(new { msg = "no" }));
            }
            
        }
        #endregion

        #region 完成角色修改
        public ActionResult EditRoleInfo(Inventory_ActionInfo roleInfo)
        {
            var ai = ActionInfoService.LoadEntities(x => x.ID == roleInfo.ID).FirstOrDefault();
            ai.ActionInfoName = roleInfo.ActionInfoName;
            ai.Url = roleInfo.Url;
            ai.HttpMethod = roleInfo.HttpMethod;
            ai.Sort = roleInfo.Sort;
            
            if (ActionInfoService.EditEntity(ai))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion
        #region 完成权限的添加
        public ActionResult AddActionInfo(Inventory_ActionInfo actionInfo  )
        {
            actionInfo.DelFlag = 0;
            actionInfo.ModifiedOn = DateTime.Now.ToShortTimeString();
            actionInfo.SubTime = DateTime.Now;
            actionInfo.Url = actionInfo.Url.ToLower();
            
            ActionInfoService.AddEntity(actionInfo);
            return Content("ok");

        }
        #region 为权限分配角色
        public ActionResult SetActionRole()
        {
            int id = int.Parse(Request["id"]);//要分配角色的权限编号
            
            Inventory_ActionInfo actioninfo = ActionInfoService.LoadEntities(a => a.ID == id).FirstOrDefault();
            ViewBag.ActionInfo = actioninfo;
            //获取所有角色
            short delflag = (short)DelFlagEnum.Normarl;
            var AllRoleList = RoleInfoService.LoadEntities(a => a.DelFlag == delflag).ToList();
            //获取当前权限已经有的角色信息
            var AllExtRoleIdList = (from r in actioninfo.Inventory_RoleInfo
                                    select r.ID).ToList();
            ViewBag.RoleList = AllRoleList;
            ViewBag.AllExtRoleIdList = AllExtRoleIdList;
            return View();
        }
        #endregion
        #region 完成对角色权限的分配
        public ActionResult SetActionRoleInfo()
        {
            int RoleinfoId = int.Parse(Request["actionId"]);
            List<int> list = new List<int>();
            string[] allkeys = Request.Form.AllKeys;//获取所有表单中Name属性的值
            foreach (string key in allkeys)
            {
                if (key.StartsWith("cba_"))
                {
                    string k = key.Replace("cba_", "");
                    list.Add(int.Parse(k));
                }
            }
            if (ActionInfoService.SetActionRoleInfo(RoleinfoId, list))
            {
                return Content("ok");
            }
            else {
                return Content("no");
            }

        }
        #endregion
        #endregion
        public ActionResult DelActioninfo() {
            var strId = Convert.ToInt32( Request["strId"]);
            var temp = ActionInfoService.LoadEntities(x => x.ID == strId).FirstOrDefault();
            ActionInfoService.DeleteEntity(temp);
            return Json(new { ret= "ok" }, JsonRequestBehavior.AllowGet);
        }

        //搜索框功能
        public ActionResult Find()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 20;
            int totalCount;
            var value = Request["value"];
            var name = Request["name"];
            var temp = ActionInfoService.LoadEntities(a =>a.ID > 0).DefaultIfEmpty();
            if (name == "RequestUrl"){
                List<Inventory_ActionInfo> list = new List<Inventory_ActionInfo>();
                foreach (var a in temp)
                {
                    if (a.Url.IndexOf(value)!=-1)
                    {
                        list.Add(a);
                    }else
                    {
                        continue;
                    }
                }
                var rtmp = from a in list
                           select new
                           {
                               ID = a.ID,
                               ActionInfoName = a.ActionInfoName,
                               Sort = a.Sort,
                               Remark = a.Remark,
                               Url = a.Url,
                               HttpMethod = a.HttpMethod,
                               ActionTypeEnum = a.ActionTypeEnum,
                               SubTime = a.SubTime
                           };
                totalCount = rtmp.Count();
                return Json(new { total = totalCount,rows = rtmp} , JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Inventory_ActionInfo> list = new List<Inventory_ActionInfo>();
                foreach (var a in temp)
                {
                    if (a.ActionInfoName.IndexOf(value) != -1)
                    {
                        list.Add(a);
                    }
                    else
                    {
                        continue;
                    }
                }
                var rtmp = from a in list
                           select new
                           {
                               ID = a.ID,
                               ActionInfoName = a.ActionInfoName,
                               Sort = a.Sort,
                               Remark = a.Remark,
                               Url = a.Url,
                               HttpMethod = a.HttpMethod,
                               ActionTypeEnum = a.ActionTypeEnum,
                               SubTime = a.SubTime
                           };
                totalCount = rtmp.Count();
                return Json(new { total = totalCount, rows = rtmp }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
