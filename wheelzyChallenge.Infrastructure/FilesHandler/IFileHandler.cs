using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wheelzyChallenge.Infrastructure.FilesHandler
{
    public interface IFileHandler
    {
        string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
        string ReadAllText(string path);
        void WriteAllText(string path, string contents);
        string[] ReadAllLines(string path);
        void WriteAllLines(string path, IEnumerable<string> contents);
    }
}
