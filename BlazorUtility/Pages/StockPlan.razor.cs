using System.Net.Http.Json;
using BlazorUtility.Models;

namespace BlazorUtility.Pages;

public partial class StockPlan
{
    private double MoneyAvailable = 0;
    private double StockPrice = 0;
    private double CustomPercentage = 0;
    private string SelectedStockSymbol = "SOXL";
    private string[] _stockSymbols = { "SOXL", "NVDA", "AMD", "INTC", "SCHD" };

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

    private async Task GetCurrentStockPrice()
    {
        var i = GetTimeBasedValue();
        string cacheKey = $"{SelectedStockSymbol}_StockPrice";
        string timeBasedValueKey = $"{SelectedStockSymbol}_TimeBasedValue";

        // Check if the cached value is still valid
        var cachedTimeBasedValue = await localStorage.GetItemAsync<int?>(timeBasedValueKey);
        if (cachedTimeBasedValue.HasValue && cachedTimeBasedValue.Value == i)
        {
            StockPrice = await localStorage.GetItemAsync<double>(cacheKey);
            return;
        }

        string chartUrl = $"api/YahooFinancial?symbol={SelectedStockSymbol}";

        var httpClient = HttpClientFactory.CreateClient("YahooFinance");
        var response = await httpClient.GetAsync(chartUrl);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<List<FyQuote>>();

            if (content != null && content.Count >= i)
            {
                StockPrice = Math.Round((double)content[^i].Close, 2);

                // Cache the stock price and time-based value
                await localStorage.SetItemAsync(cacheKey, StockPrice);
                await localStorage.SetItemAsync(timeBasedValueKey, i);
            }
        }
    }

    private int GetTimeBasedValue()
    {
        var currentTime = DateTime.Now.TimeOfDay;
        var startTime = new TimeSpan(17, 0, 0); // 5:00 PM
        var endTime = new TimeSpan(6, 30, 0); // 6:30 AM

        if (currentTime >= startTime || currentTime <= endTime)
        {
            return 1;
        }
        return 2;
    }
}
