using Dapper_API.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Data = await _orderRepository.GetOrders();
                return Ok(new
                {
                    Success = true,
                    Message = "All orders returned.",
                    Data
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Data = await _orderRepository.GetById(id);
                return Ok(new
                {
                    Success = true,
                    Message = "an order returned.",
                    Data
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDTO createOrderDTO)
        {
            try
            {
                await _orderRepository.Create(createOrderDTO);
                return Ok(new
                {
                    Success = true,
                    Message = "Order item created."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(OrderDTO OrderDTO, int id)
        {
            try
            {
                await _orderRepository.Update(OrderDTO, id);
                return Ok(new
                {
                    Success = true,
                    Message = "Order item updated."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _orderRepository.Delete(id);
                return Ok(new
                {
                    Success = true,
                    Message = "Order item deleted."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("Month/{month}")]
        public async Task<IActionResult> GetByMonth(string month)
        {
            try
            {
                var order = await _orderRepository.GetOrderByCreatedDateMonth(month);
                return Ok(new
                {
                    Success = true,
                    Message = "Order items by Month."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Status/{status}")]
        public async Task<IActionResult> GetByStatus(Status status)
        {
            var order = await _orderRepository.GetByStatus(status);
            return Ok(order);
        }

        [HttpDelete("BulkDelete")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            try
            {
                await _orderRepository.BulkDeleteOrderById(ids);
                return Ok(new
                {
                    Success = true,
                    Message = "Order items deleted."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
