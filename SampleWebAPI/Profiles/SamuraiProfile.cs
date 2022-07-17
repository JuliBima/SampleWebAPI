using AutoMapper;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Profiles
{
    public class SamuraiProfile : Profile
    {
        public SamuraiProfile()
        {
            CreateMap<SamuraiWithQuotesDTO, Samurai>();
            CreateMap<Samurai, SamuraiWithQuotesDTO>();

            CreateMap<Samurai, SamuraiReadDTO>();
            CreateMap<SamuraiReadDTO, Samurai>();
            CreateMap<SamuraiCreateDTO, Samurai>();

            CreateMap<QuoteDTO, Quote>();
            CreateMap<Quote,QuoteDTO>();
            //Sword
            CreateMap<SwordDTO, Sword>();
            CreateMap<Sword, SwordDTO>();   
            CreateMap<SwordCreateDTO, Sword>();
            CreateMap<Sword, SwordCreateDTO>();
            //Element
            CreateMap<ElementDTO, Element>();
            CreateMap<Element, ElementDTO>();
            CreateMap<ElementCreateDTO, Element>();
            CreateMap<Element, ElementCreateDTO>();

        }
    }
}
