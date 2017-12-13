namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.user_recommendations")]
    public partial class user_recommendations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        public string message { get; set; }

        public byte? pending { get; set; }

        public long? user_from_id { get; set; }

        public long? user_to_id { get; set; }

        public int? note { get; set; }
    }
}
