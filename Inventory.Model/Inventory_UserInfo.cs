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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class Inventory_UserInfo
    {
        public Inventory_UserInfo()
        {
            this.Inventory_Login_list = new HashSet<Inventory_Login_list>();
            this.Inventory_R_UserInfo_ActionInfo = new HashSet<Inventory_R_UserInfo_ActionInfo>();
            this.Inventory_Transaction = new HashSet<Inventory_Transaction>();
            this.Inventory_Transaction1 = new HashSet<Inventory_Transaction>();
            this.Inventory_Userbak = new HashSet<Inventory_Userbak>();
            this.Inventory_Department = new HashSet<Inventory_Department>();
            this.Inventory_RoleInfo = new HashSet<Inventory_RoleInfo>();
        }
    
        public int ID { get; set; }
        public string UName { get; set; }
        public string UPwd { get; set; }
        public System.DateTime SubTime { get; set; }
        public short DelFlag { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public string Remark { get; set; }
        public string Sort { get; set; }
        public string Login_now { get; set; }
        public string PerSonName { get; set; }
        public Nullable<int> BuMenID { get; set; }
        public string UserNumber { get; set; }
        public string DingDingNumber { get; set; }
        public Nullable<int> Position_ID { get; set; }
        public Nullable<short> Sex { get; set; }
        public string Photo { get; set; }
        public string Bak { get; set; }
     
        [JsonIgnore]
        public virtual Inventory_BumenInfoSet Inventory_BumenInfoSet { get; set; }
        [JsonIgnore]
        public virtual ICollection<Inventory_Login_list> Inventory_Login_list { get; set; }
        [JsonIgnore]
        public virtual Inventory_Position Inventory_Position { get; set; }
        [JsonIgnore]
        public virtual ICollection<Inventory_R_UserInfo_ActionInfo> Inventory_R_UserInfo_ActionInfo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Inventory_Transaction> Inventory_Transaction { get; set; }
        [JsonIgnore]
        public virtual ICollection<Inventory_Transaction> Inventory_Transaction1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Inventory_Userbak> Inventory_Userbak { get; set; }
        [JsonIgnore]
        public virtual ICollection<Inventory_Department> Inventory_Department { get; set; }
        [JsonIgnore]
        public virtual ICollection<Inventory_RoleInfo> Inventory_RoleInfo { get; set; }
    }
}
