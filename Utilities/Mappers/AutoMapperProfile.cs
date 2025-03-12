using AutoMapper;
using MassageApi_V1.DTOs;
using MassageApi_V1.Models;

namespace MassageApi_V1.Utilities.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ContactNewDTO, Contact>();
            CreateMap<Contact, ContactNewDTO>();
            CreateMap<ShiftNewDTO, Shift>();
            CreateMap<Shift, ShiftNewDTO>();
            CreateMap<UserNewDTO, User>();
            CreateMap<User, UserNewDTO>();
        }
    }
}
