using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Boss;

namespace EclipticTwo.Audio
{
    public class BossAudio : SoundPlayer
    {
        [SerializeField] private BossBody _boss;
        [SerializeField] private AudioClip _onHitAudio;
        [SerializeField] private AudioClip _onStateChangeAudio;
        [SerializeField] private AudioClip _onDeathAudio;

        private void OnEnable()
        {
            _boss.GotHit += () => PlaySoundWithDistance(_onHitAudio);
            _boss.StateChanged += () => PlaySoundWithDistance(_onStateChangeAudio);
            _boss.Dead += (_boss) => PlaySoundWithDistance(_onDeathAudio);
        }
        private void OnDisable()
        {
            _boss.GotHit -= () => PlaySoundWithDistance(_onHitAudio);
            _boss.StateChanged -= () => PlaySoundWithDistance(_onStateChangeAudio);
            _boss.Dead -= (_boss) => PlaySoundWithDistance(_onDeathAudio);
        }
    }
}