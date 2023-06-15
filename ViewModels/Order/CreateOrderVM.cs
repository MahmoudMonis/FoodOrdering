using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.ViewModels.vm
{
    public class CreateOrderVM
    {
        public string? Name { get; set; }
        public int BasketId { get; set; }
    }
}