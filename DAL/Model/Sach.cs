namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [Key]
        [StringLength(6)]
        [DisplayName("Mã sách")]
        public string MaSach { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên sách")]
        public string TenSach { get; set; }

        [DisplayName("Năm XB")]
        public int NamXB { get; set; }

        public int MaLoai { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }

        [NotMapped] // Đánh dấu không ánh xạ trường này vào cơ sở dữ liệu
        [DisplayName("Thể loại")]
        public string TenLoaiSach { get; set; }
    }
}
