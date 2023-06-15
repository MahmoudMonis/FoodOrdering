using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Model
{
    public class Subcategory
    {
        public Category category { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

    }
}