using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Model
{
    public class Order
    {
        public int Id { get; set; }

        public string? OrderName { get; set; }

        public double Total { get; set; }

        public string? UserId { get; set; }

        public Basket Basket { get; set; }
    }
}