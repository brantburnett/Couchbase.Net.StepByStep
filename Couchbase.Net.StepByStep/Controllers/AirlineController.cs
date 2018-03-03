using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.IO;
using Couchbase.Net.StepByStep.Documents;
using Couchbase.Net.StepByStep.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Couchbase.Net.StepByStep.Controllers
{
    [Route("[controller]")]
    public class AirlineController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBucketProvider _bucketProvider;

        public AirlineController(IMapper mapper, IBucketProvider bucketProvider)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _bucketProvider = bucketProvider ?? throw new ArgumentNullException(nameof(bucketProvider));
        }

        // GET /airline
        [HttpGet]
        public async Task<IActionResult> GetAirlines()
        {
            throw new NotImplementedException();
        }

        // GET /airline/10123
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAirline(int id)
        {
            var bucket = _bucketProvider.GetBucket("travel-sample");

            var document = await bucket.GetDocumentAsync<Airline>(Airline.GetKey(id));
            if (document.Status == ResponseStatus.KeyNotFound)
            {
                return NotFound();
            }

            document.EnsureSuccess();

            return Ok(_mapper.Map<AirlineDto>(document.Content));
        }

        // POST /airline
        [HttpPost]
        public async Task<IActionResult> PostAirline([FromBody] AirlineDto value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            throw new NotImplementedException();
        }

        // PUT /airline/10123
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirline(int id, [FromBody] AirlineDto value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            throw new NotImplementedException();
        }

        // DELETE /airline/10123
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirline(int id)
        {
            throw new NotImplementedException();
        }
    }
}
