using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class GameplayControls : MonoBehaviour
    {
        Controls _gameplayControls;
        private float _thrust;
        private float _rotate;
        private bool _fire;
        private bool _zoom;
        private bool _retry;
        private bool _pause;
        private bool _screenshot;

        private void Awake()
        {
            _gameplayControls = new Controls();

            _gameplayControls.Gameplay.UpDown.performed += ctx => _thrust = ctx.ReadValue<float>();
            _gameplayControls.Gameplay.LeftRight.performed += ctx => _rotate = ctx.ReadValue<float>();
            _gameplayControls.Gameplay.Fire.performed += ctx => _fire = true;
            _gameplayControls.Gameplay.ZoomOut.performed += ctx => _zoom = true;
            _gameplayControls.Gameplay.Retry.performed += ctx => _retry = true;
            _gameplayControls.Gameplay.Pause.performed += ctx => _pause = true;
            _gameplayControls.Gameplay.Screenshot.performed += ctx => _screenshot = true;

            _gameplayControls.Gameplay.UpDown.canceled += ctx => _thrust = 0f;
            _gameplayControls.Gameplay.LeftRight.canceled += ctx => _rotate = 0f;
            _gameplayControls.Gameplay.Fire.canceled += ctx => _fire = false;
            _gameplayControls.Gameplay.ZoomOut.canceled += ctx => _zoom = false;
            _gameplayControls.Gameplay.Retry.canceled += ctx => _retry = false;
            _gameplayControls.Gameplay.Pause.canceled += ctx => _pause = false;
            _gameplayControls.Gameplay.Screenshot.canceled += ctx => _screenshot = false;
        }

        private void OnEnable()
        {
            _gameplayControls.Gameplay.Enable();
        }
        private void OnDisable()
        {
            _gameplayControls.Gameplay.Disable();
        }
        public float GetThrust()
        {
            return _thrust;
        }
        public float GetRotation()
        {
            return _rotate;
        }
        public bool GetFire()
        {
            return _fire;
        }
        public bool GetZoom()
        {
            return _zoom;
        }
        public bool GetRetry()
        {
            return _retry;
        }
        public bool GetPause()
        {
            return _pause;
        }
        public bool GetScreenshot()
        {
            return _screenshot;
        }
    }
}