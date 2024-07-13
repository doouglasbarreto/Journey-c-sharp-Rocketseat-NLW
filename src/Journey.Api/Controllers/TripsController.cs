﻿using Journey.Communication.Requests;
using Microsoft.AspNetCore.Mvc;
using Journey.Application.UseCases.Trips.Register;
using Journey.Exception.ExceptionsBase;

namespace Journey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterTripJson request)
        {
            try
            {
                var useCase = new RegisterTripUseCase();

                useCase.Execute(request);

                return Created();
            }
            catch (JourneyException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
