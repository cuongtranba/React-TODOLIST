namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.emails_prefs")]
    public partial class emails_prefs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public byte? ghost { get; set; }

        public int bounce { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        public byte? email_validated { get; set; }

        public string notifications { get; set; }

        [StringLength(255)]
        public string recovery_email { get; set; }

        public byte? recovery_email_validated { get; set; }

        public int softBounceCount { get; set; }

        public long? user_id { get; set; }
    }
}
