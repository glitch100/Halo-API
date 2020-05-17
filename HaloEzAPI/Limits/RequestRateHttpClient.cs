using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace HaloEzAPI.Limits
{
    /// <summary>
    /// Responsible for handling all Http Request to the API, via a Semaphore and Stopwatch system
    /// to prevent excessive requests.
    /// </summary>
    public static class RequestRateHttpClient
    {
        private static readonly HttpClient HttpClient;
        private static SemaphoreSlim _rateSemaphore;
        private static int _limit = 10;

        /// <summary>
        /// Number of seconds the for the Limit of requests (10 seconds for 10 requests etc)
        /// </summary>
        public static int SecondsLimit = 10;
        private const string APITokenHeader = "Ocp-Apim-Subscription-Key";
        private static readonly Stopwatch Stopwatch;
        private static int _concurrentRequests = 0;
        static RequestRateHttpClient()
        {
            // TODO: On migration to dotnet core use the HttpClientFactory
            var httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression =  DecompressionMethods.Deflate | DecompressionMethods.GZip 
            };
            HttpClient = new HttpClient(httpClientHandler);
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _rateSemaphore = new SemaphoreSlim(_limit,_limit);
            Stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Set the API Token Header in the HttpClient
        /// </summary>
        /// <param name="token">Your Halo Developer API Token</param>
        public static void SetAPIToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return;
            }
            if (HttpClient.DefaultRequestHeaders.Contains(APITokenHeader))
            {
                HttpClient.DefaultRequestHeaders.Remove(APITokenHeader);
            }
            HttpClient.DefaultRequestHeaders.Add(APITokenHeader, token);
        }

        /// <summary>
        /// Recreates the Semaphore, and reassigns a Limit
        /// </summary>
        /// <param name="limit">Request limit</param>
        public static void SetRequestLimit(int limit)
        {
            _limit = limit;
            _rateSemaphore = new SemaphoreSlim(limit, limit);
        }

        /// <summary>
        /// Assigns a new seconds limit
        /// </summary>
        /// <param name="limit">Seconds limit</param>
        public static void SetSecondsLimit(int limit)
        {
            SecondsLimit = limit;
        }

        /// <summary>
        /// Goes to make a Get request to the specified Uri, only if it hasn't exceeded the call limit 
        /// </summary>
        /// <param name="endpoint">Endpoint to request</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetRequest(Uri endpoint)
        {
            await _rateSemaphore.WaitAsync();
            if (Stopwatch.Elapsed.Seconds >= SecondsLimit || _rateSemaphore.CurrentCount == 0 || _concurrentRequests == _limit)
            {
                int seconds = (SecondsLimit - Stopwatch.Elapsed.Seconds) * 1000;
                int sleep = seconds > 0 ? seconds : seconds * -1;
                await Task.Delay(sleep);
                _concurrentRequests = 0;
                Stopwatch.Restart();
            }
            ++_concurrentRequests;
            var task = await HttpClient.GetAsync(endpoint).ContinueWith(t =>
            {
                _rateSemaphore.Release();
                if (_rateSemaphore.CurrentCount == _limit && Stopwatch.Elapsed.Seconds >= SecondsLimit)
                {
                    Stopwatch.Restart();
                    --_concurrentRequests;
                }
                return t;
            });
            return await task;
        }
    }
}
