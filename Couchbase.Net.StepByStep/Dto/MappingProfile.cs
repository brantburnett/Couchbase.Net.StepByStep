using System;
using AutoMapper;
using Couchbase.Net.StepByStep.Documents;

namespace Couchbase.Net.StepByStep.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AirlineDto, Airline>()
                .ForMember(p => p.Id, c => c.Ignore());

            CreateMap<Airline, AirlineDto>();
        }
    }
}
