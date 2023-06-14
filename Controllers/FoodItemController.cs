using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.DBAccess;


using FoodOrdering.Model;


namespace FoodOrdering.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FoodItemController : ControllerBase
    {
        private readonly DBConnection _Context;
        public FoodItemController(DBConnection Context)
        {
            _Context = Context;
        }
        [HttpGet]/*
        public async Task<IEnumerable<FoodItem>> Get()
        {
            return await _Context..GetAsync();
        }*/


    }
}