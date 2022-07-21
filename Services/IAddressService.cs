using ResiliencyHttpCallsPolly.Models;

namespace ResiliencyHttpCallsPolly.Services
{
    public interface IAddressService
    {
        Task<ServiceResult<Address>> GetAddressByCepAsync(string cep);
    }
}