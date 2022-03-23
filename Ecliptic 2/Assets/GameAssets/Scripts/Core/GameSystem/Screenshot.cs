using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;

namespace EclipticTwo.Core
{
    public class Screenshot : MonoBehaviour
    {
        private IInputReader _input;
        private bool _canScreenshot;
        private void Awake()
        {
            _input = GetComponent<IInputReader>();
        }
        private void Update()
        {
            if (_input == null) return;
            if (_input.GetScreenshot())
            {
                if (_canScreenshot)
                {
                    _canScreenshot = false;
                    ScreenCapture.CaptureScreenshot($"Screenshots/EclipticTwoScreenshot{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}");
                }
            }
            else
            {
                _canScreenshot = true;
            }
        }
    }
}