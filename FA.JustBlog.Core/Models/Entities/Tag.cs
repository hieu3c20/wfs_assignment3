using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models.Entities;

public class Tag
{
	[Key]
	public int Id { get; set; }
	[Required(ErrorMessage = "Category name is required.")]
	[StringLength(255)]
	public string? Name { get; set; }
	[StringLength(255)]
	public string? UrlSlug { get; set; }
	[StringLength(1024)]
	public string? Description { get; set; }
	[DefaultValue(0)]
	public int Count { get; set; }
	public ICollection<PostTagMap>? PostTagMaps { get; set; }
}