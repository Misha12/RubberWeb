using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RubberWeb.Models.GrillBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RubberWeb.Services
{
    public class GrillBotService : IDisposable
    {
        private ulong GuildID { get; }
        private HttpClient HttpClient { get; }

        public GrillBotService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            GuildID = config.GetValue<ulong>("Guild");
            HttpClient = httpClientFactory.CreateClient("GrillBot");
        }

        public async Task<List<SimpleUserInfo>> GetUsersSimpleInfoBatchAsync(List<ulong> userIds)
        {
            var queryParams = string.Join("&", userIds.Select(id => $"userIds={id}"));
            var response = await HttpClient.GetAsync($"users/usersSimpleInfoBatch/{GuildID}?{queryParams}");

            if (!response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                throw new WebException(responseData);
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<SimpleUserInfo>>(content);
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}
