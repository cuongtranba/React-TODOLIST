namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.CandidateEducation")]
    public partial class CandidateEducation
    {
        public int CandidateEducationId { get; set; }

        public int CandidateId { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public int? DomainId { get; set; }

        public int? CountryId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual Country Country { get; set; }

        public virtual Domain Domain { get; set; }
    }
}
