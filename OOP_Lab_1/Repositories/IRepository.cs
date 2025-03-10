public interface IRepository<T>{
    void SaveChanges();
    public List<T> GetList();
}