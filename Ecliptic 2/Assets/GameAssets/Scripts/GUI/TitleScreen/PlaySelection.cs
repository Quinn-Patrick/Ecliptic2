using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EclipticTwo.Core;

namespace EclipticTwo.Title
{
    public class PlaySelection : MonoBehaviour, ISelection
    {
        [SerializeField] private TitleScreenSelections _selections;
        private void Awake()
        {
            if (_selections == null) return;
            _selections.Options.Add(this);

        }
        public void Selected()
        {
            SceneManager.LoadScene(Loader.Scene.Level1.ToString());
        }
        public Transform GetTransform()
        {
            return transform;
        }
    }
}