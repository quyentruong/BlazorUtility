using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace BlazorUtility.Pages;

public partial class StockPlan
{
    private double MoneyAvailable = 0;
    private double StockPrice = 0;
    private double CustomPercentage = 0;

    private string GetStockPriceByPercentage(double percentage)
    {
        return Math.Round(StockPrice * percentage, 2).ToString();
    }

    private string GetNumberOfStocks(double percentage)
    {
        if (StockPrice == 0)
            return "0"; // avoid divide by zero (StockPrice = 0)
        double stockPrice = 1;
        double.TryParse(GetStockPriceByPercentage(percentage), out stockPrice);
        return $"{stockPrice} = {Math.Floor(MoneyAvailable / 4 / stockPrice).ToString()}";
    }

    private async void GetCurrentStockPrice()
    {
        string stockSymbol = "msft";
        long startTime = 1730105412; // Unix timestamp for start date
        long endTime = 1730235031; // Unix timestamp for end date
        string interval = "1d"; // Data interval

        // Chart API
        string chartUrl =
            $"https://query1.finance.yahoo.com/v8/finance/chart/{stockSymbol}?period1={startTime}&period2={endTime}&interval={interval}";

        var request = new HttpRequestMessage(HttpMethod.Get, chartUrl);
        request.SetBrowserRequestMode(BrowserRequestMode.Cors);

        using var httpClient = new HttpClient();
        var response = await httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }
}
