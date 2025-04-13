public class FileRepositoryCreator(){
    public static string CreateClass(){
        return @"
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
namespace Global;
public class FileRepository(IWebHostEnvironment webHostEnvironment) : IFileRepository{
    public async Task<string> Save(IFormFile file){
            var path = $""/Files/{Path.GetRandomFileName()}.{file.FileName.Split('.')[1]}"";
            using (var fileStream = new FileStream($""{webHostEnvironment.WebRootPath}{path}"", FileMode.Create))
            {{
                await file.CopyToAsync(fileStream);
            }}
            return path;
    }
}
        ";
    }

    public static string CreateInterface(){
        return @"
using Microsoft.AspNetCore.Http;
namespace Global;
public interface IFileRepository{
    public Task<string> Save(IFormFile file);
}
        ";
    }
}