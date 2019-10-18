using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using MyProject.Persistence;
using MediatR;

namespace MyProject.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        private readonly MyProjectDbContext _dbContext;

        public GetAllCustomersQueryHandler(MyProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(()=> _dbContext.Customers, cancellationToken);
        }
    }
}