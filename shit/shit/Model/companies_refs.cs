namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.companies_refs")]
    public partial class companies_refs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public byte? ghost { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        public string name { get; set; }

        [StringLength(9)]
        public string siren { get; set; }

        [StringLength(20)]
        public string size { get; set; }
    }
}
