using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EclipticTwo.TimingAndScoring;

namespace EclipticTwo.Gui
{
    public class TimerReadout : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Update()
        {
            _text.text = $"Time: {Timer.Instance.GetElapsedTimeFormatted()}";
        }
    }
}