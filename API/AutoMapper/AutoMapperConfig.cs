using System;
using AutoMapper;

namespace API.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<string, int>().ConvertUsing(property => Convert.ToInt32(property));
                cfg.AddProfile(new DomainToModelProfile());
            });
        }
    }
}