using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<JustBlogContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(
	options =>
	{
		options.SignIn.RequireConfirmedAccount = false;
		options.SignIn.RequireConfirmedEmail = false;
	}).AddRoles<IdentityRole<Guid>>()
	.AddEntityFrameworkStores<JustBlogContext>().AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.Configure<IdentityOptions>(options =>
{
	options.SignIn.RequireConfirmedAccount = false;
	options.SignIn.RequireConfirmedEmail = false;
	//password
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireDigit = false;
	options.Password.RequireUppercase = false;
	//user
	options.User.AllowedUserNameCharacters ="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
	options.User.RequireUniqueEmail = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Post}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "AreaRoute",
	pattern: "{area:exists}/{controller}/{action}"
);

app.MapRazorPages();

app.Run();