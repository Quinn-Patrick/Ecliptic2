using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.TimingAndScoring;
using EclipticTwo.Core;
using TMPro;

namespace EclipticTwo.Gui
{
    public class EndScreen : MonoBehaviour
    {
        private string[] _metrics;
        [SerializeField] private TextMeshProUGUI[] _textReadouts = new TextMeshProUGUI[8];
        private void Awake()
        {
            Timer.Instance.EndTime();
            _metrics = Metrics.Instance.GetFormattedMetrics();
            int index = 0;
            foreach(TextMeshProUGUI tmp in _textReadouts)
            {
                tmp.text = _metrics[index];
                index++;
            }
        }
    }
}