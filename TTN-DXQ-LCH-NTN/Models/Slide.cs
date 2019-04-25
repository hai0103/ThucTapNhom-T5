namespace TTN_DXQ_LCH_NTN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SlideID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Image { get; set; }

        [StringLength(50)]
        public string SlideContent { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
    }
}
