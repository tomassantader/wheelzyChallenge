using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Entities;
using wheelzyChallenge.Infrastructure.Repositories.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace wheelzyChallenge.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Order>> GetOrdersAsync(DateTime? dateFrom, DateTime? dateTo, List<int> customerIds, List<int> statusIds, bool? isActive)
        {
            try
            {
                var query = DbContext.Set<Order>()
                    .Include(o => o.Quote)
                        .ThenInclude(q => q.Buyer)
                    .Include(o => o.Status)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Car)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.OrderHistories)
                            .ThenInclude(oh => oh.Status)
                    .AsQueryable();

                if (dateFrom.HasValue)
                    query = query.Where(o => o.CreatedDate >= dateFrom.Value);

                if (dateTo.HasValue)
                    query = query.Where(o => o.CreatedDate <= dateTo.Value);

                if (customerIds is { Count: > 0 })
                    query = query.Where(o => customerIds.Contains(o.Quote.BuyerId));

                if (statusIds is { Count: > 0 })
                    query = query.Where(o => statusIds.Contains(o.Status.Id));

                if (isActive.HasValue)
                    query = query.Where(o => o.IsActive == isActive.Value);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Order>();
            }
        }
    }
}
