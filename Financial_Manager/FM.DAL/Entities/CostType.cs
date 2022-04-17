using System.Collections.Generic;

namespace FM.DAL.Entities
{
    public class CostType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cost> Costs { get; set; }
    }
}
