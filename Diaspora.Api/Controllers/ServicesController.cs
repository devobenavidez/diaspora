using Asp.Versioning;
using Diaspora.Application.Services.Commands.CreateService;
using Diaspora.Application.Services.DTOs;
using Diaspora.Application.Services.Queries.GetCheapestService;
using Diaspora.Application.Services.Queries.GetServiceQuote;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diaspora.Api.Controllers
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }



        // GET: api/<ServiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3", "value4" };
        }

        [HttpPost("cheapestprice")]
        public async Task<ActionResult<CheapestServiceDto>> GetCheapestPrice(CheapestServiceQuery request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("servicequote")]
        public async Task<ActionResult<ServiceQuoteDto>> GetServiceQuote(GetServiceQuoteQuery request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ServiceController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateServiceCommand service)
        {
            var result = await _mediator.Send(service);
            return Ok(result);
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
