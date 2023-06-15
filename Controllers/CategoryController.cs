using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.ViewModels.vm;


using FoodOrdering.Model;
using FoodOrdering.DBAccess;

namespace FoodOrdering.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly DBConnection _Context;
          public CategoryController(DBConnection context)
          {
              _Context = context;
          }
          // GET: api/values
          [HttpGet]
          public async Task <IEnumerable<Category>> GetFooditemByCategory(int CategoryId)
          {
            var vm = await _Context.vm.
            include(p=>p.subcategory)
            .where(p=>p.subcategory.CategoryId== CategoryId)
            .tolistasync();
            return vm .select(p=> new createfoodItemVM
            {
                CategoryId=p.subcategory.CategoryId,
                Name=p.subcategory.Name,
                Description=p.subcategory.Description,
                Price=p.subcategory.Price,
                Image=p.subcategory.Image,

                subcategory= new CreatesubcategoryVM
                {
                    CategoryId=p.subcategory.CategoryId,
                    Name=p.subcategory.Name,
                    Description=p.subcategory.Description,
                    Price=p.subcategory.Price,
                    Image=p.subcategory.Image
                }
            }).ToList();
              
              
          }
          [HttpGet]
          public async Task<IEnumerable<CreateFoodItemVM>> GetAllFooditemBySubcategory(int subcategoryId)
          {
            var ch = await _Context.ch
            include(p=>p.subcategory)
            .where(p=>p.subcategoryId==subcategoryId)
            .tolistasync();
            return ch.Select(p=> new CreateFoodItemVM
            {
                SubCategoryId = p.subcategory.CategoryId,
                Name=p.subcategory.Name,
                Description=p.subcategory.Description,
                Price=p.subcategory.Price,
               

                SubCategoryId=new CreateSubCategoryVM
                {
                    CategoryId=p.subcategory.CategoryId,
                    Name=p.subcategory.Name,
                   
                }


    }).tolist();
}
[HttpPost]
public async Task<IActionResult>post(CreateFoodItemVM  vm){
    var foodItem = new FoodItem
    {
        IdSubcategory=vm.SubCategoryId,
                Name=vm.Name,
                Description=vm.Description,
               Price=vm.Price,
                 
    };
    _Context.vm.add(foodItem);
    await _Context.SaveChangesAsync();
    return Ok();
}


[HttpPut]
public async Task<IActionResult>Ubdate(int id)
{
    var foodItem = await _Context.vm.where(p=>p.id==id).ToOneAsync();
    if (foodItem == null)
    {
        return NotFound();
    }
    foodItem.Name = foodItem.Name;
    foodItem.Description = foodItem.Description;
    foodItem.Price = foodItem.Price;
    foodItem.Image = foodItem.Image;
    _Context.vm.update(foodItem);
    await _Context.SaveChangesAsync();
    return Ok();

    }
}}
    
