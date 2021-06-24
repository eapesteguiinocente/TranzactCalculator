using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PremiumCalculatorWebApi.IServices;
using PremiumCalculatorWebApi.Models.Request;
using PremiumCalculatorWebApi.Validations;
using PremiumService.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculatorWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PremiumController : ControllerBase
    {
        private IPremiumServices _oPremium;
        private readonly ILogger<PremiumController> _logger;
        private RequestValidation validation;

        public PremiumController(IPremiumServices premiumServices, ILogger<PremiumController> logger)
        {
            _logger = logger;
            _oPremium = premiumServices;
            validation = new RequestValidation();
        }

        [HttpGet]
        public IActionResult GetPremiumList(string DateBirth, string State, int Age, string Plan)
        {
            DateTime dateBirthResult;
            if (validation.ValidateDate(DateBirth, out dateBirthResult))
            {
                return Ok(_oPremium.GetPremiumList(new GetPremiunRequest()
                {
                    Age = Age,
                    DateBirth = dateBirthResult,
                    Plan = Plan,
                    State = State
                }));
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
