using CurrentAccount.Account.Service;
using CurrentAccount.Account.Service.Exceptions;
using CurrentAccount.Account.ServiceHost.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

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
        [Route("get/{customerId}", Name = "GetByCustomerId")]
        public async Task<ActionResult> GetByCustomerId(int customerId)
        {
            var result = await _accountService.GetAccounts(customerId);
            return Ok(result);
        }

        // GET api/<AccountController>/5
        [HttpGet("{accountId}")]
        public async Task<ActionResult> Get(string accountId)
        {
            var customerAccount = await _accountService.GetAccountCustomer(accountId);
            return Ok(customerAccount);
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<ActionResult> CreateAccount([FromBody] CreateAccountModel createAccountModel)
        { bool isCustomerExists = await _customerService.CheckIfCustomerExists(createAccountModel.CustomerId);
            if (!isCustomerExists)
                throw new ApiException("Customer could not be found.", HttpStatusCode.BadRequest);
            var result = await _accountService.AddAccount(createAccountModel.CustomerId, createAccountModel.InitialCredit);
            return Ok(result);
        }
    }
}
