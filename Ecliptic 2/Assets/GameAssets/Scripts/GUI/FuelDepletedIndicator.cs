using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EclipticTwo.Core;

namespace EclipticTwo.Gui
{
    public class FuelDepletedIndicator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private Fuel _fuel;
        public void SetFuelObject(Fuel fuel)
        {
            _fuel = fuel;
            
        }
        private void Update()
        {
            if (_fuel == null) return;
            
            if (_fuel.GetFuelLevel() < float.Epsilon)
            {
                _text.text = "Fuel Depleted, Press 'R' to Retry";
            }
            else
            {
                _text.text = "";
            }
        }
    }
}