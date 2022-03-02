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
        [SerializeField] private GameObject _exhaust;
        private Fuel _fuel;

        bool _canThrust = true;

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
            if (_input == null || _entity == null || !_canThrust) return;
            float xThrust = _input.GetThrust() * Mathf.Cos(Mathf.Deg2Rad * _eulerAngles.z);
            float yThrust = _input.GetThrust() * Mathf.Sin(Mathf.Deg2Rad * _eulerAngles.z);
            _fuel.DepleteFuel(math.abs(_input.GetThrust()));
            Vector3 thrust = new Vector3(xThrust, yThrust, 0f);
            _entity.UpdateAcceleration(_power * Time.fixedDeltaTime * thrust);
        }
        private void ProjectExhaust()
        {
            if (_exhaust == null) return;
            if (_input.GetThrust() > 0 && (_fuel == null || _fuel.GetFuelLevel() > 0f))
            {
                _exhaust.transform.localScale = Vector3.one;
            }
            else
            {
                _exhaust.transform.localScale = Vector3.zero;
            }
        }
    }
}