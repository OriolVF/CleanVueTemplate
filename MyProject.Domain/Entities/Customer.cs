using System;
using System.Collections.Generic;

namespace MyProject.Domain.Entities
{
    public class Customer 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
