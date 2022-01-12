using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Entities
{
    public class Basket:EntityBase
    {
        public int CarId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
