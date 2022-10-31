using System;
using System.IO;
using Module3HW7.Services.Abstractions;

namespace Module3HW7.Services
{
    public class BackUpService : IBackUpService
    {
        private readonly IFileService _fileService;
        private StreamWriter _streamWriter;
        private string _backUpPath;

        public BackUpService(IFileService fileService, IConfigService configService)
        {
            _backUpPath = configService.Config.BackUpPath;

            if (!Directory.Exists(_backUpPath))
            {
                Directory.CreateDirectory(_backUpPath);
            }

            _fileService = fileService;
        }

        public async void AddBackUpAsync(string text)
        {
            string nameFile = DateTime.UtcNow.ToString("yyyyMMdd_HH_mm_ss_fffff");
            nameFile = Path.Combine(_backUpPath, $"{nameFile}.txt");
            _streamWriter = new StreamWriter(nameFile);
            await _fileService.WriteAsync(_streamWriter, text);
        }
    }
}