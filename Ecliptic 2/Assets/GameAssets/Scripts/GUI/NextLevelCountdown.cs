using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EclipticTwo.Core;
using System;

namespace EclipticTwo.Missions
{
    public class NextLevelCountdown : MonoBehaviour
    {
        private int _remainingTime = 3;
        [SerializeField] private TextMeshProUGUI _textField;
        [SerializeField] private Animator _anim;
        private string _fieldName = "CountingDown";
        public static NextLevelCountdown Instance;

        public delegate void CountdownOverHandler();
        public event CountdownOverHandler CountdownEnded;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        private void OnEnable()
        {
            LevelEndZone._enteredZone += InitiateCountdown;
            LevelEndZone._exitedZone += CancelCountdown;
        }
        private void OnDisable()
        {
            LevelEndZone._enteredZone -= InitiateCountdown;
            LevelEndZone._exitedZone -= CancelCountdown;
        }
        private void SubtractTime()
        {
            _remainingTime -= 1;
        }

        private void Update()
        {
            _textField.text = $"Next Level In {_remainingTime}";
        }

        private void InitiateCountdown()
        {
            _remainingTime = 3;
            _anim.SetBool(_fieldName, true);
        }
        private void CancelCountdown()
        {
            _remainingTime = 3;
            _anim.SetBool(_fieldName, false);
        }
        private void EndCountdown()
        {
            CountdownEnded?.Invoke();
        }
    }
}