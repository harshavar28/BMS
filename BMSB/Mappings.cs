using AutoMapper;
using BMSB.Models;
using BMSB.Dto;

namespace BMSB
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<data, Book>().ReverseMap();
            CreateMap<Approval, Udata>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Book.Category))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Book.AuthCred.Name))
                .ForMember(dest => dest.Uname, opt => opt.MapFrom(src => src.Cred.Uname));

            CreateMap<Adata, Cred>();

        }

    }
}
