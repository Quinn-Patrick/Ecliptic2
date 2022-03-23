using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Audio
{
    public class FuelAudio : SoundPlayer
    {
        [SerializeField] private Fuel _fuelTank;
        [SerializeField] private AudioClip _lowFuelClip;
        [SerializeField] private AudioClip _outOfFuelClip;
        private float _alarmRate = -1f;
        private float _timer = 0f;
        private void OnEnable()
        {
            _fuelTank.FuelDepleted += () => PlaySoundWithDistance(_outOfFuelClip);
        }
        private void OnDisable()
        {
            _fuelTank.FuelDepleted -= () => PlaySoundWithDistance(_outOfFuelClip);
        }
        new private void FixedUpdate()
        {
            base.FixedUpdate();
            if(_fuelTank.GetFuelPercentage() < 0.25f && _fuelTank.GetFuelPercentage() > float.Epsilon)
            {
                _alarmRate = 1f;
                if (_fuelTank.GetFuelPercentage() < 0.15f)
                {
                    _alarmRate = 0.7f;
                    if (_fuelTank.GetFuelPercentage() < 0.10f)
                    {
                        _alarmRate = 0.4f;
                    }
                }
            }
            else
            {
                _alarmRate = -1f;
            }
            if (_alarmRate < 0f) return;
            _timer += Time.fixedDeltaTime;
            if (_timer >= _alarmRate)
            {
                PlaySoundWithDistance(_lowFuelClip);
                _timer = 0;
            }
        }
    }
}