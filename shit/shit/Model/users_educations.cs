namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.users_educations")]
    public partial class users_educations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public byte? ghost { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        public string description { get; set; }

        [StringLength(255)]
        public string domain { get; set; }

        public int? education_family { get; set; }

        public int? education_level { get; set; }

        public int? start_month { get; set; }

        public int start_year { get; set; }

        public int? stop_month { get; set; }

        public int? stop_year { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public long? country_id { get; set; }

        public long? education_id { get; set; }

        public long user_id { get; set; }

        public virtual country1 country { get; set; }
    }
}
