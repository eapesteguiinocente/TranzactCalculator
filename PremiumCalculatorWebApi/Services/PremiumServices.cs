using PremiumCalculatorWebApi.IServices;
using PremiumService.Models.Request;
using PremiumService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculatorWebApi.Services
{
    public class PremiumServices : IPremiumServices
    {
        public List<GetPremiumResponse> GetPremiumList(GetPremiunRequest request)
        {
            PremiumService.Services.PremiumServices premiumServices = new PremiumService.Services.PremiumServices();
            return premiumServices.GetPremiumList(request);
        }
    }
}
