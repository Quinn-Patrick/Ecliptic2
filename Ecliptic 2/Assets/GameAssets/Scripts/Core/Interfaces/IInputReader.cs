using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public interface IInputReader
    {
        public float GetThrust();
        public float GetRotation();
        public List<bool> GetActionList();
        public bool GetAction();
        public bool GetZoom();
        public bool GetRetry();
        public bool GetPause();
        public bool GetScreenshot();
    }
}