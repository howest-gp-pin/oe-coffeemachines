using Microsoft.AspNetCore.Components;
using Pin.CoffeeMachines.Model;
using Pin.CoffeeMachines.Services;

namespace Pin.CoffeeMachines.Pages
{
    public partial class Index
    {
        private bool showDeleteMessagebox = false;

        private CoffeeMachine[] displayMachines;
        private CoffeeMachine currentCoffeeMachine = null;

        private CoffeeMachine[] leaderboardMachines;
        private CoffeeMachine[] grayMachines;

        private CoffeeMachine machineToDelete;

        [Inject]
        private ICrudService<CoffeeMachine> coffeeMachineService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            displayMachines = (await coffeeMachineService.GetAll()).ToArray();

            //filtering here should better be done in the service layer!
            leaderboardMachines = displayMachines.OrderByDescending(machine => machine.TimesDefected)
                                                 .Take(3)
                                                 .ToArray();

            grayMachines = displayMachines.Where(machine => machine.Color.ToLower() == "gray" || machine.Color.ToLower() == "grey")
                                          .ToArray();
        }

        private void OnAddCoffeeMachine()
        {
            currentCoffeeMachine = new CoffeeMachine();
        }

        private void OnEditCoffeeMachine(CoffeeMachine editMachine)
        {
            currentCoffeeMachine = editMachine;
        }

        private async void OnDeleteCoffeeMachine(CoffeeMachine deleteMachine)
        {
            machineToDelete = deleteMachine;
            showDeleteMessagebox = true;
        }

        private async void DeleteConfirmed()
        {
            await coffeeMachineService.Delete(machineToDelete.Id);
            displayMachines = (await coffeeMachineService.GetAll()).ToArray();
        }


        private void CancelOperation()
        {
            currentCoffeeMachine = null;
        }

        private async void SaveCoffeeMachine(CoffeeMachine coffeeMachine)
        {
            if (coffeeMachine.Id == Guid.Empty)
            {
                await coffeeMachineService.Create(coffeeMachine);
            }

            else
            {
                await coffeeMachineService.Update(coffeeMachine);
            }

            displayMachines = (await coffeeMachineService.GetAll()).ToArray();
            currentCoffeeMachine = null;

        }
    }
}
