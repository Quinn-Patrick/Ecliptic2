using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public interface ITriggerObject
    {
        public void PlayerEnter(Player player);
        public void PlayerStay(Player player);
        public void PlayerExit(Player player);
    }
}
