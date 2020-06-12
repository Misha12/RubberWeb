using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RubberWeb.Models.GrillBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        public async Task<List<SimpleUserInfo>> GetUsersSimpleInfoBatchAsync(IEnumerable<ulong> userIds)
        {
            var request = new GetUsersSimpleInfoBatchRequest() { UserIDs = userIds.ToList() };
            using var postData = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync($"users/usersSimpleInfoBatch/{GuildID}", postData);
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
