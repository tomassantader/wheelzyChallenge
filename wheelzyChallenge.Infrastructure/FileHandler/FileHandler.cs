using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wheelzyChallenge.Infrastructure.FileHandler
{
    public class FileHandler : IFileHandler
    {
        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        => Directory.GetFiles(path, searchPattern, searchOption);

        public string ReadAllText(string path) => File.ReadAllText(path);

        public void WriteAllText(string path, string contents) => File.WriteAllText(path, contents);

        public string[] ReadAllLines(string path) => File.ReadAllLines(path);

        public void WriteAllLines(string path, IEnumerable<string> contents) => File.WriteAllLines(path, contents);
    }
}
