using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Gui
{
    public class FuelNeedle : MonoBehaviour
    {
        [SerializeField] private Vector2 _fullFuelPosition;
        [SerializeField] private Vector2 _emptyFuelPosition;
        [SerializeField] private Fuel _fuelTank;
        [SerializeField] private FuelDepletedIndicator _text;
        private void Start()
        {
            _text.SetFuelObject(_fuelTank);
        }
        private void Update()
        {
            if (_fuelTank == null || _fullFuelPosition == null || _emptyFuelPosition == null) return;

            RectTransform needleTransform = gameObject.GetComponent<RectTransform>();
            if (needleTransform == null) return;

            needleTransform.anchoredPosition = Vector2.Lerp(_emptyFuelPosition, _fullFuelPosition, _fuelTank.GetFuelPercentage());
        }
    }
}