using UnityEngine;

namespace Core.Game
{
    public class WinGameState : GameState
    {
        public override void Launch()
        {
            base.Launch();

            Debug.Log("GameState: Win");
        }
    }
}