public class Health
{
    private Character _character;
    private int _current;

    public int Max
    {
        get
        {
            return _character switch
            {
                Hero            => _character.Level * 56, // A basic formula but gets the job done
                VinFletcher     => _character.Level * 44,
                MylaraAndSkorin => _character.Level * 37,
                Skeleton        => _character.Level * 29,
                StoneAmarok     => _character.Level * 26,
                BitDragon       => _character.Level * 60,
                UncodedOne      => _character.Level * 78,
                _               => _character.Level * 10,
            };
        }
    }
    public int Current
    {
        get => _current;
        set => _current = Math.Clamp(value, 0, Max);
    }
    public double Percentage => (double)Current / Max;

    public Health(Character character)
    {
        _character = character;
        _current = Max;
    }
}