using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HaloEzAPI.Limits
{
    /// <summary>
    /// Responsible for handling all Http Request to the API, via a Semaphore and Stopwatch system
    /// to prevent excessive requests.
    /// </summary>
    public static class RequestRateHttpClient
    {
        private static readonly HttpClient HttpClient;
        private static readonly SemaphoreSlim RateSemaphore;
        private const int Limit = 10;
        /// <summary>
        /// Number of seconds the for the Limit of requests (10 seconds for 10 requests etc)
        /// </summary>
        public static int SecondsLimit = 10;
        private const string APITokenHeader = "Ocp-Apim-Subscription-Key";
        private static readonly Stopwatch Stopwatch;
        private static int _concurrentRequests = 0;
        static RequestRateHttpClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression =  DecompressionMethods.Deflate | DecompressionMethods.GZip 
            };
            HttpClient = new HttpClient(httpClientHandler);
            RateSemaphore = new SemaphoreSlim(Limit,Limit);
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
        /// Goes to make a Get requst to the specifed Uri, only if it hasn't exceeded the call limit 
        /// </summary>
        /// <param name="endpoint">Endpoint to request</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetRequest(Uri endpoint)
        {
            await RateSemaphore.WaitAsync();
            if (Stopwatch.Elapsed.Seconds >= SecondsLimit || RateSemaphore.CurrentCount == 0 || _concurrentRequests == Limit)
            {
                int seconds = Stopwatch.Elapsed.Seconds;

                Thread.Sleep((SecondsLimit - seconds) * 1000);
                _concurrentRequests = 0;
                Stopwatch.Restart();
            }
            _concurrentRequests++;
            var task = await HttpClient.GetAsync(endpoint).ContinueWith(t =>
            {
                RateSemaphore.Release();
                if (RateSemaphore.CurrentCount == Limit && Stopwatch.Elapsed.Seconds >= SecondsLimit)
                {
                    Stopwatch.Restart();
                    _concurrentRequests --;
                }
                return t;
            });
            return await task;
        }
    }
}
