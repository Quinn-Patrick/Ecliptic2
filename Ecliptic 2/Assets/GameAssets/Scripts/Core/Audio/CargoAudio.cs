using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Cargo;

namespace EclipticTwo.Audio
{
    public class CargoAudio : SoundPlayer
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private CargoCollectible _collectible;

        private void OnEnable()
        {
            _collectible.Collected += (_collectible) => PlaySoundWithDistance(_clip);
        }
        private void OnDisable()
        {
            _collectible.Collected -= (_collectible) => PlaySoundWithDistance(_clip);
        }
    }
}