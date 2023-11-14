using System.Text.Json.Serialization;

namespace Pin.CoffeeMachines.Dtos
{
    public class CoffeeDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
