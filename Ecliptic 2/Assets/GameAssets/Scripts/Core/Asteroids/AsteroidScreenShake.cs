using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Asteroids
{
    public class AsteroidScreenShake : MonoBehaviour
    {
        [SerializeField] private Asteroid _asteroid;
        private void OnEnable()
        {
            _asteroid.Destroyed += ShakeScreen;
        }
        private void OnDisable()
        {
            _asteroid.Destroyed -= ShakeScreen;
        }

        private void ShakeScreen(Asteroid a)
        {
            if (ScreenShake.Instance == null) return;
            ScreenShake.Instance.AddShake(0.6f);
        }
    }
}