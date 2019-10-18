using System.Threading;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using MyProject.Persistence;
using MediatR;

namespace MyProject.Application.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand>
    {
        private readonly MyProjectDbContext _dbContext;

        public CreateAppointmentCommandHandler(MyProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Appointment()
            {
                CustomerId = request.CustomerId,
                Date = request.Date
            };

            _dbContext.Appointments.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}