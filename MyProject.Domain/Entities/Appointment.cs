using System;

namespace MyProject.Domain.Entities
{
    public class Appointment : IEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
    }
}
