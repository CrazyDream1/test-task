using System;
using System.Collections.Generic;
using Core.Player.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace Core.EnemyLogic
{
    public class EnemyController : MonoBehaviour
    {
        public void Construct(PlayerMovement player)
        {
            _player = player;
        }
        
        private void FixedUpdate()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i] != null)
                {
                    _enemies[i] .destination = _player.Center;
                }
                else
                {
                    _enemies.RemoveAt(i);
                }
            }
        }

        public void AddEnemy(NavMeshAgent enemy)
        {
            _enemies.Add(enemy);
        }
        
        private PlayerMovement _player;
        private List<NavMeshAgent> _enemies = new List<NavMeshAgent>();
    }
}