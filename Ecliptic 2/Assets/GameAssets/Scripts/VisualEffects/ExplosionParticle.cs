using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.VisualEffects
{
    public class ExplosionParticle : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private HealthSystem _exploder;
        [SerializeField] private Rigidbody2D _body;
        private float _lifetime;
        private bool _canExplode = true;

        private void OnEnable()
        {
            _exploder.Dead += Explode;
            _particle.Pause();
        }
        private void OnDisable()
        {
            _exploder.Dead -= Explode;
        }

        private void Explode()
        {
            if (_canExplode)
            {
                _particle.transform.position = _exploder.transform.position;
                if (!_particle.isPaused) return;
                _particle.Play();
                _lifetime = 0f;
                _canExplode = false;
            }
        }

        private void FixedUpdate()
        {
            if (_exploder.GetCurrentHealth() > 0) _canExplode = true;

            transform.localPosition = _body.transform.localPosition;

            if (_particle.isPaused) return;
            _lifetime += Time.fixedDeltaTime;

            if(_lifetime > 0.4f)
            {
                _particle.Pause();
                _particle.time = 0;
            }

            
        }
    }
}
