using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scraper_NetCore.Models.Domain;
using Scraper_NetCore.Models.DTO;
using Scraper_NetCore.Repositories.Interfaces;
using Scraper_NetCore.Services;
namespace Scraper_NetCore.Controllers;

[ApiController]
[Route("scraper")]
public class ScraperController : Controller
{
	private readonly IMapper _mapper;
	private readonly IScraper _scraper;
	private readonly ICompanyGet _companyGet;
	private readonly ICompanyCreate _companyCreate;

	private readonly ICompanyItemsCreate _companyItemsCreate;
    private readonly ICompanyItemsGet _companyItemsGet;
    public ScraperController(IMapper mapper, IScraper scraper, ICompanyGet companyGet, ICompanyCreate companyCreate, ICompanyItemsCreate companyItemsCreate, ICompanyItemsGet companyItemsGet)
	{
		_mapper = mapper;
		_scraper = scraper;
		_companyGet = companyGet;
		_companyCreate = companyCreate;
		_companyItemsCreate = companyItemsCreate;
		_companyItemsGet = companyItemsGet;
	}
	[HttpGet]
	[Route("get-companies")]
	public async Task<IActionResult> GetCompanies()
	{
		try
		{
			var companies = await _companyGet.GetAllCompaniesAsync();
			if(companies == null)
			{
				return BadRequest();
			}
            return Ok(companies);
		}
		catch (Exception)
		{

			throw;
		}
	}
    [HttpGet]
    [Route("get-items/{ticker}")]
    public async Task<IActionResult> GetItems(string ticker)
    {
        try
        {
            var companyExistsId = await _companyGet.GetCompanyByTickerAsync(ticker);
			if(companyExistsId == 0)
			{
				return BadRequest();
			}
			var companyItems = await _companyItemsGet.GetItemsByTicker(companyExistsId);
            if (companyItems == null)
            {
                return BadRequest();
            }
            return Ok(companyItems);
        }
        catch (Exception)
        {

            throw;
        }
    }
    [HttpPost]
	[Route("post-ticker")]
	public async Task<IActionResult> CreateData(TickerPOST tickerPost)
	{
		var htmlDoc = await _scraper.GetHtmlAsync(tickerPost.Ticker);

		var companyExistsId = await _companyGet.GetCompanyByTickerAsync(tickerPost.Ticker);
        if (companyExistsId == 0)
		{
            var newCompanyDto = await _scraper.PrepareCompany(htmlDoc,tickerPost.Ticker);
			var newCompany = _mapper.Map<Company>(newCompanyDto);
			await _companyCreate.CreateCompanyAsync(newCompany);
			companyExistsId = newCompany.Id;
        }
		if(companyExistsId != 0)
		{
            DateTime dateWithoutTimeStamp = new DateTime(tickerPost.Date.Year, tickerPost.Date.Month, tickerPost.Date.Day);
            htmlDoc = await _scraper.GetItemsHtmlAsync(tickerPost.Ticker, dateWithoutTimeStamp);
            var newItemDTO = _scraper.PrepareCompanyItems(htmlDoc);
			newItemDTO.Date = tickerPost.Date;
			newItemDTO.CompanyId = companyExistsId;
            var newItem = _mapper.Map<CompanyItem>(newItemDTO);
            await _companyItemsCreate.CreateCompanyItemAsync(newItem);
            return Ok($"Data on date: {tickerPost.Date.Year.ToString() + "." + tickerPost.Date.Month.ToString() + tickerPost.Date.Day.ToString()} for company:{tickerPost.Ticker} added successfuly!");
        }
		return BadRequest();
        
    }
}


