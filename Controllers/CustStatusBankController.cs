using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TCSBanking.Extensions.Alerts;
using TCSBanking.Models;
using TCSBanking.Repositorys;
using TCSBanking.ViewModels;

namespace TCSBanking.Controllers
{
    [Authorize(Roles = "AccountExecutive")]
    public class CustStatusBankController : Controller
    {
        private readonly ICustStatusBankRepo bankRepo;
        public CustStatusBankController(ICustStatusBankRepo users)
        {
            bankRepo = users;
        }

        public IActionResult AddCust()
        {
            var viewModel = new AddCustViewModel
            {
                UserInfos = bankRepo.UserInfor()
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult AddCust(AddCustViewModel VModel)
        {
            if (ModelState.IsValid)
            {
                var info = new UserInfo
                {
                    Ssnid = VModel.Ssnid,
                    Name = VModel.Name,
                    Address = VModel.Address1,
                    Age = VModel.Age
                };
                bankRepo.Addinfo(info);
                var status = new CustomerStatus
                {
                    CustomerId = info.CustomerId,
                    Ssnid = VModel.Ssnid,
                    Status = "Active",
                    Message = "Customer was recently created",
                    LastUpdated = DateTime.Now
                };
                CustomerStatus custStatus = bankRepo.Addstatus(status); 

                if(custStatus.CustomerId > 0)
                    return RedirectToAction("ViewCustomerStatus").WithSuccess("Success!", "The account " + custStatus.CustomerId + " was created.");
                else
                    return RedirectToAction("ViewCustomerStatus").WithDanger("Error ocurred", "The account was NOT created.");

            }
            return View(VModel);
        }

        //Used to display the Customer Status Table from the BankDB
        public IActionResult ViewCustomerStatus()
        {
            var users = bankRepo.CustomerStatuses();
            if (users.Count() == 0)
            {
                return RedirectToAction("Error");
            }
            else
            {
                return View(users);
            }
        }

        //If no records are in the Customer Status Table will print out no records
        public IActionResult ViewUserInfo()
        {
            var users = bankRepo.UserInfor();

            if (users.Count() == 0)
            {
                return RedirectToAction("Error");
            }
            else
            {
                return View(users);
            }
        }

        public IActionResult UpdateCust(int id)
        {
            var cust = bankRepo.GetCustById(id);

            var custEditViewModel = new EditCustViewModel
            {
                Ssnid = cust.Ssnid,
                Id = cust.CustomerId,
                Name = cust.Name,
                Address1 = cust.Address,
                Age = cust.Age

            };
            return View(custEditViewModel);
        }

        [HttpPost]
        public IActionResult UpdateCust(EditCustViewModel editCustViewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = new UserInfo
                {
                    Ssnid = editCustViewModel.Ssnid,
                    CustomerId = editCustViewModel.Id,
                    Name = editCustViewModel.Name,
                    Address = editCustViewModel.Address1,
                    Age = editCustViewModel.Age
                };

                bankRepo.UpdateCust(customer);

                CustomerStatus status = bankRepo.GetStatusById(editCustViewModel.Id);
                var updatedStatus = new CustomerStatus
                {
                    Id = status.Id,
                    CustomerId = customer.CustomerId,
                    Ssnid = status.Ssnid,
                    Status = "Active",
                    Message = "Customer was recently edited",
                    LastUpdated = DateTime.Now
                };
                
                CustomerStatus custStatus = bankRepo.UpdateStatus(updatedStatus);
                if (custStatus.CustomerId > 0)
                    return RedirectToAction("ViewCustomerStatus").WithSuccess("Success!", "The account " + custStatus.CustomerId + " was updated.");
                else
                    return RedirectToAction("ViewCustomerStatus").WithDanger("Error ocurred", "The account was NOT updated.");
            }
            editCustViewModel.UserInfos = bankRepo.getUsers();
            return View(editCustViewModel);

        }

        public IActionResult DeleteCust(int id)
        {
            var cust = bankRepo.GetCustById(id);

            DeleteCustViewModel custInfo = new DeleteCustViewModel
            {
                Ssnid = cust.Ssnid,
                Id = cust.CustomerId,
                Name = cust.Name,
                Age = cust.Age,
                Address1 = cust.Address
            };
            return View(custInfo);
        }

        [HttpPost]
        public IActionResult DeleteCust(DeleteCustViewModel deleteCustViewModel)
        {

            if (ModelState.IsValid)
            {
                UserInfo deleted = bankRepo.GetCustById(deleteCustViewModel.Id);
                int ret = bankRepo.deleteCust(deleted);
                if (ret > 0)
                {
                    return RedirectToAction("ViewCustomerStatus").WithSuccess("Success!", "The customer " + deleteCustViewModel.Id + " was deleted.");
                }
                else
                {
                    return RedirectToAction("ViewCustomerStatus").WithDanger("Error occured!", "The customer was NOT deleted.");
                }

            }
            return View(deleteCustViewModel);
        }


        //If no records are in the Customer Status Table will print out no records
        public IActionResult Error()
        {
            return View();
        }
    }
}
