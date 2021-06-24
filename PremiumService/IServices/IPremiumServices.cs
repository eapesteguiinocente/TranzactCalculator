using PremiumService.Models.Request;
using PremiumService.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumService.IServices
{
    public interface IPremiumServices
    {
        public List<GetPremiumResponse> GetPremiumList(GetPremiunRequest request);
    }
}
