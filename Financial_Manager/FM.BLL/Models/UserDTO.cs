using System.Collections.Generic;

namespace FM.BLL.Models
{
    public class UserDTO
    {
        public UserDTO()
        {
            Balances = new List<BalanceDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<BalanceDTO> Balances { get; set; }
    }
}
