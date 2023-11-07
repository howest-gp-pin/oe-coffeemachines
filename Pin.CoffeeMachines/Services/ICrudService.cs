namespace Pin.CoffeeMachines.Services
{
    public interface ICrudService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(Guid id);
    }
}
