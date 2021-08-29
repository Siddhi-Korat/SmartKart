using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCart.Repo.Model;
using SmartCart.Repo.Repositories;
using SmartKart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartKart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private ItemManager itemManager { get; set; }
        private IMapper mapper { get; set; }
        public ItemsController(ItemManager itemManager, IMapper mapper)
        {
            this.itemManager = itemManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var items = itemManager.GetAll();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ItemsModel model)
        {
            var itemData = mapper.Map<Item>(model);
            //ToDo: add validations
            var response = itemManager.Insert(itemData);
            return Ok(response);
        }
    }
}
