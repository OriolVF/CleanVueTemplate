using System;
using System.Collections.Generic;

namespace MyProject.Domain.Entities
{
    public class Customer : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
