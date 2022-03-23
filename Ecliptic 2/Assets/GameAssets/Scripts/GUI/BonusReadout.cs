using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.TimingAndScoring;
using TMPro;

namespace EclipticTwo.Gui
{
    public class BonusReadout : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Update()
        {
            _text.text = $"Bonus: {Score.Instance.GetFormattedBonus()} X";
        }
    }
}