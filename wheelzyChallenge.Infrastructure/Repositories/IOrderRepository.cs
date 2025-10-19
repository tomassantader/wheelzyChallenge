using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Entities;
using wheelzyChallenge.Infrastructure.Repositories.Base;

namespace wheelzyChallenge.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<List<Order>> GetOrdersAsync(DateTime? dateFrom,DateTime? dateTo, List<int> customerIds,List<int> statusIds, bool? isActive);
    }
}
