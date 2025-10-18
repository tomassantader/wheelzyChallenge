using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Application.DTOs;
using wheelzyChallenge.Domain.Entities;

namespace wheelzyChallenge.Application.Services.QuoteService
{
    public interface IQuoteService
    {
        List<Quote> GetCurrentQuoteByZipCode(int zipCode);
    }
}
