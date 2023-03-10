using System;
using UnityEngine;

namespace Core.Game
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private GameStateBehavior _gameStateBehavior;
        
        private void Start()
        {
            _gameStateBehavior.SwitchState<StartGameState>();
            _gameStateBehavior.InvokeCurrentState();
            
            _gameStateBehavior.SwitchState<NewWaveGameState>();
            _gameStateBehavior.InvokeCurrentState();
        }
    }
}