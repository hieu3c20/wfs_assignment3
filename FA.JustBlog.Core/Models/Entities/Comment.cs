using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models.Entities;

public class Comment
{
	public int CommentId { get; set; }
	
	[StringLength(50)]
	public string? Name { get; set; }
	
	[StringLength(50)]
	public string? Email { get; set; }
	
	public int PostId { get; set; }
	public Post? Post { get; set; }
	
	[StringLength(255)]
	public string? CommentHeader { get; set; }
	
	[StringLength(1024)]
	public string? CommentText { get; set; }
	
	public DateTime? CommentTime { get; set; }
}