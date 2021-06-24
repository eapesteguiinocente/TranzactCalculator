using PremiumService.IServices;
using PremiumService.Models.Map;
using PremiumService.Models.Request;
using PremiumService.Models.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PremiumService.Services
{
    public class PremiumServices : IPremiumServices
    {
        public DataTable GetData()
        {
            DataTable table = new DataTable("PremiumTable");
            table.Columns.Add("Carrier");
            table.Columns.Add("Plan");
            table.Columns.Add("State");
            table.Columns.Add("MonthBirth");
            table.Columns.Add("MinAge");
            table.Columns.Add("MaxAge");
            table.Columns.Add("Premium");

            table.Rows.Add("Qwerty", "A", "NY", 7, 21, 45, 150);
            table.Rows.Add("Qwerty", "B", "NY", 1, 46, 65, 200.5);
            table.Rows.Add("Qwerty", "A,C", "NY", 0, 18, 65, 120.99);
            table.Rows.Add("Qwerty", "A", "AL", 11, 18, 65, 85.5);
            table.Rows.Add("Qwerty", "C", "AL", 0, 18, 65, 100);
            table.Rows.Add("Qwerty", "A", "AK", 12, 65, -1, 175.2);
            table.Rows.Add("Qwerty", "A", "AK", 12, 18, 64, 125.16);
            table.Rows.Add("Qwerty", "B", "AK", 0, 18, 65, 100.8);
            table.Rows.Add("Qwerty", "A,C", "*", 0, 18, 65, 90);

            table.Rows.Add("Asdf", "A", "NY", 10, 21, 45, 150);
            table.Rows.Add("Asdf", "B", "NY", 1, 46, 65, 184.5);
            table.Rows.Add("Asdf", "A", "NY", 0, 18, 65, 129.95);
            table.Rows.Add("Asdf", "A", "AL", 11, 18, 65, 84.5);
            table.Rows.Add("Asdf", "B", "WY", 0, 18, 65, 100);
            table.Rows.Add("Asdf", "B,C", "AK", 0, 18, 65, 100.8);
            table.Rows.Add("Asdf", "A,C", "*", 0, 18, 65, 89.99);

            return table;
        }
        public List<PremiumItemMap> GetDataList()
        {
            List<PremiumItemMap> list = null;
            var table = GetData();
            if (table.Rows.Count > 0)
            {
                list = new List<PremiumItemMap>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    list.Add(new PremiumItemMap()
                    {
                        Carrier = table.Rows[i]["Carrier"].ToString(),
                        Plan = table.Rows[i]["Plan"].ToString(),
                        State = table.Rows[i]["State"].ToString(),
                        MonthBirth = Convert.ToInt32(table.Rows[i]["MonthBirth"]),
                        MinAge = Convert.ToInt32(table.Rows[i]["MinAge"]),
                        MaxAge = Convert.ToInt32(table.Rows[i]["MaxAge"]),
                        Premium = Convert.ToDouble(table.Rows[i]["Premium"]),
                    });
                }
            }
            return list;
        }
        public List<GetPremiumResponse> GetPremiumList(GetPremiunRequest request)
        {
            List<GetPremiumResponse> response = new List<GetPremiumResponse>();
            List<PremiumItemMap> list = GetDataList();
            if (list != null)
            {
                //Search Plan
                list = list.Where(x => x.Plan.ToLower().Contains(request.Plan.ToLower())).ToList();
                //Search State
                list = list.Where(x => x.State.ToLower() == request.State.ToLower()).Union(
                    list.Where(x => x.State == "*")
                    ).ToList();
                //Search MOB
                list = list.Where(x => x.MonthBirth == request.DateBirth.Month).Union(
                    list.Where(x => x.MonthBirth == 0)
                    ).ToList();
                //Search Age
                list = list.Where(x => x.MinAge <= request.Age && request.Age <= x.MaxAge).ToList();
            }
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    response.Add(new GetPremiumResponse
                    {
                        Carrier = item.Carrier,
                        Premium = item.Premium
                    });
                }
            }
            return response;
        }
    }
}
