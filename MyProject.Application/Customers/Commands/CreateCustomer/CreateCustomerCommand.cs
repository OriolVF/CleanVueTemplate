using System;
using MediatR;

namespace MyProject.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}