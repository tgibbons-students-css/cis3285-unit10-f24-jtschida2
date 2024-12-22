using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class URLAsyncProvider : ITradeDataProvider
    {
        private readonly ITradeDataProvider _baseTradeProvider;
        public URLAsyncProvider(ITradeDataProvider baseTradeProvider)
        {
            _baseTradeProvider = baseTradeProvider;
        }

        public IEnumerable<string> GetTradeData()
        {
            Task<IEnumerable<string>> task = Task.Run(() => _baseTradeProvider.GetTradeData()); ;
            task.Wait();
            IEnumerable<string> lines = task.Result;
            return lines;
        }
    }
}
