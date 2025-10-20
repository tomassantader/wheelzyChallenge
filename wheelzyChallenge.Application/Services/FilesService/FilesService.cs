using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using wheelzyChallenge.Infrastructure.FilesHandler;
using wheelzyChallenge.Infrastructure.Repositories;

namespace wheelzyChallenge.Application.Services.FilesService
{
    public class FilesService : IFileService
    {
        private readonly string _rootPath;
        private readonly IFileHandler _fileHandler;
        public FilesService(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
            _rootPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.FullName, "TestFiles");
        }

        public bool UpdateAsyncMethods()
        {
            var files = _fileHandler.GetFiles(_rootPath, "*.cs", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var text = _fileHandler.ReadAllText(file);

                var pattern = @"async\s+(?:Task|ValueTask)(?:<[^>]+>)?\s+([A-Za-z0-9_]+)\s*\(";
                var replaced = Regex.Replace(text, pattern, match =>
                {
                    var methodName = match.Groups[1].Value;
                    if (!methodName.EndsWith("Async"))
                    {
                        return match.Value.Replace(methodName, methodName + "Async");
                    }
                    return match.Value;
                });

                if (replaced != text)
                    _fileHandler.WriteAllText(file, replaced); 
            }

            return true;
        }

        public bool UpdateToUpper()
        {
            var files = _fileHandler.GetFiles(_rootPath, "*.cs", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var text = _fileHandler.ReadAllText(file);

                var pattern = @"\b([A-Za-z0-9_]+)(Vm|Dto)";
                var replaced = Regex.Replace(text, pattern, match =>
                {
                    var prefix = match.Groups[1].Value;
                    var suffix = match.Groups[2].Value;
                    return prefix + suffix.ToUpper();
                });

                if (replaced != text)
                    _fileHandler.WriteAllText(file, replaced);
            }

            return true;
        }

        public bool UpdateBlankLine()
        {
            var files = _fileHandler.GetFiles(_rootPath, "*.cs", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var lines = _fileHandler.ReadAllLines(file).ToList();
                var newLines = new List<string>();

                for (int i = 0; i < lines.Count; i++)
                {
                    newLines.Add(lines[i]);

                    if (lines[i].Trim() == "}" &&
                        i + 1 < lines.Count &&
                        Regex.IsMatch(lines[i + 1], @"^\s*(public|private|protected|internal)\s"))
                    {
                        if (i > 0 && !string.IsNullOrWhiteSpace(lines[i - 1]))
                            newLines.Add("");
                    }
                }

                _fileHandler.WriteAllLines(file, newLines);
            }

            return true;
        }
    }
}
