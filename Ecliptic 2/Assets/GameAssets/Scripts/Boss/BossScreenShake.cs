using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Boss
{
    public class BossScreenShake : MonoBehaviour
    {
        [SerializeField] private BossBody _boss;
        private void OnEnable()
        {
            _boss.GotHit += ShakeScreen;
        }
        private void OnDisable()
        {
            _boss.GotHit -= ShakeScreen;
        }
        private void ShakeScreen()
        {
            ScreenShake.Instance.AddShake(0.2f);
        }
    }
}