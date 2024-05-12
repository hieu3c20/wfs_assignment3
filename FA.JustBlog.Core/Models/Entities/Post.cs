using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FA.JustBlog.Core.Models.Entities;

namespace FA.JustBlog.Core.Models.Entities;

public class Post
{
	[Key]
	public int Id { get; set; }
	[StringLength(255)]
	public string? Title { get; set; }
	public string? ShortDescription { get; set; }
	public string? PostContent { get; set; }
	[StringLength(255)]
	public string UrlSlug { get; set; }
	[DefaultValue(false)]
	public bool Published { get; set; }
	public DateTime PostedOn { get; set; }
	[DefaultValue(false)]
	public bool Modified { get; set; }
	
	[DefaultValue(0)]
	public int ViewCount { get; set; }
	
	[DefaultValue(0)]
	public int RateCount { get; set; }
	
	[DefaultValue(0)]
	public int TotalRate { get; set; }
	
	[NotMapped]
	public decimal Rate => RateCount == 0 ? 0 : (decimal)TotalRate / RateCount;

	public int CategoryId { get; set; }
	
	[ForeignKey("CategoryId")]
	public Category? Category { get; set; }
	public ICollection<PostTagMap>? PostTagMaps { get; set; }
	
	public ICollection<Comment>? Comments { get; set; }
}