using System;
using System.ComponentModel.DataAnnotations;

namespace Dapper.Core.Models.Commands
{
    public class CarInsertDTO
    {
        [Required]
        [StringLength(60)]
        public string Brand { get; set; }
        [Required]
        [StringLength(40)]
        public string Model { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        public bool IsLightOn { get; set; }
        [Required]
        public bool IsDoorOn { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(70)]
        public string AddedBy { get; set; }
    }
}
