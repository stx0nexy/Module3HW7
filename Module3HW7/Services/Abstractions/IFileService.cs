using System.IO;
using System.Threading.Tasks;

namespace Module3HW7.Services.Abstractions
{
    public interface IFileService
    {
        Task WriteAsync(StreamWriter streamWriter, string text);
    }
}
