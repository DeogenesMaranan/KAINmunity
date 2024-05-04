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
        GET, POST, PUT
    }

    internal class APIConnector
    {
        private static readonly string _api_url;

        static APIConnector()
        {
            _api_url = "http://localhost:5000/api/";
        }

        public static async Task<Dictionary<string, object>> SendRequest(RequestMethod method, string endpoint, Dictionary<string, object> body = null)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = null;

                    switch (method)
                    {
                        case RequestMethod.GET:
                            {
                                response = await client.GetAsync(_api_url + endpoint);
                                break;
                            }
                        case RequestMethod.POST:
                            {
                                string json = JsonConvert.SerializeObject(body);
                                var content = new StringContent(json, Encoding.UTF8, "application/json");
                                response = await client.PostAsync(_api_url + endpoint, content);
                                break;
                            }
                        case RequestMethod.PUT:
                            {
                                string json = JsonConvert.SerializeObject(body);
                                var content = new StringContent(json, Encoding.UTF8, "application/json");
                                response = await client.PutAsync(_api_url + endpoint, content);
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
