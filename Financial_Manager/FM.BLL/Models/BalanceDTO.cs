using System.Collections.Generic;

namespace FM.BLL.Models
{
    public class BalanceDTO
    {
        public BalanceDTO()
        {
            Incomes = new List<IncomeDTO>();
            Costs = new List<CostDTO>();
        }

        public int Id { get; set; }
        public decimal Money { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyChar { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }

        public virtual ICollection<IncomeDTO> Incomes { get; set; }
        public virtual ICollection<CostDTO> Costs { get; set; }
    }
}
