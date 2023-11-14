using Pin.CoffeeMachines.Dtos;
using Pin.CoffeeMachines.Model;

namespace Pin.CoffeeMachines.Services
{
    public interface ICoffeeTypeProvider
    {
        Task<List<Bean>> GetAllBeans();
    }
}
