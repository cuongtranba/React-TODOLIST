namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.user_contacts_requests")]
    public partial class user_contacts_requests
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public byte? ghost { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? date { get; set; }

        public int referer { get; set; }

        public int typology { get; set; }

        public long? receiver_id { get; set; }

        public long? sender_id { get; set; }
    }
}
