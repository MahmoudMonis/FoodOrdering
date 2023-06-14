using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Basket.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private static List<BasketItem> basketItems = new List<BasketItem>();

        [HttpGet]
        public IActionResult GetBasketItems()
        {
            return Ok(basketItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetBasketItem(int id)
        {
            BasketItem basketItem = basketItems.Find(item => item.Id == id);
            if (basketItem == null)
            {
                return NotFound();
            }
            return Ok(basketItem);
        }

        [HttpPost]
        public IActionResult AddToBasket(BasketItem item)
        {
            item.Id = basketItems.Count + 1;
            basketItems.Add(item);
            return CreatedAtAction(nameof(GetBasketItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBasketItem(int id, BasketItem item)
        {
            BasketItem basketItem = basketItems.Find(i => i.Id == id);
            if (basketItem == null)
            {
                return NotFound();
            }
            basketItem.Name = item.Name;
            basketItem.Price = item.Price;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasketItem(int id)
        {
            BasketItem basketItem = basketItems.Find(item => item.Id == id);
            if (basketItem == null)
            {
                return NotFound();
            }
            basketItems.Remove(basketItem);
            return NoContent();
        }
    }

    public class BasketItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}