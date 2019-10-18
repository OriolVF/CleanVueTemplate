using System;
using MyProject.Domain.Entities;
using MediatR;

namespace MyProject.Application.Appointments.Queries.GetAppointment
{
    public class GetAppointmentCommand : IRequest<Appointment>
    {
        public Guid Id { get; set; }
    }
}
