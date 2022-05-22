﻿using Furion.DependencyInjection;
using Furion.FriendlyException;
using Furion.RemoteRequest.Extensions;
using Interface.Fetch;
using Mapster;
using Model.Dto.Fetch;
using Model.Entity;
using SqlSugar;
using SqlSugar.IOC;
using Yitter.IdGenerator;

namespace Furion.Application.Implement.Fetch
{
    internal class FetchService : IFetchService, ITransient
    {
        private readonly SqlSugarProvider _db;

        public FetchService()
        {
            _db = DbScoped.SugarScope.GetConnection("db1");
        }

        public async Task ExcuteFetch(string address)
        {
#if DEBUG
            _db.CodeFirst.SetStringDefaultLength(50).InitTables<ContractBaseEntity, ContractTokenEntity>();
#endif
            var task = await _db.Queryable<CollectTaskEntity>().FirstAsync(p => p.CollectAddress == address);
            var fetchId = YitIdHelper.NextId();
            var nowTime = DateTime.Now;

            await FetchBase(address, fetchId, task.Id, nowTime);
            await FetchToken(address, fetchId, nowTime);
            await FetchTransaction(address, fetchId, nowTime, 0, 20);
            await FetchTrasfer(address, fetchId, nowTime, 0, 20);
            await FetchInternal(address, fetchId, nowTime, 0, 20);
            await FetchEvent(address, fetchId, nowTime);

            task.LastCollectTime = nowTime;
            await _db.Updateable(task).ExecuteCommandAsync();
        }

        public async Task FetchBase(string address, long fetchId, long relationId, DateTime fetchTime)
        {
            var url = $"https://apilist.tronscan.org/api/contract?contract={address}&type=contract";
            var response = await url.GetAsAsync<ContractData>();
            if (response.Status.Code != 0) throw Oops.Oh("Request Error:" + response.Status.Message);
            var info = response.Data.First();
            var entity = new ContractBaseEntity
            {
                Id = fetchId,
                Balance = Convert.ToDecimal(info.balance * 1.0 / 1000_000),
                Transactions = info.trxCount,
                RelationId = relationId,
                CollectTime = fetchTime,
            };
            await _db.Insertable(entity).ExecuteCommandAsync();
        }

        public async Task FetchToken(string address, long relationId, DateTime fetchTime)
        {
            var url = $"https://apilist.tronscan.org/api/account/tokens?address={address}&start=0&limit=20&hidden=0";
            var response = await url.GetAsAsync<ContractToken>();
            foreach (var item in response.Data)
            {
                var newToken = item.Adapt<ContractTokenEntity>();
                newToken.Id = YitIdHelper.NextId();
                newToken.RelationId = relationId;
                newToken.CollectTime = fetchTime;
                newToken.Balance = Convert.ToDecimal(item.Balance * 1.0 / 1000_000);

                await _db.Insertable(newToken).ExecuteCommandAsync();
            }
        }

        public async Task FetchTransaction(string address, long relationId, DateTime fetchTime, int start, int limit)
        {
            var url = $"https://apilist.tronscan.org/api/transaction?sort=-timestamp&count=true&limit={limit}&start={start}&address={address}";
            var response = await url.GetAsAsync<ContractTransaction>();
            foreach (var item in response.Data)
            {
                var newTransaction = item.Adapt<ContractTransactionEntity>();
                newTransaction.Id = YitIdHelper.NextId();
                newTransaction.MethodName = item.trigger_info.methodName;
                newTransaction.Token = item.tokenInfo.tokenName;
                newTransaction.RelationId = relationId;
                newTransaction.CollectTime = fetchTime;

                await _db.Insertable(newTransaction).ExecuteCommandAsync();
            }
        }

        public async Task FetchTrasfer(string address, long relationId, DateTime fetchTime, int start, int limit)
        {
            var url = $"https://apilist.tronscan.org/api/transfer?sort=-timestamp&count=true&limit={limit}&start={start}&address={address}";
            var response = await url.GetAsAsync<ContractTransfer>();
            foreach (var item in response.data)
            {
                var newTransfer = item.Adapt<ContractTransferEntity>();
                newTransfer.Id = YitIdHelper.NextId();
                newTransfer.token = item.tokenInfo.tokenName;
                newTransfer.RelationId = relationId;
                newTransfer.CollectTime = fetchTime;

                await _db.Insertable(newTransfer).ExecuteCommandAsync();
            }
        }

        public async Task FetchInternal(string address, long relationId, DateTime fetchTime, int start, int limit)
        {
            var url = $"https://apilist.tronscan.org/api/internal-transaction?limit={limit}&start={start}&confirm=&address={address}";
            var response = await url.GetAsAsync<ContractInternal>();
            foreach (var item in response.data)
            {
                var newInter = item.Adapt<ContractInternalEntity>();
                newInter.Id = YitIdHelper.NextId();
                newInter.token = item.token_list.tokenName;
                newInter.RelationId = relationId;
                newInter.CollectTime = fetchTime;

                await _db.Insertable(newInter).ExecuteCommandAsync();
            }
        }

        public async Task FetchEvent(string address, long relationId, DateTime fetchTime)
        {
            var url = $"https://apilist.tronscan.org/api/contracts/smart-contract-triggers-batch?fields=hash,method";
            var body = new { contractAddress = address };
            var response =await url.SetBody(body).PostAsAsync<EventList>();
            foreach (var item in response.event_list)
            {
                var newEvent = item.Adapt<ContractEventEntity>();
                newEvent.Id = YitIdHelper.NextId();
                newEvent.RelationId=relationId;
                newEvent.CollectTime = fetchTime;
                newEvent.zero = item.result.zero;
                newEvent.two = item.result.two;
                newEvent.two = item.result.two;
                newEvent.value = item.result.value;
                newEvent.from = item.result.from;
                newEvent.to = item.result.to;
                newEvent.spender = item.result.spender;
                newEvent.owner = item.result.owner;

                await _db.Insertable(newEvent).ExecuteCommandAsync();
            }
        }
    }
}