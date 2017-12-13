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
    
    public partial class Attribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Attribute()
        {
            this.EntityAttributes = new HashSet<EntityAttribute>();
            this.EntityTypeAttributes = new HashSet<EntityTypeAttribute>();
        }
    
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public int AttributeTypeId { get; set; }
        public int CreatedByUserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string DataSourceUrl { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRequired { get; set; }
        public int UpdatedByUserId { get; set; }
    
        public virtual AttributeType AttributeType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntityAttribute> EntityAttributes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntityTypeAttribute> EntityTypeAttributes { get; set; }
    }
}