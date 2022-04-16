using System.Collections.Generic;

namespace FM.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Balance> Balances { get; set; }
    }
}
