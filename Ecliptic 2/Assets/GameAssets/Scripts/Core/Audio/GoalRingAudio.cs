using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Rings;

namespace EclipticTwo.Audio
{
    public class GoalRingAudio : SoundPlayer
    {
        [SerializeField] private GoalRing _ring;
        [SerializeField] private AudioClip _ringCleared;
        private void OnEnable()
        {
            transform.parent = null;
            _ring.Cleared += PlayClearSound;
        }
        private void OnDisable()
        {
            _ring.Cleared -= PlayClearSound;
        }
        private void PlayClearSound(GoalRing g)
        {
            PlaySoundWithDistance(_ringCleared);
        }
    }
}