namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioiTinh")]
    public partial class GioiTinh
    {
        [Key]
        [StringLength(1)]
        public string MaGioiTinh { get; set; }

        [Required]
        [StringLength(4)]
        public string LoaiGioiTinh { get; set; }
    }
}
