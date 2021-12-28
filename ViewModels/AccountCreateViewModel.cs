using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCSBanking.Models;
using System.ComponentModel.DataAnnotations;

namespace TCSBanking.ViewModels
{
    
        public class AccountCreateViewModel
        {
            [Range(999999999, int.MaxValue, ErrorMessage = "Customer ID is a 10 digit number.")]
            public int CustomerId { get; set; }

            public string AccountType { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Must deposit atleast $1.")]
            public int DepositAmount { get; set; }

        }
    
}
