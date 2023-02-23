using HtmlAgilityPack;
using Scraper_NetCore.Models.DTO;

namespace Scraper_NetCore.Services;
public class Scraper : IScraper
{
    private readonly HttpClient _client;
    public Scraper()
    {
        _client = new HttpClient();
    }
    public async Task<string> GetHtmlAsync(string ticker)
    {
        string url = $"https://finance.yahoo.com/quote/{ticker}/profile?p={ticker}&.tsrc=fin-srch";
        return await _client.GetStringAsync(url);
    }
    public async Task<string> GetHtmlSummary(string ticker)
    {
        string url = $"https://finance.yahoo.com/quote/{ticker}?p={ticker}&.tsrc=fin-srch";
        return await _client.GetStringAsync(url);
    }
    public async Task<string> GetItemsHtmlAsync(string ticker, DateTime date)
    {
        string today = ReturnEpoch(date);
        date = date.AddDays(1);
        string tomorrow = ReturnEpoch(date);
        string url = $"https://finance.yahoo.com/quote/{ticker}/history?period1={today}&period2={tomorrow}&interval=1d&filter=history&frequency=1d&includeAdjustedClose=true&.tsrc=fin-srch";
        return await _client.GetStringAsync(url);
    }
    public async Task<CompanyDTO> PrepareCompany(string html, string ticker)
    {
        string[] xPathCompany = new string[3];
        CompanyDTO newCompany = new ();
        xPathCompany[0] = "html/body/div[1]/div/div/div[1]/div/div[2]/div/div/div[6]/div/div/div/div[2]/div[1]/div[1]/h1"; //xPathCompanyName
        xPathCompany[1] = "/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div/section/div[1]/div/div/p[2]/span[6]/span"; //xPathNumberOfEmployees
        xPathCompany[2] = "/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div/section/div[1]/div/div/p[1]"; //xPathCompanyAdress
        var htmlDoc = new HtmlDocument();
        try
        {
            htmlDoc.LoadHtml(html);
        }
        catch (Exception )
        {
            Console.WriteLine("Error while loading HTML!");
            throw;
        }
        newCompany.CompanyName = ReadValues(htmlDoc, xPathCompany[0]);
        newCompany.Employees = ReadValues(htmlDoc, xPathCompany[1]);
        newCompany.Adress = ReadValues(htmlDoc, xPathCompany[2]);
        newCompany.Ticker = ticker;
        newCompany.MarketCap = await GetMarketCap(newCompany.Ticker);
        return newCompany;
    }
    public async Task<string> GetMarketCap(string ticker)
    {
        string html = await GetHtmlSummary(ticker);
        var xPathMarketCap = "/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div/div[2]/div[2]/table/tbody/tr[1]/td[2]";
        var htmlDoc = new HtmlDocument();
        try
        {
            htmlDoc.LoadHtml(html);
        }
        catch (Exception)
        {
            Console.WriteLine("Error while loading HTML!");
            throw;
        }
        return ReadItemValues(htmlDoc, xPathMarketCap);
    }
    public CompanyItemDTO PrepareCompanyItems(string html)
    {
        CompanyItemDTO newItemDTO = new();
        string xPathForPreviousClose = "/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[2]/div/div/section/div[2]/table/tbody/tr[1]/td[6]/span";
        string xPathForOpen = "/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[2]/div/div/section/div[2]/table/tbody/tr[1]/td[2]/span";
        
        var htmlDoc = new HtmlDocument();
        try
        {
            htmlDoc.LoadHtml(html);
        }
        catch (Exception)
        {
            Console.WriteLine("Error while loading HTML!");
            throw;
        }
        newItemDTO.PreviousClosePrice= ReadItemValues(htmlDoc, xPathForPreviousClose);
        newItemDTO.OpenPrice = ReadItemValues(htmlDoc, xPathForOpen);
        return newItemDTO;
    }
    public string ReadItemValues(HtmlDocument htmlDoc, string xPath)
    {
        var repositories =
        htmlDoc.
        DocumentNode.
        SelectNodes(xPath);
        if (repositories != null)
        {
            var item = from repo in repositories
                       select repo.InnerHtml.ToString();
            if (item != null)
            {
                string tmpVal = item.First().ToString();
                return tmpVal;
            }
        }
        return "";
    }
    public string ReadValues(HtmlDocument htmlDoc, string xPath)
    {
        var repositories =
        htmlDoc.
        DocumentNode.
        SelectNodes(xPath);
        if (repositories != null)
        {
            var item = from repo in repositories
                       select repo.InnerHtml.ToString(); 
            if (item != null)
            {
                string tmpVal = item.First().ToString();
                tmpVal = tmpVal.Replace("<br>", "; ");
                for (int j = 0; j < tmpVal.Length; j++)
                {
                    if (tmpVal[j] == '<')
                    {
                        tmpVal = tmpVal.Substring(0, j - 1);
                        return tmpVal;
                    }
                }
                return tmpVal;
            }
        }
        return "";
    }
    public string ReturnEpoch(DateTime date)
    {
        TimeSpan t = date - new DateTime(1970, 1, 1);
        return t.TotalSeconds.ToString();
    }
}
