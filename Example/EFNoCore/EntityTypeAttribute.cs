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
    
    public partial class EntityTypeAttribute
    {
        public int EntityTypeAttributeId { get; set; }
        public int CreatedByUserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int UpdatedByUserId { get; set; }
        public int AttributeId { get; set; }
        public int EntityTypeId { get; set; }
    
        public virtual Attribute Attribute { get; set; }
        public virtual EntityType EntityType { get; set; }
    }
}
