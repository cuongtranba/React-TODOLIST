namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.CandidateExperience")]
    public partial class CandidateExperience
    {
        public int CandidateExperienceId { get; set; }

        public int CandidateId { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public int? CompanyId { get; set; }

        public int? TownId { get; set; }

        public int? CountryId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public int? BusinessLineId { get; set; }

        public virtual BusinessLine BusinessLine { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual CompanyExperience CompanyExperience { get; set; }

        public virtual Country Country { get; set; }

        public virtual Town Town { get; set; }

        public virtual CandidateExperienceDetail CandidateExperienceDetail { get; set; }
    }
}
