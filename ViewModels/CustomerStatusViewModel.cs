using TCSBanking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCSBanking.ViewModels
{
    public class CustomerStatusViewModel
    {
        public int StatusId { get; set; }

        [Required(ErrorMessage ="Please Enter the SSN associated to this account")]
        public int Ssnid { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }

        public DateTime LastUpdated { get; set; }

        
    }
}
