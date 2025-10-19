using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestFiles.SubFolder
{
    // Clases para renombrar sufijos
    public class ProductVm
    {
        public string Name { get; set; }
        public CategoryDto Category { get; set; }
    }

    public class CategoryDto
    {
        public string Title { get; set; }
    }

    public class OrdersDtos
    {
        public List<OrderDto> OrderList { get; set; }
    }

    public class OrderDto
    {
        public int Id { get; set; }
    }

    public class Processor
    {
        // Métodos async sin Async
        public async Task ProcessOrder()
        {
            await Task.Delay(100);
            Console.WriteLine("Order processed");
        }

        private async Task LoadData()
        {
            await Task.Delay(50);
            Console.WriteLine("Data loaded");
        }

        // Métodos seguidos sin línea en blanco
        public void MethodA()
        {
            Console.WriteLine("A");
        }
        public void MethodB()
        {
            Console.WriteLine("B");
        }

        // Variables y parámetros
        public void MapToVm(ProductVm productVm, CategoryDto categoryDto)
        {
            var newVm = new ProductVm
            {
                Name = productVm.Name,
                Category = categoryDto
            };
        }

        public List<OrderDto> GetOrders(OrdersDtos ordersDtos)
        {
            var list = new List<OrderDto>();
            foreach (var dto in ordersDtos.OrderList)
            {
                list.Add(dto);
            }
            return list;
        }
    }
}
