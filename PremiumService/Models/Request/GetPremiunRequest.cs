using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumService.Models.Request
{
    public class GetPremiunRequest
    {
        public DateTime DateBirth { get; set; }
        public string State { get; set; }
        public int Age { get; set; }
        public string Plan { get; set; }
    }
}
