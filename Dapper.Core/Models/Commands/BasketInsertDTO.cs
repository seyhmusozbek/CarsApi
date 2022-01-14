using System.ComponentModel.DataAnnotations;

namespace Dapper.Core.Models.Commands
{
    public class BasketInsertDTO
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(70)]
        public string AddedBy { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }

    }
}
