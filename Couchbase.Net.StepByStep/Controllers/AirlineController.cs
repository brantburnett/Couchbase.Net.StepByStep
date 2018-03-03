using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Couchbase.Core;
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

            var bucket = _bucketProvider.GetBucket("travel-sample");

            var content = _mapper.Map<Airline>(value);
            content.Id = await GetNextId(bucket);

            var document = new Document<Airline>
            {
                Content = content,
                Id = Airline.GetKey(content.Id)
            };

            var result = await bucket.InsertAsync(document);
            result.EnsureSuccess();

            return Ok(_mapper.Map<AirlineDto>(content));
        }

        // PUT /airline/10123
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirline(int id, [FromBody] AirlineDto value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bucket = _bucketProvider.GetBucket("travel-sample");

            var document = await bucket.GetDocumentAsync<Airline>(Airline.GetKey(id));
            if (document.Status == ResponseStatus.KeyNotFound)
            {
                return NotFound();
            }

            document.EnsureSuccess();

            _mapper.Map(value, document.Content);

            var result = await bucket.ReplaceAsync(document.Document);
            result.EnsureSuccess();

            return Ok(_mapper.Map<AirlineDto>(document.Content));
        }

        // DELETE /airline/10123
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirline(int id)
        {
            throw new NotImplementedException();
        }

        private static async Task<int> GetNextId(IBucket bucket)
        {
            while (true)
            {
                var builder = bucket.MutateIn<AirlineId>(AirlineId.GetKey());
                builder.Counter(p => p.Id, 1, true);

                var result = await builder.ExecuteAsync();
                if (result.Status == ResponseStatus.KeyNotFound)
                {
                    var document = new Document<AirlineId>
                    {
                        Content = new AirlineId
                        {
                            Id = 100000 // Base for new increments, probably 0 for real apps
                        },
                        Id = AirlineId.GetKey()
                    };

                    var insertResult = await bucket.InsertAsync(document);
                    if (insertResult.Status != ResponseStatus.KeyExists)
                    {
                        // Ignore failure if key exists, just means another thread created it simultaneously
                        insertResult.EnsureSuccess();
                    }

                    // Now that the document exists, try to increment again on next loop
                }
                else
                {
                    result.EnsureSuccess();

                    return result.Content(p => p.Id);
                }
            }
        }
    }
}
