using AutoMapper;
using FA.JustBlog.Areas.Admin.Models;
using FA.JustBlog.Core.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging;

namespace FA.JustBlog.AutoMapper;

public class AutoMapper : Profile
{
	public AutoMapper()
	{
		CreateMap<Post, PostCreateModel>()
			.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
			.ForMember(dest => dest.TagIds, opt => opt.MapFrom(src => src.PostTagMaps.Select(ptm => ptm.TagId)))
			.ReverseMap();
	}
}