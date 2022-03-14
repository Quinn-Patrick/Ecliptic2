using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Missions;

namespace EclipticTwo.Audio
{
    public class UIAudio : SoundPlayer
    {
        [SerializeField] private AudioClip _levelEndSound;
        private void OnEnable()
        {
            NextLevelCountdown.CountdownOver += () => PlaySound(_levelEndSound);
        }
        private void OnDisable()
        {
            NextLevelCountdown.CountdownOver -= () => PlaySound(_levelEndSound);
        }
    }
}