using FM.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL.Interfaces
{
    public interface IFinanceService
    {
        IEnumerable<BalanceDTO> GetBalanses();
        void CreateBalance(BalanceDTO balanceDTO);
        void DeleteBalance(BalanceDTO balanceDTO);
    }
}
