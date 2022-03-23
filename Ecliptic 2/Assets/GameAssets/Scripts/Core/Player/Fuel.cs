using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] private float _maxFuel;
        [SerializeField] private float _currentFuel;
        [SerializeField] private float _fuelEfficiency;

        public delegate void FuelEmptyManager();
        public event FuelEmptyManager FuelDepleted;

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
            float initialFuelLevel = _currentFuel;
            float drainAmount = drain * Time.fixedDeltaTime / _fuelEfficiency;
            _currentFuel -= drainAmount;
            
            EnsureFuel();
            float finalFuelLevel = _currentFuel;
            Metrics.Instance.FuelUsed += (initialFuelLevel - finalFuelLevel);
            if(finalFuelLevel < initialFuelLevel && finalFuelLevel < float.Epsilon)
            {
                FuelDepleted?.Invoke();
            }
        }
        public void PumpFuel(float flow)
        {
            _currentFuel += flow * Time.fixedDeltaTime;
            EnsureFuel();
        }
        public void RestoreFuel()
        {
            _currentFuel = _maxFuel;
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
}