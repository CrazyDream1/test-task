using System.Collections;
using UnityEngine;

namespace Core.FightLogic
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        
        private void FixedUpdate()
        {
            transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        }

        public void Init(int damage, EFighter owner, BulletPull bulletPull)
        {
            _damage = damage;
            _owner = owner;
            _bulletPull = bulletPull;
            StartCoroutine(Destroy());
        }

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(_lifeTime);
            _bulletPull.ReturnBullet(this);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Body enemy))
            {
                if (enemy.GetOwner().GetEFighter() != _owner)
                {
                    Debug.Log("Bullet hit3");
                    enemy.GetOwner().GetDamage(_damage);
                    _bulletPull.ReturnBullet(this);
                }
            }
        }

        private BulletPull _bulletPull;
        private EFighter _owner;
        private int _damage;
    }
}