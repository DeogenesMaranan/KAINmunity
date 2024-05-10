using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KainmunityClient.ServerAPI
{
    internal enum RequestMethod
    {
        GET, POST, PUT, DELETE
    }

    internal class APIConnector
    {
        public static string ApiUrl { get; set; }

        public static string UserId { get; set; }
        public static string AccountType { get; set; }

        static APIConnector()
        {
            
        }

        public static async Task<Dictionary<string, object>> SendRequest(RequestMethod method, string endpoint, Dictionary<string, object> dictionaryBody = null, List<object> listBody = null)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = null;

                    if (!string.IsNullOrEmpty(UserId))
                    {
                        client.DefaultRequestHeaders.Add("User-Id", UserId);
                    }

                    switch (method)
                    {
                        case RequestMethod.GET:
                            {
                                response = await client.GetAsync(ApiUrl + endpoint);
                                break;
                            }
                        case RequestMethod.POST:
                            {
                                string json = dictionaryBody == null ? JsonConvert.SerializeObject(listBody) : JsonConvert.SerializeObject(dictionaryBody);
                                var content = new StringContent(json, Encoding.UTF8, "application/json");
                                response = await client.PostAsync(ApiUrl + endpoint, content);
                                break;
                            }
                        case RequestMethod.PUT:
                            {
                                string json = dictionaryBody == null ? JsonConvert.SerializeObject(listBody) : JsonConvert.SerializeObject(dictionaryBody);
                                var content = new StringContent(json, Encoding.UTF8, "application/json");
                                response = await client.PutAsync(ApiUrl + endpoint, content);
                                break;
                            }
                    }
                        
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

                    return responseDict;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return null;
        }
    }
}
