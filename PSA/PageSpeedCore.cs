using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PSA
{
    public class PageSpeedCore
    {
        public object FetchURL(string v)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(v);

            HttpResponseMessage res = client.GetAsync("").Result;

            if(res.IsSuccessStatusCode)
            {
                return res;
            }
            else
            {
                return null;
            }
        }
    }
}
