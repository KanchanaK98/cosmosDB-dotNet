using Newtonsoft.Json;

namespace CosmosProject.Models
{
    public class Car
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("modle")]
        public string Modle { get; set; }
        [JsonProperty("chassisNumber")]
        public string ChassisNumber { get; set; }
    }
}
