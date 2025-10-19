using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wheelzyChallenge.Application.DTOs;
using wheelzyChallenge.Application.Services.QuoteService;
using wheelzyChallenge.Domain.Entities;

namespace wheelzyChallenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }


        [HttpGet("GetOrders")]
        public async Task<List<OrderDto>> GetOrdersAsync([FromQuery] DateTime? dateFrom,[FromQuery] DateTime? dateTo,[FromQuery] List<int>? customerIds,[FromQuery] List<int>? statusIds,[FromQuery] bool? isActive)
        {
            return await _orderService.GetOrdersAsync(dateFrom, dateTo, customerIds, statusIds, isActive);
        }
    }
}
