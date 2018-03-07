using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Couchbase.Net.StepByStep.Documents;
using Couchbase.Net.StepByStep.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Couchbase.Net.StepByStep.Controllers
{
    [Route("[controller]")]
    public class AirlineController : Controller
    {
        private readonly IMapper _mapper;

        public AirlineController(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            throw new NotImplementedException();
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
