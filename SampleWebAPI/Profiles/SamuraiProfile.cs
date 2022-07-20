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
            CreateMap<RegistrasiDTO, User>();
            CreateMap<User, RegistrasiDTO>();


            //samurai with sword, type dan element (Sword)
            //CreateMap<SamuraiWithSwordTypeSwordElementDTO, Sword>();
            //CreateMap<Sword, SamuraiWithSwordTypeSwordElementDTO>();

            CreateMap<SamuraiWithSwordTypeSwordElementDTO, Samurai>();
            CreateMap<Samurai, SamuraiWithSwordTypeSwordElementDTO>();
            CreateMap<SwordTypeElementDTO, Samurai>();
            CreateMap<Samurai, SwordTypeElementDTO>();

            CreateMap<SwordTypeElementDTO, Sword>();
            CreateMap<Sword, SwordTypeElementDTO>();

            CreateMap<SamuraiWithSwordDTO, Samurai>();
            CreateMap<Samurai,SamuraiWithSwordDTO>();

            CreateMap<SamuraiWithSwordDTO, Sword>();
            CreateMap<Sword, SamuraiWithSwordDTO>();

            CreateMap<SwordWithTypeDTO, Sword>();
            CreateMap<Sword, SwordWithTypeDTO>();

            CreateMap<SwordInputDTO, Sword>();
            CreateMap<Sword, SwordInputDTO>();

            CreateMap<SwordWithTypeCreateDTO, Sword>();
            CreateMap<Sword, SwordWithTypeCreateDTO>();

            CreateMap<TypeSword, TypeSwordReadDTO>();
            CreateMap<TypeSwordReadDTO, TypeSword >();

            CreateMap<Sword, TypeSwordReadDTO>();
            CreateMap<TypeSwordReadDTO, Sword>();

            CreateMap<ElementIdDTO, Element>();
            CreateMap<Element, ElementIdDTO>();

            CreateMap<Sword, SwordToExistingElementDTO>();
            CreateMap<SwordToExistingElementDTO, Sword>();

            CreateMap<Sword, SwordIdDTO>();
            CreateMap<SwordIdDTO, Sword>();

            CreateMap<ElementToExistingSwordDTO, Element>();
            CreateMap<Element, ElementToExistingSwordDTO>();
            CreateMap<ElementToExistingSwordDTO, Sword>();
            CreateMap<Sword, ElementToExistingSwordDTO>();
           




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
            //TypeSword
            CreateMap<TypeSwordDTO, TypeSword>();
            CreateMap<TypeSword, TypeSwordDTO>();
            CreateMap<TypeSwordCreateDTO, TypeSword>();
            CreateMap<TypeSword, TypeSwordCreateDTO>();


        }
    }
}
