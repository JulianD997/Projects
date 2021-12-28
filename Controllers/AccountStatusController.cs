using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TCSBanking.Extensions.Alerts;
using TCSBanking.Models;
using TCSBanking.Repositorys;
using TCSBanking.ViewModels;

namespace TCSBanking.Controllers
{
    [Authorize(Roles = "AccountExecutive")]
    public class AccountStatusController : Controller
    {
        private readonly IAccountStatusRepository _accountStatusRepository;

        public AccountStatusController(IAccountStatusRepository accountStatusRepository)
        {
            _accountStatusRepository = accountStatusRepository;
        }

        // GET - LIST OF ACCOUNTS
        public IActionResult List()
        {
            var accounts = _accountStatusRepository.getAccountStatuses();
            return View(accounts);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            AccountCreateViewModel viewModel = new AccountCreateViewModel();
            return View(viewModel);
        }

        // POST - CREATE
        [HttpPost]
        public IActionResult Create(AccountCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AccountStatus accountStatus = new AccountStatus
                {
                    CustomerId = viewModel.CustomerId,
                    AccountType = viewModel.AccountType,
                    Balance = viewModel.DepositAmount,
                    Status = "Active",
                    Message = "Account created.",
                    LastUpdated = DateTime.Now
                };

                var account = _accountStatusRepository.Add(accountStatus);
                if(account.AccountId > 0)
                    return RedirectToAction("List").WithSuccess("Success!", "The account " + account.AccountId +" was created.");
                else
                    return RedirectToAction("List").WithDanger("Error ocurred", "The account was NOT created.");
            }

            return View(viewModel);
        }

        // GET - SEARCH FORM
        public IActionResult Search()
        {
            AccountSearchViewModel viewModel = new AccountSearchViewModel();
            return View(viewModel);
        }

        // GET - SEARCH RESULTS
        [HttpGet]
        public IActionResult Search(AccountSearchViewModel viewModel)
        {
            viewModel.Accounts = _accountStatusRepository.getAccounts(viewModel.CustomerId);
            return View(viewModel);
        }

        // GET - DELETE 
        public IActionResult Delete(int Id)
        {

            AccountStatus account = _accountStatusRepository.GetAccountStatusById(Id);

            var accountDeleteViewModel = new AccountDeleteViewModel
            {
                CustomerId = account.CustomerId,
                AccountId = account.AccountId,
                AccountType = account.AccountType,
                Status = account.Status,
                Message = account.Message,
                LastUpdated = account.LastUpdated,
            };

            return View(accountDeleteViewModel);
        }

        // POST- DELETE
        [HttpPost]
        public IActionResult DeleteAccount(int Id)
        {
            int ret = _accountStatusRepository.deleteAccount(Id);
            if (ret > 0)
            {
                return RedirectToAction("List").WithSuccess("Success!", "The account " + Id + " was deleted.");
            }
            else
            {
                return RedirectToAction("List").WithDanger("Error occured!", "The account was not deleted.");
            }
        }
    }
}