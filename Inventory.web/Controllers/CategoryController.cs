using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Inventory.web.Helpers;
using Inventory.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Inventory.web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly string _apiURL;
        public CategoryController(IConfiguration configuration)
        {
            _apiURL = configuration["API_URL"];
        }
        public async Task<IActionResult> IndexAsync()
        {
            var categories = await ApiHelper.GetListAsync<CategoryViewModel>(_apiURL, "Categories");
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string categoryName)
        {
            var items = await ApiHelper.GetListAsync<CategoryViewModel>(_apiURL, "Categories/filter", categoryName);
            return View(items);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync(CategoryViewModel category)
        {
            var result = await ApiHelper.PostAsync<CategoryViewModel>(_apiURL, "Categories", category);
            if (result.Item1)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("Error", result.Item2);
            return View();
        }
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest("Category needed");
            }
            var result = await ApiHelper.GetAsync<CategoryViewModel>(_apiURL, "Categories", id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(CategoryViewModel category)
        {
            if (category == null || category.CategoryID == 0)
            {
                return BadRequest("Category needed");
            }
            var result = await ApiHelper.DeleteAsync(_apiURL, "Categories", category.CategoryID);
            if (result.Item1)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("Error", result.Item2);
            return View();
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest("Category needed");
            }
            var result = await ApiHelper.GetAsync<CategoryViewModel>(_apiURL, "Categories", id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(CategoryViewModel category)
        {
            if (category == null || category.CategoryID == 0)
            {
                return BadRequest("Category needed");
            }
            var result = await ApiHelper.PutAsync<CategoryViewModel>(_apiURL, "Categories", category.CategoryID, category);
            if (result.Item1)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("Error", result.Item2);
            return View();
        }
    }
}