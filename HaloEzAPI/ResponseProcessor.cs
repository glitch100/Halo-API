using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Interfaces;
using HaloEzAPI.Limits;
using HaloEzAPI.Model.Response.Error;
using Newtonsoft.Json;

namespace HaloEzAPI
{
    public class ResponseProcessor
    {
        private readonly IApiCacheManager _apiCache;
        public ResponseProcessor(IApiCacheManager apiCache)
        {
            _apiCache = apiCache;
        }

        /// <summary>
        /// Handle the HttpResponse, by throwing a known exception, or by deserializing into T
        /// </summary>
        /// <typeparam name="T">The type to deserialize into</typeparam>
        /// <param name="message">The HttpResponseMessage</param>
        /// <returns></returns>
        public async Task<T> HandleResponse<T>(HttpResponseMessage message) where T : class
        {
            if (message.IsSuccessStatusCode)
            {
                var messageJson = await message.Content.ReadAsStringAsync();
                var messageObject = JsonConvert.DeserializeObject<T>(messageJson);
                if (messageObject == null)
                {
                    throw new HaloAPIException(CommonErrorMessages.CantDeserialize);
                }
                return messageObject;
            }
            BaseHandleResponse(message);
            throw new HaloAPIException(string.Format("Unknown Error in HandleResponse: {0}", message.RequestMessage));
        }

        private async Task<Image> HandleImageResponse(HttpResponseMessage message)
        {
            if (message.IsSuccessStatusCode)
            {
                Image image;
                using (var stream = await message.Content.ReadAsStreamAsync())
                {
                    image = Image.FromStream(stream);
                }
                return image;
            }
            BaseHandleResponse(message);
            throw new HaloAPIException(string.Format("Unknown Error in HandleImageResponse: {0}", message.RequestMessage));
        }

        internal void BaseHandleResponse(HttpResponseMessage message)
        {
            if (message.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HaloAPIException(message.ReasonPhrase);
            }
            if (message.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HaloAPIException(message.ReasonPhrase);
            }
            if (message.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HaloAPIException(CommonErrorMessages.AccessDenied);
            }
            if (message.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new HaloAPIException(CommonErrorMessages.BadRequest);   
            }
            if (message.StatusCode == (HttpStatusCode) 429)
            {
                throw new HaloAPIException(CommonErrorMessages.TooManyRequests);
            }
        }

        public async Task<Image> ProcessImageRequest(Uri endpoint, int cacheExpiryMin, bool bustCache = false)
        {
            string key = endpoint.AbsoluteUri;
            if (!bustCache && _apiCache.Contains(key))
            {
                return _apiCache.Get<Image>(key);
            }
            if (bustCache)
            {
                _apiCache.Remove(key);
            }
            var message = await RequestRateHttpClient.GetRequest(endpoint);
            var messageObject = await HandleImageResponse(message);
            _apiCache.Add<Image>(messageObject, key, cacheExpiryMin);
            return messageObject;
        }

        public async Task<T> ProcessRequest<T>(Uri endpoint, int cacheExpiryMin, bool bustCache = false) where T : class
        {
            string key = endpoint.AbsoluteUri;
            if (!bustCache && _apiCache.Contains(key))
            {
                return _apiCache.Get<T>(key);
            }
            if (bustCache)
            {
                _apiCache.Remove(key);
            }
            var message = await RequestRateHttpClient.GetRequest(endpoint);
            var messageObject = await HandleResponse<T>(message);
            _apiCache.Add<T>(messageObject, key, cacheExpiryMin);
            return messageObject;
        }
    }
}