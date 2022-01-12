using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Models.Commands
{
    public class CarUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsDoorOn { get; set; }
        [Required]
        public bool IsLightOn { get; set; }
        [Required]
        [StringLength(70)]
        public string ModifiedBy { get; set; }


    }
}
