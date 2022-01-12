using System;

namespace Dapper.Core.Entities
{
    public class Car:EntityBase
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public bool IsLightOn { get; set; }
        public bool IsDoorOn { get; set; }
        public decimal Price { get; set; }
    }
}
