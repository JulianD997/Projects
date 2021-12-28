using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCSBanking.Models;

namespace TCSBanking.Repositorys
{
    public class SqlAccountRepository : IAccountStatusRepository
    {
        private readonly BankDBContext _context;
        public SqlAccountRepository(BankDBContext context)
        {
            _context = context;
        }

        public AccountStatus Add(AccountStatus accountStatus)
        {
            try
            {
                _context.AccountStatus.Add(accountStatus);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return new AccountStatus();
            }

            return accountStatus;
        }

        public AccountStatus GetAccountStatusById(int id)
        {
            return _context.AccountStatus.Find(id);
        }

        public List<AccountStatus> getAccountStatuses()
        {
            return _context.AccountStatus.ToList();
        }

        public UserInfo getAccountUserInfo(int id)
        {
            AccountStatus account = _context.AccountStatus.Find(id);
            return _context.UserInfo.Find(account.CustomerId);
        }

        // GET LIST WITH CUSTOMER ID or SSN ID
        public List<AccountStatus> getAccounts(int customerId)
        {
            return _context.AccountStatus.Include(c => c.Customer).Where(s => s.CustomerId == customerId || s.Customer.Ssnid == customerId).ToList();
        }

        // DELETE ACCOUNT
        public int deleteAccount(int accountId)
        {
            AccountStatus account = GetAccountStatusById(accountId);
            if (account == null)
                return -1;

            _context.Remove(account);
            _context.SaveChanges();
            return accountId;
        }
    }

}
