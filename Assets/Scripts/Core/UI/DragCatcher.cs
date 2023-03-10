using Core.Player.Movement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.UI
{
    public class DragCatcher : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _imageBig;
        [SerializeField] private Image _imageSmall;
        
        public void Construct(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            var sizeDelta = _imageBig.rectTransform.sizeDelta / 2;
            var vector2 = Vector2.ClampMagnitude(eventData.position - _startPos, sizeDelta.x);
            var length = vector2.x * vector2.x + vector2.y * vector2.y;
            _playerMovement.SetChange(length / (sizeDelta.x * sizeDelta.x),  vector2.y, vector2.x);
            _imageSmall.transform.position = _startPos +  vector2;
            
            // Debug.Log(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _playerMovement.SetChange(0, 0, 0);
            
            _imageBig.gameObject.SetActive(false);
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _imageBig.transform.position = eventData.position;
            _imageSmall.transform.position = eventData.position;
            _startPos = eventData.position;
            
            _imageBig.gameObject.SetActive(true);
            
            // Debug.Log(_startPos);
        }

        private PlayerMovement _playerMovement;
        private Vector2 _startPos;
    }
}