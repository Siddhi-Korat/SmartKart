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
    public class OrderController : Controller
    {
        private OrderManager orderManager { get; set; }
        private IMapper mapper { get; set; }
        public OrderController(OrderManager orderManager, IMapper mapper)
        {
            this.orderManager = orderManager;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Post(OrderModel model)
        {
            //Validations
            // Tax calculation
            var order = mapper.Map<Order>(model);
            //ToDo: add validations
            var response = orderManager.Insert(order);
            return Ok(response);
        }
    }
}
