using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class RefuelingStation : MonoBehaviour, ITriggerObject
    {
        [SerializeField] private float flowRate;
        private bool _hasNewlyEntered;

        public delegate void BeginRefuelHandler();
        public delegate void EndRefuelHandler();
        public delegate void FullFuelHandler();

        public event BeginRefuelHandler RefuelBegan;
        public event EndRefuelHandler RefuelEnded;
        public event FullFuelHandler FuelFilled;
        public void PlayerEnter(Player player)
        {
            _hasNewlyEntered = true;
            RefuelBegan?.Invoke();
        }

        public void PlayerExit(Player player)
        {
            RefuelEnded?.Invoke();
        }

        public void PlayerStay(Player player)
        {
            Fuel fuelSystem = player.GetFuelSystem();
            
            fuelSystem.PumpFuel(flowRate);
            if(fuelSystem.GetFuelLevel() >= fuelSystem.GetMaxFuel())
            {
                RefuelEnded?.Invoke();
                if (_hasNewlyEntered)
                {
                    FuelFilled?.Invoke();
                    _hasNewlyEntered = false;
                }
            }
        }
    }
}