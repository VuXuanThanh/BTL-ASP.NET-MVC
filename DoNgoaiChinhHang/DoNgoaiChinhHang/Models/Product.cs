namespace DoNgoaiChinhHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(10)]
        public string ProductID { get; set; }

        [Required]
        [StringLength(10)]
        public string CategoryID { get; set; }

        [StringLength(200)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public int? Evaluation { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(50)]
        public string Orgin { get; set; }

        public float? Price { get; set; }

        public string Benefit { get; set; }

        [StringLength(4000)]
        public string Introduction { get; set; }

        [StringLength(1000)]
        public string Element { get; set; }

        [StringLength(1000)]
        public string Tutorial { get; set; }

        public float? Discount { get; set; }

        public bool? Freeship { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public virtual Category Category { get; set; }

        public virtual Category Category1 { get; set; }
    }
}
