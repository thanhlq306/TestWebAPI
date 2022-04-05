using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIWebTinTuc.Data
{
    [Table("UserTable")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string PassWord { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        

    }
}
