using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Model
{
    public class Order
    {
    public int Id { get; set; }

	public string Name { get; set; }

	public double Total { get; set; }

    public int FoodItemId { get; set; }
    public string FoodItemName { get; set; }

	public Basket basket { get; set;}
    }
}