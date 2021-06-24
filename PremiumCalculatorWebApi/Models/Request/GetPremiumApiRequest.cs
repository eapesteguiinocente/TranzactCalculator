using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculatorWebApi.Models.Request
{
    public class GetPremiumApiRequest
    {
        public string DateBirth { get; set; }
        public string State { get; set; }
        public int Age { get; set; }
        public string Plan { get; set; }
    }
}
