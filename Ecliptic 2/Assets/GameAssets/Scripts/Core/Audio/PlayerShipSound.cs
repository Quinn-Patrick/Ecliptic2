using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using EclipticTwo.Guns;

namespace EclipticTwo.Audio 
{
    public class PlayerShipSound : SoundPlayer
    {
        [SerializeField] private HealthSystem _playerShip;
        [SerializeField] private Thruster _thruster;
        [SerializeField] private Gun _gun;

        [SerializeField] private AudioClip _deathSound;
        [SerializeField] private AudioClip _damageSound;
        [SerializeField] private AudioClip _gunshotSound;
        private void OnEnable()
        {
            _playerShip.Dead += PlayDeathSound;
            _gun.ShotFired += PlayGunSound;
            _playerShip.Damaged += PlayHurtSound;
        }
        private void OnDisable()
        {
            _playerShip.Dead -= PlayDeathSound;
            _gun.ShotFired -= PlayGunSound;
            _playerShip.Damaged -= PlayHurtSound;
        }
        private void PlayDeathSound()
        {
            PlaySoundWithDistance(_deathSound);
        }
        private void PlayGunSound()
        {
            PlaySoundWithDistance(_gunshotSound);
        }
        private void PlayHurtSound(float damage)
        {
            float volume = damage / 100;
            if (volume < 0.2) volume = 0.2f;
            else if (volume > 1) volume = 1;
            PlaySoundWithVolume(_damageSound, volume);
        }
    }
}