namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.CandidateMobility")]
    public partial class CandidateMobility
    {
        public int CandidateMobilityId { get; set; }

        public int CandidateId { get; set; }

        [Required]
        [StringLength(255)]
        public string Label { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
