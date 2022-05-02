﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ManipulaJsonECsv
{
    public class LoopIcao
    {
        public static async Task<Aeroporto> GetICAOAsync(string icao)
        {
            var client = new HttpClient();
            var stringConexao = "https://airport-info.p.rapidapi.com/airport?icao=" + icao;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(stringConexao),
                Headers = {
                          { "X-RapidAPI-Host", "airport-info.p.rapidapi.com" },
                          { "X-RapidAPI-Key", "676387d8cfmsh9926058a5874536p17ca86jsn2ace1081ec45" },
                },
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            try
            {
                return await response.Content.ReadAsAsync<Aeroporto>();
            }
            catch // Could be ArgumentNullException or UnsupportedMediaTypeException
            {
                Console.WriteLine("HTTP Response was invalid or could not be deserialised.");
            }

            return null;

            //var body = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(body);
            //return body;
        }
    }
}
