using PremiumService.Models.Request;
using PremiumService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculatorWebApi.IServices
{
    public interface IPremiumServices
    {
        public List<GetPremiumResponse> GetPremiumList(GetPremiunRequest getTerritoryRequest);
    }
}
