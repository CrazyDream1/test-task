using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Core.FightLogic
{
    public class BulletPull : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;

        private void Awake()
        {
            _bullet = _bulletPrefab;
        }

        private ObjectPool<Bullet> _pool = new ObjectPool<Bullet>(
            createFunc: () => Instantiate(_bullet), 
            actionOnGet: (obj) => obj.gameObject.SetActive(true), 
            actionOnRelease: (obj) => obj.gameObject.SetActive(false), 
            actionOnDestroy: (obj) => Destroy(obj.gameObject),
            true, 50, 200);

        public Bullet GetBullet() => _pool.Get();
        
        public void ReturnBullet(Bullet bullet) => _pool.Release(bullet);
        
        private static Bullet _bullet;
    }
}