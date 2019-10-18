using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Api.Models;
using MyProject.Application.Customers.Commands.CreateCustomer;
using MyProject.Application.Customers.Queries.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Customers.Queries.GetCustomer;

namespace MyProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<CustomerApiModel>>> GetAll()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(customers.Select(c => new CustomerApiModel(c)));
        }

        [HttpGet("get/{customerId}")]
        public async Task<ActionResult<CustomerApiModel>> Get(Guid customerId)
        {
            var customer = await _mediator.Send(new GetCustomerQuery(){Id = customerId});

            if (customer == null)
                return NotFound();

            return Ok(new CustomerApiModel(customer));
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        //[HttpPost("delete/{CustomerId}")]
        //public async Task<ActionResult> Delete(Guid CustomerId)
        //{
        //    await _CustomerRepository.Delete(CustomerId);
        //    return Ok();
        //}
    }
}