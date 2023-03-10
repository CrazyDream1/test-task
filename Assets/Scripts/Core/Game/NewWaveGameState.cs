using UnityEngine;

namespace Core.Game
{
    public class NewWaveGameState : GameState
    {
        public override void Launch()
        {
            base.Launch();

            Debug.Log("GameState: NewWave");
        }
    }
}