using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Boss
{
    public class BossState3 : IBossState
    {
        private BossBody _boss;
        private Shield _shield;
        public BossState3(BossBody boss, Shield shield)
        {
            _boss = boss;
            _shield = shield;
        }
        public IBossState UpdateState()
        {
            _shield.SetTargetAngularSpeed(28);

            if (_boss.GetHealthPercentage() < float.Epsilon) return this;
            return this;
        }
    }
}
