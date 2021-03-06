using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Burst;

namespace EclipticTwo.Core
{
    public class GravitatingBody : DynamicEntity
    {
        [SerializeField] protected Fuel _fuelSystem;
        [SerializeField] protected Thruster _thrustSystem;
        [SerializeField] protected Rotator _rotationSystem;
        [SerializeField] protected HealthSystem _healthSystem;
        private new void Awake()
        {
            base.Awake();
            _fuelSystem = GetComponent<Fuel>();
            _thrustSystem = GetComponent<Thruster>();
            _rotationSystem = GetComponent<Rotator>();
        }
        protected void Start()
        {
            if (!Game.gravitators.Contains(this))
            {
                Game.gravitators.Add(this);
            }
        }

        public Fuel GetFuelSystem()
        {
            return _fuelSystem;
        }
        public Thruster GetThrustSystem()
        {
            return _thrustSystem;
        }
        public Rotator GetRotationSystem()
        {
            return _rotationSystem;
        }
        public HealthSystem GetHealthSystem()
        {
            return _healthSystem;
        }

        private void OnDestroy()
        {
            Game.gravitators.Remove(this);
        }
    }
}