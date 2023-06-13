using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using FoodOrdering.Model;


namespace FoodOrdering.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FoodItemController : ControllerBase
    {
        private readonly FoodItemContext _Context;
        public FoodItemController(FoodItemContext Context)
        {
            _Context = Context;
        }
        [HttpGet]
        public async Task<IEnumerable<FoodItem>> Get()
        {
            return await _Context.FoodItems.GetAsync();
        }

        
    }
}