namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.Candidate")]
    public partial class Candidate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Candidate()
        {
            BusinessUnits = new HashSet<BusinessUnit>();
            BusinessUnits1 = new HashSet<BusinessUnit>();
            CandidateEducations = new HashSet<CandidateEducation>();
            CandidateExperiences = new HashSet<CandidateExperience>();
            CandidateMobilities = new HashSet<CandidateMobility>();
            CandidateResumes = new HashSet<CandidateResume>();
            CandidateSkills = new HashSet<CandidateSkill>();
            LbcMappings = new HashSet<LbcMapping>();
        }

        public int CandidateId { get; set; }

        public byte StatusId { get; set; }

        public int HoldingId { get; set; }

        [StringLength(40)]
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public double? AdressLongitude { get; set; }

        public double? AdressLatitude { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(100)]
        public string MobilePhone { get; set; }

        public byte? GenderId { get; set; }

        public string Summary { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? AvailabilityDate { get; set; }

        public int? TownId { get; set; }

        public int? CountryId { get; set; }

        [StringLength(255)]
        public string UserLocaleCountry { get; set; }

        [StringLength(255)]
        public string UserLocaleLanguage { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public int? BusinessLineId { get; set; }

        public int? CompanyId { get; set; }

        [StringLength(255)]
        public string CompanyName { get; set; }

        public int? AccountTypeId { get; set; }

        public bool IsOnProject { get; set; }

        public virtual AccountType AccountType { get; set; }

        public virtual BusinessLine BusinessLine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusinessUnit> BusinessUnits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusinessUnit> BusinessUnits1 { get; set; }

        public virtual CompanyAffiliation CompanyAffiliation { get; set; }

        public virtual Country Country { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual Status Status { get; set; }

        public virtual Town Town { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateEducation> CandidateEducations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateExperience> CandidateExperiences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateMobility> CandidateMobilities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateResume> CandidateResumes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateSkill> CandidateSkills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LbcMapping> LbcMappings { get; set; }
    }
}
