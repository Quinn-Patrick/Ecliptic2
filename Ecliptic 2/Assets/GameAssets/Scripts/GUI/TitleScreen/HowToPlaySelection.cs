using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using UnityEngine.SceneManagement;

namespace EclipticTwo.Title
{
    public class HowToPlaySelection : MonoBehaviour, ISelection
    {
        [SerializeField] private TitleScreenSelections _selections;
        private void Awake()
        {
            if (_selections == null) return;
            _selections.Options.Add(this);

        }
        public void Selected()
        {
            SceneManager.LoadScene(Loader.Scene.HowToPlay1.ToString());
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}