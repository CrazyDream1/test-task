using UnityEngine;

namespace Core.FightLogic
{
    public class Body : MonoBehaviour
    {
        [SerializeField] private Fighter _owner;
        
        public Fighter GetOwner() => _owner;
    }
}