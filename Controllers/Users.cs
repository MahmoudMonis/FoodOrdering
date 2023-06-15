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
public class UsersController : ControllerBase
{
    private List<User> users = new List<User>(); 

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        User? user = users.Find(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public IActionResult AddUser(User user)
    {
        user.Id = users.Count + 1;
        users.Add(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        User? existingUser = users.Find(u => u.Id == id);
        if (existingUser == null)
        {
            return NotFound();
        }
        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        User? user = users.Find(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        users.Remove(user);
        return NoContent();
    }
}