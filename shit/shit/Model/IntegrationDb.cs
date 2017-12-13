namespace shit.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IntegrationDb : DbContext
    {
        public IntegrationDb()
            : base("name=IntegrationDb")
        {
        }

        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<BusinessLine> BusinessLines { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidateEducation> CandidateEducations { get; set; }
        public virtual DbSet<CandidateExperience> CandidateExperiences { get; set; }
        public virtual DbSet<CandidateExperienceDetail> CandidateExperienceDetails { get; set; }
        public virtual DbSet<CandidateMobility> CandidateMobilities { get; set; }
        public virtual DbSet<CandidateResume> CandidateResumes { get; set; }
        public virtual DbSet<CandidateSkill> CandidateSkills { get; set; }
        public virtual DbSet<CompanyAffiliation> CompanyAffiliations { get; set; }
        public virtual DbSet<CompanyExperience> CompanyExperiences { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Domain> Domains { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<LbcMapping> LbcMappings { get; set; }
        public virtual DbSet<SkillCategory> SkillCategories { get; set; }
        public virtual DbSet<SkillDomain> SkillDomains { get; set; }
        public virtual DbSet<SkillType> SkillTypes { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<companies_refs> companies_refs { get; set; }
        public virtual DbSet<country1> countries1 { get; set; }
        public virtual DbSet<emails_prefs> emails_prefs { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<rfp_applications> rfp_applications { get; set; }
        public virtual DbSet<rfp> rfps { get; set; }
        public virtual DbSet<town1> towns1 { get; set; }
        public virtual DbSet<user_contacts> user_contacts { get; set; }
        public virtual DbSet<user_contacts_requests> user_contacts_requests { get; set; }
        public virtual DbSet<user_recommendations> user_recommendations { get; set; }
        public virtual DbSet<user_registration_tokens> user_registration_tokens { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<users_educations> users_educations { get; set; }
        public virtual DbSet<users_positions> users_positions { get; set; }
        public virtual DbSet<users_roles> users_roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>()
                .Property(e => e.AccountTypeName)
                .IsFixedLength();

            modelBuilder.Entity<Candidate>()
                .HasMany(e => e.BusinessUnits)
                .WithOptional(e => e.Candidate)
                .HasForeignKey(e => e.ConsultantId);

            modelBuilder.Entity<Candidate>()
                .HasMany(e => e.BusinessUnits1)
                .WithOptional(e => e.Candidate1)
                .HasForeignKey(e => e.ManagerId);

            modelBuilder.Entity<Candidate>()
                .HasMany(e => e.CandidateEducations)
                .WithRequired(e => e.Candidate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Candidate>()
                .HasMany(e => e.CandidateExperiences)
                .WithRequired(e => e.Candidate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Candidate>()
                .HasMany(e => e.CandidateMobilities)
                .WithRequired(e => e.Candidate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Candidate>()
                .HasMany(e => e.CandidateResumes)
                .WithRequired(e => e.Candidate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Candidate>()
                .HasMany(e => e.CandidateSkills)
                .WithRequired(e => e.Candidate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Candidate>()
                .HasMany(e => e.LbcMappings)
                .WithRequired(e => e.Candidate)
                .HasForeignKey(e => e.IntegrationCandidateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CandidateExperience>()
                .HasOptional(e => e.CandidateExperienceDetail)
                .WithRequired(e => e.CandidateExperience);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<SkillCategory>()
                .HasMany(e => e.CandidateSkills)
                .WithOptional(e => e.SkillCategory)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<SkillDomain>()
                .HasMany(e => e.SkillCategories)
                .WithOptional(e => e.SkillDomain)
                .HasForeignKey(e => e.DomainId);

            modelBuilder.Entity<SkillType>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<SkillType>()
                .HasMany(e => e.CandidateSkills)
                .WithOptional(e => e.SkillType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<Status>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Candidates)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.rfps)
                .WithOptional(e => e.company)
                .HasForeignKey(e => e.company_id);

            modelBuilder.Entity<country1>()
                .HasMany(e => e.users_educations)
                .WithOptional(e => e.country)
                .HasForeignKey(e => e.country_id);
        }
    }
}
