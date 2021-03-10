using Domain.Dtos;
using Domain.Services.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICustomerService
    {
        Task<ServiceResponse<List<CustomerDto>>> List();
        Task<ServiceResponse<CustomerDto>> Get(int id);
        Task<ServiceResponse<CustomerDto>> Create(CustomerDto customerDto);
        Task<ServiceResponse<CustomerDto>> Update(int id, CustomerDto customerDto);
        Task<ServiceResponse<CustomerDto>> Delete(int id);
    }
}