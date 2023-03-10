using UnityEngine;

namespace Core.FightLogic
{
    public class MeleeFighter : Fighter
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Body character) && character.GetOwner().GetEFighter() != _eFighter)
            {
                Debug.Log("Enemy had found character");
                if (_target == null)
                {
                    _target = character.GetOwner();
                    _possibleTargets.Add(character.GetOwner());
                    StartCoroutine(AttackController());
                }
                else
                {
                    _possibleTargets.Add(character.GetOwner());
                }
            }
        }

        protected override void Attack()
        {
            _target.GetDamage(_damage);
        }
    }
}