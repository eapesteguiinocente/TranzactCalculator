using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumService.Models.Map
{
    public class PremiumItemMap
    {
        public string Carrier { get; set; }
        public string Plan { get; set; }
        public string State { get; set; }
        public int MonthBirth { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public double Premium { get; set; }
    }
}
