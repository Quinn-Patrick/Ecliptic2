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
            level6
        }
        private static Action _onLoaderCallback;
        public static void Load(Scene scene)
        {
            SceneManager.LoadScene(scene.ToString());

            _onLoaderCallback = () =>
            {
                SceneManager.LoadScene(Scene.Loading.ToString());
            };
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