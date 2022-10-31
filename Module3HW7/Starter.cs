using System;
using System.IO;
using System.Threading.Tasks;
using Module3HW7.Services.Abstractions;

namespace Module3HW7
{
    public class Starter
    {
        private StreamWriter _streamWriter;
        private string _logName = "Log.txt";
        public Starter(ILogger logger, IBackUpService backUpService, IConfigService configService)
        {
            Logger = logger;
            BackUpService = backUpService;
            _streamWriter = new StreamWriter(Path.Combine(configService.Config.LogPath, _logName));
        }

        public ILogger Logger { get; }
        public IBackUpService BackUpService { get; }
        public async Task Run()
        {
            Logger.MakeBackUp += BackUpService.AddBackUpAsync;
            var task1 = Task.Run(async () => await MakeLogAsync(50));
            var task2 = Task.Run(async () => await MakeLogAsync(50));
            await Task.WhenAll(task1, task2);
        }

        public async Task MakeLogAsync(int countLogs)
        {
            var rnd = new Random();
            for (var i = 0; i < countLogs; i++)
            {
                await Logger.Log((Type)rnd.Next(3), _streamWriter, $"{i}");
            }
        }
    }
}
