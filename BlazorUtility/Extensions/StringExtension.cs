using System.Text;

namespace Extensions;

public static class StringExtension
{
    public static string RemoveConsecutiveAtSymbols(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var result = new StringBuilder();
        var count = 0;

        foreach (var currentChar in input)
        {
            if (currentChar == '@')
            {
                count++;
                if (count > 1)
                {
                    continue;
                }
            }
            result.Append(currentChar);
        }

        return result.ToString();
    }
}