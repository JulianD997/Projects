using TCSBanking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace TCSBanking.Repositorys
{
    public class CustStatusSQLRepo : ICustStatusBankRepo
    {
        private BankDBContext _context;

        public CustStatusSQLRepo(BankDBContext context)
        {
            _context = context;
        }

        public CustomerStatus Addstatus(CustomerStatus status)
        {
            _context.CustomerStatus.Add(status);
            _context.SaveChanges();
            return status;
        }

        public UserInfo Addinfo(UserInfo info)
        {
            _context.UserInfo.Add(info);
            _context.SaveChanges();
            return info;
        }

        public List<UserInfo> UserInfor()
        {
            return _context.UserInfo.ToList();
        }

        public List<CustomerStatus> CustomerStatuses()
        {
            return _context.CustomerStatus.ToList();
        }

        public UserInfo GetCustById(int id)
        {
            return _context.UserInfo.Find(id);
        }

        public CustomerStatus GetStatusById(int id)
        {
            var statusId = _context.CustomerStatus.Where(x => x.CustomerId.Equals(id)).FirstOrDefault();
            _context.Entry(statusId).State = EntityState.Detached;
            return statusId;
        }

        public UserInfo UpdateCust(UserInfo updatedCust)
        {
            _context.UserInfo.Attach(updatedCust);
            _context.Entry(updatedCust).State = EntityState.Modified;
            _context.SaveChanges();
            return updatedCust;
        }

        public CustomerStatus UpdateStatus(CustomerStatus updatedStatus)
        {
            _context.CustomerStatus.Attach(updatedStatus);
            _context.Entry(updatedStatus).State = EntityState.Modified;
            _context.SaveChanges();
            return updatedStatus;
        }

        public List<UserInfo> getUsers()
        {
            return _context.UserInfo.ToList();
        }

        public int deleteCust(UserInfo deleteCust)
        {
            CustomerStatus customer = _context.CustomerStatus.Find(deleteCust.CustomerId);

            if (customer == null)
                return -1;

            _context.UserInfo.Attach(deleteCust);
            _context.Entry(deleteCust).State = EntityState.Deleted;
            _context.SaveChanges();
            return deleteCust.CustomerId;
        }

    }
}
