using AutoMapper;
using FM.BLL.Interfaces;
using FM.BLL.Models;
using FM.DAL.Entities;
using FM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL
{
    public class FinanceService : IFinanceService
    {
        IDataGenericRepository<Balance> _balanceRepo;
        IDataGenericRepository<Cost> _costRepo;
        IDataGenericRepository<CostType> _costTypeRepo;
        IDataGenericRepository<Currency> _currencyRepo;
        IDataGenericRepository<Income> _incomeRepo;
        IDataGenericRepository<IncomeSource> _incomeSourceRepo;
        IDataGenericRepository<User> _userRepo;
        Mapper _financeMapper;


        public FinanceService(
            IDataGenericRepository<Balance> balanceRepo,
            IDataGenericRepository<Cost> costRepo,
            IDataGenericRepository<CostType> costTypeRepo,
            IDataGenericRepository<Currency> curencyRepo,
            IDataGenericRepository<Income> incomeRepo,
            IDataGenericRepository<IncomeSource> incomeSourceRepo,
            IDataGenericRepository<User> userRepo,
            Mapper financeMaper)
        {
            _balanceRepo = balanceRepo;
            _costRepo = costRepo;
            _costTypeRepo = costTypeRepo;
            _currencyRepo = curencyRepo;
            _incomeRepo = incomeRepo;
            _incomeSourceRepo = incomeSourceRepo;
            _userRepo = userRepo;
            _financeMapper = financeMaper;
        }


        public void CreateBalance(BalanceDTO balanceDTO)
        {
            Balance balance = _financeMapper.Map<Balance>(balanceDTO);
            Currency currency = _currencyRepo.GetAll().FirstOrDefault(x => x.Name == balance.Currency.Name); // Check this!!!
            currency = _currencyRepo.Get(currency.Id);
            if (currency != null)
                balance.Currency = currency;
            User user = _userRepo.GetAll().FirstOrDefault(x => x.Name == balance.User.Name);
            user = _userRepo.Get(user.Id);
            if (user != null)
                balance.User= user;

            _balanceRepo.Create(balance);
        }

        public void DeleteBalance(BalanceDTO balanceDTO)
        {
            _balanceRepo.Delete(balanceDTO.Id);
        }

        public IEnumerable<BalanceDTO> GetBalanses()
        {
            IEnumerable<Balance> balances = _balanceRepo.GetAll("Balances", "Currencies", "Users");           
            return _financeMapper.Map<IEnumerable<BalanceDTO>>(balances);
        }
    }
}
