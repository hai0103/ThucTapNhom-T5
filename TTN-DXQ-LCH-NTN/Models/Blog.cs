namespace TTN_DXQ_LCH_NTN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int BlogID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string ContentDM { get; set; }

        [StringLength(50)]
        public string ContentDetail { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        public int? New { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
    }
}
