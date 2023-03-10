using UnityEngine;

namespace Core.Player
{
    public class StopPlayerState : PlayerState
    {
        public override void Launch()
        {
            base.Launch();

            Debug.Log("PlayerState: Stop");
        }
    }
}