using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private DynamicEntity _owner;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minimumCrashSpeed;
    [SerializeField] private float _crashDamageMultiplier;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _owner.Impacted += Crash;
    }
    private void Crash(Collision2D collision)
    {
        float relativeSpeed = _owner.GetBody().velocity.magnitude;
        if(collision != null)
        {
            Vector2 relativeVelocity = collision.relativeVelocity;
            relativeSpeed = relativeVelocity.magnitude;
        }
        Debug.Log($"Collision at relative speed {relativeSpeed}");

        if (relativeSpeed < _minimumCrashSpeed) return;

        _currentHealth -= Mathf.Pow((relativeSpeed - _minimumCrashSpeed), 2) * _crashDamageMultiplier;
    }
    private void Update()
    {
        if(_currentHealth <= 0)
        {
            Destroy(_owner.gameObject);
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
}
