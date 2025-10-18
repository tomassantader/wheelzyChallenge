using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Entities;
using wheelzyChallenge.Infrastructure.Repositories.Base;

namespace wheelzyChallenge.Infrastructure.Repositories
{
    public class QuoteRepository : Repository<Quote> , IQuoteRepository
    {
        public QuoteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public List<Quote> GetCurrentQuoteByZipCode(int zipCode)
        {

            var result = DbContext.Set<Quote>()
                .Where(x => x.IsCurrent)
                .Select(x => new Quote
                {
                    Id = x.Id,
                    ZipCodeId = x.ZipCodeId,
                    Buyer = new Buyer
                    {
                        FullName = x.Buyer.FullName
                    },
                    Amount = x.Amount,
                    Orders = x.Orders.Select(o => new Order
                    {
                        Status = o.Status,
                        OrderDetails = o.OrderDetails.Select(od => new OrderDetail
                        {
                            Car = new Car
                            {
                                Make = od.Car.Make,
                                Model = od.Car.Model,
                                Submodel = od.Car.Submodel,
                                Year = od.Car.Year,
                            },
                            PickedUpDate = od.PickedUpDate,
                            OrderHistories = od.OrderHistories.OrderByDescending(oh => oh.UpdateDate).Take(1).ToList()
                        }).ToList()
                    }).ToList()
                }).ToList();

            return result;
        }
    }

}
