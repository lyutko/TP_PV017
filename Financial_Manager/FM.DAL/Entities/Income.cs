using System;

namespace FM.DAL.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public decimal Money { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int IncomeSourceId { get; set; }
        public IncomeSource IncomeSource { get; set; }

        public int BalanceId { get; set; }
        public Balance Balance { get; set; }
    }
}
