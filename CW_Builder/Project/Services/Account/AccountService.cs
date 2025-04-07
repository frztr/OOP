
namespace Global;
public class AccountService(IAccountRepository repository) : IAccountService
{
    public AccountDto Add(AddAccountDto addDto)
    {
        return repository.Add(addDto);
    }

    public void Delete(int id)
    {
        repository.Delete(id);
    }

    public AccountListDto GetAll(int count = 50, int offset = 0)
    {
        return repository.GetAll(count, offset);
    }

    public AccountDto GetById(int id)
    {
        return repository.GetById(id);
    }

    public void Update(UpdateAccountDto updateDto)
    {
        repository.Update(updateDto);
    }
}