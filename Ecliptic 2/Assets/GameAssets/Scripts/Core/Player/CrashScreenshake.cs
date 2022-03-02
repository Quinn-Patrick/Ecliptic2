using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class CrashScreenshake : MonoBehaviour
    {
        [SerializeField] private HealthSystem _crasher;

        private void OnEnable()
        {
            _crasher.Damaged += ShakeScreen;
        }
        private void OnDisable()
        {
            _crasher.Damaged -= ShakeScreen;
        }

        private void ShakeScreen(float damage)
        {
            if (ScreenShake.Instance == null) return;
            if (damage > 100) damage = 100;
            if (damage < 20) damage = 20;
            ScreenShake.Instance.AddShake(damage / 100);
        }
    }
}