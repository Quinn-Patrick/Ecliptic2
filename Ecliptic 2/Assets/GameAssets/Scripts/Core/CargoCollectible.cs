using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Cargo
{
    public class CargoCollectible : GravitatingBody, ITriggerObject
    {
        public delegate void CollectHandler(CargoCollectible cargo);
        public event CollectHandler Collected;
        [SerializeField] private CargoGrabber _grabber;
        private Transform _startingTransform;

        private float _timeSinceActivation;
        private new void Awake()
        {
            base.Awake();
            _body = GetComponent<Rigidbody2D>();
            _startingTransform = transform;

            if (_grabber == null) return;
            _grabber.AddPotentialCargo(this);
        }
        public void PlayerEnter(Player player)
        {
            Collected?.Invoke(this);
        }

        public void PlayerExit(Player player) { }

        public void PlayerStay(Player player) { }
        private void OnEnable()
        {
            _timeSinceActivation = 0f;
        }
        private new void FixedUpdate()
        {
            base.FixedUpdate();
            if (_timeSinceActivation < 0.5)//This is to force the box not to go crazy when it respawns. Sorry, I know it's gross.
            {
                _body.velocity = _initialVelocity;
                _body.angularVelocity = 0f;
                gameObject.transform.position = _startingTransform.position;
            }
            _timeSinceActivation += Time.fixedDeltaTime;
        }
    }
}