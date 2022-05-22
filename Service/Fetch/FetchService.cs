
using Furion.FriendlyException;
using Furion.RemoteRequest.Extensions;
using Interface.Fetch;
using Mapster;
using Model.Dto.Fetch;
using Model.Entity;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Yitter.IdGenerator;

namespace Furion.Application.Implement.Fetch
{
    internal class FetchService : IFetchService
    {
        private readonly SqlSugarProvider _db;

        public FetchService()
        {
            _db = DbScoped.SugarScope.GetConnection("db1");
        }

        public async Task<dynamic> ContractFetchAsync(string address)
        {
            _db.CodeFirst.InitTables<ContractBaseEntity>();
            var task = await _db.Queryable<CollectTaskEntity>().FirstAsync(p => p.CollectAddress == address);
            // contract base info
            var url = $"https://apilist.tronscan.org/api/contract?contract={address}&type=contract";
            var response = await url.GetAsAsync<ContractData>();
            if (response.Status.Code != 0) throw Oops.Oh("Request Error:" + response.Status.Message);

            var info = response.Data.First();
            var id = YitIdHelper.NextId();
            var nowTime = DateTime.Now;

            var entity = new ContractBaseEntity
            {
                Id = id,
                Balance = Convert.ToDecimal( info.balance*1.0 / 1000_000),
                Transactions = info.trxCount,
                CollectTime = nowTime,
                ContractId = task.Id,
            };
            task.LastCollectTime = nowTime;

            var count = await _db.Insertable(entity).ExecuteCommandAsync();
            await _db.Updateable(task).ExecuteCommandAsync();

            //contract token list
            var tokenurl = $"https://apilist.tronscan.org/api/account/tokens?address={address}&start=0&limit=20&hidden=0";
            var test = await tokenurl.GetAsStringAsync();
            var tokenRes = await tokenurl.GetAsAsync<ContractToken>();
            _db.CodeFirst.InitTables<ContractTokenEntity>();
            foreach (var item in tokenRes.Data)
            {
                var newToken = item.Adapt<ContractTokenEntity>();
                newToken.Id = YitIdHelper.NextId();
                newToken.ContractId = id;
                newToken.CollectTime = nowTime;
                newToken.Balance = Convert.ToDecimal(item.Balance * 1.0 / 1000_000);
                await _db.Insertable(newToken).ExecuteCommandAsync();
            }

            return new { count };
        }
    }
}
