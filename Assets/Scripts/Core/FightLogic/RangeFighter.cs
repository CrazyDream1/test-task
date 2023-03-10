using UnityEngine;

namespace Core.FightLogic
{
    public class RangeFighter : Fighter
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Body enemy) && enemy.GetOwner().GetEFighter() != _eFighter)
            {
                Debug.Log("Someone had found enemy");
                if (_target == null)
                {
                    _target = enemy.GetOwner();
                    _possibleTargets.Add(enemy.GetOwner());
                    StartCoroutine(AttackController());
                }
                else
                {
                    _possibleTargets.Add(enemy.GetOwner());
                }
            }
        }
        
        protected override void Attack()
        {
            var bullet = _bulletPull.GetBullet();
            bullet.Init(_damage, _eFighter, _bulletPull);
            bullet.transform.position = _firePoint.position;
            bullet.transform.rotation = Quaternion.LookRotation(_target.transform.position - _firePoint.transform.position); //transform.rotation; если нормальное положение ствола
        }
    }
}