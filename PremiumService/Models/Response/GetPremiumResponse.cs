using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumService.Models.Response
{
    public class GetPremiumResponse
    {
        public string Carrier { get; set; }
        public double Premium { get; set; }

    }
}
