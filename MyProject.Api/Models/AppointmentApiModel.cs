using System;
using MyProject.Domain.Entities;

namespace MyProject.Api.Models
{
    public class AppointmentApiModel
    {
        public AppointmentApiModel(Appointment appointment)
        {
            Id = appointment.Id;
            CustomerId = appointment.CustomerId;
            Date = appointment.Date;
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
    }
}