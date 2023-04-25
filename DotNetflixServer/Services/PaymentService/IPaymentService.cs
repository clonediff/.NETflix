using DtoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PaymentService
{
    internal interface IPaymentService
    {
        bool PayByCard(CardDataDto cardCredentials, decimal amount);
    }
}
