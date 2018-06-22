 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.IDAL
{
	public partial interface IDBSession
    {

	
		IInventory_ActionInfoDal Inventory_ActionInfoDal{get;set;}
	
		IInventory_BoolItemDal Inventory_BoolItemDal{get;set;}
	
		IInventory_BumenInfoSetDal Inventory_BumenInfoSetDal{get;set;}
	
		IInventory_ChangKuDal Inventory_ChangKuDal{get;set;}
	
		IInventory_CompanyDal Inventory_CompanyDal{get;set;}
	
		IInventory_DepartmentDal Inventory_DepartmentDal{get;set;}
	
		IInventory_DepotDal Inventory_DepotDal{get;set;}
	
		IInventory_DepotItemsDal Inventory_DepotItemsDal{get;set;}
	
		IInventory_GongYingShangDal Inventory_GongYingShangDal{get;set;}
	
		IInventory_Login_listDal Inventory_Login_listDal{get;set;}
	
		IInventory_PositionDal Inventory_PositionDal{get;set;}
	
		IInventory_R_UserInfo_ActionInfoDal Inventory_R_UserInfo_ActionInfoDal{get;set;}
	
		IInventory_RoleInfoDal Inventory_RoleInfoDal{get;set;}
	
		IInventory_TransactionDal Inventory_TransactionDal{get;set;}
	
		IInventory_UserbakDal Inventory_UserbakDal{get;set;}
	
		IInventory_UserInfoDal Inventory_UserInfoDal{get;set;}
	}	
}