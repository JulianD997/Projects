using TCSBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCSBanking.Repositorys
{
    public interface ICustStatusBankRepo
    {
        List<CustomerStatus> CustomerStatuses();

        CustomerStatus Addstatus(CustomerStatus status);

        UserInfo Addinfo(UserInfo user);

        CustomerStatus GetStatusById(int id);

        public List<UserInfo> UserInfor();
        UserInfo GetCustById(int id);

        UserInfo UpdateCust(UserInfo updatedCust);

        CustomerStatus UpdateStatus(CustomerStatus updatedStatus);

        List<UserInfo> getUsers();

        int deleteCust(UserInfo deleteCust);
    }
    
}
