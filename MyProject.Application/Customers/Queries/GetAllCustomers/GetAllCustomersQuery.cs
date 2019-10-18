using System;
using System.Collections.Generic;
using System.Text;
using MyProject.Domain.Entities;
using MediatR;

namespace MyProject.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }
}
