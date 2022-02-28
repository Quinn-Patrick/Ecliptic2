using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EclipticTwo.Core
{
    public class LevelEndZone : MonoBehaviour, ITriggerObject
    {
        public static Action _enteredZone;
        public static Action _exitedZone;
        public void PlayerEnter(Player player)
        {
            _enteredZone?.Invoke();
        }

        public void PlayerExit(Player player)
        {
            _exitedZone?.Invoke();
        }

        public void PlayerStay(Player player){}
    }
}