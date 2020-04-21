using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDelicious_.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private CRUDelicious_Context dbContext;
        public HomeController(CRUDelicious_Context context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dishes> MostRecent = dbContext.CRUD.OrderByDescending(d => d.CreatedAt).ToList();
            return View("Index", MostRecent);
        }

        [HttpGet]
        [Route("add")]
        public ViewResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("newdish")]
        public IActionResult NewDish(Dishes newDish)
        {

            dbContext.Add(newDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index", newDish);

        }

        [HttpGet]
        [Route("{id}")]
        public ViewResult DisplayDish(int id)
        {
            Dishes dish = dbContext.CRUD.SingleOrDefault(d => d.DishID == id);
            return View("Display", dish);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ViewResult Edit(int id)
        {
            Dishes dish = dbContext.CRUD.SingleOrDefault(d => d.DishID == id);
            return View("Edit", dish);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpdatedDish(Dishes updatedDish)
        {
        
            Dishes dish = dbContext.CRUD.SingleOrDefault(d => d.DishID == updatedDish.DishID);
            dish.Name = updatedDish.Name;
            dish.Chef = updatedDish.Chef;
            dish.Calories = updatedDish.Calories;
            dish.Tastiness = updatedDish.Tastiness;
            dish.Description = updatedDish.Description;
            dish.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        
        }

        [HttpGet]
        [Route("delete/{id}")]
        public RedirectToActionResult Delete(int id)
        {
            Dishes dish = dbContext.CRUD.SingleOrDefault(d => d.DishID == id);
            dbContext.CRUD.Remove(dish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
