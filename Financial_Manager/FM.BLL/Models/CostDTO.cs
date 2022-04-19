using System;

namespace FM.BLL.Models
{
    public class CostDTO
    {
        public int Id { get; set; }
        public decimal Money { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string CostType { get; set; }
        public decimal Balance { get; set; }
    }
}
