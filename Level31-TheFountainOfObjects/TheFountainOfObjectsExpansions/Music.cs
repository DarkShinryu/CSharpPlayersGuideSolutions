// Let's consider this a bonus expansion

public class Music
{
	private Note[] _victorySong;
	private Note[] _lossSong;	

    public Music()
    {
		_victorySong = new Note[]	// Final Fantasy Victory Music
		{
			new Note(Tone.D5, Duration.Eight),
			new Note(Tone.D5, Duration.Eight),
			new Note(Tone.D5, Duration.Eight),
			new Note(Tone.D5, Duration.DottedQuarter),
			new Note(Tone.A4s,Duration.Quarter),
			new Note(Tone.C5, Duration.Quarter),
			new Note(Tone.D5, Duration.Quarter),
			new Note(Tone.C5, Duration.DottedEight),
			new Note(Tone.D5, Duration.Half),
		};

		_lossSong = new Note[]	// Original Composition
{
			new Note(Tone.D5, Duration.DottedEight),
			new Note(Tone.F5, Duration.DottedEight),
			new Note(Tone.F5s, Duration.DottedEight),
			new Note(Tone.G5, Duration.Half),
			new Note(Tone.B5,Duration.Half),
			new Note(Tone.G5s, Duration.DottedHalf),
			new Note(Tone.F5s, Duration.Quarter),
			new Note(Tone.G5, Duration.Quarter),
			new Note(Tone.G5s, Duration.Quarter),
			new Note(Tone.G5, Duration.DottedHalf),
};
	}
	public void Victory()
    {
        foreach (Note note in _victorySong)
			Beep(note.Tone, note.Duration);
    }

    public void Loss()
    {
		foreach (Note note in _lossSong)
			Beep(note.Tone, note.Duration);
	}

    private void Beep(Tone tone, Duration duration)
    {
        if (tone > 0)
            Console.Beep((int)tone, (int)duration);  // I fixed the compiler warning about OSs by targeting only windows
        else
            Thread.Sleep((int)duration);
    }
}

public record Note(Tone Tone, Duration Duration);

public enum Tone	// I'm just going to do C4-C6
{
	Rest = 0,
	C4	= (int)261.63,
	C4s = (int)277.18,
	D4	= (int)293.66,
	D4s	= (int)311.13,
	E4	= (int)329.63,
	F4	= (int)349.23,
	F4s = (int)369.99,
	G4	= (int)392.00,
	G4s = (int)415.30,
	A4	= (int)440.00,
	A4s = (int)466.16,
	B4	= (int)493.88,
	C5	= (int)523.25,
	C5s = (int)554.37,
	D5	= (int)587.33,
	D5s = (int)622.25,
	E5	= (int)659.26,
	F5	= (int)698.46,
	F5s = (int)739.99,
	G5	= (int)783.99,
	G5s = (int)830.61,
	A5	= (int)880.00,
	A5s = (int)932.33,
	B5	= (int)987.77,
	C6	= (int)1046.50
}

public enum Duration    // Assuming 120 quarter notes per minute (1 Quarter Note = 500 ms)
{
	// Triplets are missing, can't be arsed
	Longa = DoubleWhole * 2,
	DottedDoubleWhole = (int)(DoubleWhole * 1.5f),
	DoubleWhole = Whole * 2,
	DottedWhole = (int)(Whole * 1.5f),
	Whole = Half * 2,
	DottedHalf = (int)(Half * 1.5f),
	Half = Quarter * 2,
	DottedQuarter = (int)(Quarter * 1.5f),
	Quarter = 500,
	DottedEight = (int)(Eight * 1.5f),
	Eight = Quarter / 2,
	DottedSixteenth = (int)(Sixteenth * 1.5f),
	Sixteenth = Eight / 2,
}