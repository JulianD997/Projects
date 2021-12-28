using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCSBanking.Models;

namespace TCSBanking.ViewModels
{
    public class AddCustViewModel
    {
        [Required(ErrorMessage ="Please Enter 9 digit SSN")]
        public int Ssnid { get; set; }

        [Required(ErrorMessage ="Enter Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter Customer address")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required(ErrorMessage ="Enter Customer Age")]
        public int Age { get; set; }

        public List<UserInfo> UserInfos { get; set; }
    }
}
