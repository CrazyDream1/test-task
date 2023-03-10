using UnityEngine;

namespace Core.Player
{
    public class RunPlayerState : PlayerState
    {
        public override void Launch()
        {
            base.Launch();

            Debug.Log("PlayerState: Run");
        }
    }
}