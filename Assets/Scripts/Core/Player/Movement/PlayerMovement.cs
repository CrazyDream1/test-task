using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _maxChange;
        [SerializeField] private float _squadRadius;
        [SerializeField] private List<NavMeshAgent> _characters;

        public void Construct(PlayerStateBehavior playerStateBehavior)
        {
            _playerStateBehavior = playerStateBehavior;
        }
        
        private void FixedUpdate()
        {
            UpdateCharacters();
            var speed = _maxSpeed; // * _change;
            _characters[0].speed = speed;
            _characters[0].destination =
                _characters[0].transform.position + Vector3.Normalize(new Vector3(_changeZ, 0, _changeX)) * _maxChange;
            var angle = 360 / (_characters.Count + 1);
            var center = _characters[0].destination - new Vector3(0, 0, _squadRadius);
            var radius = _characters[0].destination - center;
            for (int i = 1; i < _characters.Count; i++)
            {
                if (_characters[i] != null)
                {
                    _characters[i].destination =
                        center + (Quaternion.AngleAxis(angle * (i + 1), Vector3.up) * radius);
                    _characters[i].speed = speed;
                }
            }
        }

        private void Update()
        {
            if (_characters[0] != null)
            {
                Center = _characters[0].transform.position - new Vector3(0, 0, _squadRadius);
            }
        }

        public Vector3 Center;
        
        private void UpdateCharacters()
        {
            for (var i = 0; i < _characters.Count; i++)
            {
                if (_characters[i] == null)
                {
                    _characters.RemoveAt(i);
                    i--;
                }
            }
        }
        
        public void SetChange(float change, float changeX, float changeZ)
        {
            _change = change;
            _changeX = changeX;
            _changeZ = changeZ;
            if (changeX == 0 && changeZ == 0)
            {
                if (_playerStateBehavior.IsCurrentState<RunPlayerState>())
                {
                    _playerStateBehavior.SwitchState<StopPlayerState>();
                    _playerStateBehavior.InvokeCurrentState();
                }
            }
            else
            {
                if (_playerStateBehavior.IsCurrentState<StopPlayerState>())
                {
                    _playerStateBehavior.SwitchState<RunPlayerState>();
                    _playerStateBehavior.InvokeCurrentState();
                }
            }
        }

        public int GetNumberOfCharacters() => _characters.Count;

        private float _change;
        private float _changeX;
        private float _changeZ;
        private PlayerStateBehavior _playerStateBehavior;
    }
}