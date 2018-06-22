 

using Inventory.DAL;
using Inventory.IDAL;
using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DALFactory
{
	public partial class DBSession : IDBSession
    {
	
		private IInventory_ActionInfoDal _Inventory_ActionInfoDal;
        public IInventory_ActionInfoDal Inventory_ActionInfoDal
        {
            get
            {
                if(_Inventory_ActionInfoDal == null)
                {
                   // _Inventory_ActionInfoDal = new Inventory_ActionInfoDal();
				    _Inventory_ActionInfoDal =AbstractFactory.CreateInventory_ActionInfoDal();
                }
                return _Inventory_ActionInfoDal;
            }
            set { _Inventory_ActionInfoDal = value; }
        }
	
		private IInventory_BoolItemDal _Inventory_BoolItemDal;
        public IInventory_BoolItemDal Inventory_BoolItemDal
        {
            get
            {
                if(_Inventory_BoolItemDal == null)
                {
                   // _Inventory_BoolItemDal = new Inventory_BoolItemDal();
				    _Inventory_BoolItemDal =AbstractFactory.CreateInventory_BoolItemDal();
                }
                return _Inventory_BoolItemDal;
            }
            set { _Inventory_BoolItemDal = value; }
        }
	
		private IInventory_BumenInfoSetDal _Inventory_BumenInfoSetDal;
        public IInventory_BumenInfoSetDal Inventory_BumenInfoSetDal
        {
            get
            {
                if(_Inventory_BumenInfoSetDal == null)
                {
                   // _Inventory_BumenInfoSetDal = new Inventory_BumenInfoSetDal();
				    _Inventory_BumenInfoSetDal =AbstractFactory.CreateInventory_BumenInfoSetDal();
                }
                return _Inventory_BumenInfoSetDal;
            }
            set { _Inventory_BumenInfoSetDal = value; }
        }
	
		private IInventory_ChangKuDal _Inventory_ChangKuDal;
        public IInventory_ChangKuDal Inventory_ChangKuDal
        {
            get
            {
                if(_Inventory_ChangKuDal == null)
                {
                   // _Inventory_ChangKuDal = new Inventory_ChangKuDal();
				    _Inventory_ChangKuDal =AbstractFactory.CreateInventory_ChangKuDal();
                }
                return _Inventory_ChangKuDal;
            }
            set { _Inventory_ChangKuDal = value; }
        }
	
		private IInventory_CompanyDal _Inventory_CompanyDal;
        public IInventory_CompanyDal Inventory_CompanyDal
        {
            get
            {
                if(_Inventory_CompanyDal == null)
                {
                   // _Inventory_CompanyDal = new Inventory_CompanyDal();
				    _Inventory_CompanyDal =AbstractFactory.CreateInventory_CompanyDal();
                }
                return _Inventory_CompanyDal;
            }
            set { _Inventory_CompanyDal = value; }
        }
	
		private IInventory_DepartmentDal _Inventory_DepartmentDal;
        public IInventory_DepartmentDal Inventory_DepartmentDal
        {
            get
            {
                if(_Inventory_DepartmentDal == null)
                {
                   // _Inventory_DepartmentDal = new Inventory_DepartmentDal();
				    _Inventory_DepartmentDal =AbstractFactory.CreateInventory_DepartmentDal();
                }
                return _Inventory_DepartmentDal;
            }
            set { _Inventory_DepartmentDal = value; }
        }
	
		private IInventory_DepotDal _Inventory_DepotDal;
        public IInventory_DepotDal Inventory_DepotDal
        {
            get
            {
                if(_Inventory_DepotDal == null)
                {
                   // _Inventory_DepotDal = new Inventory_DepotDal();
				    _Inventory_DepotDal =AbstractFactory.CreateInventory_DepotDal();
                }
                return _Inventory_DepotDal;
            }
            set { _Inventory_DepotDal = value; }
        }
	
		private IInventory_DepotItemsDal _Inventory_DepotItemsDal;
        public IInventory_DepotItemsDal Inventory_DepotItemsDal
        {
            get
            {
                if(_Inventory_DepotItemsDal == null)
                {
                   // _Inventory_DepotItemsDal = new Inventory_DepotItemsDal();
				    _Inventory_DepotItemsDal =AbstractFactory.CreateInventory_DepotItemsDal();
                }
                return _Inventory_DepotItemsDal;
            }
            set { _Inventory_DepotItemsDal = value; }
        }
	
		private IInventory_GongYingShangDal _Inventory_GongYingShangDal;
        public IInventory_GongYingShangDal Inventory_GongYingShangDal
        {
            get
            {
                if(_Inventory_GongYingShangDal == null)
                {
                   // _Inventory_GongYingShangDal = new Inventory_GongYingShangDal();
				    _Inventory_GongYingShangDal =AbstractFactory.CreateInventory_GongYingShangDal();
                }
                return _Inventory_GongYingShangDal;
            }
            set { _Inventory_GongYingShangDal = value; }
        }
	
		private IInventory_Login_listDal _Inventory_Login_listDal;
        public IInventory_Login_listDal Inventory_Login_listDal
        {
            get
            {
                if(_Inventory_Login_listDal == null)
                {
                   // _Inventory_Login_listDal = new Inventory_Login_listDal();
				    _Inventory_Login_listDal =AbstractFactory.CreateInventory_Login_listDal();
                }
                return _Inventory_Login_listDal;
            }
            set { _Inventory_Login_listDal = value; }
        }
	
		private IInventory_PositionDal _Inventory_PositionDal;
        public IInventory_PositionDal Inventory_PositionDal
        {
            get
            {
                if(_Inventory_PositionDal == null)
                {
                   // _Inventory_PositionDal = new Inventory_PositionDal();
				    _Inventory_PositionDal =AbstractFactory.CreateInventory_PositionDal();
                }
                return _Inventory_PositionDal;
            }
            set { _Inventory_PositionDal = value; }
        }
	
		private IInventory_R_UserInfo_ActionInfoDal _Inventory_R_UserInfo_ActionInfoDal;
        public IInventory_R_UserInfo_ActionInfoDal Inventory_R_UserInfo_ActionInfoDal
        {
            get
            {
                if(_Inventory_R_UserInfo_ActionInfoDal == null)
                {
                   // _Inventory_R_UserInfo_ActionInfoDal = new Inventory_R_UserInfo_ActionInfoDal();
				    _Inventory_R_UserInfo_ActionInfoDal =AbstractFactory.CreateInventory_R_UserInfo_ActionInfoDal();
                }
                return _Inventory_R_UserInfo_ActionInfoDal;
            }
            set { _Inventory_R_UserInfo_ActionInfoDal = value; }
        }
	
		private IInventory_RoleInfoDal _Inventory_RoleInfoDal;
        public IInventory_RoleInfoDal Inventory_RoleInfoDal
        {
            get
            {
                if(_Inventory_RoleInfoDal == null)
                {
                   // _Inventory_RoleInfoDal = new Inventory_RoleInfoDal();
				    _Inventory_RoleInfoDal =AbstractFactory.CreateInventory_RoleInfoDal();
                }
                return _Inventory_RoleInfoDal;
            }
            set { _Inventory_RoleInfoDal = value; }
        }
	
		private IInventory_TransactionDal _Inventory_TransactionDal;
        public IInventory_TransactionDal Inventory_TransactionDal
        {
            get
            {
                if(_Inventory_TransactionDal == null)
                {
                   // _Inventory_TransactionDal = new Inventory_TransactionDal();
				    _Inventory_TransactionDal =AbstractFactory.CreateInventory_TransactionDal();
                }
                return _Inventory_TransactionDal;
            }
            set { _Inventory_TransactionDal = value; }
        }
	
		private IInventory_UserbakDal _Inventory_UserbakDal;
        public IInventory_UserbakDal Inventory_UserbakDal
        {
            get
            {
                if(_Inventory_UserbakDal == null)
                {
                   // _Inventory_UserbakDal = new Inventory_UserbakDal();
				    _Inventory_UserbakDal =AbstractFactory.CreateInventory_UserbakDal();
                }
                return _Inventory_UserbakDal;
            }
            set { _Inventory_UserbakDal = value; }
        }
	
		private IInventory_UserInfoDal _Inventory_UserInfoDal;
        public IInventory_UserInfoDal Inventory_UserInfoDal
        {
            get
            {
                if(_Inventory_UserInfoDal == null)
                {
                   // _Inventory_UserInfoDal = new Inventory_UserInfoDal();
				    _Inventory_UserInfoDal =AbstractFactory.CreateInventory_UserInfoDal();
                }
                return _Inventory_UserInfoDal;
            }
            set { _Inventory_UserInfoDal = value; }
        }
	}	
}