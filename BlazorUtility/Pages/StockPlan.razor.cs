using System.Net.Http.Json;
using BlazorUtility.Models;
using MudBlazor;

namespace BlazorUtility.Pages;

public partial class StockPlan
{
    private double MoneyAvailable = 0;
    private double StockPrice = 0;
    private double CustomPercentage = 0;
    private string SelectedStockSymbol = "SOXL";
    private readonly string[] _stockSymbols =
    {
        "SOXL",
        "NVDA",
        "AMD",
        "INTC",
        "SCHD",
        "T",
        "SPLG"
    };

    protected override Task OnInitializedAsync()
    {
        Array.Sort(_stockSymbols);
        return Task.CompletedTask;
    }

    private string GetStockPriceByPercentage(double percentage)
    {
        return Math.Round(StockPrice * percentage, 2).ToString();
    }

    private string GetNumberOfSharesByCustomPercentage()
    {
        if (StockPrice == 0)
            return "0"; // avoid divide by zero (StockPrice = 0)
        _ = double.TryParse(
            GetStockPriceByPercentage(1 + CustomPercentage / 100),
            out double stockPrice
        );
        return Math.Floor(MoneyAvailable / stockPrice).ToString();
    }

    private string GetNumberOfStocks(double percentage)
    {
        if (StockPrice == 0)
            return "0"; // avoid divide by zero (StockPrice = 0)
        _ = double.TryParse(GetStockPriceByPercentage(percentage), out double stockPrice);
        return $"{stockPrice} = {Math.Floor(MoneyAvailable / 4 / stockPrice)}";
    }

    private async Task GetCurrentStockPrice()
    {
        Snackbar.Add("Getting stock price...", Severity.Info);
        var i = GetTimeBasedValue();
        string cacheKey = $"{SelectedStockSymbol}_StockPrice";
        string timeBasedValueKey = $"{SelectedStockSymbol}_TimeBasedValue";

        // Check if the cached value is still valid
        var cachedTimeBasedValue = await localStorage.GetItemAsync<int?>(timeBasedValueKey);
        if (cachedTimeBasedValue.HasValue && cachedTimeBasedValue.Value == i)
        {
            StockPrice = await localStorage.GetItemAsync<double>(cacheKey);
            Snackbar.Add("Stock price retrieved from cache.", Severity.Success);
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

                Snackbar.Add("Stock price fetched successfully.", Severity.Success);
            }
        }
        else
        {
            Snackbar.Add("Failed to fetch stock price.", Severity.Error);
        }
    }

    private static int GetTimeBasedValue()
    {
        var currentTime = DateTime.UtcNow.TimeOfDay;
        // Need to update for daylight saving time
        var startTime = new TimeSpan(13, 30, 0); // 1:30 PM UTC
        var endTime = new TimeSpan(21, 0, 0); // 9:00 PM UTC

        if (currentTime >= startTime && currentTime <= endTime)
        {
            return 2;
        }
        return 1;
    }
}
