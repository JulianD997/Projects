using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCSBanking.ViewModels
{
    public class UserInfoViewModel
    {
        public int SSNID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }
    }
}
