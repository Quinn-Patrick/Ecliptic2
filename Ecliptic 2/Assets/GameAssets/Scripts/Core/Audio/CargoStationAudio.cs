using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Cargo;

namespace EclipticTwo.Audio
{
    public class CargoStationAudio : SoundPlayer
    {
        [SerializeField] private CargoStation _station;
        [SerializeField] private AudioClip _depositCargoClip;
        [SerializeField] private AudioClip _completeStationClip;
        private void OnEnable()
        {
            _station.CargoDeposited += PlayDepositCargoClip;
            _station.Complete += PlayCompleteStationClip;
        }
        private void OnDisable()
        {
            _station.CargoDeposited -= PlayDepositCargoClip;
            _station.Complete -= PlayCompleteStationClip;
        }
        private void PlayDepositCargoClip()
        {
            PlaySoundWithDistance(_depositCargoClip);
        }
        private void PlayCompleteStationClip(CargoStation cs)
        {
            PlaySoundWithDistance(_completeStationClip);
        }
    }
}