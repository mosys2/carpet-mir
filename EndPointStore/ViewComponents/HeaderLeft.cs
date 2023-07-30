using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
	[ViewComponent(Name = "HeaderLeft")]
	public class HeaderLeft:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(viewName: "HeaderLeft");
		}
	}
}
