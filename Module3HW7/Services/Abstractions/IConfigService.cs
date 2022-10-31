using System.Threading.Tasks;
using Module3HW7.Models;

namespace Module3HW7.Services.Abstractions
{
    public interface IConfigService
    {
        Config Config { get; set; }
        Task SaveConfigAsync();
        Task LoadConfig();
    }
}
