using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.web.Helpers;
using Inventory.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Inventory.web.Controllers
{
    public class ItemController : Controller
    {
        private readonly string _apiURL;
        public ItemController(IConfiguration configuration)
        {
            _apiURL = configuration["API_URL"];
        }
        public async Task<IActionResult> IndexAsync()
        {
            var items = await ApiHelper.GetListAsync<ItemViewModel>(_apiURL, "Items");
            return View(items);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync(ItemViewModel item)
        {
            var result = await ApiHelper.PostAsync<ItemViewModel>(_apiURL, "Items", item);
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
                return BadRequest("Items needed");
            }
            var result = await ApiHelper.GetAsync<ItemViewModel>(_apiURL, "items", id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(ItemViewModel item)
        {
            if (item == null || item.ItemID == 0)
            {
                return BadRequest("Item needed");
            }
            var result = await ApiHelper.DeleteAsync(_apiURL, "Items", item.ItemID);
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
                return BadRequest("Item needed");
            }
            var result = await ApiHelper.GetAsync<ItemViewModel>(_apiURL, "Items", id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(ItemViewModel item)
        {
            if (item == null || item.ItemID == 0)
            {
                return BadRequest("Items needed");
            }
            var result = await ApiHelper.PutAsync<ItemViewModel>(_apiURL, "Items", item.ItemID, item);
            if (result.Item1)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("Error", result.Item2);
            return View();
        }
    }
}