using AutoMapper;
using Repository.EntitiyModels;
using RandevumAPI.Objects.DTO;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<CompanyDTO, Company>();
        CreateMap<UserDTO, User>();
    }
}