using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Audio
{
    public abstract class SoundPlayer : MonoBehaviour
    {
        [SerializeField] protected AudioSource _source;
        [SerializeField] protected Transform _pseudoParent;
        protected AudioListener _listener;
        protected void Awake()
        {
            _listener = FindObjectOfType<AudioListener>();
        }
        protected void PlaySoundWithDistance(AudioClip _clip)
        {
            _source.PlayOneShot(_clip, ComputeVolume());
        }
        protected void PlaySoundWithVolume(AudioClip _clip, float volume)
        {
            if (volume > 1) volume = 1;
            _source.PlayOneShot(_clip, ComputeVolume() * volume);
        }
        protected void PlaySound(AudioClip _clip)
        {
            _source.PlayOneShot(_clip, 1f);
        }
        protected float ComputeVolume()
        {
            if (_listener == null) return 1f;
            float distance = Vector3.Distance(_source.transform.position, _listener.transform.position - new Vector3(0, 0, -14)) / 4;
            if (distance < float.Epsilon) return 1f;
            
            float effectiveVolume = 4 / (distance * distance);
            if (effectiveVolume > 1) return 1f;
            else return effectiveVolume;
        }
        protected void FixedUpdate()
        {
            transform.position = _pseudoParent.position;
        }
    }
}