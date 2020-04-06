using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using FoodSafety.API.Helpers;
using FoodSafety.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json;

namespace FoodSafety.API.Data
{
    public class RestuarantRepoKingCounty : IRestuarantRepository
    {
        const string data = "https://data.kingcounty.gov/resource/f29f-zza5.json";
        private readonly IHttpClientFactory _clientFactory;
        public IEnumerable<RestuarantDeserializer> Restuarants { get; private set; }


        private readonly IMapper _mapper;

        public RestuarantRepoKingCounty(IHttpClientFactory clientFactory, IMapper mapper)
        {
            _mapper = mapper;
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<Restuarant>> GetRestuarantsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, data + "?$limit=25&$offset=5&$select=business_id,name,phone,address,MAX(inspection_date),grade,city, zip_code&$group=business_id,name,phone,address,city, zip_code, grade");

            var client = _clientFactory.CreateClient();

            var res = await client.SendAsync(request);

            if (res.IsSuccessStatusCode)
            {
                var responseStream = await res.Content.ReadAsStreamAsync();
                var list = DeserializeJsonFromStream<IEnumerable<RestuarantDeserializer>>(responseStream);

                List<Restuarant> restuarants = new List<Restuarant>();

                foreach(RestuarantDeserializer r in list)
                {
                    restuarants.Add(_mapper.Map<Restuarant>(r));
                }
                return restuarants;

            }

            return null;
        }

        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new Newtonsoft.Json.JsonSerializer();
                var searchResult = js.Deserialize<T>(jtr);
                return searchResult;
            }
        }

    }
}