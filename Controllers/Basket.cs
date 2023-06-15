using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodOrdering.DBAccess;
using FoodOrdering.Model;
using FoodOrdering.ViewModels;

namespace Basket.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private static List<FoodItem> foodItems = new List<FoodItem>();

        [HttpGet]
        public IActionResult GetFoodItems()
        {
            return Ok(foodItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetFoodItem(int id)
        {
            FoodItem? foodItem = foodItems.Find(item => item.FoodItemId == id);
            if (foodItem == null)
            {
                return NotFound();
            }
            return Ok(foodItem);
        }

        [HttpPost]
        public IActionResult AddToBasket(FoodItem item)
        {
            item.FoodItemId = foodItems.Count + 1;
            foodItems.Add(item);
            return CreatedAtAction(nameof(GetFoodItem), new { id = item.FoodItemId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBasketItem(int id, FoodItem item)
        {
            FoodItem? foodItem = foodItems.Find(i => i.FoodItemId == id);
            if (foodItem == null)
            {
                return NotFound();
            }
            foodItem.Name = item.Name;
            foodItem.Price = item.Price;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasketItem(int id)
        {
            FoodItem? foodItem = foodItems.Find(item => item.FoodItemId == id);
            if (foodItem == null)
            {
                return NotFound();
            }
            foodItems.Remove(foodItem);
            return NoContent();
        }
    }
}