using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.DBAccess;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using FoodOrdering.ViewModels;
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


        [HttpGet]
        public List<FoodItem> GetAllFoods(int? subcategory, string? name)
        {
            if (subcategory != null && name != null)
            {
                return _Context.foodItem.Where(x => x.IdSubcategory == subcategory && x.Name == name).ToList();

            }
            else if (subcategory != null)
            {
                return _Context.foodItem.Where(x => x.IdSubcategory == subcategory).ToList();

            }
            else if (name != null)
            {
                return _Context.foodItem.Where(x => x.Name == name).ToList();

            }
            else
            {
                return _Context.foodItem.ToList();
            }

        }


        [HttpPost]
        public string UpdateFoodItem(CreateFoodItemVM FoodItem)
        {

            if (checkitemexisted(FoodItem.Name))
            {
                FoodItem item = _Context.foodItem.FirstOrDefault(x => x.Name == FoodItem.Name);
                bool changes = false;
                if (item.Name != FoodItem.Name) { item.Name = FoodItem.Name; _Context.SaveChanges(); changes = true; } else {/*Nothing To Update */}
                if (item.Description != FoodItem.Description) { item.Description = FoodItem.Description; _Context.SaveChanges(); changes = true; } else {/*Nothing To Update */}
                if (item.Price != FoodItem.Price) { item.Price = FoodItem.Price; _Context.SaveChanges(); changes = true; } else {/*Nothing To Update */}
                if (item.IdSubcategory != FoodItem.SubCategoryId) { item.IdSubcategory = FoodItem.SubCategoryId; _Context.SaveChanges(); changes = true; } else {/*Nothing To Update */}


                if (changes == true) { return "Item Has Been Updated"; } else { return "Item Found But nothing has been updated  no new changes "; }
            }
            else
            {
                return "There is no Such an item Like " + FoodItem.Name;
            }

        }


        [HttpPost]
        public string AddFoodItem(CreateFoodItemVM FoodItem)
        {
            if (checkitemexisted(FoodItem.Name))
            {
                //Add Update Function 
                return "You cant add already existed Item";
            }
            else
            {
                _Context.Add(new FoodItem
                {
                    Name = FoodItem.Name,
                    Description = FoodItem.Description,
                    Price = FoodItem.Price,
                    IdSubcategory = FoodItem.SubCategoryId
                });
                _Context.SaveChanges();

                return JsonSerializer.Serialize(FoodItem);
            }

        }

        private bool checkitemexisted(string Name)
        {
            FoodItem item = _Context.foodItem.FirstOrDefault(x => x.Name == Name);
            if (item != null && item.Name != null) { return true; } else { return false; }
        }



    }
}