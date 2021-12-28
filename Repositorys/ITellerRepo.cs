using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCSBanking.Models;

namespace TCSBanking.Repositorys 
{ 
    public interface ITellerRepo
    {

        public AccountStatus GetAccounts(int customerId);

        public List<AccountStatus> GetaccountbyAccID(int AccountID);

        public List<AccountStatus> GetaccountbyCustID(int AccountID);

        int depWit(AccountStatus modifiedAccount);
    }
}
