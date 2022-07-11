Sword IronSword = new Sword(Material.Iron, Gemstone.None, 80f, 8f);
Sword SteelSword = IronSword with { Gemstone = Gemstone.Emerald };
Sword SacredSword = IronSword with { Material = Material.Binarium, Gemstone = Gemstone.Bitstone };

Sword[] swords = new Sword[] { IronSword, SteelSword, SacredSword };
foreach (Sword sword in swords)
    Console.WriteLine(sword);



public record Sword(Material Material, Gemstone Gemstone, float Length, float GuardWidth);

public enum Material { Wood, Bronze, Iron, Steel, Binarium }
public enum Gemstone { None, Emerald, Amber, Sapphire, Diamond, Bitstone }