namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.companies")]
    public partial class company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public company()
        {
            rfps = new HashSet<rfp>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public string address { get; set; }

        public string admin_notes { get; set; }

        [StringLength(255)]
        public string attachements_id { get; set; }

        public int? nb_attachements { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? logo_updated { get; set; }

        public byte? ghost { get; set; }

        public string bank_infomations { get; set; }

        public int? category { get; set; }

        public string city { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? company_creation_date { get; set; }

        public long? company_referencing_id { get; set; }

        [StringLength(255)]
        public string contact1_email { get; set; }

        [StringLength(255)]
        public string contact1_first_name { get; set; }

        [StringLength(255)]
        public string contact1_job { get; set; }

        [StringLength(255)]
        public string contact1_last_name { get; set; }

        [StringLength(255)]
        public string contact1_phone { get; set; }

        [StringLength(255)]
        public string contact2_email { get; set; }

        [StringLength(255)]
        public string contact2_first_name { get; set; }

        [StringLength(255)]
        public string contact2_job { get; set; }

        [StringLength(255)]
        public string contact2_last_name { get; set; }

        [StringLength(255)]
        public string contact2_phone { get; set; }

        public string country { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        [StringLength(255)]
        public string division { get; set; }

        public string doc_alerts { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? fiscal_validated_until { get; set; }

        public string invoice_infomations { get; set; }

        public double? address_latitude { get; set; }

        public double? address_longitude { get; set; }

        [StringLength(255)]
        public string naf { get; set; }

        public string name { get; set; }

        [StringLength(100)]
        public string phone { get; set; }

        public byte? referenced_company { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? refused_by_admin_date { get; set; }

        public double? refused_by_admin_id { get; set; }

        [StringLength(255)]
        public string siret { get; set; }

        [StringLength(255)]
        public string tva { get; set; }

        public double? tva_value { get; set; }

        public int? type { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? urssaf_validated_until { get; set; }

        public bool? validated_by_admin { get; set; }

        public string zip { get; set; }

        public long? logo_id { get; set; }

        public long? logoCreator_id { get; set; }

        public long? logoTemp_id { get; set; }

        public byte? contract_accepted { get; set; }

        public string manager_name { get; set; }

        public string bittle_publication_url { get; set; }

        [StringLength(255)]
        public string legal_form { get; set; }

        public string contract_special_conditions { get; set; }

        public string bittle_all_dashboard_publication_url { get; set; }

        public string bittle_fournisseurs_dashboard_publication_url { get; set; }

        public string bittle_invoices_dashboard_publication_url { get; set; }

        public string bittle_rfps_dashboard_publication_url { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? validated_by_admin_date { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? desactivated_by_admin_date { get; set; }

        public long? desactivated_by_admin_id { get; set; }

        public int? att_fisc_alert_counter { get; set; }

        public int? att_travail_alert_counter { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? contract_acceptance_date { get; set; }

        public int? kbis_alert_counter { get; set; }

        public int? rc_alert_counter { get; set; }

        public int? urssaf_alert_counter { get; set; }

        public string bittle_cra_dashboard_publication_url { get; set; }

        public byte? client_pays { get; set; }

        public byte? has_been_notified { get; set; }

        public double? portage_day { get; set; }

        public double? portage_package { get; set; }

        public byte? presta_uses_portage { get; set; }

        public byte? receive_doc_alert { get; set; }

        public byte? enable_company_modifications { get; set; }

        public byte? enable_direct_payment { get; set; }

        public double? sourcing_day { get; set; }

        public double? sourcing_package { get; set; }

        public byte? switch_presta_client_activated { get; set; }

        public string bic { get; set; }

        public string iban { get; set; }

        [StringLength(255)]
        public string solocal_code_marche { get; set; }

        public int? generateInvoiceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rfp> rfps { get; set; }
    }
}
