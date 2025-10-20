using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wheelzyChallenge.Application.DTOs;
using wheelzyChallenge.Application.Services.QuoteService;
using wheelzyChallenge.Domain.Entities;

namespace wheelzyChallenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("GetQuotes")]
        public List<QuoteInfoDto> GetCurrentQuotes()
        {

            List<QuoteInfoDto> result = _quoteService.GetCurrentQuotes();
            return result;
        }
    }
}
