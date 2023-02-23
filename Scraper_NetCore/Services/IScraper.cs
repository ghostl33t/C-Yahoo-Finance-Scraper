using HtmlAgilityPack;
using Scraper_NetCore.Models.DTO;

namespace Scraper_NetCore.Services;
public interface IScraper
{
    public Task<string> GetHtmlAsync(string ticker);
    public Task<string> GetHtmlSummary(string ticker);
    public Task<string> GetItemsHtmlAsync(string ticker, DateTime date);
    public  Task<CompanyDTO> PrepareCompany(string html, string ticker);
    public Task<string> GetMarketCap(string html);
    public CompanyItemDTO PrepareCompanyItems(string html);
    public string ReadValues(HtmlDocument htmlDoc, string xPath);
    public string ReturnEpoch(DateTime date);
    public string ReadItemValues(HtmlDocument htmlDoc, string xPath);
}
