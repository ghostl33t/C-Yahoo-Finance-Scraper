using AutoMapper;
using Scraper_NetCore.Models.Domain;
using Scraper_NetCore.Models.DTO;

namespace Scraper_NetCore.Profiles;
public class CompanyProfiles : Profile
{
	public CompanyProfiles()
	{
        CreateMap<Company, CompanyDTO>();
        CreateMap<Company, CompanyDTO>().ReverseMap();
    }
}
