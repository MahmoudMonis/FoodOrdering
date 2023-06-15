using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Model
{
    public class Basket
    {
        public int Id { get; set; }
        public int FoodItemId { get; set; }
        public string? FoodItemName { get; set; }
        public string? UserId { get; set; }

    }
}