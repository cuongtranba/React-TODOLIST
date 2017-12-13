namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.users_positions")]
    public partial class users_positions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(255)]
        public string business_line { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        public string description { get; set; }

        [StringLength(255)]
        public string position_title { get; set; }

        public int? start_month { get; set; }

        public int start_year { get; set; }

        public int? stop_month { get; set; }

        public int? stop_year { get; set; }

        public long? company_id { get; set; }

        public long? country_id { get; set; }

        public long? town_id { get; set; }

        public long user_id { get; set; }
    }
}
