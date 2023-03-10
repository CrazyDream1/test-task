using System.Collections;
using System.Collections.Generic;
using Core.Game;
using UnityEngine;

namespace Core.FightLogic
{
    public abstract class Fighter : MonoBehaviour
    {
        [SerializeField] protected Transform _firePoint;
        [SerializeField] protected int _hp;
        [SerializeField] protected int _damage;
        [SerializeField] protected float _attackSpeed;
        [SerializeField] protected EFighter _eFighter;
        [SerializeField] protected LookAt _lookAt;
        
        protected Fighter _target;
        protected List<Fighter> _possibleTargets = new List<Fighter>();

        public void Construct(BulletPull bulletPull, GameController gameController)
        {
            _bulletPull = bulletPull;
            _gameController = gameController;
        }

        public EFighter GetEFighter() => _eFighter;
        
        protected IEnumerator AttackController()
        {
            while (_target != null)
            {

                _lookAt.Target = _target.gameObject;
                Attack();
                yield return new WaitForSeconds(_attackSpeed);
                UpdateTargets();
            }
            _lookAt.Target = null;
        }
        
        protected abstract void OnTriggerEnter(Collider other);
        protected abstract void Attack();

        protected void Dead()
        {
            if (_eFighter == EFighter.Enemy)
            {
                _gameController.EnemyDead();
            }
            else
            {
                _gameController.CharacterDead();
            }
            Destroy(this.gameObject);
        }
        
        protected void UpdateTargets()
        {
            for (var i = 0; i < _possibleTargets.Count; i++)
            {
                if (_possibleTargets[i] == null)
                {
                    _possibleTargets.RemoveAt(i);
                    i--;
                }
            }

            if (_possibleTargets.Count > 0)
            {
                _target = _possibleTargets[0];
            }
        }

        public void GetDamage(int damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Dead();
            }
        }

        protected BulletPull _bulletPull;
        protected GameController _gameController;
    }
}