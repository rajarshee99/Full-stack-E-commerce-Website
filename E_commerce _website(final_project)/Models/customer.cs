using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce__website_final_project_.Models
{
    public class customer
    {
      

        [Required]
        [StringLength(200)]
        public string? c_address { get; set; }
        
        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string? c_password { get; set; }

        [Required]
        [Key]
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]
        public string? c_e_mail { get; set; }

        



    }
}
