using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Boss
{
    public class BossState1 : IBossState
    {
        private BossBody _boss;
        private Shield _shield;
        public BossState1(BossBody boss, Shield shield)
        {
            _boss = boss;
            _shield = shield;
        }
        public IBossState UpdateState()
        {
            _shield.SetTargetAngularSpeed(16);

            if (_boss.GetHealthPercentage() < 0.66666667f)
            {
                return new BossState2(_boss, _shield);
            }
            return this;
        }
    }
}