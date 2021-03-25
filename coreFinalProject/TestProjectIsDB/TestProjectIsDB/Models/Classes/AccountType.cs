using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectIsDB.Models.Classes
{
    public class AccountType
    {
        public int AccountTypeId { get; set; }
        public string AccountName { get; set; }
        public Nullable<int> Status { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
