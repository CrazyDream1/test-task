using System.Collections;
using Core.EnemyLogic;
using Core.Player.Movement;
using Core.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private int _maxNumberOfEnemies = 50;
        [SerializeField] private int _spawnNumberOfEnemies = 5;
        [SerializeField] private int _spawnNumberOfEnemiesStep = 5;
        [SerializeField] private float _spawnInterval = 0.2f;
        [SerializeField] private LevelEnemyTypes _levelEnemyTypes;

        public void Construct(GameStateBehavior gameStateBehavior, EnemySpawner enemySpawner, PlayerMovement playerMovement)
        {
            _gameStateBehavior = gameStateBehavior;
            _enemySpawner = enemySpawner;
            _playerMovement = playerMovement;
        }

        private void Awake()
        {
            _gameStateBehavior.SubscribeAction<LoseGameState>(Reload);
            _gameStateBehavior.SubscribeAction<WinGameState>(Reload);
            _gameStateBehavior.SubscribeAction<NewWaveGameState>(SpawnWave);
            _currentNumberOfCharacters = _playerMovement.GetNumberOfCharacters();
        }

        private void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void SpawnWave()
        {
            _currentNumberOfEnemies = _spawnNumberOfEnemies;
            StartCoroutine(SpawnEnemies(_spawnNumberOfEnemies));
            _spawnNumberOfEnemies += _spawnNumberOfEnemiesStep;
        }
        
        IEnumerator SpawnEnemies(int numberOfEnemies)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                _enemySpawner.SpawnOne(_levelEnemyTypes.EnemyTypes[Random.Range(0, _levelEnemyTypes.EnemyTypes.Count)].gameObject);
                yield return new WaitForSeconds(_spawnInterval); // Add Random?
            }
        }

        public void EnemyDead()
        {
            if (_currentNumberOfEnemies > 1)
            {
                _currentNumberOfEnemies--;
            }
            else
            {
                if (_spawnNumberOfEnemies >= _maxNumberOfEnemies)
                {
                    _gameStateBehavior.SwitchState<WinGameState>();
                    _gameStateBehavior.InvokeCurrentState();
                    return;
                }
                _gameStateBehavior.SwitchState<NewWaveGameState>();
                _gameStateBehavior.InvokeCurrentState();
            }
        }

        public void CharacterDead()
        {
            if (_currentNumberOfCharacters > 1)
            {
                _currentNumberOfCharacters--;
            }
            else
            {
                _gameStateBehavior.SwitchState<LoseGameState>();
                _gameStateBehavior.InvokeCurrentState();
            }
        }
        
        private int _currentNumberOfEnemies = 0;
        private int _currentNumberOfCharacters = 0;
        private PlayerMovement _playerMovement;
        private EnemySpawner _enemySpawner;
        private GameStateBehavior _gameStateBehavior;
    }
}