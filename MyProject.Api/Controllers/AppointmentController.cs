using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Api.Models;
using MyProject.Application.Appointments.Commands.CreateAppointment;
using MyProject.Application.Appointments.Queries.GetAppointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Appointments.Queries.GetAllAppointments;

namespace MyProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<AppointmentApiModel>>> GetAll()
        {
            var appointments = await _mediator.Send(new GetAllAppointmentsQuery());
            return Ok(appointments.Select(v => new AppointmentApiModel(v)));
        }

        [HttpGet("get/{AppointmentId}")]
        public async Task<ActionResult<AppointmentApiModel>> Get(Guid appointmentId)
        {
            var appointment = await _mediator.Send(new GetAppointmentCommand()
            {
                Id = appointmentId
            });

            if (appointment == null)
                return NotFound();

            return Ok(new AppointmentApiModel(appointment));
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateAppointmentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        //[HttpPost("delete/{AppointmentId}")]
        //public async Task<ActionResult> Delete(Guid AppointmentId)
        //{
        //    await _AppointmentRepository.Delete(AppointmentId);
        //    return Ok();
        //}
    }
}