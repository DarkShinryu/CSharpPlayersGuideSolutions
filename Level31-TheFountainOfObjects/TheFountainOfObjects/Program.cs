Console.Title = "Fountain of Objects";

(int rowCount, int colCount) cavernSize = (3, 3);
Cavern cavern = new Cavern(cavernSize.rowCount, cavernSize.colCount);
Game game = new Game(cavern);

game.Run();


// A few words about my strategy for tackling the fountain of objects challenge.
/* 
 * While creating this program I intentionally did not read the content of the expansions.
 * This allowed me to make the base version to be as malleable as I could with no knowledge about what is coming next.
 * My intention is to mimic real word non-tutorial programs in which you add functionality you had no idea needed to be implemented at first.
 * Which I assume happens very often.
*/ 