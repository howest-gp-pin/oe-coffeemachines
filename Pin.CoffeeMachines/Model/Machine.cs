using System.ComponentModel.DataAnnotations;

namespace Pin.CoffeeMachines.Model
{
    public class Machine
    {
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string Color { get; set; }
        public int TimesDefected { get; set; }
    }
}
