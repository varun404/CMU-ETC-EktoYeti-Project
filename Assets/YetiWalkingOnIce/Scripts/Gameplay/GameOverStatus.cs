using System;

public static class GameOverStatus
{


    public static Action GameOverAction = delegate { };

    public enum GameState
    {
        Lose,
        Win
    }
    public static GameState gameState { get; set; }

    public static void SetGameState(GameState newGameState)
    {
        gameState = newGameState;
        GameOverTrigger();
    }

    public static GameState GetGameState()
    {
        return gameState;
    }

    public static void GameOverTrigger()
    {
        GameOverAction?.Invoke();
    }





    public enum LosingReason
    {
        None,
        Penguin,
        WalkOffPath
    }
    public static LosingReason reasonForLosingGame = LosingReason.None;

    public static void SetLosingReason(LosingReason losingReason )
    {
        reasonForLosingGame = losingReason;
    }
}
