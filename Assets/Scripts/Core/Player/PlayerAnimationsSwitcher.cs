using System;
using System.Collections.Generic;
using Core.Game;
using UnityEngine;

namespace Core.Player
{
    public class PlayerAnimationsSwitcher : MonoBehaviour
    {
        [SerializeField] private List<Animator> _animator;

        public void Construct(PlayerStateBehavior playerStateBehavior)
        {
            _playerStateBehavior = playerStateBehavior;
        }
        
        private void Awake()
        {
            _playerStateBehavior.SubscribeAction<RunPlayerState>(Run);
            _playerStateBehavior.SubscribeAction<StopPlayerState>(Stop);
        }

        public void Run()
        {
            foreach (var animator in _animator)
            {
                if (animator != null)
                {
                    animator.SetTrigger(RunTrigger);
                }
            }
        }

        public void Stop()
        {
            foreach (var animator in _animator)
            {
                if (animator != null)
                {
                    animator.SetTrigger(StopTrigger);
                }
            }
        }
        
        private PlayerStateBehavior _playerStateBehavior;
        private static readonly int RunTrigger = Animator.StringToHash("Run");
        private static readonly int StopTrigger = Animator.StringToHash("Stop");
    }
}