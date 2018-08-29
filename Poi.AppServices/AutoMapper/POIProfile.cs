using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poi.AppServices.AutoMapper
{
    public class POIProfile : Profile
    {
        public POIProfile()
        {
            CreateMap<Domain.City, Data.Entities.City>()
                .ReverseMap()
                .ForMember(c => c.NumberOfPointsOfInterest, opt => opt.UseValue(0));
            CreateMap<Domain.PointOfInterest, Data.Entities.PointOfInterest>()
                .ReverseMap()
                .ForSourceMember(c => c.City, opt => opt.Ignore());
        }
    }
}
