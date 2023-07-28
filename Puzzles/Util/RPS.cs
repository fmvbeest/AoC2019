namespace AoC2019.Util;

public class Game
{
    public GameRules.Move TheirMove { get; init; }
    public GameRules.Move OurMove { get; set; }
    public GameRules.Result ExpectedOutcome { get; init; }
}

public static class GameRules
{
    public enum Move
    {
        Rock = 1, Paper = 2, Scissor = 3
    }

    public enum Result
    {
        Loss = 0, Draw = 3, Win = 6
    }

    public static int GetPoints(Game game)
    {
        return (int)GetResult(game) + (int)game.OurMove;
    }

    public static Game FixGame(Game game)
    {
        game.OurMove = SuggestedMoves[(game.TheirMove, game.ExpectedOutcome)];
        return game;
    }

    private static Result GetResult(Game game)
    {
        return Outcome[(game.OurMove, game.TheirMove)];
    }

    private static readonly Dictionary<(Move, Move), Result> Outcome = new()
    {
        { (Move.Rock, Move.Scissor), Result.Win },
        { (Move.Scissor, Move.Paper), Result.Win },
        { (Move.Paper, Move.Rock), Result.Win },
        { (Move.Scissor, Move.Rock), Result.Loss },
        { (Move.Paper, Move.Scissor), Result.Loss },
        { (Move.Rock, Move.Paper), Result.Loss },
        { (Move.Rock, Move.Rock), Result.Draw },
        { (Move.Paper, Move.Paper), Result.Draw },
        { (Move.Scissor, Move.Scissor), Result.Draw }
    };

    private static readonly Dictionary<(Move, Result), Move> SuggestedMoves = new()
    {
        { (Move.Rock, Result.Win), Move.Paper },
        { (Move.Rock, Result.Loss), Move.Scissor },
        { (Move.Rock, Result.Draw), Move.Rock },
        { (Move.Scissor, Result.Win), Move.Rock },
        { (Move.Scissor, Result.Loss), Move.Paper },
        { (Move.Scissor, Result.Draw), Move.Scissor },
        { (Move.Paper, Result.Win), Move.Scissor },
        { (Move.Paper, Result.Loss), Move.Rock },
        { (Move.Paper, Result.Draw), Move.Paper }
    };
}