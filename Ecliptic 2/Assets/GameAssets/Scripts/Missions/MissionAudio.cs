using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using EclipticTwo.Missions;

namespace EclipticTwo.Audio
{
    public class MissionAudio : SoundPlayer
    {
        [SerializeField] private Mission _mission;
        [SerializeField] private AudioClip _completionClip;

        private void OnEnable()
        {
            _mission.MissionCompleted += PlayCompletionAudio;
        }
        private void OnDisable()
        {
            _mission.MissionCompleted -= PlayCompletionAudio;
        }
        private void PlayCompletionAudio()
        {
            PlaySound(_completionClip);
        }
    }
}