using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HaloEzAPI.Limits
{
    public static class HttpClientRateHandler
    {
        private static readonly HttpClient HttpClient;
        private static readonly SemaphoreSlim RateSemaphore;

        private static ConcurrentQueue<sk> TaskList = new List<Task>(); 
        private const int Limit = 10;
        private const string APITokenHeader = "Ocp-Apim-Subscription-Key";

        static HttpClientRateHandler()
        {
            HttpClient = new HttpClient();
            RateSemaphore = new SemaphoreSlim(Limit);
        }

        public static void SetAPIToken(string token)
        {
            if (!HttpClient.DefaultRequestHeaders.Contains(APITokenHeader))
            {
                HttpClient.DefaultRequestHeaders.Add(APITokenHeader, token);
            }
        }    

        public static async Task<HttpResponseMessage> GetRequest(Uri endpoint)
        {
            var task = HttpClient.GetAsync(endpoint);
            TaskList.Add(task);
            await Task.Run(() => ProcessRequests());
            return await task;
        }

        private static async void ProcessRequests()
        {
            
            await TaskQue

            await Task.WhenAll(TaskList).ContinueWith(t =>
            {
                RateSemaphore.Release();
            });
        }
    }
}
