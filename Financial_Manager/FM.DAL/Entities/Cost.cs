using System;

namespace FM.DAL.Entities
{
    public class Cost
    {
        public int Id { get; set; }
        public decimal Money { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int CostTypeId { get; set; }
        public CostType CostType { get; set; }

        public int BalanceId { get; set; }
        public Balance Balance { get; set; }
    }
}
