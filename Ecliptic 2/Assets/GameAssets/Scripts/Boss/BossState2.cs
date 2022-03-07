using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Boss
{
    public class BossState2 : IBossState
    {
        private BossBody _boss;
        private Shield _shield;
        public BossState2(BossBody boss, Shield shield)
        {
            _boss = boss;
            _shield = shield;
        }
        public IBossState UpdateState()
        {
            _shield.SetTargetAngularSpeed(-24);

            if (_boss.GetHealthPercentage() < 0.33333333f) return new BossState3(_boss, _shield);
            return this;
        }
    }
}