using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Ai;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AiController : Controller
    {
        private readonly IAiServices _aiServices;
        public AiController(IAiServices aiServices)
        {
            _aiServices = aiServices;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateAiContent(AiContentDto aiContent)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message=MessageInUser.InvalidFormValue
                } );
            }
            var result = await _aiServices.CreateContent(new AiContentDto
            {
                Title_Ai = aiContent.Title_Ai,
                Keywords_Ai=aiContent.Keywords_Ai,
                MaxChar_Ai = aiContent.MaxChar_Ai,
                Language_Ai = aiContent.Language_Ai,
            });
            return Json(result );
        }

        [HttpPost]
        public async Task<IActionResult> GenerateAiImage(AIImageDto model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message=MessageInUser.InvalidFormValue
                });
            }
            var result = await _aiServices.CreateImages(new AIImageDto
            {
                n=model.n,
                prompt=model.prompt,
                size=model.size,
            });
            return Json(result);
        }
    }
}
