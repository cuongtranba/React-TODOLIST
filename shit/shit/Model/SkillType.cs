namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.SkillType")]
    public partial class SkillType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SkillType()
        {
            CandidateSkills = new HashSet<CandidateSkill>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte SkillTypeId { get; set; }

        [Required]
        [StringLength(64)]
        public string Label { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateSkill> CandidateSkills { get; set; }
    }
}
