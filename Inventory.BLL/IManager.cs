 
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
	
	public partial class Inventory_ActionInfoService :BaseService<Inventory_ActionInfo>,IInventory_ActionInfoService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_ActionInfoDal;
        }
    }   
	
	public partial class Inventory_BoolItemService :BaseService<Inventory_BoolItem>,IInventory_BoolItemService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_BoolItemDal;
        }
    }   
	
	public partial class Inventory_BumenInfoSetService :BaseService<Inventory_BumenInfoSet>,IInventory_BumenInfoSetService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_BumenInfoSetDal;
        }
    }   
	
	public partial class Inventory_ChangKuService :BaseService<Inventory_ChangKu>,IInventory_ChangKuService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_ChangKuDal;
        }
    }   
	
	public partial class Inventory_CompanyService :BaseService<Inventory_Company>,IInventory_CompanyService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_CompanyDal;
        }
    }   
	
	public partial class Inventory_DepartmentService :BaseService<Inventory_Department>,IInventory_DepartmentService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_DepartmentDal;
        }
    }   
	
	public partial class Inventory_DepotService :BaseService<Inventory_Depot>,IInventory_DepotService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_DepotDal;
        }
    }   
	
	public partial class Inventory_DepotItemsService :BaseService<Inventory_DepotItems>,IInventory_DepotItemsService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_DepotItemsDal;
        }
    }   
	
	public partial class Inventory_GongYingShangService :BaseService<Inventory_GongYingShang>,IInventory_GongYingShangService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_GongYingShangDal;
        }
    }   
	
	public partial class Inventory_Login_listService :BaseService<Inventory_Login_list>,IInventory_Login_listService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_Login_listDal;
        }
    }   
	
	public partial class Inventory_PositionService :BaseService<Inventory_Position>,IInventory_PositionService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_PositionDal;
        }
    }   
	
	public partial class Inventory_R_UserInfo_ActionInfoService :BaseService<Inventory_R_UserInfo_ActionInfo>,IInventory_R_UserInfo_ActionInfoService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_R_UserInfo_ActionInfoDal;
        }
    }   
	
	public partial class Inventory_RoleInfoService :BaseService<Inventory_RoleInfo>,IInventory_RoleInfoService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_RoleInfoDal;
        }
    }   
	
	public partial class Inventory_TransactionService :BaseService<Inventory_Transaction>,IInventory_TransactionService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_TransactionDal;
        }
    }   
	
	public partial class Inventory_UserbakService :BaseService<Inventory_Userbak>,IInventory_UserbakService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_UserbakDal;
        }
    }   
	
	public partial class Inventory_UserInfoService :BaseService<Inventory_UserInfo>,IInventory_UserInfoService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.Inventory_UserInfoDal;
        }
    }   
	
}