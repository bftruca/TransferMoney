# TransferMoney
A simple app in .NET MVC that simulate a transfer of your money to someone .

1.) It has a login page .
- i used a library, for ecnryption of password .

2.) After you are logged in, you can see your transactions: (Home Page)
- there you can change the status of your trasaction(s) (Completed / Revoked / Refunded etc.) 
- you can renew the expiration date of your token* .

3.) Transaction page; Where you complete what it takes for a transfer/transaction . 
Details like CNP (ID of a Romanian identity card), IBAN (International Bank Account Number), Amount and the Currencies (your currency and receiver currency)
- for CNP, i used a custom validation that inheritance ValidationAttribute
- for IBAN i used an API : https://openiban.com
- and for currencies i also used an API : https://exchangeratesapi.io
- there is also custom taxes and commissions . If the country of the bank where you want to transfer it's not in UE, you have 2% commission (by checking first two letter of the IBAN)
- Taxes and comission are calculated on server side, using an Ajax Request and it fills the receicer's amount .
- after a transaction it's finished, it's automatically generated a token for that transaction *

4.) A check page, where you can check a transaction by using the CNP and Token .

For the connection with database i used: SQL Server / ADO .NET / Stored Precedures 
Patterns : Singleton Pattern for db and APIs

Login:
user: bogdan
pass: parola

user: user
pass: user
