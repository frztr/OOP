
using Microsoft.EntityFrameworkCore;
namespace Global;
public class AccountRepository(AppDbContext db) : IAccountRepository
{ 
    DbSet<Account> set = db.Set<Account>();
    public AccountDto Add(AddAccountDto addDto)
    {  
        Account entity = new Account(){
			FamilyId = addDto.FamilyId,
			Name = addDto.Name,
			Balance = addDto.Balance,
			Currency = addDto.Currency
        };
        set.Add(entity);
        db.SaveChanges();
        return new AccountDto(){
			Id = entity.Id,
			FamilyId = entity.FamilyId,
			Name = entity.Name,
			Balance = entity.Balance,
			Currency = entity.Currency
        };
    }

    public void Delete(int id)
    {
        set.ToList().Remove(set.FirstOrDefault(x => x.Id == id));
        db.SaveChanges();
    }

    public AccountListDto GetAll(int count = 50, int offset = 0)
    {
        return new AccountListDto()
        {
            items = set.Skip(offset).Take(count < 50 ? count : 50).ToList().Select(x => new AccountDto(){
				Id = x.Id,
				FamilyId = x.FamilyId,
				Name = x.Name,
				Balance = x.Balance,
				Currency = x.Currency
            })
        };
    }

    public AccountDto GetById(int id)
    {
        var entity = set.FirstOrDefault(x => x.Id == id);
        return new AccountDto(){
			Id = entity.Id,
			FamilyId = entity.FamilyId,
			Name = entity.Name,
			Balance = entity.Balance,
			Currency = entity.Currency
        };
    }

    public void Update(UpdateAccountDto updateDto)
    {
        var entity = set.FirstOrDefault(x => x.Id == updateDto.Id);
		if(updateDto.FamilyId.HasValue){
            entity.FamilyId = updateDto.FamilyId.Value;
        }
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }
		if(updateDto.Balance.HasValue){
            entity.Balance = updateDto.Balance.Value;
        }
		if(!String.IsNullOrEmpty(updateDto.Currency)){
            entity.Currency = updateDto.Currency;
        }
        db.SaveChanges();
    }
}