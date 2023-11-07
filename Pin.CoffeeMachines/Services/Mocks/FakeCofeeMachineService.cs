using Pin.CoffeeMachines.Model;
using System.Runtime.InteropServices;

namespace Pin.CoffeeMachines.Services.Mocks
{
    public class FakeCofeeMachineService : ICrudService<CoffeeMachine>
    {
        private static readonly List<CoffeeMachine> coffeeMachines = new List<CoffeeMachine>() 
        {
            new CoffeeMachine { Id = Guid.NewGuid(), Description = "Machine DAD", Color = "Black", TimesDefected = 3 },
            new CoffeeMachine { Id = Guid.NewGuid(), Description = "Machine Lectorenlokaal", Color = "#eeaaee", TimesDefected = 7 },
            new CoffeeMachine { Id = Guid.NewGuid(), Description = "Machine P", Color = "Gray", TimesDefected = 2 },
        };

        public Task Create(CoffeeMachine item)
        {
            item.Id = Guid.NewGuid();
            coffeeMachines.Add(item);

            return Task.CompletedTask;
        }

        public async Task Delete(Guid id)
        {
            var deleteMachine = await Get(id);
            coffeeMachines.Remove(deleteMachine);
        }

        public Task<CoffeeMachine> Get(Guid id)
        {
            return Task.FromResult(coffeeMachines.FirstOrDefault(machine => machine.Id.Equals(id)));
        }

        public Task<IEnumerable<CoffeeMachine>> GetAll()
        {
            return Task.FromResult(coffeeMachines.AsEnumerable());
        }

        public async Task Update(CoffeeMachine item)
        {
            var existingMachine = await Get(item.Id);

            existingMachine.TimesDefected = item.TimesDefected;
            existingMachine.Description = item.Description;
            existingMachine.Color = item.Color;
        }
    }
}
