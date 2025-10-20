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
        public List<QuoteInfoDto> GetCurrentQuotes()
        {
            try
            {
                List<Quote> quotes = _quoteRepository.GetCurrentQuotes();
                List<QuoteInfoDto> quoteInfoDtos = new List<QuoteInfoDto>();
                quotes.ForEach(quote =>
                {
                    quoteInfoDtos.Add(new QuoteInfoDto
                    {
                        Status = quote.Orders.FirstOrDefault().Status.Description,
                        BuyerName = quote.Buyer.FullName,
                        Amount = quote.Amount,
                        StatusDate = quote.Orders.FirstOrDefault().OrderDetails.SingleOrDefault().OrderHistories.FirstOrDefault().UpdateDate,
                        Cars = quote.Orders.FirstOrDefault()?.OrderDetails.Select(od => new CarDto { Make = od.Car.Make, Model = od.Car.Model, SubModel = od.Car.Submodel, Year = od.Car.Year }).ToList(),

                    });
                });
                return quoteInfoDtos;

            }
            catch(Exception ex)
            {
                return new List<QuoteInfoDto>();
            }
        }
    }
}
