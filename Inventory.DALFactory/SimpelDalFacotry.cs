 

using Inventory.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DALFactory
{
    public partial class AbstractFactory
    {
      
   
		
	    public static IInventory_ActionInfoDal CreateInventory_ActionInfoDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_ActionInfoDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_ActionInfoDal;
        }
		
	    public static IInventory_BoolItemDal CreateInventory_BoolItemDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_BoolItemDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_BoolItemDal;
        }
		
	    public static IInventory_BumenInfoSetDal CreateInventory_BumenInfoSetDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_BumenInfoSetDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_BumenInfoSetDal;
        }
		
	    public static IInventory_ChangKuDal CreateInventory_ChangKuDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_ChangKuDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_ChangKuDal;
        }
		
	    public static IInventory_CompanyDal CreateInventory_CompanyDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_CompanyDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_CompanyDal;
        }
		
	    public static IInventory_DepartmentDal CreateInventory_DepartmentDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_DepartmentDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_DepartmentDal;
        }
		
	    public static IInventory_DepotDal CreateInventory_DepotDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_DepotDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_DepotDal;
        }
		
	    public static IInventory_DepotItemsDal CreateInventory_DepotItemsDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_DepotItemsDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_DepotItemsDal;
        }
		
	    public static IInventory_GongYingShangDal CreateInventory_GongYingShangDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_GongYingShangDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_GongYingShangDal;
        }
		
	    public static IInventory_Login_listDal CreateInventory_Login_listDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_Login_listDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_Login_listDal;
        }
		
	    public static IInventory_PositionDal CreateInventory_PositionDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_PositionDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_PositionDal;
        }
		
	    public static IInventory_R_UserInfo_ActionInfoDal CreateInventory_R_UserInfo_ActionInfoDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_R_UserInfo_ActionInfoDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_R_UserInfo_ActionInfoDal;
        }
		
	    public static IInventory_RoleInfoDal CreateInventory_RoleInfoDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_RoleInfoDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_RoleInfoDal;
        }
		
	    public static IInventory_TransactionDal CreateInventory_TransactionDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_TransactionDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_TransactionDal;
        }
		
	    public static IInventory_UserbakDal CreateInventory_UserbakDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_UserbakDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_UserbakDal;
        }
		
	    public static IInventory_UserInfoDal CreateInventory_UserInfoDal()
        {

            string classFulleName = ConfigurationManager.AppSettings["NameSpace"] + ".Inventory_UserInfoDal";


            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DalAssembly"]).CreateInstance(classFulleName, true);
            var obj  = CreateInstance(ConfigurationManager.AppSettings["DalAssemblyPath"], classFulleName);


            return obj as IInventory_UserInfoDal;
        }
	}
	
}