using System.Threading;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using MediatR;
using MyProject.Domain.Interfaces;

namespace MyProject.Application.Appointments.Queries.GetAppointment
{
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentCommand, Appointment>
    {
        private readonly IRepository<Appointment> _repository;

        public GetAppointmentQueryHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task<Appointment> Handle(GetAppointmentCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}