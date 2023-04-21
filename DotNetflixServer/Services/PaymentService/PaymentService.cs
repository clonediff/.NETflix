using DtoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        static bool ValidateCredentialsFormat(CardDataDto cardCredentials)
        {
            if(!Regex.IsMatch(cardCredentials.CardNumber, @"\d\d*"))
                return false;

            return (cardCredentials.CVV_CVC >= 100 && cardCredentials.CVV_CVC <= 999);
        }

        public bool PayByCard(CardDataDto cardCredentials, decimal amount)
        {
            if(!ValidateCredentialsFormat(cardCredentials))
                return false;

            //payment logic

            return true;
        }
    }
}
