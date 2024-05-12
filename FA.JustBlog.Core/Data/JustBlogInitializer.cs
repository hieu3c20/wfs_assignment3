using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Core.Models.Enums;
using FA.JustBlog.Core.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Data;

public static class JustBlogInitializer
{
	public static void Seed(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Category>()
			.HasData(
				new Category() { Id = 1, Name = "Movies", UrlSlug = "movies", Description = "Description for movies" },
				new Category() { Id = 2, Name = "Sports", UrlSlug = "sports", Description = "Description for sports" },
				new Category()
				{
					Id = 3, Name = "Art and Design", UrlSlug = "art-and-design",
					Description = "Description for art and design"
				}
			);
		modelBuilder.Entity<Post>()
			.HasData(
				new Post()
				{
					Id = 1,
					Title = "Today I learned that CR7 is sub-goat",
					ShortDescription = "CR7 < Messi",
					PostContent = "Sport bla bla",
					UrlSlug = "ronaldo-is-sub-goat",
					Published = true,
					PostedOn = DateTime.Now,
					Modified = true,
					CategoryId = 2
				},
				new Post()
				{
					Id = 2,
					Title = "Kung Fu Panda 4 is not reached its potential",
					ShortDescription = "kung fu panda 4 sucks",
					PostContent = "Movies bleh bleh",
					UrlSlug = "kung-fu-panda-4-sucks",
					Published = false,
					PostedOn = new DateTime(2020, 4, 11),
					CategoryId = 1
				},
				new Post()
				{
					Id = 3,
					Title = "AI is replacing humans in content creating",
					ShortDescription = "ai superior",
					PostContent = "For content creators",
					UrlSlug = "ai-is-dominant",
					Published = true,
					PostedOn = new DateTime(2022, 1, 17),
					CategoryId = 3
				}
			);
		modelBuilder.Entity<PostTagMap>().HasData(
			new PostTagMap() { PostId = 1, TagId = 1 },
			new PostTagMap() { PostId = 1, TagId = 2 },
			new PostTagMap() { PostId = 2, TagId = 3 }
		);
		modelBuilder.Entity<Tag>().HasData(
			new Tag() { Id = 1, Name = "CR7", UrlSlug = "cristiano-ronaldo", Description = "Penaldo", Count = 1 },
			new Tag() { Id = 2, Name = "Messi", UrlSlug = "lionel-messi", Description = "Si Tax", Count = 3 },
			new Tag() { Id = 3, Name = "Martial Art", UrlSlug = "martial-art", Description = "Kung fu", Count = 5 }
		);
		
		modelBuilder.Entity<IdentityRole<Guid>>().HasData(
			new IdentityRole<Guid>()
			{
				Id = new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
				Name = Role.Blog_Owner.ToString()
			},
			new IdentityRole<Guid>()
			{
				Id = new Guid("c84066e6-bf5e-4652-b948-2ba8d78b6cd0"),
				Name = Role.Contributor.ToString()
			},
			new IdentityRole<Guid>()
			{
				Id = new Guid("99f46327-5753-421a-9ffc-bc87e54774ea"),
				Name = Role.User.ToString()
			}
		);

		var hasher = new PasswordHasher<AppUser>();
		modelBuilder.Entity<AppUser>().HasData(
			new AppUser
			{
				Id = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
				UserName = "admin name",
				NormalizedUserName = "ADMIN NAME",
				Email = "admin@gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
				FirstName = "Ass",
				LastName = "Mean",
				Age = 24,
				AboutMe = "Curabitur cursus nisi tellus, vitae aliquam risus pharetra ac. Nullam lobortis nec massa vel hendrerit. Integer tincidunt vehicula risus eu.",
				PasswordHash = hasher.HashPassword(null, "Kenh14.vn")
			},
			new AppUser
			{
				Id = new Guid("b2c0e4f9-b5b7-4578-bdad-0eb1040147a2"),
				UserName = "Contributor name",
				NormalizedUserName = "Contributor NAME",
				Email = "Contributor@gmail.com",
				NormalizedEmail = "Contributor@GMAIL.COM",
				FirstName = "Corn",
				LastName = "Cheese",
				Age = 14,
				AboutMe = "Donec tincidunt est ac est semper feugiat. Maecenas vulputate tristique metus vel pretium. Vestibulum ante ipsum primis in faucibus orci.",
				PasswordHash = hasher.HashPassword(null, "faceb00k.com")
			},
			new AppUser
			{
				Id = new Guid("706e2fa2-d699-4b42-b012-b3472c3ffe15"),
				UserName = "user name",
				NormalizedUserName = "USER NAME",
				Email = "user@gmail.com",
				NormalizedEmail = "USER@GMAIL.COM",
				FirstName = "Yuu",
				LastName = "The",
				Age = 4,
				AboutMe = "Duis dignissim rutrum dictum. Nunc porttitor, ex id tristique iaculis, sem lectus placerat nisi, sed egestas diam magna et nisi.\n\n",
				PasswordHash = hasher.HashPassword(null, "Laptop247.vn")
			}
		);

		modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
			new IdentityUserRole<Guid>
			{
				RoleId = new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
				UserId = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9")
			},
			new IdentityUserRole<Guid>
			{
				RoleId = new Guid("c84066e6-bf5e-4652-b948-2ba8d78b6cd0"),
				UserId = new Guid("b2c0e4f9-b5b7-4578-bdad-0eb1040147a2")
			},
			new IdentityUserRole<Guid>
			{
				RoleId = new Guid("99f46327-5753-421a-9ffc-bc87e54774ea"),
				UserId = new Guid("706e2fa2-d699-4b42-b012-b3472c3ffe15")
			}
		);
	}
}