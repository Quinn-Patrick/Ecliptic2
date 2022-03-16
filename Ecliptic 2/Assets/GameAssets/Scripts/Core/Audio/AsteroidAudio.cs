using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Asteroids;

namespace EclipticTwo.Audio
{
    public class AsteroidAudio : SoundPlayer
    {
        [SerializeField] private Asteroid _asteroid;
        [SerializeField] private AudioClip _getHitSound;

        private void OnEnable()
        {
            _asteroid.Destroyed += PlayDestroySound;
        }
        private void OnDisable()
        {
            _asteroid.Destroyed -= PlayDestroySound;
        }
        private void PlayDestroySound(Asteroid a)
        {
            PlaySoundWithDistance(_getHitSound);
        }
    }
}