using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Guns {
    public class GunshotScreenshake : MonoBehaviour
    {
        [SerializeField] private Gun _gun;
        [SerializeField] private float _amount;

        private void OnEnable()
        {
            _gun.ShotFired += ShakeScreen;
        }
        private void OnDisable()
        {
            _gun.ShotFired -= ShakeScreen;
        }

        private void ShakeScreen()
        {
            if (ScreenShake.Instance == null) return;
            ScreenShake.Instance.AddShake(0.2f);
        }
    }
}