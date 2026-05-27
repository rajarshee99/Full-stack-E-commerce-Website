using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce__website_final_project_.Models
{
    public class admin
    {
        
        
        [Key]
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]
        public string ? a_e_mail { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string ? a_password { get; set; }


    }
}
