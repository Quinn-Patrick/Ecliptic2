using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class PlayerInputReader : MonoBehaviour, IInputReader
    {
        [SerializeField] private GameplayControls _controller;
        public bool GetAction()
        {
            return _controller.GetFire();
        }

        public List<bool> GetActionList()
        {
            List<bool> output = new List<bool>
            {
                _controller.GetFire()
            };
            return output;
        }

        public float GetRotation()
        {
            return _controller.GetRotation();
        }

        public float GetThrust()
        {
            return _controller.GetThrust();
        }

        public bool GetZoom()
        {
            return _controller.GetZoom();
        }
        public bool GetRetry()
        {
            return _controller.GetRetry();
        }
    }
}