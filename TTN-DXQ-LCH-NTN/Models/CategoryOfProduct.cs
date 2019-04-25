namespace TTN_DXQ_LCH_NTN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryOfProduct")]
    public partial class CategoryOfProduct
    {
        public int CategoryOfProductID { get; set; }

        [StringLength(20)]
        public string CategoryOfProductName { get; set; }

        public int? Total { get; set; }
    }
}
