using ResiliencyHttpCallsPolly.Models;

namespace ResiliencyHttpCallsPolly.Services
{
    public class AddressService : IAddressService
    {
        private HttpClient _httpClient;
        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ServiceResult<Address>> GetAddressByCepAsync(string cep)
        {
            if(string.IsNullOrWhiteSpace(cep))
                return new ServiceResult<Address>(false, "Invalid CEP", null);

            try
            {
                var address = await _httpClient.GetFromJsonAsync<Address>($"{cep.Trim()}/json2/");
                return new ServiceResult<Address>(true, null, address);
            }
            catch (System.Exception ex)
            {
                return new ServiceResult<Address>(false, ex.Message, null);
            }
        }
    }
}