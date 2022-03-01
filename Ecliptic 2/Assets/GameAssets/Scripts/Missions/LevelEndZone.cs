using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EclipticTwo.Core;

namespace EclipticTwo.Missions
{
    public class LevelEndZone : MonoBehaviour, ITriggerObject
    {
        public static Action _enteredZone;
        public static Action _exitedZone;
        public void PlayerEnter(Player player)
        {
            if (!MissionCore.Instance.AllMissionsClear()) return;
            _enteredZone?.Invoke();
        }

        public void PlayerExit(Player player)
        {
            _exitedZone?.Invoke();
        }

        public void PlayerStay(Player player){}
    }
}