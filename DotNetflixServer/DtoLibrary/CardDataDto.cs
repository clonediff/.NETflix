using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLibrary
{
    public class CardDataDto
    {
        public string CardNumber { get; set; }
        public string Cardholder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVV_CVC { get; set; }
    }
}
