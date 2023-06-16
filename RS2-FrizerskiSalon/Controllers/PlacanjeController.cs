using Microsoft.AspNetCore.Mvc;
using RS2_FrizerskiSalon.Services;
using Stripe;
using System;
using System.Threading;
using System.Threading.Tasks;
using FrizerskiSalon.Modal;
using System.Globalization;


namespace RS2_FrizerskiSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacanjeController : ControllerBase
    {
        public PlacanjeController(INarudzbaService narudzbaService)
        {
            _narudzbaService = narudzbaService;
        }
        public PlacanjeController(ITerminService terminService)
        {
            _terminService = terminService;
        }
        #nullable enable
        private INarudzbaService ?_narudzbaService;
        private ITerminService ?_terminService;

        private Token ?stripeToken;
        private TokenService ?Tokenservice;

        private string StripePublishableApiKey = "";
        private string StripeSecretApiKey = "";

        public bool IsTransactionSuccess { get; set; }

        [HttpPost]
        [Route("ProccessPayment")]
  
        public async Task<IActionResult> ProccessPayment(FrizerskiSalon.Modal.CreditCard creditCard)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            await Task.Run(() =>
            {
                var Token = CreateToken(creditCard);
                if (Token != null)
                {
                    if (creditCard.NarudzbaId != 0)
                    {
                        IsTransactionSuccess = MakePayment(Token, creditCard.Amount, creditCard.Currency, creditCard.NarudzbaId, creditCard.Description);
                    }
                    else if (creditCard.TerminId != 0)
                    {
                        IsTransactionSuccess = MakePayment(Token, creditCard.Amount, creditCard.Currency, creditCard.TerminId, creditCard.Description);
                    }

                }
            });
            if (IsTransactionSuccess)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

   
        private string CreateToken(FrizerskiSalon.Modal.CreditCard creditCard)
        {
            try
            {
                StripeConfiguration.ApiKey = StripePublishableApiKey;
                var service = new ChargeService();

                var tokenOptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = creditCard.Number,
                        ExpYear = Convert.ToString(creditCard.ExpYear, CultureInfo.InvariantCulture),
                        ExpMonth = Convert.ToString(creditCard.ExpMonth, CultureInfo.InvariantCulture),
                        Cvc = creditCard.Cvc,
                        Name = creditCard.Name,
                        AddressState = creditCard.AddressState,
                        AddressCountry = creditCard.AddressCountry,
                        AddressLine1 = creditCard.AddressLine1,
                        Currency = creditCard.Currency,
                        AddressLine2 = "SpringBoard",
                        AddressCity = "Gurgoan",
                        AddressZip = "284005",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(tokenOptions);
                return stripeToken.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool MakePayment(string token, long? amount, string currency, int transakcijaId, string description)
        {
            try
            {
                StripeConfiguration.ApiKey = StripeSecretApiKey;
                var options = new ChargeCreateOptions
                {
                    Amount = amount,
                    Currency = currency,
                    Description = description,
                    Source = stripeToken?.Id,
                    StatementDescriptor = "Custom descriptor",
                    Capture = true,
                    ReceiptEmail = "sejlamasic1997@hotmail.com",
                };
                var service = new ChargeService();
                Charge charge = service.Create(options);
                if (_terminService != null)
                {
                    _terminService.SetPaid(transakcijaId);
                }
                else if (_narudzbaService != null)
                {
                    _narudzbaService.SetPaid(transakcijaId);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
