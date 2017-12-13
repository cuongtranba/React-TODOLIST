namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.CandidateExperienceDetail")]
    public partial class CandidateExperienceDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CandidateExperienceDetailId { get; set; }

        public string BusinessDevelopment { get; set; }

        public string TechnicalEnvironment { get; set; }

        public string Management { get; set; }

        public string TasksPerformed { get; set; }

        public string FunctionalEnvironment { get; set; }

        public string Description { get; set; }

        public virtual CandidateExperience CandidateExperience { get; set; }
    }
}
