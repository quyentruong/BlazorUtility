namespace BlazorUtility;

public static class UnitedStatesTax
{
    public static readonly Dictionary<int, Dictionary<string, TaxInfo>> Data = new()
    {
        [2017] = new Dictionary<string, TaxInfo>
        {
            ["Single"] = new TaxInfo
            {
                Deduction = 6350,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 9325 },
                    new() { Rate = 0.15m, Lower = 9325, Upper = 37950 },
                    new() { Rate = 0.25m, Lower = 37950, Upper = 91900 },
                    new() { Rate = 0.28m, Lower = 91900, Upper = 191650 },
                    new() { Rate = 0.33m, Lower = 191650, Upper = 416700 },
                    new() { Rate = 0.35m, Lower = 416700, Upper = 418400 },
                    new() { Rate = 0.396m, Lower = 418400, Upper = decimal.MaxValue }
                ]
            },
            ["Married"] = new TaxInfo
            {
                Deduction = 12700,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 18650 },
                    new() { Rate = 0.15m, Lower = 18650, Upper = 75900 },
                    new() { Rate = 0.25m, Lower = 75900, Upper = 153100 },
                    new() { Rate = 0.28m, Lower = 153100, Upper = 233350 },
                    new() { Rate = 0.33m, Lower = 233350, Upper = 416700 },
                    new() { Rate = 0.35m, Lower = 416700, Upper = 470700 },
                    new() { Rate = 0.396m, Lower = 470700, Upper = decimal.MaxValue }
                ]
            },
            ["Head of Household"] = new TaxInfo
            {
                Deduction = 9350,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 13350 },
                    new() { Rate = 0.15m, Lower = 13350, Upper = 50800 },
                    new() { Rate = 0.25m, Lower = 50800, Upper = 131200 },
                    new() { Rate = 0.28m, Lower = 131200, Upper = 212500 },
                    new() { Rate = 0.33m, Lower = 212500, Upper = 416700 },
                    new() { Rate = 0.35m, Lower = 416700, Upper = 444500 },
                    new() { Rate = 0.396m, Lower = 444500, Upper = decimal.MaxValue }
                ]
            }
        },
        [2020] = new Dictionary<string, TaxInfo>
        {
            ["Single"] = new TaxInfo
            {
                Deduction = 12400,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 9875 },
                    new() { Rate = 0.12m, Lower = 9875, Upper = 40125 },
                    new() { Rate = 0.22m, Lower = 40125, Upper = 85525 },
                    new() { Rate = 0.24m, Lower = 85525, Upper = 163300 },
                    new() { Rate = 0.32m, Lower = 163300, Upper = 207350 },
                    new() { Rate = 0.35m, Lower = 207350, Upper = 518400 },
                    new() { Rate = 0.37m, Lower = 518400, Upper = decimal.MaxValue }
                ]
            },
            ["Married"] = new TaxInfo
            {
                Deduction = 24800,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 19750 },
                    new() { Rate = 0.12m, Lower = 19750, Upper = 80250 },
                    new() { Rate = 0.22m, Lower = 80250, Upper = 171050 },
                    new() { Rate = 0.24m, Lower = 171050, Upper = 326600 },
                    new() { Rate = 0.32m, Lower = 326600, Upper = 414700 },
                    new() { Rate = 0.35m, Lower = 414700, Upper = 622050 },
                    new() { Rate = 0.37m, Lower = 622050, Upper = decimal.MaxValue }
                ]
            },
            ["Head of Household"] = new TaxInfo
            {
                Deduction = 18650,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 14100 },
                    new() { Rate = 0.12m, Lower = 14100, Upper = 53700 },
                    new() { Rate = 0.22m, Lower = 53700, Upper = 85500 },
                    new() { Rate = 0.24m, Lower = 85500, Upper = 163300 },
                    new() { Rate = 0.32m, Lower = 163300, Upper = 207350 },
                    new() { Rate = 0.35m, Lower = 207350, Upper = 518400 },
                    new() { Rate = 0.37m, Lower = 518400, Upper = decimal.MaxValue }
                ]
            }
        },
        [2021] = new Dictionary<string, TaxInfo>
        {
            ["Single"] = new TaxInfo
            {
                Deduction = 12550,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 9950 },
                    new() { Rate = 0.12m, Lower = 9950, Upper = 40525 },
                    new() { Rate = 0.22m, Lower = 40525, Upper = 86375 },
                    new() { Rate = 0.24m, Lower = 86375, Upper = 164925 },
                    new() { Rate = 0.32m, Lower = 164925, Upper = 209425 },
                    new() { Rate = 0.35m, Lower = 209425, Upper = 523600 },
                    new() { Rate = 0.37m, Lower = 523600, Upper = decimal.MaxValue }
                ]
            },
            ["Married"] = new TaxInfo
            {
                Deduction = 25100,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 19900 },
                    new() { Rate = 0.12m, Lower = 19900, Upper = 81050 },
                    new() { Rate = 0.22m, Lower = 81050, Upper = 172750 },
                    new() { Rate = 0.24m, Lower = 172750, Upper = 329850 },
                    new() { Rate = 0.32m, Lower = 329850, Upper = 418850 },
                    new() { Rate = 0.35m, Lower = 418850, Upper = 628300 },
                    new() { Rate = 0.37m, Lower = 628300, Upper = decimal.MaxValue }
                ]
            }
        },
        [2022] = new Dictionary<string, TaxInfo>
        {
            ["Single"] = new TaxInfo
            {
                Deduction = 12950,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 10275 },
                    new() { Rate = 0.12m, Lower = 10275, Upper = 41775 },
                    new() { Rate = 0.22m, Lower = 41775, Upper = 89075 },
                    new() { Rate = 0.24m, Lower = 89075, Upper = 170050 },
                    new() { Rate = 0.32m, Lower = 170050, Upper = 215950 },
                    new() { Rate = 0.35m, Lower = 215950, Upper = 539900 },
                    new() { Rate = 0.37m, Lower = 539900, Upper = decimal.MaxValue }
                ]
            },
            ["Married"] = new TaxInfo
            {
                Deduction = 25900,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 20550 },
                    new() { Rate = 0.12m, Lower = 20550, Upper = 83550 },
                    new() { Rate = 0.22m, Lower = 83550, Upper = 178150 },
                    new() { Rate = 0.24m, Lower = 178150, Upper = 340100 },
                    new() { Rate = 0.32m, Lower = 340100, Upper = 431900 },
                    new() { Rate = 0.35m, Lower = 431900, Upper = 647850 },
                    new() { Rate = 0.37m, Lower = 647850, Upper = decimal.MaxValue }
                ]
            },
            ["Head of Household"] = new TaxInfo
            {
                Deduction = 19400,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 14650 },
                    new() { Rate = 0.12m, Lower = 14650, Upper = 55900 },
                    new() { Rate = 0.22m, Lower = 55900, Upper = 89050 },
                    new() { Rate = 0.24m, Lower = 89050, Upper = 170050 },
                    new() { Rate = 0.32m, Lower = 170050, Upper = 215950 },
                    new() { Rate = 0.35m, Lower = 215950, Upper = 539900 },
                    new() { Rate = 0.37m, Lower = 539900, Upper = decimal.MaxValue }
                ]
            }
        },
        [2023] = new Dictionary<string, TaxInfo>
        {
            ["Single"] = new TaxInfo
            {
                Deduction = 13850,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 11000 },
                    new() { Rate = 0.12m, Lower = 11000, Upper = 44725 },
                    new() { Rate = 0.22m, Lower = 44725, Upper = 95375 },
                    new() { Rate = 0.24m, Lower = 95375, Upper = 182100 },
                    new() { Rate = 0.32m, Lower = 182100, Upper = 231350 },
                    new() { Rate = 0.35m, Lower = 231350, Upper = 578125 },
                    new() { Rate = 0.37m, Lower = 578125, Upper = decimal.MaxValue }
                ]
            },
            ["Married"] = new TaxInfo
            {
                Deduction = 27700,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 22000 },
                    new() { Rate = 0.12m, Lower = 22000, Upper = 89450 },
                    new() { Rate = 0.22m, Lower = 89450, Upper = 190750 },
                    new() { Rate = 0.24m, Lower = 190750, Upper = 364200 },
                    new() { Rate = 0.32m, Lower = 364200, Upper = 462500 },
                    new() { Rate = 0.35m, Lower = 462500, Upper = 693750 },
                    new() { Rate = 0.37m, Lower = 693750, Upper = decimal.MaxValue }
                ]
            },
            ["Head of Household"] = new TaxInfo
            {
                Deduction = 20800,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 15700 },
                    new() { Rate = 0.12m, Lower = 15700, Upper = 59850 },
                    new() { Rate = 0.22m, Lower = 59850, Upper = 95350 },
                    new() { Rate = 0.24m, Lower = 95350, Upper = 182100 },
                    new() { Rate = 0.32m, Lower = 182100, Upper = 231250 },
                    new() { Rate = 0.35m, Lower = 231250, Upper = 578100 },
                    new() { Rate = 0.37m, Lower = 578100, Upper = decimal.MaxValue }
                ]
            }
        },
        [2024] = new Dictionary<string, TaxInfo>
        {
            ["Single"] = new TaxInfo
            {
                Deduction = 14600,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 11600 },
                    new() { Rate = 0.12m, Lower = 11600, Upper = 47150 },
                    new() { Rate = 0.22m, Lower = 47150, Upper = 100525 },
                    new() { Rate = 0.24m, Lower = 100525, Upper = 191950 },
                    new() { Rate = 0.32m, Lower = 191950, Upper = 243725 },
                    new() { Rate = 0.35m, Lower = 243725, Upper = 609350 },
                    new() { Rate = 0.37m, Lower = 609350, Upper = decimal.MaxValue }
                ]
            },
            ["Married"] = new TaxInfo
            {
                Deduction = 29200,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 23200 },
                    new() { Rate = 0.12m, Lower = 23200, Upper = 94300 },
                    new() { Rate = 0.22m, Lower = 94300, Upper = 201050 },
                    new() { Rate = 0.24m, Lower = 201050, Upper = 384000 },
                    new() { Rate = 0.32m, Lower = 384000, Upper = 487450 },
                    new() { Rate = 0.35m, Lower = 487450, Upper = 731200 },
                    new() { Rate = 0.37m, Lower = 731200, Upper = decimal.MaxValue }
                ]
            },
            ["Head of Household"] = new TaxInfo
            {
                Deduction = 21900,
                TaxBrackets =
                [
                    new() { Rate = 0.1m, Lower = 0, Upper = 16550 },
                    new() { Rate = 0.12m, Lower = 16550, Upper = 63100 },
                    new() { Rate = 0.22m, Lower = 63100, Upper = 100500 },
                    new() { Rate = 0.24m, Lower = 100500, Upper = 191950 },
                    new() { Rate = 0.32m, Lower = 191950, Upper = 243700 },
                    new() { Rate = 0.35m, Lower = 243700, Upper = 609350 },
                    new() { Rate = 0.37m, Lower = 609350, Upper = decimal.MaxValue }
                ]
            }
        },
    };
}