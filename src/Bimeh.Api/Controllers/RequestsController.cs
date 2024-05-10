using Bimeh.Api.Models;
using Bimeh.Domain.Requests.Commands;
using Bimeh.Domain.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bimeh.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var query = new GetRequestsQuery();

            var requests = await _mediator.Send(query);

            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            var query = new GetRequestQuery(id);

            var request = await _mediator.Send(query);

            return Ok(request);
        }

        // POST api/<RequestsController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateRequestModel createRequestModel)
        {

            var command = new CreateRequestCommand();
            command.Title = createRequestModel.Title;
            command.CoverageCapitals = createRequestModel.Coverages.Select(x => new CreateRequestCommand.CoverageCapital { Amount = x.Amount, CoverageId = x.CoverageId }).ToList();

            var request = await _mediator.Send(command);

            return Ok(request);
        }
    }
}
