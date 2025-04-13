
using Microsoft.AspNetCore.Http;
namespace Global;
public interface IFileRepository{
    public Task<string> Save(IFormFile file);
}
        