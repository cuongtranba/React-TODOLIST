namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.CandidateResume")]
    public partial class CandidateResume
    {
        public int CandidateResumeId { get; set; }

        public int CandidateId { get; set; }

        [Required]
        public byte[] FileContent { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastUpdatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
