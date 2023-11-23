using Org.BouncyCastle.Asn1.Crmf;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Text.Json.Nodes;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Store.Common.Constant;

namespace Store.Application.Services.Ai
{
    public interface IAiServices
    {
        Task<ResultDto<AIConentResultDto>> CreateContent(AiContentDto request);
        Task<ResultDto<AIImageResultDto>> CreateImages(AIImageDto request);
    }
    public class AiServices : IAiServices
    {
        private readonly HttpClient _httpClient;

        public AiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResultDto<AIConentResultDto>> CreateContent(AiContentDto request)
        {
            string query = "a blog to title:" +request.Title_Ai + "and to keywords:" + request.Keywords_Ai.Replace("-", " ")+ "and to language:"+request.Language_Ai+"and min word="+request.MaxChar_Ai;
            string apiUrl = $"https://corkstops.com/UsechatGpt?query={query}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return new ResultDto<AIConentResultDto>
                {
                    IsSuccess=false,
                    Message=$"خطا در ارتباط با سرور. : {response.StatusCode}"
                };
                throw new Exception($"خطا در ارتباط با سرور. : {response.StatusCode}");
            }
            string content = await response.Content.ReadAsStringAsync();
            return new ResultDto<AIConentResultDto>
            {
                IsSuccess=true,
                Data=new AIConentResultDto
                {
                    Response=content
                }
            };

        }

        public async Task<ResultDto<AIImageResultDto>> CreateImages(AIImageDto request)
        {
            var query = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            string apiUrl = $"http://localhost:5170/UsechatGptImage{query}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return new ResultDto<AIImageResultDto>
                {
                    IsSuccess=true,
                    Message=$"خطا در ارتباط با سرور. : {response.StatusCode}"
                };
                throw new Exception($"خطا در ارتباط با سرور. : {response.StatusCode}");
            }
            var content = await response.Content.ReadAsStringAsync();
            return new ResultDto<AIImageResultDto>
            {
                Data=content,
                IsSuccess=true,
                Message="با موفقیت ایجاد شد."
            };
        }
    }
    public class AIConentResultDto
    {
        public string? Response { get; set; }
    }
    public class AiContentDto
    {
        [Required]
        public string? Title_Ai { get; set; }
        [Required]
        public string? Keywords_Ai { get; set; }
        [Required]
        public int MaxChar_Ai { get; set; }
        [Required]
        public string? Language_Ai { get; set; }

    }
    public class AIImageDto
    {
        public string? prompt { get; set; }
        public short? n { get; set; }
        public string? size { get; set; }
    }
    public class AIImageResultDto
    {
        public long? created { get; set; }
        public List<AIImageUrls>? data { get; set; }

        public static implicit operator AIImageResultDto(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class AIImageUrls
    {
        public string? url { get; set; }
    }



}
