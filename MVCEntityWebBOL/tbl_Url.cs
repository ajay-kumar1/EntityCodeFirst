namespace MVCEntityWebBOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Url
    {
        [Key]
        public int UrlId { get; set; }

        [Required]
        [StringLength(50)]
        public string UrlTitle { get; set; }

        [Required]
        [StringLength(50)]
        public string Url { get; set; }

        [Required]
        public string UrlDesc { get; set; }

        public int? CategoryId { get; set; }

        public int? UserId { get; set; }

        [StringLength(1)]
        public string IsApproved { get; set; }

        //public virtual tbl_Category tbl_Category { get; set; }

        //public virtual tbl_User tbl_User { get; set; }
    }
}
