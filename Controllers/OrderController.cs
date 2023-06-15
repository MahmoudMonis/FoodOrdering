using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodOrdering.DBAccess;
using FoodOrdering.Model;
using FoodOrdering.ViewModels;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController : ControllerBase
{
    private static List<Order> orders = new List<Order>();

    [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        Order order = orders.Find(o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public IActionResult AddOrder(Order order)
    {
        order.Id = orders.Count + 1;
        orders.Add(order);
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id, Order updatedOrder)
    {
        Order? existingOrder = orders.Find(o => o.Id == id);
        if (existingOrder == null)
        {
            return NotFound();
        }
        existingOrder.OrderName = updatedOrder.OrderName;
        existingOrder.Total = updatedOrder.Total;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        Order order = orders.Find(o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        orders.Remove(order);
        return NoContent();
    }
}