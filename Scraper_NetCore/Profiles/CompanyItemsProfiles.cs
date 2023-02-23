using AutoMapper;
using Scraper_NetCore.Models.Domain;
using Scraper_NetCore.Models.DTO;

namespace Scraper_NetCore.Profiles;
public class CompanyItemsProfiles : Profile
{
    public CompanyItemsProfiles()
    {
        CreateMap<CompanyItem, CompanyItemDTO>();
        CreateMap<CompanyItem, CompanyItemDTO>().ReverseMap();
    }
}
