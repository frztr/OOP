
namespace Global;
public interface IAccountService
    {
        public AccountListDto GetAll(int count = 50, int offset = 0);

        public AccountDto GetById(int id);

        public AccountDto Add(AddAccountDto addDto);

        public void Delete(int id);

        public void Update(UpdateAccountDto updateDto);
    }