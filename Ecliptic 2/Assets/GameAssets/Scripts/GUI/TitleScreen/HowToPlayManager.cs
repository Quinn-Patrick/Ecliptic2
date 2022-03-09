using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using UnityEngine.SceneManagement;

namespace EclipticTwo.Title {
    public class HowToPlayManager : MonoBehaviour
    {
        private IInputReader _input;
        [SerializeField] private Loader.Scene _nextScene;
        private bool _canAdvance = false;
        private void Awake()
        {
            _input = GetComponent<IInputReader>();
        }
        private void Update()
        {
            if (_input == null) return;
            if (_canAdvance)
            {
                if (_input.GetAction())
                {
                    SceneManager.LoadScene(_nextScene.ToString());
                }
            }
            _canAdvance = true;
        }
    }
}