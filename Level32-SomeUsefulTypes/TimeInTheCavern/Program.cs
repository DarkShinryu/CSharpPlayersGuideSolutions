Console.Title = "Fountain of Objects";

Display.Intro();    // I would rather have this inside game.Run(), but I need the cavern ready before passing it to game object
Cavern cavern = CavernGenerator.Run();
Game game = new Game(cavern, 5);

game.Run();