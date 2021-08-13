namespace DoNgoaiChinhHang.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryBase")]
    public partial class CategoryBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoryBase()
        {
            Categories = new HashSet<Category>();
        }

        [StringLength(10)]
        [Required(ErrorMessage = "Mã danh mục không được để trống")]
        [DisplayName("Mã danh mục")]
        public string CategoryBaseID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [DisplayName("Tên danh mục")]
        public string CategoryBaseName { get; set; }

        [StringLength(4000)]
        [Required(ErrorMessage = "Mô tả không được để trống")]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
