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

        private void OnEnable()
        {
            _adjusters.SoundAdjusted += () => PlaySound(_clip);
        }
        private void OnDisable()
        {
            _adjusters.SoundAdjusted -= () => PlaySound(_clip);
        }
    }
}