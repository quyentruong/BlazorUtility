#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace BlazorUtility;

public class CommanderData
{
    public string Commander { get; set; }
    public List<string> Aliases { get; set; }

    public static List<string> GetAllCommanders(CommanderData[] commanderDatas)
    {
        return [.. commanderDatas.Select(x => x.Commander).OrderBy(x => x)];
    }
}