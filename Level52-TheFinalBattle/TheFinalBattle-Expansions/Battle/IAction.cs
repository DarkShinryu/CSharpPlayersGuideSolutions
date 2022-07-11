public interface IAction
{
    string Name { get; }
    DamageType Type { get; }
    Character? Target { get; }
    bool Success { get; }

    void Use();
    void SetTarget(Party heroes, Party villains);
    void SetSuccess();
}

public class NothingAction : IAction
{
    public string Name { get; } = "Nothing";
    public DamageType Type { get; } = DamageType.Normal;
    public Character? Target { get; private set; }
    public bool Success { get; private set; }

    public void Use() { /* Do nothing */ }
    public void SetTarget(Party heroes, Party villains) { /* No target */ }
    public void SetSuccess() => Success = true;
}

public enum DamageType { Normal, Decoding }