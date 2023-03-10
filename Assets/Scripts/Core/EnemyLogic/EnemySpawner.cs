using Core.Player.Movement;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Core.EnemyLogic
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _center;
        [SerializeField] private float _xMax;
        [SerializeField] private float _zMax;
        [SerializeField] private float _radiusToPlayer;
        
        public void Construct(PlayerMovement player, EnemyController enemyController)
        {
            _player = player;
            _enemyController = enemyController;
        }

        private void Awake()
        {
            _squareRadius = _radiusToPlayer * _radiusToPlayer;
        }

        public void SpawnOne(GameObject enemyPrefab)
        {
            Vector3 position;
            do
            {
                var x = Random.Range(-_xMax, _xMax);
                var z = Random.Range(-_zMax, _zMax);
                position = _center.transform.position + new Vector3(x, 0, z);
            } while ((position.x - _player.transform.position.x) * (position.x - _player.transform.position.x) +
                     (position.y - _player.transform.position.y) * (position.y - _player.transform.position.y) < _squareRadius);
            var enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            var navMeshAgent = enemy.GetComponent<NavMeshAgent>();
            _enemyController.AddEnemy(navMeshAgent);
        }

        private float _squareRadius;
        private EnemyController _enemyController;
        private PlayerMovement _player;
    }
}