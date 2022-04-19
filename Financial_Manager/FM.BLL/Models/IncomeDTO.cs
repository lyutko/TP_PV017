using System;

namespace FM.BLL.Models
{
    public class IncomeDTO
    {
        public int Id { get; set; }
        public decimal Money { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string IncomeSource { get; set; }
        public decimal Balance { get; set; }
    }
}
