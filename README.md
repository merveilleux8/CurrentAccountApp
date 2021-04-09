# CurrentAccountApp

The app aims to be used for opening a new “current account” of already existing customers

You should clone the repo and start both CurrentAccount.Transaction.ServiceHost and CurrentAccount.Account.ServiceHost APIs

1. You can list the customer seed with GET https://localhost:44366/api/customer endpoint. I set 8 customers, ids 1-8.

2. The API will expose an endpoint which accepts the user information (customerID, 
initialCredit) -> for this, you can use CreateAccount endpoint. It is included in the postman collection. 
    POST https://localhost:44366/api/account
    body example : 
{
    "customerId" : 1,
    "initialCredit" : 5.0
}
In the result, you will get the information of the created account. Copy the accountId from result to your clipboard or you can list customer accounts with GET https://localhost:44366/api/account/get/1 and take it from here.
(If you call this again, new account will be created for the same customer. So the relation is 1 to many in this case.)
3. You can add more transactions to the created account with POST https://localhost:44313/api/transaction (you can also find this in the postman collection I shared)
You can create multiple transactions by calling this many time :)

body example : 
{
    "accountId":"9375961e-78ee-485b-a7a9-9b3efbfb4a2b", #your account's guid here
    "credit":4.7
}

4. Another Endpoint will output the user information showing Name, Surname, balance, and transactions of the accounts.
GET https://localhost:44366/api/account/9375961e-78ee-485b-a7a9-9b3efbfb4a2b with this endpoint, you can get account's all detail. 

