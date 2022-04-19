using System.Collections.Generic;

namespace FM.DAL.Entities
{
    public class Balance
    {
        public Balance()
        {
            Incomes = new List<Income>();
            Costs = new List<Cost>();
        }

        public int Id { get; set; }
        public decimal Money { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Cost> Costs { get; set; }
    }
}
