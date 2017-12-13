namespace shit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lbc.users")]
    public partial class user
    {
        [Required]
        [StringLength(31)]
        public string user_type { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public long? graph_id { get; set; }

        public byte? ghost { get; set; }

        [StringLength(255)]
        public string stats_id { get; set; }

        [StringLength(255)]
        public string confidentiality_prefs { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        public string groups { get; set; }

        public byte? hidden { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_connection { get; set; }

        [StringLength(255)]
        public string last_ip { get; set; }

        [StringLength(255)]
        public string mobile_password { get; set; }

        public int? notifications { get; set; }

        public string roles { get; set; }

        public int visits { get; set; }

        public int? account_type { get; set; }

        public string invitation_count { get; set; }

        public int? invitations_total { get; set; }

        public string contacts { get; set; }

        public int? nb_contacts { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string user_locale_country { get; set; }

        [StringLength(255)]
        public string user_locale_language { get; set; }

        public int? civility { get; set; }

        [StringLength(255)]
        public string first_name { get; set; }

        [StringLength(255)]
        public string last_name { get; set; }

        [StringLength(255)]
        public string screen_name { get; set; }

        [StringLength(255)]
        public string second_name { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(100)]
        public string fax { get; set; }

        [StringLength(100)]
        public string fix_phone { get; set; }

        public double? address_latitude { get; set; }

        public double? address_longitude { get; set; }

        [StringLength(100)]
        public string mobile_phone { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? avatar_updated { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birth_date { get; set; }

        public int? business_line { get; set; }

        public byte[] cv { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? cv_updated_at { get; set; }

        public int? pro_status { get; set; }

        public byte? buyer_capabilities { get; set; }

        public byte? company_affiliation_validated { get; set; }

        [StringLength(255)]
        public string companyName { get; set; }

        [StringLength(255)]
        public string computing_other_skills_title { get; set; }

        public int? cv_completion { get; set; }

        [StringLength(255)]
        public string cv_completion_map { get; set; }

        public long? default_buyer_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? dispo_date { get; set; }

        [StringLength(255)]
        public string functional_other_skills_title { get; set; }

        public int? hors_scope_counter { get; set; }

        public string mobility_zones { get; set; }

        public byte? need_first_step { get; set; }

        public byte? need_second_step { get; set; }

        public string rfps_searched { get; set; }

        public byte? saler_capabilities { get; set; }

        public string summary { get; set; }

        public long? country_id { get; set; }

        public long? town_id { get; set; }

        public long? avatar_id { get; set; }

        public long? avatarTemp_id { get; set; }

        public long? company_id { get; set; }

        [StringLength(255)]
        public string engineering_other_skills_title1 { get; set; }

        [StringLength(255)]
        public string engineering_other_skills_title2 { get; set; }

        [StringLength(255)]
        public string engineering_other_skills_title3 { get; set; }

        [StringLength(255)]
        public string engineering_other_skills_title4 { get; set; }

        public byte? search_indexed { get; set; }

        public long? desactivated_by_admin_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? desactivated_date { get; set; }

        public byte? presence_status { get; set; }

        public long? time_since_last_connection { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? updated_at { get; set; }

        public long? amaris_id { get; set; }

        public byte? is_presta_client { get; set; }

        public byte? first_connection_v2 { get; set; }
    }
}
