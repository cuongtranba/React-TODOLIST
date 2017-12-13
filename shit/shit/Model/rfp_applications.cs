namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.rfp_applications")]
    public partial class rfp_applications
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public byte? ghost { get; set; }

        [StringLength(255)]
        public string cancel_reason { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? canceled_at { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? candidate_dispo_date { get; set; }

        public long? candidate_id { get; set; }

        public long? candidate_manager_id { get; set; }

        public long? company_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? modified_at { get; set; }

        public string motivation { get; set; }

        public string notes { get; set; }

        public double price { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? publish_after_hors_scope_date { get; set; }

        public long? rfp_id { get; set; }

        public long? spammed_by_user_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? spammed_date { get; set; }

        public int? status { get; set; }

        public byte? referenced_presta { get; set; }

        public byte? immediate_payment { get; set; }

        public double? presta_price { get; set; }

        [StringLength(255)]
        public string refusal_reason { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? refused_at { get; set; }

        public long? refused_by_user_id { get; set; }
    }
}
