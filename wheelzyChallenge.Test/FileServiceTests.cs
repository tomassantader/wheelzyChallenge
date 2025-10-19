using Moq;
using System.IO;
using Xunit;
using wheelzyChallenge.Application.Services.FilesService;
using wheelzyChallenge.Infrastructure.FileHandler;

public class FilesServiceTests
{
    private readonly Mock<IFileHandler> _fileHandlerMock;
    private readonly FilesService _service;

    public FilesServiceTests()
    {
        _fileHandlerMock = new Mock<IFileHandler>();
        _service = new FilesService(_fileHandlerMock.Object);
    }

    [Fact]
    public void UpdateAsyncMethods_ShouldRenameMethodsEndingWithoutAsync()
    {
        var filePath = "Test.cs";
        _fileHandlerMock.Setup(f => f.GetFiles(It.IsAny<string>(), "*.cs", SearchOption.AllDirectories))
                       .Returns(new[] { filePath });

        var fileContent = "public async Task DoWork() { }";
        _fileHandlerMock.Setup(f => f.ReadAllText(filePath)).Returns(fileContent);

        var result = _service.UpdateAsyncMethods();

        Assert.True(result);
        _fileHandlerMock.Verify(f => f.WriteAllText(filePath, "public async Task DoWorkAsync() { }"), Times.Once);
    }

    [Fact]
    public void UpdateAsyncMethods_ShouldNotChangeMethodsAlreadyEndingWithAsync()
    {
        var filePath = "Test.cs";
        _fileHandlerMock.Setup(f => f.GetFiles(It.IsAny<string>(), "*.cs", SearchOption.AllDirectories))
                       .Returns(new[] { filePath });

        var fileContent = "public async Task DoWorkAsync() { }";
        _fileHandlerMock.Setup(f => f.ReadAllText(filePath)).Returns(fileContent);

        var result = _service.UpdateAsyncMethods();

        Assert.True(result);
        _fileHandlerMock.Verify(f => f.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void UpdateToUpper_ShouldConvertSuffixToUpperCase()
    {
        var filePath = "Test.cs";
        _fileHandlerMock.Setup(f => f.GetFiles(It.IsAny<string>(), "*.cs", SearchOption.AllDirectories))
                       .Returns(new[] { filePath });

        var fileContent = "public class UserVm { }";
        _fileHandlerMock.Setup(f => f.ReadAllText(filePath)).Returns(fileContent);

        var result = _service.UpdateToUpper();

        Assert.True(result);
        _fileHandlerMock.Verify(f => f.WriteAllText(filePath, "public class UserVM { }"), Times.Once);
    }

    [Fact]
    public void UpdateToUpper_ShouldNotChangeIfAlreadyUpper()
    {
        var filePath = "Test.cs";
        _fileHandlerMock.Setup(f => f.GetFiles(It.IsAny<string>(), "*.cs", SearchOption.AllDirectories))
                       .Returns(new[] { filePath });

        var fileContent = "public class UserDTO { }";
        _fileHandlerMock.Setup(f => f.ReadAllText(filePath)).Returns(fileContent);

        var result = _service.UpdateToUpper();

        Assert.True(result);
        _fileHandlerMock.Verify(f => f.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void UpdateBlankLine_ShouldInsertBlankLineAfterClosingBrace()
    {
        var filePath = "Test.cs";
        _fileHandlerMock.Setup(f => f.GetFiles(It.IsAny<string>(), "*.cs", SearchOption.AllDirectories))
                       .Returns(new[] { filePath });

        var lines = new[]
        {
                "public class TestClass",
                "{",
                "    public void Method1() { }",
                "}",
                "public void Method2() { }"
            };

        _fileHandlerMock.Setup(f => f.ReadAllLines(filePath)).Returns(lines);

        var result = _service.UpdateBlankLine();

        Assert.True(result);

        _fileHandlerMock.Verify(f => f.WriteAllLines(filePath,
            It.Is<IEnumerable<string>>(l => l.Contains("") && l.Count() == 6)
        ), Times.Once);
    }

    [Fact]
    public void UpdateBlankLine_ShouldNotAddBlankIfAlreadyPresent()
    {
        var filePath = "Test.cs";
        _fileHandlerMock.Setup(f => f.GetFiles(It.IsAny<string>(), "*.cs", SearchOption.AllDirectories))
                       .Returns(new[] { filePath });

        var lines = new[]
        {
                "public class TestClass",
                "{",
                "    public void Method1() { }",
                "}",
                "",
                "public void Method2() { }"
            };

        _fileHandlerMock.Setup(f => f.ReadAllLines(filePath)).Returns(lines);

        var result = _service.UpdateBlankLine();

        Assert.True(result);

        _fileHandlerMock.Verify(f => f.WriteAllLines(It.IsAny<string>(), It.IsAny<IEnumerable<string>>()), Times.Once);
    }
}
