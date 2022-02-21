using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] private float _maxFuel;
    [SerializeField] private float _currentFuel;
    [SerializeField] private float _fuelEfficiency;

    public float GetFuelLevel()
    {
        return _currentFuel;
    }
    public float GetMaxFuel()
    {
        return _maxFuel;
    }
    public float GetFuelEfficiency()
    {
        return _fuelEfficiency;
    }

    public void DepleteFuel(float drain)
    {
        _currentFuel -= drain * Time.fixedDeltaTime / _fuelEfficiency;
        EnsureFuel();
    }
    public void PumpFuel(float flow)
    {
        _currentFuel += flow * Time.fixedDeltaTime;
        EnsureFuel();
    }

    private void EnsureFuel()
    {
        if (_currentFuel > _maxFuel)
        {
            _currentFuel = _maxFuel;
            return;
        }
        if (_currentFuel < 0) _currentFuel = 0;
    }
    public float GetFuelPercentage()
    {
        return (_currentFuel / _maxFuel);
    }
}
