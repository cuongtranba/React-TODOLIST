namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.BusinessUnit")]
    public partial class BusinessUnit
    {
        public int BusinessUnitId { get; set; }

        public int? ConsultantId { get; set; }

        public int? ManagerId { get; set; }

        public int? CompanyId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RfpApplicationCreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RfpApplicationUpdatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public long LBCManagerId { get; set; }

        public long LBCConsultanId { get; set; }

        public long? LBCCompanyAffiliationId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual Candidate Candidate1 { get; set; }

        public virtual CompanyAffiliation CompanyAffiliation { get; set; }
    }
}
