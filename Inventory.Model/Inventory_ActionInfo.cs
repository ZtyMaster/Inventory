//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory_ActionInfo
    {
        public Inventory_ActionInfo()
        {
            this.Inventory_R_UserInfo_ActionInfo = new HashSet<Inventory_R_UserInfo_ActionInfo>();
            this.Inventory_Department = new HashSet<Inventory_Department>();
            this.Inventory_RoleInfo = new HashSet<Inventory_RoleInfo>();
        }
    
        public int ID { get; set; }
        public System.DateTime SubTime { get; set; }
        public short DelFlag { get; set; }
        public string ModifiedOn { get; set; }
        public string Remark { get; set; }
        public string Url { get; set; }
        public string HttpMethod { get; set; }
        public string ActionMethodName { get; set; }
        public string ControllerName { get; set; }
        public string ActionInfoName { get; set; }
        public string Sort { get; set; }
        public short ActionTypeEnum { get; set; }
        public string MenuIcon { get; set; }
        public int IconWidth { get; set; }
        public int IconHeight { get; set; }
    
        public virtual ICollection<Inventory_R_UserInfo_ActionInfo> Inventory_R_UserInfo_ActionInfo { get; set; }
        public virtual ICollection<Inventory_Department> Inventory_Department { get; set; }
        public virtual ICollection<Inventory_RoleInfo> Inventory_RoleInfo { get; set; }
    }
}
