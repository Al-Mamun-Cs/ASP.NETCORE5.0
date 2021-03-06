using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestProjectIsDB.Models.Classes;

namespace TestProjectIsDB.Models.ViewModel
{
    public class ClientListViewModel
    {
        public int ClientID { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        [Required(ErrorMessage = "IsActive Is Required")]
        public string IsActive { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Is Required")]
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountName { get; set; }
        public virtual AccountType Accounts { get; set; }
    }
}
