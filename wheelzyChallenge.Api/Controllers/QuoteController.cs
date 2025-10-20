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
        private readonly ILogger<QuoteController> _logger;

        public QuoteController(ILogger<QuoteController> logger, IQuoteService quoteService)
        {
            _logger = logger;
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
