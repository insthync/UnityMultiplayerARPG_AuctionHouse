﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UnityRestClient;

namespace MultiplayerARPG.Auction
{
    public class AuctionRestClient : RestClient
    {
        public string url;
        public string accessToken;

        public Task<Result<AuctionListResponse>> GetAuctionList(int limit = 20, int page = 1)
        {
            return Get<AuctionListResponse>(GetUrl(url, "/"), accessToken);
        }

        public Task<Result<AuctionListResponse>> GetHistoryList(int limit = 20, int page = 1)
        {
            return Get<AuctionListResponse>(GetUrl(url, "/history"), accessToken);
        }

        public Task<Result<AuctionData>> GetAuction(int id)
        {
            return Get<AuctionData>(GetUrl(url, $"/{id}"), accessToken);
        }

        public Task<Result> CreateAuction(int itemDataId, int itemLevel, int itemAmount, float itemDurability, int itemExp, float itemLockRemainsDuration, long itemExpireTime, int itemRandomSeed, string itemSockets, int startPrice, int buyoutPrice, string sellerId, string sellerName)
        {
            Dictionary<string, object> form = new Dictionary<string, object>();
            form.Add(nameof(itemDataId), itemDataId);
            form.Add(nameof(itemLevel), itemLevel);
            form.Add(nameof(itemAmount), itemAmount);
            form.Add(nameof(itemDurability), itemDurability);
            form.Add(nameof(itemExp), itemExp);
            form.Add(nameof(itemLockRemainsDuration), itemLockRemainsDuration);
            form.Add(nameof(itemExpireTime), itemExpireTime);
            form.Add(nameof(itemRandomSeed), itemRandomSeed);
            form.Add(nameof(itemSockets), itemSockets);
            form.Add(nameof(startPrice), startPrice);
            form.Add(nameof(buyoutPrice), buyoutPrice);
            form.Add(nameof(sellerId), sellerId);
            form.Add(nameof(sellerName), sellerName);
            return Post(GetUrl(url, "/internal/auction"), form, accessToken);
        }

        public Task<Result> Bid(string characterId, string characterName, int id, int price)
        {
            Dictionary<string, object> form = new Dictionary<string, object>();
            form.Add(nameof(characterId), characterId);
            form.Add(nameof(characterName), characterName);
            form.Add(nameof(id), id);
            form.Add(nameof(price), price);
            return Post(GetUrl(url, "/internal/bid"), form, accessToken);
        }

        public Task<Result> Buyout(string characterId, string characterName, int id)
        {
            Dictionary<string, object> form = new Dictionary<string, object>();
            form.Add(nameof(characterId), characterId);
            form.Add(nameof(characterName), characterName);
            form.Add(nameof(id), id);
            return Post(GetUrl(url, "/internal/buyout"), form, accessToken);
        }
    }
}
