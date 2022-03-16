using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EclipticTwo.Core;
using EclipticTwo.Missions;

namespace EclipticTwo.Gui
{
    public class LevelTransitioner : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        [SerializeField] Loader.Scene _nextLevel;
        private readonly string _trigger = "LevelOver";
        private void OnEnable()
        {
            NextLevelCountdown.Instance.CountdownEnded += ActivateWipe;
        }
        private void OnDisable()
        {
            NextLevelCountdown.Instance.CountdownEnded -= ActivateWipe;
        }
        public void TransitionLevel(Loader.Scene scene)
        {
            Loader.Load(_nextLevel);
        }
        private void ActivateWipe()
        {
            _anim.SetTrigger(_trigger);
        }
    }
}