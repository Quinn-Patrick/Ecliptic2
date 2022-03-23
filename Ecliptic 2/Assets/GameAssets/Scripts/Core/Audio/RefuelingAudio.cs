using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Audio
{
    public class RefuelingAudio : SoundPlayer
    {
        [SerializeField] private RefuelingStation _station;
        [SerializeField] private AudioClip _refuelLoop;
        [SerializeField] private AudioClip _fuelFullClip;
        new private void Awake()
        {
            base.Awake();
            _source.clip = _refuelLoop;
            _source.Stop();
        }
        private void OnEnable()
        {
            _station.FuelFilled += () => PlaySoundWithDistance(_fuelFullClip);
            _station.RefuelBegan += () =>
            {
                _source.Play();
                _source.loop = true;
            };
            _station.RefuelEnded += () => _source.loop = false;
        }
        private void OnDisable()
        {
            _station.FuelFilled -= () => PlaySoundWithDistance(_fuelFullClip);
            _station.RefuelBegan -= () =>
            {
                _source.Play();
                _source.loop = true;
            };
            _station.RefuelEnded -= () => _source.loop = false;
        }

    }
}