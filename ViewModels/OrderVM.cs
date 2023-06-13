using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public OrderVM? Order { get; set; }
    }
}