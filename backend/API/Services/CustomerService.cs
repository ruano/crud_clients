using Domain.Dtos;
using Domain.Model;
using Domain.Repositories;
using Domain.Services;
using Domain.Services.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ServiceResponse<List<CustomerDto>>> List()
        {
            List<Customer> customers = await _customerRepository.ListAsync();

            List<CustomerDto> customersDto = customers.Select(c => new CustomerDto(c)).ToList();

            return new ServiceResponse<List<CustomerDto>>(customersDto);
        }

        public async Task<ServiceResponse<CustomerDto>> Get(int id)
        {
            Customer customer = await _customerRepository.FindByIdAsync(id);

            if (customer == null)
            {
                return new ServiceResponse<CustomerDto>("Cliente não encontrado.");
            }

            return new ServiceResponse<CustomerDto>(new CustomerDto(customer));
        }

        public async Task<ServiceResponse<CustomerDto>> Create(CustomerDto customerDto)
        {
            if (await _customerRepository.FindByNameAsync(customerDto.Name) != null)
            {
                return new ServiceResponse<CustomerDto>($"Já existe um cliente como nome {customerDto.Name}.");
            }

            await _customerRepository.AddAsync(new Customer(customerDto));

            return new ServiceResponse<CustomerDto>();
        }

        public async Task<ServiceResponse<CustomerDto>> Update(int id, CustomerDto customerDto)
        {
            Customer customer = await _customerRepository.FindByIdAsync(id);

            if (customer == null)
            {
                return new ServiceResponse<CustomerDto>("Cliente não encontrado.");
            }

            Customer customerByName = await _customerRepository.FindByNameAsync(customerDto.Name);
            if (customerByName != null && customer.Name != customerByName.Name)
            {
                return new ServiceResponse<CustomerDto>($"Já existe um cliente como nome {customerDto.Name}.");
            }

            customer.Update(customerDto);
            await _customerRepository.UpdateAsync(customer);

            return new ServiceResponse<CustomerDto>();
        }

        public async Task<ServiceResponse<CustomerDto>> Delete(int id)
        {
            Customer customer = await _customerRepository.FindByIdAsync(id);

            if (customer == null)
            {
                return new ServiceResponse<CustomerDto>("Cliente não encontrado.");
            }

            await _customerRepository.RemoveAsync(customer);

            return new ServiceResponse<CustomerDto>();
        }
    }
}