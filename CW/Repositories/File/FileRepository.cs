
        public class FileRepository{
            public async Task<string> Save(IFormFile file){
                var path = "/Files/{Path.GetRandomFileName()}.{file.FileName.Split('.')[1]}";
                using (var fileStream = new FileStream($"{{webHostEnvironment.WebRootPath}}", FileMode.Create))
                {{
                    await file.CopyToAsync(fileStream);
                }}
                return path;
            }
        }
        