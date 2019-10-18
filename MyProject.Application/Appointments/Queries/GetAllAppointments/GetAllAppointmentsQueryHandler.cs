using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;

namespace MyProject.Application.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, IEnumerable<Appointment>>
    {
        private readonly IRepository<Appointment> _repository;

        public GetAllAppointmentsQueryHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}