using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using MediatR;
using MyProject.Domain.Interfaces;

namespace MyProject.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        private readonly IRepository<Customer> _repository;

        public GetAllCustomersQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}