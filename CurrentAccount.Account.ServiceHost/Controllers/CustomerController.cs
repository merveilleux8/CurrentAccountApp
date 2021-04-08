using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrentAccount.Account.Service;
using CurrentAccount.Account.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrentAccount.Account.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_customerService.GetCustomers());
        }
    }
}
