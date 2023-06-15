using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.ViewModels
{
    public class CreateFoodItemVM
    {
        public string? Name { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }

        public int SubCategoryId { get; set; }
    }
}