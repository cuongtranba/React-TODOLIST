//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFNoCore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Warehouse
    {
        public int WarehouseId { get; set; }
        public int CreatedByUserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int UpdatedByUserId { get; set; }
    }
}