using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIWebTinTuc.Data
{
    [Table("LoaiBV")]
    public class LoaiBaiViet
    {
        [Key]
        public int Maloai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }

        public virtual ICollection<DataBaiViet> dataBV { get; set; }
    }
}
