using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Module3HW7.Services.Abstractions;

namespace Module3HW7.Services
{
    public class FileService : IFileService
    {
        private SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);
        private string _logPath;

        public FileService(IConfigService configService)
        {
            _logPath = configService.Config.LogPath;

            if (!Directory.Exists(_logPath))
            {
                Directory.CreateDirectory(_logPath);
            }
        }

        public async Task WriteAsync(StreamWriter streamWriter, string text)
        {
            await _semaphoreSlim.WaitAsync();
            await streamWriter.WriteLineAsync(text);
            await streamWriter.FlushAsync();
            _semaphoreSlim.Release();
        }
    }
}