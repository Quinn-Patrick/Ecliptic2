using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using EclipticTwo.Core;

namespace EclipticTwo.Gui
{
    public class AudioAdjusters : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _musicLevelIndicator;
        [SerializeField] private TextMeshProUGUI _soundLevelIndicator;
        [SerializeField] private AudioMixer _mixer;

        private IInputReader _input;

        private float _musicLevel;
        private float _soundLevel;

        public delegate void SoundAdjustmentHandler();
        public event SoundAdjustmentHandler SoundAdjusted;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();

            _mixer.GetFloat("SoundEffectsVolume", out _soundLevel);
            _soundLevel = Mathf.Pow(10, _soundLevel / 20);

            _mixer.GetFloat("MusicVolume", out _musicLevel);
            _musicLevel = Mathf.Pow(10, _musicLevel / 20);
        }

        private void Update()
        {
            if(Mathf.Abs(_input.GetThrust()) > 0)
            {
                _musicLevel += 0.5f * Time.deltaTime * _input.GetThrust();
                if (_musicLevel > 1) _musicLevel = 1;
                if (_musicLevel < float.Epsilon) _musicLevel = float.Epsilon;
            }
            if (Mathf.Abs(_input.GetRotation()) > 0)
            {
                _soundLevel -= 0.5f * Time.deltaTime * _input.GetRotation();
                if (_soundLevel > 1) _soundLevel = 1;
                if (_soundLevel < float.Epsilon) _soundLevel = float.Epsilon;
                SoundAdjusted?.Invoke();
            }
            if(_input.GetPause() || _input.GetAction())
            {
                Loader.Load(Loader.Scene.Title);
            }

            _musicLevelIndicator.text = $"{_musicLevel * 100:000}";
            _soundLevelIndicator.text = $"{_soundLevel * 100:000}";

            _mixer.SetFloat("SoundEffectsVolume", Mathf.Log10(_soundLevel) * 20);
            _mixer.SetFloat("MusicVolume", Mathf.Log10(_musicLevel) * 20);
        }
    }
}