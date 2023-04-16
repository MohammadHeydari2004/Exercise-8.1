using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Handlers;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace tamrin8API
{
    public class ReadAPI
    {
        public static async Task<Data2API> ReadAPI1()
        {
            string URL = "https://api.kucoin.com/api/v1/market/stats?symbol=BTC-USDT";
            using (HttpResponseMessage response = await API.Client.GetAsync(URL))
            {
                if (response.IsSuccessStatusCode)
                {
                    DataAPI Data = await response.Content.ReadAsAsync<DataAPI>();

                    return Data.data;
                }
                else
                    throw new Exception(response.ReasonPhrase);


            }
        }

    }
}
