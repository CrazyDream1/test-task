using UnityEngine;

namespace Core.Game
{
    public class StartGameState : GameState
    {
        public override void Launch()
        {
            base.Launch();

            Debug.Log("GameState: Start");
        }
    }
}