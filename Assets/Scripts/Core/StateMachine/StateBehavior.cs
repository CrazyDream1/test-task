using System;
using System.Collections.Generic;
using Core.Game;
using Core.Player;
using UnityEngine;

namespace Core.StateMachine
{
    public abstract class StateBehavior : MonoBehaviour
    {
        public void SwitchState<TState>() where TState : State
        {
            var necessaryState = default(TState);

            foreach (var state in AllStates())
            {
                if (state is TState) necessaryState = (TState) state;
            }

            _currentState = necessaryState;
        }

        public bool TryFindState<TState>(out TState foundState) where TState : State
        {
            foreach (var state in AllStates())
            {
                if (state is TState stateOfRequiredType)
                {
                    foundState = stateOfRequiredType;
                    return true;
                }
            }

            foundState = default;
            return false;
        }

        public void SubscribeAction<TState>(Action influence) where TState : State
        {
            foreach (var state in AllStates())
            {
                if (state is TState stateOfRequiredType)
                {
                    stateOfRequiredType.SubscribeActionToLaunch(influence);
                    return;
                }
            }
        }

        public void UnSubscribeAction<TState>(Action influence) where TState : State
        {
            foreach (var state in AllStates())
            {
                if (state is TState stateOfRequiredType)
                {
                    stateOfRequiredType.UnSubscribeActionToLaunch(influence);
                    return;
                }
            }
        }

        public void InvokeCurrentState()
        {
            _currentState?.Launch();
        }

        public bool IsCurrentState<TState>() where TState : State => _currentState is TState;

        protected abstract List<State> AllStates();
        private State _currentState;
    }
}