using Pin.CoffeeMachines.Dtos;
using Pin.CoffeeMachines.Model;

namespace Pin.CoffeeMachines.Services
{
    public class ApiCoffeeProvider : ICoffeeTypeProvider
    {
        private readonly HttpClient httpClient;

        public ApiCoffeeProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Bean>> GetAllBeans()
        {
            var dtos = await httpClient.GetFromJsonAsync<List<CoffeeDto>>("https://coffee-type-api.web.app/coffee");
            var beans = dtos.Select(dto => new Bean
            {
                Name = dto.Type
            }).ToList();

            return beans;
        }
    }
}
