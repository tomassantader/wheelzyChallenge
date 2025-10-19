using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wheelzyChallenge.Application.Services.FilesService
{
    public interface IFileService
    {
        public bool UpdateAsyncMethods();

        public bool UpdateToUpper();

        public bool UpdateBlankLine();
    }
}
