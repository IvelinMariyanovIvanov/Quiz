﻿using AutoMapper;
using Quiz.Models.Entities;
using Quiz.Web.ViewModels;

namespace Quiz.Web
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfiguration = new MapperConfiguration(mapper =>
            {
                mapper.CreateMap<Quote, QuoteVM>();
                mapper.CreateMap<QuoteVM, Quote>();
                 // .ForPath(dest => dest.Author.Id, opt => opt.MapFrom(src => src.AuthorId));
            });

            return mapperConfiguration;
        }
    }
}