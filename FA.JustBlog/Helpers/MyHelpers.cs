using System.Text;
using FA.JustBlog.Core.Models.Entities;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.Helpers;

public static class MyHelpers
{
	public static IHtmlContent CategoryLink(this IHtmlHelper htmlHelper, string category)
	{
		var httpContext = htmlHelper.ViewContext.HttpContext;
		var currentUrl = httpContext.Request.Path.Value;

		// Check if the current URL path ends with "/Category"
		if (currentUrl.Contains("/Category"))
		{
			return new HtmlString(
				$"<p class='post-meta fw-bold mb-1'>Category <a class='text-decoration-underline' href='/{category}'>{category}</a></p>");
		}

		return new HtmlString(
			$"<p class='post-meta fw-bold mb-1'>Category <a class='text-decoration-underline' href='Category/{category}'>{category}</a></p>");
	}

	public static IHtmlContent TagLink(this IHtmlHelper htmlHelper, IEnumerable<Tag> tags)
	{
		var stringBuilder = new StringBuilder();
		foreach (var tag in tags)
		{
			stringBuilder.Append($"<div class='border border-2 text-center text-decoration-underline me-2 d-inline-block px-2 fs-6'>#{tag.Name}</div>");
		}
		return new HtmlString($"<p class='post-meta fw-bold me-2 d-inline-block'>Tag(s): </p>{stringBuilder}");
	}

	public static string DateFormat(this DateTime dateTime)
	{
		return string.Empty;
	}
}