using System.Collections.Generic;

namespace FM.DAL.Entities
{
    public class Currency
    {
        public Currency()
        {
            Balances = new List<Balance>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Char { get; set; }

        public virtual ICollection<Balance> Balances { get; set; }
    }
}
