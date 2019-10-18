using System;
using MediatR;

namespace MyProject.Application.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
    }
}
