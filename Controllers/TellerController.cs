using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCSBanking.ViewModels;
using TCSBanking.Repositorys;
using TCSBanking.Models;
using Microsoft.AspNetCore.Authorization;
using TCSBanking.Extensions.Alerts;

namespace TCSBanking.Controllers
{
    [Authorize(Roles = "Teller")]
    public class TellerController : Controller
    {
        private readonly ITellerRepo _tellerRepo;

        public TellerController(ITellerRepo tellerSearchRepo)
        {
            _tellerRepo = tellerSearchRepo;
        }

        public IActionResult TellerRequest()
        {
            return View("TellerRequest");
        }

        public IActionResult RequestAccID()
        {
            TellerSearchViewModel VModel = new TellerSearchViewModel();
            return View(VModel);
        }

        [HttpGet]
        public IActionResult RequestAccID(TellerSearchViewModel VModel)
        {
            VModel.Account = _tellerRepo.GetaccountbyAccID(VModel.AccountId);
            return View(VModel);
        }

        public IActionResult RequestCustID()
        {
            TellerSearchViewModel VModel = new TellerSearchViewModel();
            return View(VModel);
        }

        [HttpGet]
        public IActionResult RequestCustID(TellerSearchViewModel VModel)
        {
            VModel.Account = _tellerRepo.GetaccountbyCustID(VModel.CustomerId);
            return View(VModel);
        }

        // GET - DEPOSIT SCREEN
        public IActionResult Deposit(int Id)
        {
            DepWitViewModel viewModel = new DepWitViewModel
            {
                AccountId = Id,
                Account = _tellerRepo.GetAccounts(Id)
            };
            return View(viewModel);
        }

        // POST - DEPOSIT 
        [HttpPost]
        public IActionResult Deposit(DepWitViewModel viewModel, int Id)
        {
            viewModel.AccountId = Id;
            viewModel.Account = _tellerRepo.GetAccounts(Id);

            if (ModelState.IsValid)
            {
                viewModel.Account.Balance += viewModel.Ammount;
                viewModel.Account.LastUpdated = DateTime.Now;
                viewModel.Account.Message = "Deposited";
                int ret = _tellerRepo.depWit(viewModel.Account);
                if(ret > 0)
                    return RedirectToAction("TellerRequest").WithSuccess("Success!", "The amount $" + viewModel.Ammount + " was deposited in account " + viewModel.AccountId + ".");
                else
                    return RedirectToAction("TellerRequest").WithDanger("Error ocurred!", "The amount $" + viewModel.Ammount + " was NOT deposited in account " + viewModel.AccountId+ ".");
            }

            return View(viewModel);
        }


        // GET - WITHDRAW SCREEN
        public IActionResult Withdraw(int Id)
        {
            DepWitViewModel viewModel = new DepWitViewModel
            {
                AccountId = Id,
                Account = _tellerRepo.GetAccounts(Id)
            };
            return View(viewModel);
        }

        // POST - WITHDRAW 
        [HttpPost]
        public IActionResult Withdraw(DepWitViewModel viewModel, int Id)
        {
            viewModel.AccountId = Id;
            viewModel.Account = _tellerRepo.GetAccounts(Id);

            if (viewModel.Ammount > viewModel.Account.Balance)
            {
                ModelState.AddModelError("Ammount", "Cannot withdraw more than your balance.");
            }

            if (ModelState.IsValid)
            {
                viewModel.Account.Balance -= viewModel.Ammount;
                viewModel.Account.LastUpdated = DateTime.Now;
                viewModel.Account.Message = "Withdrawn";
                int ret = _tellerRepo.depWit(viewModel.Account);
                if (ret > 0)
                    return RedirectToAction("TellerRequest").WithSuccess("Success!", "The amount $" + viewModel.Ammount + " was withdrawn in account " + viewModel.AccountId + ".");
                else
                    return RedirectToAction("TellerRequest").WithDanger("Error ocurred!", "The amount $" + viewModel.Ammount + " was NOT withdrawn in account " + viewModel.AccountId + ".");
            }
            return View(viewModel);
        }
    }
}