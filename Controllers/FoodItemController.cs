using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.DBAccess;
using System.Text.Json;
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
                return _Context.fooditem.Where(x => x.IdSubcategory == subcategory && x.Name == name).ToList();

            }
            else if (subcategory != null)
            {
                return _Context.fooditem.Where(x => x.IdSubcategory == subcategory).ToList();

            }
            else if (name != null)
            {
                return _Context.fooditem.Where(x => x.Name == name).ToList();

            }
            else
            {
                return _Context.fooditem.ToList();
            }

        }


        [HttpPost]
        public string UpdateFoodItem(CreateFoodItemVM Fooditem)
        {

            if (checkitemexisiens(Fooditem.Name))
            {
                FoodItem item = _Context.fooditem.FirstOrDefault(x => x.Name == Fooditem.Name);
                bool changes = false;
                if (item.Name != Fooditem.Name) { item.Name = Fooditem.Name; _Context.SaveChanges(); changes = true; } else {/*Nothing To Update */}
                if (item.Description != Fooditem.Description) { item.Description = Fooditem.Description; _Context.SaveChanges(); changes = true; } else {/*Nothing To Update */}
                if (item.Price != Fooditem.Price) { item.Price = Fooditem.Price; _Context.SaveChanges(); changes = true; } else {/*Nothing To Update */}
                if (item.IdSubcategory != Fooditem.SubCategoryId) { item.IdSubcategory = Fooditem.SubCategoryId; _Context.SaveChanges(); changes = true; } else {/*Nothing To Update */}


                if (changes == true) { return "Item Has Been Updated"; } else { return "Item Found But nothing has been updated  no new changes "; }
            }
            else
            {
                return "There is no Such an item Like " + Fooditem.Name;
            }

        }


        [HttpPost]
        public string AddFoodItem(CreateFoodItemVM Fooditem)
        {
            if (checkitemexisiens(Fooditem.Name))
            {
                //Add Update Function 
                return "You cant add already exisited Item";
            }
            else
            {
                _Context.Add(new FoodItem
                {
                    Name = Fooditem.Name,
                    Description = Fooditem.Description,
                    Price = Fooditem.Price,
                    IdSubcategory = Fooditem.SubCategoryId
                });
                _Context.SaveChanges();

                return JsonSerializer.Serialize(Fooditem);
            }

        }

        private bool checkitemexisiens(string Name)
        {
            FoodItem item = _Context.fooditem.FirstOrDefault(x => x.Name == Name);
            if (item != null && item.Name != null) { return true; } else { return false; }
        }



    }
}