using Core.Player.Movement;
using UnityEngine;

namespace Core
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;

        public void Construct(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        
        private void Update()
        {
            transform.position = _playerMovement.Center + _offset;
        }
        
        private PlayerMovement _playerMovement;
    }
}