using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using UnityEngine.SceneManagement;

namespace EclipticTwo.TimingAndScoring
{
    public class Timer : MonoBehaviour
    {
        private float _elapsedTime;
        private float _levelTime;
        public static Timer Instance;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
            Loader.LevelLoaded += OnNewLevel;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
        }
        public float GetElapsedTime()
        {
            return _elapsedTime;
        }
        public string GetElapsedTimeFormatted()
        {
            int seconds = (int)_elapsedTime;

            int minutes = seconds / 60;
            seconds = seconds % 60;

            return $"{minutes:00} : {seconds:00}";
        }
        public float GetLevelTime()
        {
            return _elapsedTime - _levelTime;
        }

        private void OnNewLevel()
        {
            _levelTime = _elapsedTime;
        }
    }
}