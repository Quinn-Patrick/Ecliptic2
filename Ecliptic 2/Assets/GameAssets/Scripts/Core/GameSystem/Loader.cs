using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace EclipticTwo.Core
{
    public static class Loader
    {
        public enum Scene
        {
            Title,
            Loading,
            Level1,
            Level2,
            level3,
            level4,
            level5,
            level6,
            HowToPlay1,
            HowToPlay2,
            HowToPlay3,
            End
        }
        private static Action _onLoaderCallback;

        public delegate void LevelLoadHandler ();
        public static event LevelLoadHandler LevelLoaded;
        public static void Load(Scene scene)
        {
            SceneManager.LoadScene(scene.ToString());

            _onLoaderCallback = () =>
            {
                SceneManager.LoadScene(Scene.Loading.ToString());
            };

            LevelLoaded?.Invoke();
        }
        public static void LoaderCallback()
        {
            if (_onLoaderCallback != null)
            {
                _onLoaderCallback();
                _onLoaderCallback = null;
            }
        }
    }
}