using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

namespace EclipticTwo.Core
{
    public class Thruster : MonoBehaviour
    {
        private IInputReader _input;
        private DynamicEntity _entity;
        private Vector3 _eulerAngles;
        [SerializeField] private float _power;
        [SerializeField] private ParticleSystem _exhaust;
        private Fuel _fuel;
        readonly bool _canThrust = true;
        private void Awake()
        {
            _fuel = GetComponent<Fuel>();
            _input = GetComponent<IInputReader>();
            _entity = GetComponent<DynamicEntity>();
        }

        private void FixedUpdate()
        {
            ApplyThrust();
            ProjectExhaust();
        }
        private void ApplyThrust()
        {
            if (_fuel == null) return;
            if (_fuel.GetFuelLevel() < float.Epsilon) return;
            _eulerAngles = gameObject.transform.eulerAngles;

            float thrust = _input.GetThrust();
            if (thrust < 0) thrust = 0;

            if (_input == null || _entity == null || !_canThrust) return;
            float xThrust = thrust * Mathf.Cos(Mathf.Deg2Rad * _eulerAngles.z);
            float yThrust = thrust * Mathf.Sin(Mathf.Deg2Rad * _eulerAngles.z);

            Vector3 thrustVector = new Vector3(xThrust, yThrust, 0f);
            _entity.UpdateAcceleration(_power * Time.fixedDeltaTime * thrustVector);

            _fuel.DepleteFuel(math.abs(thrust));
        }
        public float GetThrustState()
        {
            if (_fuel.GetFuelLevel() < float.Epsilon) return 0;
            return _input.GetThrust();
        }
        private void ProjectExhaust()
        {
            if (_exhaust == null) return;
            ParticleSystem.EmissionModule emission = _exhaust.emission;
            if (_input.GetThrust() > 0 && (_fuel == null || _fuel.GetFuelLevel() > 0f))
            {
                emission.rateOverTime = 30f;
            }
            else
            {
                emission.rateOverTime = 0f;
            }
        }
    }
}