using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyProject.Domain.Entities;
using MyProject.Persistence;

namespace MyProject.Application.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, IEnumerable<Appointment>>
    {
        private readonly MyProjectDbContext _dbContext;

        public GetAllAppointmentsQueryHandler(MyProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _dbContext.Appointments, cancellationToken);
        }
    }
}