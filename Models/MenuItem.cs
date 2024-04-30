using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YumYard.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemID { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
            
        [Required]
        public int Quantity { get; set; }



    }
}
