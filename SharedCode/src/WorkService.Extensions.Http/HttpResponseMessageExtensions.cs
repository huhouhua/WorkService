using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkService.Extensions.Http
{
    public static class HttpResponseMessageExtensions
    {

        public async static Task<T> AsJson<T>(this HttpResponseMessage httpResponseMessage)
        {
            string json = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);

        }

    }
}
