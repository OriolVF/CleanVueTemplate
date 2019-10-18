using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;
using MyProject.Persistence;

namespace MyProject.Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
    {
        private readonly MyProjectDbContext _dbContext;

        public GetCustomerQueryHandler(MyProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers
                                   .Include(c => c.Appointments)
                                   .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        }
    }
}