using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Fetch
{
    public interface IFetchService
    {
        Task ExcuteFetch(string address,int start,int limit);
    }
}
