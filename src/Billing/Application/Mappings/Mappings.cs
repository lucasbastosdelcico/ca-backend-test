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
            CreateMap<CustomerCommand, Customer>().ReverseMap();
            CreateMap<Product, ProductCommand>().ReverseMap();
            CreateMap<Billing.Domain.Entities.Billing, BillingDTO>().ReverseMap();
        }
    }
    
}
