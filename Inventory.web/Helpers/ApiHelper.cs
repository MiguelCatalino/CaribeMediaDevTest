using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.web.Helpers
{
    public static class ApiHelper
    {
        public static async Task<T> GetAsync<T>(string baseUrl, string action, int id) where T : new()
        {
            var result = new T();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var Res = await client.GetAsync($"{action}/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<T>(response);
                }
            }
            return result;
        }
        public static async Task<List<T>> GetListAsync<T>(string baseUrl, string action)
        {
            var resultList = new List<T>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var Res = await client.GetAsync(action);
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    resultList = JsonConvert.DeserializeObject<List<T>>(response);
                }
            }
            return resultList;
        }
        public static async Task<(bool, string)> PostAsync<T>(string baseUrl, string action, T value)
        {
            bool isSuccess = false;
            string message = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
                var Res = await client.PostAsync(action, content);
                isSuccess = Res.IsSuccessStatusCode;
                message = Res.StatusCode.ToString();
            }
            return (isSuccess, message);
        }
        public static async Task<(bool, string)> DeleteAsync(string baseUrl, string action, int id)
        {
            bool isSuccess = false;
            string message = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var Res = await client.DeleteAsync($"{action}/{id}");
                isSuccess = Res.IsSuccessStatusCode;
                message = Res.StatusCode.ToString();
            }
            return (isSuccess, message);
        }
        public static async Task<(bool, string)> PutAsync<T>(string baseUrl, string action, int id, T value)
        {
            bool isSuccess = false;
            string message = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
                var Res = await client.PutAsync($"{action}/{id}", content);
                isSuccess = Res.IsSuccessStatusCode;
                message = Res.StatusCode.ToString();
            }
            return (isSuccess, message);
        }
    }
}
