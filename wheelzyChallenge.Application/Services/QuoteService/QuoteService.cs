using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Application.DTOs;
using wheelzyChallenge.Domain.Entities;
using wheelzyChallenge.Infrastructure.Repositories;

namespace wheelzyChallenge.Application.Services.QuoteService
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }
        public List<Quote> GetCurrentQuoteByZipCode(int zipCode)
        {
            List<Quote> r = _quoteRepository.GetCurrentQuoteByZipCode(zipCode);
            List<QuoteInfoDto> quoteInfoDtos = new List<QuoteInfoDto>();
            //r.ForEach(r => {
            //    quoteInfoDtos.Add(new QuoteInfoDto
            //    {
            //        Status = r.Orders.FirstOrDefault().Status,
            //        BuyerName = r.Buyer.FullName,
            //        Cars = new List<CarDto>(r.Orders.FirstOrDefault().OrderDetails.ForEach(od => new CarDto{ Make = od.Car.Make, Model = od.Car.Model, SubModel = od.Car.Submodel, Year = od.Car.Year }))
            //    });
            //});
            return r;
        }
    }
}
