using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce__website_final_project_.Models
{
    public class product
    {
        [Key]
        public int p_id { get; set; }

        [Required]
        [StringLength(200)]
        public string? p_name { get; set; }

        [Required]
        public int p_qty { get; set; }

        [Required]
        public int p_price { get; set; }

        public string ? p_pic {  get; set; }
        [NotMapped]
        public IFormFile ? pics { get; set; }

    }
}
