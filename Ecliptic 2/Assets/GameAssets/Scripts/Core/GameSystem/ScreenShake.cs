using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float _shakeDecay;
    private float _shakeAmount;
    public static ScreenShake Instance;
    private float _maxShake = 1f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        _shakeAmount -= Time.fixedDeltaTime * _shakeDecay;
        if (_shakeAmount < 0) _shakeAmount = 0;
    }
    public float GetShake()
    {
        return _shakeAmount;
    }
    public void AddShake(float deltaShake)
    {
        _shakeAmount += deltaShake;
        if (_shakeAmount > _maxShake) _shakeAmount = _maxShake;
    }
}
