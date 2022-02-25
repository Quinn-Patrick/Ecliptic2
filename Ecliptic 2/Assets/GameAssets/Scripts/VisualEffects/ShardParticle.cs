using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Asteroids;

namespace EclipticTwo.VisualEffects
{
    public class ShardParticle : MonoBehaviour
    {
        [SerializeField] private Asteroid _asteroid;
        [SerializeField] private ParticleSystem _particles;
        private float _lifetime;
        private bool _hasActivated = false;

        private void OnEnable()
        {
            _asteroid.Destroyed += Activate;
            _particles.Pause();
        }

        private void OnDisable()
        {
            _asteroid.Destroyed -= Activate;
        }

        private void Activate(Asteroid asteroid)
        {
            transform.parent = null;
            gameObject.transform.localScale = _asteroid.transform.localScale;
            _particles.Play();
            _hasActivated = true;
        }
        private void FixedUpdate()
        {
            if (_lifetime > 5) Destroy(this.gameObject);
            if(_hasActivated)_lifetime += Time.fixedDeltaTime;
        }
    }
}
