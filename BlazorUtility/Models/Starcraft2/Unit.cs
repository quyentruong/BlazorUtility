#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace BlazorUtility;

public class Unit
{
    public string Name { get; set; }
    public List<string> Commanders { get; set; }
    public int Tier { get; set; }
    public int Cost { get; set; }
    public int Life { get; set; }
    public int Shields { get; set; }
    public double Speed { get; set; }
    public int Armor { get; set; }
    public List<string> Types { get; set; }
    public List<Weapon> Weapons { get; set; }
    public List<string> Abilities { get; set; }
    public List<string> Upgrades { get; set; }

    public static List<string> GetAllUnits(Unit[] units, string commander)
    {
        return [.. units.Where(x => x.Commanders.Contains(commander) && x.Weapons.Count > 0).Select(x => x.Name).OrderBy(x => x)];
    }
}

public class Weapon
{
    public string Name { get; set; }
    public double Range { get; set; }
    public DamageInfo Damage { get; set; }
    public double Period { get; set; }
    public List<string> Targets { get; set; }
    public LevelInfo Level { get; set; }
}

public class DamageInfo
{
    public double Base { get; set; }
    public Dictionary<string, double> Versus { get; set; }
}

public class LevelInfo
{
    public double Base { get; set; }
    public Dictionary<string, double> Versus { get; set; }
}