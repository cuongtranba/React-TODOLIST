namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.rfps")]
    public partial class rfp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public byte? according_to_profile { get; set; }

        public string address { get; set; }

        public double? address_latitude { get; set; }

        public double? address_longitude { get; set; }

        public byte? ghost { get; set; }

        public byte? autocalculate { get; set; }

        public string city { get; set; }

        public string consultants { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        public long? creator_id { get; set; }

        public string deliverables { get; set; }

        public string description { get; set; }

        public string division { get; set; }

        public int? duration_in_days { get; set; }

        public int? duration_in_days_mission { get; set; }

        public int? duration_in_hours { get; set; }

        public int? duration_in_hours_mission { get; set; }

        public int? duration_in_months { get; set; }

        public int? duration_in_months_mission { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? end_date { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? end_date_mission { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? expiry_date { get; set; }

        [StringLength(255)]
        public string external_buyer_email { get; set; }

        public string external_target { get; set; }

        public string fonctionnal_competencies { get; set; }

        public string languages { get; set; }

        public long? manager_operationnel_id { get; set; }

        public double? maximum_price { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? modifier_at { get; set; }

        public long? modifier_id { get; set; }

        public string move_address { get; set; }

        public double? move_address_latitude { get; set; }

        public double? move_address_longitude { get; set; }

        public string move_city { get; set; }

        [StringLength(255)]
        public string move_country { get; set; }

        public string move_frequency { get; set; }

        [StringLength(255)]
        public string move_zip { get; set; }

        public byte? open { get; set; }

        public byte? possible_moves { get; set; }

        [StringLength(255)]
        public string postalCode { get; set; }

        public byte? published { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? published_at { get; set; }

        public byte? published_in_feeds { get; set; }

        public byte? renewable { get; set; }

        public long? responsible_buyer { get; set; }

        public byte? start_asap { get; set; }

        public byte? start_asap_mission { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? start_date { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? start_date_mission { get; set; }

        public byte? started { get; set; }

        public string tag { get; set; }

        public byte? target_freelance { get; set; }

        public byte? target_other { get; set; }

        public byte? target_ssii { get; set; }

        public string technical_competencies { get; set; }

        public string title { get; set; }

        public byte? validated { get; set; }

        public int? work_unit_type { get; set; }

        public long? company_id { get; set; }

        public string engineering1_skills { get; set; }

        public string engineering2_skills { get; set; }

        public string engineering3_skills { get; set; }

        public string engineering4_skills { get; set; }

        public long? presta_company_ref_id { get; set; }

        public string contract_special_conditions { get; set; }

        [StringLength(255)]
        public string budgetLineId { get; set; }

        [StringLength(255)]
        public string entityId { get; set; }

        [StringLength(255)]
        public string missionIdExtendedFrom { get; set; }

        [StringLength(255)]
        public string referencedCompaniesLists { get; set; }

        [StringLength(255)]
        public string workflowId { get; set; }

        public long attachedFileId { get; set; }

        public byte? confidential_offer { get; set; }

        public byte? search_indexed { get; set; }

        public string profile_code { get; set; }

        public string project_code { get; set; }

        public bool selectionSentToBuyer { get; set; }

        [StringLength(255)]
        public string legalEntityId { get; set; }

        public long? consultant_id { get; set; }

        public byte? display_max_budget { get; set; }

        public int? status { get; set; }

        public int? work_units { get; set; }

        public int? work_units_mission { get; set; }

        public virtual company company { get; set; }
    }
}
