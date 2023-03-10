using System.Collections.Generic;
using Core.StateMachine;

namespace Core.Player
{
    public class PlayerStateBehavior : StateBehavior
    {
        private void Awake()
        {
            SwitchState<StopPlayerState>();
        }

        private readonly List<State> _allStates = new()
        {
            new RunPlayerState(),
            new StopPlayerState()
        };

        protected override List<State> AllStates() => _allStates;
    }
}