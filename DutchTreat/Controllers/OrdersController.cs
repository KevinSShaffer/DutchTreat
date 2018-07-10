using DutchTreat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository dutchRepository;
        private readonly ILogger<DutchRepository> logger;

        public OrdersController(IDutchRepository dutchRepository, ILogger<DutchRepository> logger)
        {
            this.dutchRepository = dutchRepository;
            this.logger = logger;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(dutchRepository.GetAllOrders());
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = dutchRepository.GetOrderById(id);

                if (order == null)
                    return NotFound();
                else
                    return Ok(order);
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get order: {ex}");
                return BadRequest("Failed to get order");
            }
        }
    }
}
