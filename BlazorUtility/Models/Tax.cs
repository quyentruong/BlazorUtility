namespace BlazorUtility;

public class Tax
{
    public List<CountryTaxInfo> CountryTax { get; set; }

    public Tax()
    {
        CountryTax = [];
        CountryTax.Add(
        new CountryTaxInfo
        {
            CountryName = "United States",
            YearlyTaxInfo = UnitedStatesTax.Data
        });
    }

    public string[] TaxCountryNames()
    {
        return CountryTax.Select(x => x.CountryName).ToArray();
    }

    public int[] TaxYears(string countryName)
    {
        return CountryTax.Where(x => x.CountryName == countryName).First().YearlyTaxInfo.Keys.Select(x => x).ToArray();
    }

    public string[] TaxFilers(string countryName, int year)
    {
        return CountryTax.Where(x => x.CountryName == countryName).First().YearlyTaxInfo[year].Keys.Select(x => x).ToArray();
    }

    public decimal TaxDeduction(string countryName, int year, string filerType)
    {
        return CountryTax.Where(x => x.CountryName == countryName).First().YearlyTaxInfo[year][filerType].Deduction;
    }

    public decimal TaxCalculator(string countryName, int year, string filerType, decimal grossIncome, decimal deduction, out List<TaxEquation> equations)
    {
        equations = [];
        var income = grossIncome - deduction;
        if (income <= 0) { return 0; };
        var taxResult = 0m;
        var taxInfo = CountryTax.Where(x => x.CountryName == countryName).First().YearlyTaxInfo[year][filerType];

        foreach (var taxBracket in taxInfo.TaxBrackets)
        {
            if (income > taxBracket.Lower)
            {
                var taxAmount = 0m;
                var equation = new TaxEquation
                {
                    Rate = $"{(int)(taxBracket.Rate * 100)}%"
                };
                if (income - taxBracket.Lower < taxBracket.Upper - taxBracket.Lower)
                {
                    taxAmount = income - taxBracket.Lower;
                    equation.Equation = $"(${income} - ${taxBracket.Lower})";
                }
                else
                {
                    taxAmount = taxBracket.Upper - taxBracket.Lower;
                    equation.Equation = $"(${taxBracket.Upper} - ${taxBracket.Lower})";
                }
                taxResult += taxAmount * taxBracket.Rate;
                equation.Equation += $" x {taxBracket.Rate}";
                equation.Result = $"${taxAmount * taxBracket.Rate:0.##}";
                equations.Add(equation);
            }
        }
        var incomeTaxEquation = new TaxEquation { Rate = "Income tax" };
        equations.ForEach(x => incomeTaxEquation.Equation += $"{x.Result} + ");
        incomeTaxEquation.Equation = incomeTaxEquation.Equation[..^2];
        incomeTaxEquation.Result = $"${taxResult:0.##}";
        equations.Add(incomeTaxEquation);
        var incomeTaxPercentEquation = new TaxEquation
        {
            Rate = "Income tax %",
            Equation = $"(${taxResult:0.##} / ${grossIncome}) x 100",
            Result = $"{Math.Round(taxResult / grossIncome * 100, 2):0.##}%"
        };
        equations.Add(incomeTaxPercentEquation);

        var socialSecurityTax = grossIncome * 0.062m;
        var socialSecurityTaxEquation = new TaxEquation
        {
            Rate = "Social Security Tax",
            Equation = $"${grossIncome} x 0.062",
            Result = $"${socialSecurityTax:0.##}"
        };
        equations.Add(socialSecurityTaxEquation);

        var medicareTax = grossIncome * 0.0145m;
        var medicareTaxEquation = new TaxEquation
        {
            Rate = "Medicare Tax",
            Equation = $"${grossIncome} x 0.0145",
            Result = $"${medicareTax:0.##}"
        };
        equations.Add(medicareTaxEquation);

        var longTermCareTax = grossIncome * 0.0058m;
        var longTermCareTaxEquation = new TaxEquation
        {
            Rate = "Long Term Care Tax",
            Equation = $"${grossIncome} x 0.0058",
            Result = $"${longTermCareTax:0.##}"
        };
        equations.Add(longTermCareTaxEquation);

        var totalTax = taxResult + socialSecurityTax + medicareTax + longTermCareTax;
        var totalTaxEquation = new TaxEquation
        {
            Rate = "Total tax",
            Equation = $"(${taxResult:0.##} + ${socialSecurityTax:0.##} + ${medicareTax:0.##})",
            Result = $"${totalTax:0.##}"
        };
        equations.Add(totalTaxEquation);

        var totalTaxPercentEquation = new TaxEquation
        {
            Rate = "Total tax %",
            Equation = $"(${taxResult:0.##} + ${socialSecurityTax:0.##} + ${medicareTax:0.##}) / ${grossIncome} x 100",
            Result = $"{Math.Round((totalTax) / grossIncome * 100, 2):0.##}%"
        };
        equations.Add(totalTaxPercentEquation);

        var takeHomeEquation = new TaxEquation
        {
            Rate = "Take-home after tax",
            Equation = $"${grossIncome} - ${totalTax:0.##}",
            Result = $"${(grossIncome - totalTax):0.##}"
        };
        equations.Add(takeHomeEquation);
        return taxResult;
    }
}

public class TaxEquation
{
    public string Rate { get; set; } = string.Empty;
    public string Equation { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
}

public class TaxInfo
{
    public decimal Deduction { get; set; }
    public List<TaxBracket> TaxBrackets { get; set; } = [];
}

public class TaxBracket
{
    public decimal Rate { get; set; }
    public decimal Lower { get; set; }
    public decimal Upper { get; set; }
}

public class CountryTaxInfo
{
    public string CountryName { get; set; } = string.Empty;
    public Dictionary<int, Dictionary<string, TaxInfo>> YearlyTaxInfo { get; set; } = [];
}