using AutoMapper;
using FM.BLL.Models;
using FM.DAL.Entities;

namespace FM.BLL.Utilities
{
    public class FinanceMapperConfig : Profile
    {
        public FinanceMapperConfig()
        {
            // Income
            CreateMap<Income, IncomeDTO>()
                .ForMember(incomeDTO => incomeDTO.IncomeSource, income => income.MapFrom(i => i.IncomeSource.Name))
                .ForMember(incomeDTO => incomeDTO.Balance, income => income.MapFrom(i => i.Balance.Money));

            CreateMap<IncomeDTO, Income>()
                .ForMember(income => income.IncomeSource, incomeDTO => incomeDTO.MapFrom(i => new IncomeSource { Name = i.IncomeSource }))
                .ForMember(income => income.Balance, incomeDTO => incomeDTO.MapFrom(i => new Balance { Money = i.Money }));

            // IncomeSource
            CreateMap<IncomeSource, IncomeSourceDTO>();
            CreateMap<IncomeSourceDTO, IncomeSource>()
                .ForMember(incomeSource => incomeSource.Incomes, incomeSourceDTO => incomeSourceDTO.Ignore());

            // Cost
            CreateMap<Cost, CostDTO>()
                .ForMember(costDTO => costDTO.CostType, cost => cost.MapFrom(c => c.CostType.Name))
                .ForMember(costDTO => costDTO.Balance, cost => cost.MapFrom(c => c.Balance.Money));

            CreateMap<CostDTO, Cost>()
                .ForMember(cost => cost.CostType, costDTO => costDTO.MapFrom(c => new CostType { Name = c.CostType }))
                .ForMember(cost => cost.Balance, costDTO => costDTO.MapFrom(c => new Balance { Money = c.Money }));

            // CostType
            CreateMap<CostType, CostTypeDTO>();
            CreateMap<CostTypeDTO, CostType>()
                .ForMember(costType => costType.Costs, costTypeDTO => costTypeDTO.Ignore());
        }
    }
}
