using System;
using System.Collections.Generic;
using Core.Player;
using Core.StateMachine;

namespace Core.Game
{
    public sealed class GameStateBehavior : StateBehavior
    {
        private readonly List<State> _allStates = new()
        {
            new StartGameState(),
            new LoseGameState(),
            new WinGameState(),
            new NewWaveGameState()
        };

        protected override List<State> AllStates() => _allStates;
    }
}