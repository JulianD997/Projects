using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCSBanking.Models;

namespace TCSBanking.Repositorys
{
    public class TellerSQLRepo : ITellerRepo
    {

        private BankDBContext _acc;

        public TellerSQLRepo(BankDBContext context)
        {
            _acc = context;
        }

        public AccountStatus GetAccounts(int AccountID)
        {
            return _acc.AccountStatus.Find(AccountID);
        }

        public List<AccountStatus> GetaccountbyAccID(int AccountID)
        {
            return _acc.AccountStatus.Where(s => s.AccountId == AccountID).ToList();
        }

        public List<AccountStatus> GetaccountbyCustID(int CustID)
        {
            return _acc.AccountStatus.Where(s => s.CustomerId == CustID).ToList();
        }

        public int depWit(AccountStatus modifiedAccount)
        {
            _acc.AccountStatus.Attach(modifiedAccount);
            _acc.Entry(modifiedAccount).State = EntityState.Modified;
            _acc.SaveChanges();
            return modifiedAccount.AccountId;
        }
    }
}
