using System.ComponentModel.DataAnnotations;

namespace Pin.CoffeeMachines.Model
{
    public class CoffeeMachine
    {
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string Color { get; set; }
        public int TimesDefected { get; set; }
    }
}
