using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCSBanking.Models;

namespace TCSBanking.Repositorys
{
    public interface IAccountStatusRepository
    {
        AccountStatus GetAccountStatusById(int id);
        List<AccountStatus> getAccountStatuses();
        AccountStatus Add(AccountStatus accountStatus);
        UserInfo getAccountUserInfo(int id);
        List<AccountStatus> getAccounts(int id);
        int deleteAccount(int id);
    }
}
