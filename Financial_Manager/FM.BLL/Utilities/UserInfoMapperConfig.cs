using AutoMapper;
using FM.BLL.Models;
using FM.DAL.Entities;

namespace FM.BLL.Utilities
{
    public class UserInfoMapperConfig : Profile
    {
        public UserInfoMapperConfig()
        {
            // Currecny
            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>().ForMember(currency => currency.Balances, currencyDTO => currencyDTO.Ignore());

            // Balance
            CreateMap<Balance, BalanceDTO>()
                .ForMember(balanceDTO => balanceDTO.CurrencyName, balance => balance.MapFrom(b => b.Currency.Name))
                .ForMember(balanceDTO => balanceDTO.CurrencyChar, balance => balance.MapFrom(b => b.Currency.Char))
                .ForMember(balanceDTO => balanceDTO.UserName, balance => balance.MapFrom(b => b.User.Name))
                .ForMember(balanceDTO => balanceDTO.UserSurname, balance => balance.MapFrom(b => b.User.Surname));
            CreateMap<BalanceDTO, Balance>()
                .ForMember(balance => balance.Currency, balanceDTO => balanceDTO.MapFrom(b => new Currency { Char = b.CurrencyChar, Name = b.CurrencyName }))
                .ForMember(balance => balance.User, balanceDTO => balanceDTO.MapFrom(b => new User { Name = b.UserName, Surname = b.UserSurname }));

            // User
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
