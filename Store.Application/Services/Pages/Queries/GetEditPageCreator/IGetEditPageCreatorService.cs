using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Pages.Queries.GetEditPageCreator
{
	public interface IGetEditPageCreatorService
	{
		Task<ResultDto<GetEditPageCreatorDto>> Execute(string pageId);
	}
	public class GetEditPageCreatorService : IGetEditPageCreatorService
	{
		private readonly IDatabaseContext _context;
		public GetEditPageCreatorService(IDatabaseContext context)
		{
			_context = context;
		}
		public async Task<ResultDto<GetEditPageCreatorDto>> Execute(string pageId)
		{
			var pageCreator =await _context.PageCreators.FindAsync(pageId);
			if(pageCreator==null)
			{
				return new ResultDto<GetEditPageCreatorDto>
				{
					IsSuccess = false,
					Message = MessageInUser.NotFind
				};
			}
			return new ResultDto<GetEditPageCreatorDto>
			{
				Data = new GetEditPageCreatorDto
				{
					Id = pageCreator.Id,
					Content = pageCreator.Content,
					Description = pageCreator.Description,
					IsActive = pageCreator.IsActive,
					MetaTagDescription = pageCreator.MetaTagDescription,
					MetaTagKeyWords = pageCreator.MetaTagKeyWords,
					Slug = pageCreator.Slug,
					Title = pageCreator.Title,
					Image=pageCreator.Image,
					GroupItemId=pageCreator.GroupItemId,
				},
				IsSuccess = true
			};
		}
	}
	public class GetEditPageCreatorDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		//[Required]
		public string? Content { get; set; }
		public string? Description { get; set; }
		public string? Slug { get; set; }
		public string? MetaTagKeyWords { get; set; }
		public string? MetaTagDescription { get; set; }
		public bool IsActive { get; set; }
		public string? Image { get; set; }
        public string? GroupItemId { get; set; }
    }
}
