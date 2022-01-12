using System.ComponentModel.DataAnnotations;

namespace Dapper.Core.Models.Commands
{
    public class BasketUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        [StringLength(70)]
        public string ModifiedBy { get; set; }
    }
}
