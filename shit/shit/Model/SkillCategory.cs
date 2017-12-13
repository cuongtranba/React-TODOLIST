namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.SkillCategory")]
    public partial class SkillCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SkillCategory()
        {
            CandidateSkills = new HashSet<CandidateSkill>();
        }

        public int SkillCategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Label { get; set; }

        public int? DomainId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateSkill> CandidateSkills { get; set; }

        public virtual SkillDomain SkillDomain { get; set; }
    }
}
