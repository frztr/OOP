
namespace Global;
public interface IAutomechanicService
    {
        public Task<AutomechanicListServiceDto> GetAllAsync(short count = 50, short offset = 0);

        public Task<AutomechanicServiceDto> GetByIdAsync(short id);

        public Task<AutomechanicServiceDto> AddAsync(AddAutomechanicServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateAutomechanicServiceDto updateDto);
    }