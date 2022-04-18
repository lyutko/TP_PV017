using System.Collections.Generic;

namespace FM.DAL.Entities
{
    public class IncomeSource
    {
        public IncomeSource()
        {
            Incomes = new List<Income>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
    }
}
