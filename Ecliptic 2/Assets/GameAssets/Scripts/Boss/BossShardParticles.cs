using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Boss
{
    public class BossShardParticles : MonoBehaviour
    {
        
        [SerializeField] private BossBody _boss;
        [SerializeField] private ParticleSystem _particles;
        private float _lifetime;
        private bool _hasActivated = false;

        private void OnEnable()
        {
            _boss.Dead += Activate;
            _particles.Pause();
        }

        private void OnDisable()
        {
            _boss.Dead -= Activate;
        }

        private void Activate(BossBody boss)
        {
            transform.parent = null;
            gameObject.transform.localScale = _boss.transform.localScale;
            _particles.Play();
            _hasActivated = true;
        }
        private void FixedUpdate()
        {
            if (_lifetime > 5) Destroy(this.gameObject);
            if (_hasActivated) _lifetime += Time.fixedDeltaTime;
        }
        
    }
}