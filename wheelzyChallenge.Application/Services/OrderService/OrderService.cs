using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Application.DTOs;
using wheelzyChallenge.Application.Services.QuoteService;
using wheelzyChallenge.Domain.Entities;
using wheelzyChallenge.Infrastructure.Repositories;

namespace wheelzyChallenge.Application.Services.orderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderDto>> GetOrdersAsync(DateTime? dateFrom, DateTime? dateTo, List<int> customerIds, List<int> statusIds, bool? isActive)
        {
            try
            {
                List<Order> orders = await _orderRepository.GetOrdersAsync(dateFrom, dateTo, customerIds, statusIds, isActive);
                List<OrderDto> orderDtos = new List<OrderDto>();

                orders.ForEach(order =>
                {
                    orderDtos.Add(new OrderDto
                    {
                        ZipCode = order.Quote.ZipCodeId,
                        BuyerFullName = order.Quote.Buyer.FullName,
                        Amount = order.Quote.Amount,
                        StatusDescription = order.Status.Description,
                        CreatedDate = order.CreatedDate,
                        Cars = order.OrderDetails.Select(od => new CarDto
                        {
                            Make = od.Car.Make,
                            Model = od.Car.Model,
                            SubModel = od.Car.Submodel,
                            Year = od.Car.Year,
                            OrderHistory = od.OrderHistories
                                .Select(oh => new OrderHistoryDto
                                {
                                    Description = oh.Status.Description,
                                    UpdateDate = oh.UpdateDate
                                }).ToList()
                        }).ToList(),
                    });
                });

                return orderDtos;
            }
            catch (Exception ex)
            {
                return new List<OrderDto>();
            }
        }
    }
}
