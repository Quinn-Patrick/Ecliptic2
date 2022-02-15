using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    private IInputReader _input;
    private DynamicEntity _entity;
    private Vector3 _eulerAngles;
    [SerializeField] private float _power;

    private void Awake()
    {
        _input = GetComponent<IInputReader>();
        _entity = GetComponent<DynamicEntity>();
        
    }

    private void FixedUpdate()
    {
        _eulerAngles = gameObject.transform.eulerAngles;
        if (_input == null || _entity == null) return;
        Debug.Log($"{_eulerAngles.z}");
        float xThrust = _input.GetThrust() * Mathf.Cos(Mathf.Deg2Rad * _eulerAngles.z);
        float yThrust = _input.GetThrust() * Mathf.Sin(Mathf.Deg2Rad * _eulerAngles.z);
        Vector3 thrust = new Vector3(xThrust, yThrust, 0f);
        _entity.UpdateAcceleration(thrust * _power * Time.fixedDeltaTime);
    }
}
