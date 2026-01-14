using activity_scheduling.application.Commands;
using activity_scheduling.application.Commands.AntecipateActivityInDays;
using activity_scheduling.application.Commands.AntecipateActivityInHours;
using activity_scheduling.application.Commands.AntecipateActivityInMinutes;
using activity_scheduling.application.Commands.CancelActivity;
using activity_scheduling.application.Commands.CompleteActivity;
using activity_scheduling.application.Commands.CreateActivity;
using activity_scheduling.application.Commands.ExtendActivityInDays;
using activity_scheduling.application.Commands.ExtendActivityInHours;
using activity_scheduling.application.Commands.ExtendActivityInMinutes;
using activity_scheduling.application.Queries.GetActivityById;
using activity_scheduling.application.Queries.GetActivityByState;
using activity_scheduling.application.Queries.GetAllActivities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace activity_scheduling_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(statusCode: 500, type: typeof(GenericCommandResult))]
    public class ActivityController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public ActivityController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(statusCode: 201, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 401, type: typeof(GenericCommandResult))]
        public async Task<ActionResult<GenericCommandResult>> CreateActivity([FromBody] CreateActivityCommand command)
        {
            try
            {
                var operationResult = await _Mediator.Send(command);
                return StatusCode((int)operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }

        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [HttpGet("")]
        public async Task<ActionResult<GenericCommandResult>> GetAllActivities()
        {
            try
            {
                var operationResult = await _Mediator.Send(new GetAllActivities());
                return StatusCode((int)operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }


        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 404, type: typeof(GenericCommandResult))]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<GenericCommandResult>> GetActivityById([FromRoute] Guid id)
        {
            try
            {
                var operationResult = await _Mediator.Send(new GetActivityById(id));
                return StatusCode((int)operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }

        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [HttpGet("state/{value:int}")]
        public async Task<ActionResult<GenericCommandResult>> GetActivityByState([FromRoute] int value)
        {
            try
            {
                var operationResult = await _Mediator.Send(new GetActivityByState(value));
                return StatusCode((int)operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }


        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 401, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 404, type: typeof(GenericCommandResult))]
        [HttpPut("extend/days")]
        public async Task<ActionResult<GenericCommandResult>> ExtendActivityIndays([FromBody] ExtendActivityInDaysCommand command)
        {
            try
            {
                var operationResult = await _Mediator.Send(command);
                return StatusCode((int) operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro inesperado");
            }
        }

        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 401, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 404, type: typeof(GenericCommandResult))]
        [HttpPut("extend/hours")]
        public async Task<ActionResult<GenericCommandResult>> ExtendActivityInHours([FromBody] ExtendActivityInHoursCommand command)
        {
            try
            {
                var operationResult = await _Mediator.Send(command);
                return StatusCode((int) operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro inesperado");
            }
        }

        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 401, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 404, type: typeof(GenericCommandResult))]
        [HttpPut("extend/minutes")]
        public async Task<ActionResult<GenericCommandResult>> ExtendActivityInMinutes([FromBody] ExtendActivityInMinutesCommand command)
        {
            try
            {
                var operationResult = await _Mediator.Send(command);
                return StatusCode((int) operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro inesperado");
            }
        }

        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 401, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 404, type: typeof(GenericCommandResult))]
        [HttpPut("antecipate/days")]
        public async Task<ActionResult<GenericCommandResult>> AntecipateActivityIndays([FromBody] AntecipateActivityInDaysCommand command)
        {
            try
            {
                var operationResult = await _Mediator.Send(command);
                return StatusCode((int) operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro inesperado");
            }
        }

        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 401, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 404, type: typeof(GenericCommandResult))]
        [HttpPut("antecipate/hours")]
        public async Task<ActionResult<GenericCommandResult>> AntecipateActivityInHours([FromBody] AntecipateActivityInHoursCommand command)
        {
            try
            {
                var operationResult = await _Mediator.Send(command);
                return StatusCode((int) operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro inesperado");
            }
        }

        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 401, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 404, type: typeof(GenericCommandResult))]
        [HttpPut("antecipate/minutes")]
        public async Task<ActionResult<GenericCommandResult>> AntecipateActivityInMinutes([FromBody] AntecipateActivityInMinutesCommand command)
        {
            try
            {
                var operationResult = await _Mediator.Send(command);
                return StatusCode((int) operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro inesperado");
            }
        }

        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 404, type: typeof(GenericCommandResult))]
        [HttpPut("complete")]
        public async Task<ActionResult<GenericCommandResult>> CompleteActivity([FromBody] CompleteActivityCommand command)
        {
            try
            {
                var operationResult = await _Mediator.Send(command);
                return StatusCode((int) operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro inesperado");
            }
        }

        [ProducesResponseType(statusCode: 200, type: typeof(GenericCommandResult))]
        [ProducesResponseType(statusCode: 404, type: typeof(GenericCommandResult))]
        [HttpPut("cancel")]
        public async Task<ActionResult<GenericCommandResult>> CancelActivity([FromBody] CancelActivityCommand command)
        {
            try
            {
                var operationResult = await _Mediator.Send(command);
                return StatusCode((int) operationResult.StatusCode, operationResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro inesperado");
            }
        }
    }
}