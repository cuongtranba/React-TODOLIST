namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.missions")]
    public partial class mission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public string address { get; set; }

        public string admin_comments { get; set; }

        [StringLength(255)]
        public string attachements_id { get; set; }

        public int? nb_attachements { get; set; }

        public byte? ghost { get; set; }

        public long? application_id { get; set; }

        public byte? autocalculate { get; set; }

        [StringLength(255)]
        public string bdc_client_number { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? bdc_client_validator_date { get; set; }

        public long? bdc_client_validator_id { get; set; }

        [StringLength(255)]
        public string bdc_ref_number { get; set; }

        public long? client_company_id { get; set; }

        public byte? closed { get; set; }

        public string conditions { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        public long? creator_id { get; set; }

        public string deliverables { get; set; }

        public string description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? emission_date { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? end_date { get; set; }

        public byte? external { get; set; }

        public long? last_modifier_id { get; set; }

        public double? lbc_day_price { get; set; }

        public double? lbc_package_price { get; set; }

        public string message { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? mission_validated_at { get; set; }

        public long? mission_validator_id { get; set; }

        public string presta_address { get; set; }

        public long? presta_company_id { get; set; }

        [StringLength(255)]
        public string presta_company_name { get; set; }

        [StringLength(255)]
        public string presta_email { get; set; }

        [StringLength(255)]
        public string presta_name { get; set; }

        [StringLength(255)]
        public string presta_phone { get; set; }

        [StringLength(255)]
        public string presta_siret { get; set; }

        [StringLength(255)]
        public string presta_tva { get; set; }

        public double? price { get; set; }

        public long? rfp_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? start_date { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? stop_mission_date { get; set; }

        public string stop_mission_message { get; set; }

        public string tag { get; set; }

        public string title { get; set; }

        public double? total { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? updated_at { get; set; }

        public byte? validated_by_admin { get; set; }

        public int? work_unit_type { get; set; }

        public int? work_units { get; set; }

        public double? work_units_invoiced { get; set; }

        public byte? subcontractor_mission { get; set; }

        public string contract_special_conditions { get; set; }

        [StringLength(255)]
        public string external_consultant_email { get; set; }

        [StringLength(255)]
        public string external_consultant_first_name { get; set; }

        [StringLength(255)]
        public string external_consultant_last_name { get; set; }

        [StringLength(255)]
        public string external_consultant_phone { get; set; }

        public byte? client_pays { get; set; }

        public byte? presta_uses_portage { get; set; }

        public byte? referenced_presta { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? stop_ask_date { get; set; }

        public long? stop_asker_id { get; set; }

        public byte? stopped { get; set; }

        public byte? search_indexed { get; set; }

        public byte? immediate_payment { get; set; }

        public int? immediate_payment_price { get; set; }

        public int? already_invoiced { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? bdc_client_number_date { get; set; }

        public double? client_price { get; set; }

        public byte? has_invoices { get; set; }

        public byte? isSourcing { get; set; }

        public string payment_conditions { get; set; }

        public double? presta_price { get; set; }
    }
}
