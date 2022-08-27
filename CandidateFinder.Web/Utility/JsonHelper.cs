using System.Text.Json;

namespace CandidateFinder.Web.Utility
{
    public class JsonHelper
    {
        /// <summary>
        /// Ignores case while parsing json content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>A T Representation of the JSON Value</returns>
        public static T CaseInsensitiveDeserialize<T>(string content)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<T>(content, options);
            return result;
        }
    }
}
