using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        URLTradeDataProvider url;
        public AdjustTradeDataProvider(URLTradeDataProvider url)
        {
            this.url = url;
        }
        public IEnumerable<string> GetTradeData()
        {
            var tradeData = url.GetTradeData();

            var updatedTradeData = tradeData.Select(data => data.Replace("GBP", "EUR"));

            return updatedTradeData;
        }
    }
}
