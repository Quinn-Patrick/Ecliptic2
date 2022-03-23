using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Cargo
{
    public class CargoRope : MonoBehaviour
    {
        [SerializeField] private GameObject _payload;
        [SerializeField] private Rigidbody2D _playerBody;
        [SerializeField] private GameObject _hook;
        private Rigidbody2D _payloadBody;
        private SpriteRenderer _payloadSprite;
        private float _timeSinceActivation = 0f;
        private Vector2 _targetPosition = Vector2.zero;
        

        private void Awake()
        {
            _payloadSprite = _payload.GetComponent<SpriteRenderer>();
            _payloadBody = _payload.GetComponent<Rigidbody2D>();
            gameObject.SetActive(false);
        }
        public void ActivatePayload(Transform targetCargo)
        {
            _timeSinceActivation = 0f;
            _targetPosition = targetCargo.position;
            _payload.transform.position = _targetPosition;
        }
        public void SetPayloadColor(Color color)
        {
            if (_payloadSprite == null) return;
            _payloadSprite.color = color;

        }
        private void FixedUpdate()
        {
            if (_timeSinceActivation < 0.1f)
            {
                _payload.transform.position = _targetPosition;
                _hook.transform.position = _playerBody.transform.position;
                _payloadBody.velocity = _playerBody.velocity;
                _payloadBody.angularVelocity = 0f;
            }
            _timeSinceActivation += Time.fixedDeltaTime;
        }
    }
}