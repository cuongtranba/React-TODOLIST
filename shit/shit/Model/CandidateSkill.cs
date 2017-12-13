namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.CandidateSkill")]
    public partial class CandidateSkill
    {
        public int CandidateSkillId { get; set; }

        public int CandidateId { get; set; }

        [Required]
        [StringLength(250)]
        public string Label { get; set; }

        [StringLength(15)]
        public string Level { get; set; }

        public byte? TypeId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public int? CategoryId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual SkillCategory SkillCategory { get; set; }

        public virtual SkillType SkillType { get; set; }
    }
}
