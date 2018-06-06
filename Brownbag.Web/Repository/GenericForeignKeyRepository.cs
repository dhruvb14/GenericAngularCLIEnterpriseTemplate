using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Brownbag.Web.Repository {
    public class GenericForeignKeyRepository {
        private readonly IConfiguration _configuration;

        public GenericForeignKeyRepository(IConfiguration configuration) {
            _configuration = configuration;
        }
        public async Task<Dictionary<string, dynamic>> GetGenericForeignKeyByIdAsync(int Id, string Repository, string Endpoint) {
            /*
             * Get All the rest configuration for request
             */
            var ApiBase = _configuration[Repository + "_API_BASE_URL"];
            var ApiAuthStart = _configuration[Repository + "_API_AUTH_START"];
            var ApiAuthEnd = _configuration[Repository + "_API_AUTH_END"];
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            /*
             * Add authentication for request
             */
            string TempKey = $"{ApiAuthStart}{DateTimeOffset.Now.UtcDateTime.ToString("MMddyyHH")}{ApiAuthEnd}";
            var Base64AuthKey = System.Text.Encoding.UTF8.GetBytes((TempKey));
            var ApiKey = Convert.ToBase64String(Base64AuthKey);
            client.DefaultRequestHeaders.Add("auth", ApiKey);
            /*
             * Build and execute request
             */
            var endpointUrl = ApiBase + Endpoint + "/" + Id;
            var streamTask = client.GetStringAsync(endpointUrl);
            /*
             * Convert results to generic dictionary
             */
            dynamic data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(await streamTask);
            return data;
        }
        public async Task<IList<Dictionary<string, dynamic>>> GetGenericRemoteLookupsAsync(string Repository, string Endpoint) {
            /*
             * Get All the rest configuration for request
             */
            var ApiBase = _configuration[Repository + "_API_BASE_URL"];
            var ApiAuthStart = _configuration[Repository + "_API_AUTH_START"];
            var ApiAuthEnd = _configuration[Repository + "_API_AUTH_END"];
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            /*
             * Add authentication for request
             */
            string TempKey = $"{ApiAuthStart}{DateTimeOffset.Now.UtcDateTime.ToString("MMddyyHH")}{ApiAuthEnd}";
            var Base64AuthKey = System.Text.Encoding.UTF8.GetBytes((TempKey));
            var ApiKey = Convert.ToBase64String(Base64AuthKey);
            client.DefaultRequestHeaders.Add("auth", ApiKey);
            /*
             * Build and execute request
             */
            var endpointUrl = ApiBase + Endpoint;
            var streamTask = client.GetStringAsync(endpointUrl);
            /*
             * Convert results to generic dictionary
             */
            dynamic data = JsonConvert.DeserializeObject<IList<Dictionary<string, dynamic>>>(await streamTask);
            return data;
        }
    }
}