using Application.DTO.Command;
using AutoMapper;
using Billing.Application.DTO;
using Billing.Domain.Entities;

namespace Application.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Product, ProductCommand>().ReverseMap();
            CreateMap<Customer, CustomerCommand>().ReverseMap();
            CreateMap<BillingLine, BillingLineDTO>().ReverseMap();
            CreateMap<BillingLine, BillingLineDTO>().ReverseMap();
            CreateMap<BillingLineDTO, BillingLine>().ReverseMap();
            CreateMap<BillingDTO, Billing.Domain.Entities.Billing>()
                .ForMember(dest => dest.BillingLines, opt => opt.MapFrom(src => src.BillingLines)).ReverseMap();
        }
    }
    
}
