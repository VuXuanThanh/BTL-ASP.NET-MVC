namespace DoNgoaiChinhHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [StringLength(10)]
        public string CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string CategoryBaseID { get; set; }

        public string Images { get; set; }

        public virtual CategoryBase CategoryBase { get; set; }

        public virtual CategoryBase CategoryBase1 { get; set; }
    }
}
