
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class MessageRepository(AppDbContext db) : IMessageRepository
{ 
    DbSet<Message> set = db.Set<Message>();
    public async Task<MessageRepositoryDto> AddAsync(AddMessageRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMessageRepositoryDto, Message>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddMessageRepositoryDto, Message>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Message,MessageRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Message,MessageRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Message>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<MessageListRepositoryDto> GetAllAsync(MessageQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Message,MessageRepositoryDto>());
        var mapper = new Mapper(config);
        return new MessageListRepositoryDto()
        {
            Items = mapper.Map<List<MessageRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<MessageRepositoryDto> GetByIdAsync(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Message,MessageRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Message>(new {id});
        return mapper.Map<Message,MessageRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateMessageRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Message>(new {Id = updateDto.Id});
		if(updateDto.SenderId.HasValue){
            entity.SenderId = updateDto.SenderId.Value;
        }

		if(updateDto.ReceiverId.HasValue){
            entity.ReceiverId = updateDto.ReceiverId.Value;
        }

		if(!String.IsNullOrEmpty(updateDto.Content)){
            entity.Content = updateDto.Content;
        }




        await db.SaveChangesAsync();
    }
}