using Newtonsoft.Json;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Scraper;
public partial class frmScraper : Form
{
    private static readonly HttpClient _client = new HttpClient();
    public frmScraper()
    {
        InitializeComponent();
    }

    private void frmScraper_Load(object sender, EventArgs e)
    {
        //GetCompanies();
    }
    private void dgCompanies_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        int rowIndex = dgCompanies.CurrentCell.RowIndex;
        if (dgCompanies[1, rowIndex].Value != null)
        {
            string ticker = dgCompanies[1, rowIndex].Value.ToString();
            if(ticker != null)
            {
                GetItems(ticker);
            }
        }
    }
    private async void GetCompanies()
    {
        try
        {
            var response = await _client.GetAsync("http://localhost:5273/scraper/get-companies");
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (responseBody != null)
                {
                    dynamic res = JsonConvert.DeserializeObject(responseBody);
                    if(res != null)
                    {
                        DataTable companies = new();
                        companies.Columns.Add("CompanyName");
                        companies.Columns.Add("Ticker");
                        companies.Columns.Add("Employees");
                        companies.Columns.Add("Adress");
                        companies.Columns.Add("MarketCap");
                        foreach (var resRow in res)
                        {
                            DataRow newRow = companies.NewRow();
                            newRow["CompanyName"] = resRow.companyName;
                            newRow["Ticker"] = resRow.ticker;
                            newRow["Employees"] = resRow.employees;
                            newRow["Adress"] = resRow.adress;
                            newRow["MarketCap"] = resRow.marketCap;
                            companies.Rows.Add(newRow);
                        }
                        dgCompanies.DataSource = companies;
                    }
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    private async void GetItems(string ticker)
    {
        try
        {
            string req = $"http://localhost:5273/scraper/get-items/{ticker}";
            var response = await _client.GetAsync(req);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (responseBody != null)
                {
                    dynamic res = JsonConvert.DeserializeObject(responseBody);
                    if (res != null)
                    {
                        DataTable items = new();
                        items.Columns.Add("Date");
                        items.Columns.Add("PreviousClosePrice");
                        items.Columns.Add("OpenPrice");
                        foreach (var resRow in res)
                        {
                            DataRow newRow = items.NewRow();
                            newRow["Date"] = resRow.date;
                            newRow["PreviousClosePrice"] = resRow.previousClosePrice;
                            newRow["OpenPrice"] = resRow.openPrice;
                            items.Rows.Add(newRow);
                        }
                        dgItems.DataSource = items;
                    }
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    private async void FindData()
    {
        try
        {
            DateTime date = new(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, dtpDate.Value.Hour, dtpDate.Value.Minute, dtpDate.Value.Second);
            TickerPOST contentObject = new()
            {
                Ticker = txtTicker.Text,
                Date = date
            };
            var content = new StringContent(JsonConvert.SerializeObject(contentObject), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("http://localhost:5273/scraper/post-ticker", content);
            if (response.IsSuccessStatusCode == true)
            {
                MessageBox.Show("Data added successfuly!");
            }
            else
            {
                Console.WriteLine("No data found for this ticker and date!");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    private void btnGetData_Click(object sender, EventArgs e)
    {
        if(txtTicker.Text == "")
        {
            MessageBox.Show("Ticker is empty!");
        }
        else
        {
            FindData();
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        GetCompanies();
    }
}
public class TickerPOST
{
    public string Ticker { get; set; } = string.Empty;
    public DateTime Date { get; set; }

}