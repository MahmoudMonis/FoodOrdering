using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Model;
using System.Text.Json;

namespace FoodOrdering.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubcategoryController : ControllerBase
    {

        private static List<Subcategory> _subcategories = new List<Subcategory>();



        [HttpGet]
        public List<Subcategory> GetAllSubcategorys()
        {
            return _subcategories;
        }

        [HttpPost]
        public string UpdateCategory(Subcategory subcategory)
        {

            if (checkitemexisiens(subcategory.Name))
            {
                Subcategory item = _subcategories.Find(x => x.Name == subcategory.Name);
                bool changes = false;
                if (item.Name != subcategory.Name) { item.Name = subcategory.Name; changes = true; } else {/*Nothing To Update */}
                if (item.CategoryId != subcategory.CategoryId) { item.CategoryId = subcategory.CategoryId; changes = true; } else {/*Nothing To Update */}

                if (changes == true) { return "Item Has Been Updated"; } else { return "Item Found But nothing has been updated  no new changes "; }
            }
            else
            {
                return "There is no Such an item Like " + subcategory.Name;
            }

        }


        [HttpPost]
        public string AddSubCategoy(Subcategory subcategory)
        {
            if (checkitemexisiens(subcategory.Name))
            {
                //Add Update Function 
                return "You cant add already exisited Subcateogry";
            }
            else
            {
                _subcategories.Add(new Subcategory
                {
                    Id = _subcategories.Count + 1,
                    Name = subcategory.Name,
                    CategoryId = subcategory.CategoryId

                });

                return JsonSerializer.Serialize(_subcategories);
            }

        }

        private bool checkitemexisiens(string Name)
        {
            Subcategory item = _subcategories.Find(x => x.Name == Name);
            if (item != null && item.Name != null) { return true; } else { return false; }
        }



    }
}