using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Boss
{
    public interface IBossState
    {
        public IBossState UpdateState();
    }
}