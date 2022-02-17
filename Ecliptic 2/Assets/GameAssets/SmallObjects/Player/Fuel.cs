using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] private float _fuelMax;
    [SerializeField] private float _currentFuel;
    [SerializeField] private float _fuelEfficiency;

    public float GetFuelLevel()
    {
        return _currentFuel;
    }
    public float GetMaxFuel()
    {
        return _fuelMax;
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
        if (_currentFuel > _fuelMax)
        {
            _currentFuel = _fuelMax;
            return;
        }
        if (_currentFuel < 0) _currentFuel = 0;
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 20, 100, 20), $"Fuel: {_currentFuel}");
    }
}
