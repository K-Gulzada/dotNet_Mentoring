using Dapper_API.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.enums;

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
            var Data = await _orderRepository.GetOrders();
            return Ok(new
            {
                Success = true,
                Message = "All orders returned.",
                Data
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Data = await _orderRepository.GetById(id);
            return Ok(new
            {
                Success = true,
                Message = "an order returned.",
                Data
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order createOrderDTO)
        {
            await _orderRepository.Create(createOrderDTO);
            return Ok(new
            {
                Success = true,
                Message = "Order item created."
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Order OrderDTO, int id)
        {
            await _orderRepository.Update(OrderDTO, id);
            return Ok(new
            {
                Success = true,
                Message = "Order item updated."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderRepository.Delete(id);
            return Ok(new
            {
                Success = true,
                Message = "Order item deleted."
            });
        }

        [HttpGet("Month/{month}")]
        public async Task<IActionResult> GetByMonth(string month)
        {
            var order = await _orderRepository.GetOrderByCreatedDateMonth(month);
            return Ok(new
            {
                Success = true,
                Message = "Order items by Month."
            });
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
            await _orderRepository.BulkDeleteOrderById(ids);
            return Ok(new
            {
                Success = true,
                Message = "Order items deleted."
            });
        }
    }
}
