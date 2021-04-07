﻿using CurrentAccount.Account.Service;
using CurrentAccount.Account.ServiceHost.Models;
using Microsoft.AspNetCore.Mvc;


namespace CurrentAccount.Account.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        protected readonly IAccountService _accountService;
        protected readonly ICustomerService _customerService;

        public AccountController(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public ActionResult Get()
        {
            var result = _accountService.GetAccounts();
            return Ok(result);
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int customerId)
        {
            var customerAccount = _accountService.GetAccountCustomer(customerId);
            return Ok(customerAccount);
        }

        // POST api/<AccountController>
        [HttpPost]
        public ActionResult Post([FromBody] CreateAccountModel createAccountModel)
        {
            if(!_customerService.CheckIfCustomerExists(createAccountModel.CustomerId))
            {
                return BadRequest("Customer could not be found.");
            }
            var result = _accountService.AddAccount(createAccountModel.CustomerId, createAccountModel.InitialCredit);
            return Ok(result);
        }
    }
}
