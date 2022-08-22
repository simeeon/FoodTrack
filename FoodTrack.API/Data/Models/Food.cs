using System.ComponentModel.DataAnnotations;

namespace FoodTrack.API.Data.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public string Unit { get; set; }

        //[Range(0.0, float.MaxValue, ErrorMessage = "Only positive amount allowed")]
        //[Required]
        //public float Amount { get; set; }

        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        [Required]
        public decimal Price { get; set; }
    }
}
