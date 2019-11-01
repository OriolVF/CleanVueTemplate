using System.Threading;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using MediatR;
using MyProject.Domain.Interfaces;

namespace MyProject.Application.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand>
    {
        private readonly IRepository<Appointment> _repository;

        public CreateAppointmentCommandHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Appointment()
            {
                CustomerId = request.CustomerId,
                Date = request.Date
            };

            await _repository.Add(entity);

            return Unit.Value;
        }
    }
}