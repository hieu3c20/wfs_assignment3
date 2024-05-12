using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Core.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Data;

public class JustBlogContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
	public DbSet<Category> Categories { get; set; }
	public DbSet<Post> Posts { get; set; }
	public DbSet<PostTagMap> PostTagMaps { get; set; }
	public DbSet<Tag> Tags { get; set; }
	public DbSet<Comment> Comments { get; set; }

	public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
	{
	}

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//{
	//	optionsBuilder.UseSqlServer("Server=.;Database=FJustBlog;uid=sa;pwd=12345678;Trusted_Connection=true;TrustServerCertificate=True; MultipleActiveResultSets=true");
	//	base.OnConfiguring(optionsBuilder);
	//}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<PostTagMap>()
			.HasKey(pt => new { pt.PostId, pt.TagId });

		modelBuilder.Entity<PostTagMap>()
			.HasOne(pt => pt.Post)
			.WithMany(p => p.PostTagMaps)
			.HasForeignKey(pt => pt.PostId);
		
		modelBuilder.Entity<PostTagMap>()
			.HasOne(pt => pt.Tag)
			.WithMany(t => t.PostTagMaps)
			.HasForeignKey(pt => pt.TagId);
		
		modelBuilder.Entity<Post>().Navigation<PostTagMap>(e => e.PostTagMaps).AutoInclude();
		modelBuilder.Entity<Post>().Navigation<Category>(e => e.Category).AutoInclude();
		modelBuilder.Entity<PostTagMap>().Navigation<Tag>(e => e.Tag).AutoInclude();
		modelBuilder.Entity<PostTagMap>().Navigation<Post>(e => e.Post).AutoInclude();
		modelBuilder.Entity<Category>().Navigation<Post>(c => c.Posts).AutoInclude();
		
		modelBuilder.Seed();
	}
}