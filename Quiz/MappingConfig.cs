using AutoMapper;
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
                mapper.CreateMap<Question, QuestionVM>();
                mapper.CreateMap<QuestionVM, Question>();
                mapper.CreateMap<CreateUserVM, User>()
                   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            });

            return mapperConfiguration;
        }
    }
}
