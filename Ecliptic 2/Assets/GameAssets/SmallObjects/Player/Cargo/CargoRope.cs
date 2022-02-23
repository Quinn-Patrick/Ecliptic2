using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoRope : MonoBehaviour
{
    [SerializeField] private GameObject _payload;
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] private GameObject _hook;
    private Rigidbody2D _payloadBody;
    private float _timeSinceActivation = 0f;
    private void Awake()
    {

        gameObject.SetActive(false);
        _payloadBody = _payload.GetComponent<Rigidbody2D>();
    }
    public void ActivatePayload()
    {
        _timeSinceActivation = 0f;
        if (_hook == null) return;
        
    }
    private void FixedUpdate()
    {
        if(_timeSinceActivation < 0.2f)
        {
            _hook.transform.position = _playerBody.transform.position;
            _payloadBody.velocity = _playerBody.velocity;
            _payloadBody.angularVelocity = 0f;
        }
        _timeSinceActivation += Time.fixedDeltaTime;
    }
}
