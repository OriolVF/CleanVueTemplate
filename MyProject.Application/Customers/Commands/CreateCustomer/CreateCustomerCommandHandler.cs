using System.Threading;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using MyProject.Persistence;
using MediatR;

namespace MyProject.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly MyProjectDbContext _dbContext;

        public CreateCustomerCommandHandler(MyProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var CustomerEntity = new Customer()
            {
                Age = request.Age,
                Name = request.Name,
                Surname = request.Surname,
            };

            _dbContext.Customers.Add(CustomerEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
