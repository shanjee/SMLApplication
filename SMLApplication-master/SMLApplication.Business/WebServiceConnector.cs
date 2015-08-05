using Newtonsoft.Json;
using RestSharp;
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
        readonly string webUrl = "http://localhost:11737/api/patient/";
        RestClient client = new RestClient("http://localhost:11737/api");
        


        public List<T> GetResult(int id = -1)
        {
            string uri = "patient/" + (id != -1 ? id + "/" : "");
            var request = new RestRequest(uri, Method.GET);
            var queryResult = client.Execute<List<T>>(request).Data;
            return queryResult;
        }

        public void PutResult(T data)
        {
            var request = new RestRequest("patient/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(data);
            client.Execute(request);
        }

        public List<T> GetData(int id=-1)
        {
            string uri = webUrl;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var data = JsonConvert.DeserializeObjectAsync<List<T>>(response.Result).Result;
                return data;
            }
        }

        public T GetDataById(int id = -1)
        {
            string uri = webUrl + id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var data = JsonConvert.DeserializeObjectAsync<T>(response.Result).Result;
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
