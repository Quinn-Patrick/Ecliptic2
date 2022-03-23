using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Audio
{
    public class ImpactAudio : SoundPlayer
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private DynamicEntity _entity;

        private void OnEnable()
        {
            _entity.Impacted += PlayImpactSound;
        }
        private void OnDisable()
        {
            _entity.Impacted -= PlayImpactSound;
        }
        private void PlayImpactSound(Collision2D collision)
        {
            PlaySoundWithVolume(_clip, ComputeVolume(collision));
        }
        private float ComputeVolume(Collision2D collision)
        {
            float relativeSpeed;
            if (collision == null) return 0f;

            Vector2 relativeVelocity = collision.relativeVelocity;
            relativeSpeed = relativeVelocity.magnitude;
            float volume = relativeSpeed / 10;

            if (volume > 1) volume = 1;

            return volume;
        }
    }
}