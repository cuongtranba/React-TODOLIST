namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.user_contacts")]
    public partial class user_contacts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public byte? ghost { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? date { get; set; }

        public int referer { get; set; }

        public int typology { get; set; }

        public long? firstUser_id { get; set; }

        public long? secondUser_id { get; set; }
    }
}
