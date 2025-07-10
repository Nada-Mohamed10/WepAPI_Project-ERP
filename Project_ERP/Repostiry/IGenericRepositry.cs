namespace Project_ERP.Repostiry
{
    public interface IGenericRepositry<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByNameAsync(string name);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}