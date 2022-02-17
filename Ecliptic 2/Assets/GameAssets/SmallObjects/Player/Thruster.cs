using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Thruster : MonoBehaviour
{
    private IInputReader _input;
    private DynamicEntity _entity;
    private Vector3 _eulerAngles;
    [SerializeField] private float _power;
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
}
