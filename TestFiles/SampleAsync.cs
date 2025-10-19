using System.Threading.Tasks;

namespace TestFiles
{
    public class SampleAsync
    {
        public async Task GetData()
        {
            await Task.Delay(1000);
        }

        public async Task<string> LoadSomethingAsync()
        {
            return await Task.FromResult("ok");
        }

        private async Task Process()
        {
            await Task.Delay(100);
        }
    }
}
