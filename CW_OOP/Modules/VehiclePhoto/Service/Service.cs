
using VehiclePhoto.DTO;

namespace VehiclePhoto;

public class Service(IRepository repository,
IWebHostEnvironment appEnv) : IService
{
    public EntityListDto Add(AddServiceDto addDto)
    {
        List<EntityDto> dtos = new List<EntityDto>();
        Task.Run(async () =>
        {
            List<Task> tasks = new List<Task>();
            foreach (var photo in addDto.photos)
            {
                tasks.Add(Task.Run(async () =>
                {
                    string path = "/photos/" + photo.FileName;
                    using (var fileStream = new FileStream(appEnv.WebRootPath + path, FileMode.Create))
                    {
                        await photo.CopyToAsync(fileStream);
                    }
                    dtos.Add(repository.Add(new AddDto()
                    {
                        Src = path,
                        VehicleId = addDto.VehicleId
                    }));
                }));

            }
            await Task.WhenAll(tasks);

        }).GetAwaiter().GetResult();
        return new EntityListDto()
        {
            items = dtos
        };
    }

    public void Delete(int id)
    {
        repository.Delete(id);
    }

    public EntityListDto GetByVehicleId(int id)
    {
        return repository.GetByVehicleId(id);
    }
}