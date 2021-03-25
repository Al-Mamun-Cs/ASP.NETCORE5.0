using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectIsDB.Models.ViewModel
{
    public class CreateAccountTypeViewModel
    {
        public int AccountTypeId { get; set; }
        [Required(ErrorMessage = "AccountName Is Required")]
        public string AccountName { get; set; }
    }
}
