using Domain.Dtos;
using Domain.Services;
using Domain.Services.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/customers")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;

        public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ServiceResponse<List<CustomerDto>> customerResponse = await _customerService.List();

            return Ok(customerResponse.Resource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ServiceResponse<CustomerDto> customerResponse = await _customerService.Get(id);

            if (!customerResponse.Success)
            {
                return NotFound(customerResponse.Message);
            }

            return Ok(customerResponse.Resource);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto customerDto)
        {
            ServiceResponse<CustomerDto> customerResponse = await _customerService.Create(customerDto);

            if (!customerResponse.Success)
            {
                return UnprocessableEntity(customerResponse.Message);
            }

            return CreatedAtAction(nameof(Create), customerResponse.Resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerDto customerDto)
        {
            ServiceResponse<CustomerDto> customerResponse = await _customerService.Update(id, customerDto);

            if (!customerResponse.Success)
            {
                return UnprocessableEntity(customerResponse.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<CustomerDto> customerResponse = await _customerService.Delete(id);

            if (!customerResponse.Success)
            {
                return NotFound(customerResponse.Message);
            }

            return NoContent();
        }
    }
}