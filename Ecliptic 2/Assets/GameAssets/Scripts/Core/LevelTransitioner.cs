using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EclipticTwo.Core;

namespace EclipticTwo.Gui
{
    public class LevelTransitioner : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        private readonly string _trigger = "LevelOver";
        public void TransitionLevel(Loader.Scene scene)
        {
            Loader.Load(scene);
        }
        private void ActivateWipe()
        {
            _anim.SetTrigger(_trigger);
        }
    }
}