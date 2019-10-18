using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Domain.Entities;

namespace MyProject.Api.Models
{
    public class CustomerApiModel
    {
        public CustomerApiModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Surname = customer.Surname;
            Age = customer.Age;
            Appointments = customer.Appointments?.Select(v => new AppointmentApiModel(v));
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public IEnumerable<AppointmentApiModel> Appointments { get; set; }
    }

}
