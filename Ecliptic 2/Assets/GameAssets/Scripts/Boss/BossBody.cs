using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Boss
{
    public class BossBody : MonoBehaviour, IDestroyable
    {
        [SerializeField] private int _health;
        [SerializeField] private int _maxHealth;
        [SerializeField] private Shield _shield;
        private IBossState _state;

        public delegate void HitHandler();
        public event HitHandler GotHit;

        public delegate void DeathHandler(BossBody boss);
        public event DeathHandler Dead;

        private void Awake()
        {
            _state = new BossState1(this, _shield);
        }
        public void Defeated()
        {
            _health -= 1;
            GotHit?.Invoke();
        }

        public int GetHealth()
        {
            return _health;
        }
        public float GetHealthPercentage()
        {
            return (float)_health / (float)_maxHealth;
        }

        private void FixedUpdate()
        {
            _state = _state.UpdateState();

            if (_health <= 0)
            {
                Dead?.Invoke(this);
                Destroy(this.gameObject);
            }
        }
    }
}