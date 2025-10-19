using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wheelzyChallenge.Application.DTOs;
using wheelzyChallenge.Application.Services.FilesService;
using wheelzyChallenge.Domain.Entities;

namespace wheelzyChallenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly ILogger<FilesController> _logger;

        public FilesController(ILogger<FilesController> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        [HttpGet("UpdateAsyncMethods")]
        public bool UpdateAsyncMethods( )
        {
            return _fileService.UpdateAsyncMethods();
        }

        [HttpGet("UpdateToUpper")]
        public bool UpdateToUpper()
        {
            return _fileService.UpdateToUpper();
        }

        [HttpGet("UpdateBlankLine")]
        public bool UpdateBlankLine()
        {
            return _fileService.UpdateBlankLine();
        }
    }
}
