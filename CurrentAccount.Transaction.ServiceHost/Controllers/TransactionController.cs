﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrentAccount.Transaction.Service;
using CurrentAccount.Transaction.ServiceHost.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrentAccount.Transaction.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        protected readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        // GET api/<TransactionController>/5
        [HttpGet("{accountId}")]
        public ActionResult Get(string accountId)
        {
            var transactionList = _transactionService.GetTransactions(accountId);
            return Ok(transactionList);
        }

        // POST api/<TransactionController>
        [HttpPost]
        public ActionResult Post([FromBody] CreateTransactionModel transaction)
        {
            var accountTransaction = _transactionService.AddTransaction(transaction.AccountId, transaction.Credit);
            return Ok(accountTransaction);
        }
    }
}
