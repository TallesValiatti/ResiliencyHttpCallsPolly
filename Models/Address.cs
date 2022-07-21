#nullable disable
using System.Text.Json.Serialization;

namespace ResiliencyHttpCallsPolly.Models
{
    public class Address
    {
        [JsonPropertyName("cep")]
        public string Cep { get; set; }
        
        [JsonPropertyName("logradouro")]
        public string Street { get; set; }
        
        [JsonPropertyName("localidade")]
        public string City { get; set; }
        
        [JsonPropertyName("uf")]
        public string State { get; set; }
    }
}