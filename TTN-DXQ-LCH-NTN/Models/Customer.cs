namespace TTN_DXQ_LCH_NTN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Address { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int? Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        public int? IsAdmin { get; set; }
    }
}
