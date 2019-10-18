using System;
using MediatR;
using MyProject.Domain.Entities;

namespace MyProject.Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }
}
