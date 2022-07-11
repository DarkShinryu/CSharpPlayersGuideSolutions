public class EquipAction : IAction
{
    private Character _character;
    private Party _party;
    private GearType? _gearType = null;

    public string Name { get; }
    public DamageType Type { get; }
    public Character? Target { get; private set; }
    public bool Success { get; private set; }

    public EquipAction(Character character, Party party)
    {
        Name = "Equip";
        Type = DamageType.Normal;
        _character = character;
        _party = party;
    }

    public virtual void Use()
    {

        if (_character.ControlMode == ControlMode.Manual)
            HandleManualSelection();
        else
            HandleAutomaticSelection();

        if (_gearType.HasValue && Target != null && Success)
            Target.EquipGear(_party.Inventory, _gearType.Value);
    }

    public void SetTarget(Party heroes, Party villains) => Target = _character;

    public void SetSuccess() => Success = true;

    private void HandleManualSelection()
    {
        GearType[] gearTypes = (GearType[])Enum.GetValues(typeof(GearType));

        do
        {

            bool isFirstItem = true;
            Console.Write("Select the gear to equip (");
            for (int i = 0; i < gearTypes.Length; i++)
            {

                if (!_party.Inventory.Gear[gearTypes[i]].InPossession || _party.Inventory.Gear[gearTypes[i]].IsEquipped)
                    continue;

                if (!isFirstItem)
                    Console.Write(" | ");

                Console.Write($"{i + 1} - {_party.Inventory.Gear[gearTypes[i]].Name}");
                isFirstItem = false;
            }

            Console.Write("): ");

            _gearType = Console.ReadLine()?.ToLower() switch
            {
                "1" or "sword"          => GearType.Sword,
                "2" or "bow"            => GearType.Bow,
                "3" or "cannon"         => GearType.Cannon,
                "4" or "bitstone sword" => GearType.BitstoneSword,
                "5" or "dagger"         => GearType.Dagger,
                "6" or "decoded staff"  => GearType.DecodedStaff,
                _                       => null
            };
        } while (!_gearType.HasValue || !_party.Inventory.Gear[_gearType.Value].InPossession || _party.Inventory.Gear[_gearType.Value].IsEquipped);
    }

    private void HandleAutomaticSelection()
    {
        _gearType = Target switch
        {
            Skeleton   => GearType.Dagger,
            UncodedOne => GearType.DecodedStaff,
            _          => GearType.Dagger
        };
    }
}

public class UnEquipAction : IAction
{
    private Character _character;

    public string Name { get; }
    public string GearName { get; }
    public DamageType Type { get; }
    public Character? Target { get; private set; }
    public bool Success { get; private set; }

    public UnEquipAction(Character character)
    {
        Name = "UnEquip";
        GearName = character.Gear?.Name ?? "the gear";
        Type = DamageType.Normal;
        _character = character;
    }

    public virtual void Use()
    {
        if (Target != null && Success)
            Target.UnEquipGear();
    }

    public void SetTarget(Party heroes, Party villains) => Target = _character;

    public void SetSuccess() => Success = true;
}