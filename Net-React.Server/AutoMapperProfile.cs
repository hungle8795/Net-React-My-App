using AutoMapper;
using Net_React.Server.DTOs.Auth;
using Net_React.Server.DTOs.User;
using Net_React.Server.Models;

namespace Net_React.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Accounts, AddAccountDTO>();
            CreateMap<AddAccountDTO, Accounts>();
            //CreateMap<UpdateUserDTO, User>();
            CreateMap<AccountReqDTO, Accounts>();
            CreateMap<string, AccountRespDTO>();

        }
    }
}
