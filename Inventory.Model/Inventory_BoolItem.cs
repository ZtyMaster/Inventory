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
    
    public partial class Inventory_BoolItem
    {
        public Inventory_BoolItem()
        {
            this.Inventory_Transaction = new HashSet<Inventory_Transaction>();
        }
    
        public long ID { get; set; }
        public string str { get; set; }
        public Nullable<bool> BOLL_ { get; set; }
        public Nullable<int> @int { get; set; }
        public Nullable<System.DateTime> timener { get; set; }
        public Nullable<int> ItemsID { get; set; }
    
        public virtual ICollection<Inventory_Transaction> Inventory_Transaction { get; set; }
    }
}
