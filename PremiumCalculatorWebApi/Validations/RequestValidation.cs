using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculatorWebApi.Validations
{
    public class RequestValidation
    {
        public bool ValidateAge(int age, DateTime DOB)
        {
            bool flag = false;
            int agePlusMonths = age + 1;// Lets allow when someone has years and a few months
            DateTime today = DateTime.Now;
            DateTime MinDate = DOB.AddYears(age); DateTime MaxDate = DOB.AddYears(agePlusMonths);
            if (today > MinDate && today < MaxDate) { flag = true; }
            return flag;
        }
        public bool ValidateDate(string datetime, out DateTime date)
        {
            bool flag = false;
            flag = DateTime.TryParse(datetime, out date);
            return flag;
        }
    }
}
