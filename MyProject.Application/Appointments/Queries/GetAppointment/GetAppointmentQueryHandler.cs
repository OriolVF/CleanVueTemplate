using System.Threading;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using MyProject.Persistence;
using MediatR;

namespace MyProject.Application.Appointments.Queries.GetAppointment
{
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentCommand, Appointment>
    {
        private readonly MyProjectDbContext _dbContext;

        public GetAppointmentQueryHandler(MyProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Appointment> Handle(GetAppointmentCommand request, CancellationToken cancellationToken)
        {
            return await _dbContext.Appointments.FindAsync(request.Id);
        }
    }
}