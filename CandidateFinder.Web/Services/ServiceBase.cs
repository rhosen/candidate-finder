using CandidateFinder.Web.Utility;

namespace CandidateFinder.Web.Services
{
    public abstract class ServiceBase
    {
        private readonly HttpClient _httpClient;

        public ServiceBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// For getting the resources from a web api
        /// </summary>
        /// <param name="path">API path</param>
        /// <returns>A Task with result object of type T</returns>
        protected async Task<T> GetAsync<T>(string path)
        {
            var response = await _httpClient.GetAsync(path).ConfigureAwait(false);
            try
            {
                response.EnsureSuccessStatusCode();
                return await GetResultAsync<T>(response);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        private async Task<T> GetResultAsync<T>(HttpResponseMessage response)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            T result = JsonHelper.CaseInsensitiveDeserialize<T>(responseBody);
            return result;
        }
    }
}
