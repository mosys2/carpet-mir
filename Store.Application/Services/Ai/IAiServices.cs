using Org.BouncyCastle.Asn1.Crmf;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Text.Json.Nodes;

namespace Store.Application.Services.Ai
{
    public interface IAiServices
    {
        Task<ResultDto> Execute();
    }
    public class AiServices : IAiServices
    {
        public async Task<ResultDto> Execute()
        {


            var options = new RestClientOptions("https://api.copy.ai/api/workflow/PKGW-7c57191f-f64f-4fe1-9c7e-b9a2291ea6a6/run");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("x-copy-ai-api-key", "5e7e65cc-47ce-4d61-a448-86937dfc2bfb");
            var response = await client.GetAsync(request);

            Console.WriteLine("{0}", response.Content);
            return new ResultDto()
            {
                IsSuccess=true,

            };

        }
    }

}
