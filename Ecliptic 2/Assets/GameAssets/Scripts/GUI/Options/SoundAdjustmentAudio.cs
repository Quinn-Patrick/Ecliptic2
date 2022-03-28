using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Gui;

namespace EclipticTwo.Audio
{
    public class SoundAdjustmentAudio : SoundPlayer
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioAdjusters _adjusters;

        private float _soundTiming;

        private void OnEnable()
        {
            _adjusters.SoundAdjusted += PlayAdjustmentSound;
        }
        private void OnDisable()
        {
            _adjusters.SoundAdjusted -= PlayAdjustmentSound;
        }

        private void PlayAdjustmentSound()
        {
            _soundTiming += Time.deltaTime;

            if(_soundTiming > 0.1f)
            {
                PlaySound(_clip);
                _soundTiming -= _soundTiming;
            }
        }
    }
}