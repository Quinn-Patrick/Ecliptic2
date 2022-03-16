using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private DynamicEntity _owner;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _minimumCrashSpeed;
        [SerializeField] private float _crashDamageMultiplier;
        private float _currentHealth;
        private bool _isDead;

        public delegate void DeathHandler();
        public event DeathHandler Dead;

        public delegate void DamageHandler(float damage);
        public event DamageHandler Damaged;

        private void Awake()
        {
            _currentHealth = _maxHealth;
            _owner.Impacted += Crash;
        }
        private void Crash(Collision2D collision)
        {
            float relativeSpeed = _owner.GetBody().velocity.magnitude;
            if (collision != null)
            {
                Vector2 relativeVelocity = collision.relativeVelocity;
                relativeSpeed = relativeVelocity.magnitude;
            }
            Debug.Log($"Collision at relative speed {relativeSpeed} with {collision.gameObject}");

            if (relativeSpeed < _minimumCrashSpeed) return;
            float damage = Mathf.Pow((relativeSpeed - _minimumCrashSpeed), 2) * _crashDamageMultiplier;
            _currentHealth -= damage;

            Metrics.Instance.TotalDamage += damage;

            Damaged?.Invoke(damage);
            
            
            EnsureHealth();
        }
        private void Update()
        {
            if (_currentHealth <= 0 && !_isDead)
            {
                Dead?.Invoke();
                _isDead = true;
                _owner.gameObject.transform.localScale = Vector3.zero;
            }
        }
        private void OnDestroy()
        {
            _owner.Impacted -= Crash;
        }
        public float GetCurrentHealth()
        {
            return _currentHealth;
        }
        public float GetMaxHealth()
        {
            return _maxHealth;
        }
        public float GetHealthPercentage()
        {
            return _currentHealth / _maxHealth;
        }
        public void RestoreHealth(float restoreAmount)
        {
            _isDead = false;
            _currentHealth += restoreAmount;
            EnsureHealth();
        }
        private void EnsureHealth()
        {
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
            if (_currentHealth < 0) _currentHealth = 0;
        }

        public void InflictFixedDamage(int damage)
        {
            _currentHealth -= damage;
            Damaged?.Invoke(damage);
            EnsureHealth();
        }
    }
}