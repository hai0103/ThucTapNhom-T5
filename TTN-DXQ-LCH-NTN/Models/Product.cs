namespace TTN_DXQ_LCH_NTN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public int? Total { get; set; }

        public int? New { get; set; }

        public int? CategoryOfProductID { get; set; }
    }
}
