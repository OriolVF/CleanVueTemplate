using System.Collections.Generic;
using MediatR;
using MyProject.Domain.Entities;

namespace MyProject.Application.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQuery : IRequest<IEnumerable<Appointment>>
    {
    }
}
