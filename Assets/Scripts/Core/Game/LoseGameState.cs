using UnityEngine;

namespace Core.Game
{
    public class LoseGameState : GameState
    {
        public override void Launch()
        {
            base.Launch();

            Debug.Log("GameState: Lose");
        }
    }
}