using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
namespace EclipticTwo.Audio
{
    public class ThrusterAudio : SoundPlayer
    {
        [SerializeField] private Thruster _thruster;
        [SerializeField] private AudioClip _clip;
        new private void Awake()
        {
            base.Awake();
            _source.clip = _clip;
            _source.Play();
        }
        new private void FixedUpdate()
        {
            base.FixedUpdate();
            _source.volume = _thruster.GetThrustState() * ComputeVolume();
        }
    }
}