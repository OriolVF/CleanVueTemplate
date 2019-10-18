using System.Threading;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using MediatR;
using MyProject.Domain.Interfaces;

namespace MyProject.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly IRepository<Customer> _repository;

        public CreateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = new Customer()
            {
                Age = request.Age,
                Name = request.Name,
                Surname = request.Surname,
            };

            await _repository.Add(customerEntity);

            return Unit.Value;
        }
    }
}
