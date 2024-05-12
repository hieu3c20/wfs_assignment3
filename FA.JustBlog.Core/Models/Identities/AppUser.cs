using Microsoft.AspNetCore.Identity;

namespace FA.JustBlog.Core.Models.Identities;

public class AppUser : IdentityUser<Guid>
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public int? Age { get; set; }
	public string? AboutMe { get; set; }
}