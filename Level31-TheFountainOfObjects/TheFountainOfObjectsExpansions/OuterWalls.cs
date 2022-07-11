public readonly record struct OuterWalls(Extents Row, Extents Col);

public readonly record struct Extents(int Min, int Max);