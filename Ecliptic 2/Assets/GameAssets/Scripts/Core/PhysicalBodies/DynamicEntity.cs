using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class DynamicEntity : MonoBehaviour
    {
        protected Vector3 _acceleration;
        protected Rigidbody2D _body;
        protected Transform _transform;
        [SerializeField] protected Vector2 _initialVelocity;

        public delegate void ImpactHandler(Collision2D collision);
        public event ImpactHandler Impacted;
        protected void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _transform = gameObject.transform;
            if (_body == null) return;
            _body.velocity = _initialVelocity;
        }
        protected void FixedUpdate()
        {
            if (_body == null) return;
            _body.AddForce(_acceleration);
            _acceleration = Vector3.zero;
        }
        public void UpdateAcceleration(Vector3 DeltaA)
        {
            _acceleration += DeltaA;
        }
        public void ZeroAcceleration()
        {
            _acceleration = Vector2.zero;
        }
        public Rigidbody2D GetBody()
        {
            return _body;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Impacted?.Invoke(collision);
        }
    }
}
