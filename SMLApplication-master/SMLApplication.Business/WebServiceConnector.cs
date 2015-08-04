using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SMLApplication.Business
{
    public class WebServiceConnector<T>
    {
        readonly string webUrl = "http://192.168.1.30:8280/loginapi/login/";

        
        public List<T> GetData(int id=-1)
        {
            string uri = webUrl + (id!=-1 ? id + "/" : "");
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var data = JsonConvert.DeserializeObjectAsync<List<T>>(response.Result).Result;
                return data;
            }
        }

        public void PutData(T data)
        {
            HttpClient client = new HttpClient();
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8,
            "application/json");  
             
            client.PostAsync(new Uri(webUrl), contentPost);
                
                //.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
        }
    }
}
