using System.IO;
using System.Threading.Tasks;

namespace BreadingBread.Application.Interfaces
{
    public interface IFileService
    {
        Stream GetStreamFile(string hash);
        Task<string> SaveFile(Stream file);
    }
}
