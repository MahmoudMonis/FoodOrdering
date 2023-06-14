using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.ViewModels
{
    public class SubCategoryVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CategoryVM? Category { get; set; }
    }
}