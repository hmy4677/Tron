using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Fetch
{
    public interface IFetchService
    {
        Task<dynamic> ContractFetchAsync(string address);
    }
}
