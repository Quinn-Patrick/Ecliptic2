using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using EclipticTwo.Core;

namespace EclipticTwo.Audio
{
    public class MusicManager : SoundPlayer
    {
        [SerializeField] private MusicMapping _mapData;
        private Dictionary<Loader.Scene, AudioClip> _map = new Dictionary<Loader.Scene, AudioClip>();
        private static MusicManager _instance;
        new private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(_instance);

                for(int i = 0; i < _mapData.Scenes.Count; i++)
                {
                    if (i >= _mapData.Music.Count) break;
                    _map.Add(_mapData.Scenes[i], _mapData.Music[i]);
                }
            }
            else
            {
                Destroy(this);
            }
            base.Awake();
        }
        private void Update()
        {
            string sceneString = SceneManager.GetActiveScene().name;
            Loader.Scene scene;
            Enum.TryParse(sceneString, out scene);
            AudioClip newClip;
            _map.TryGetValue(scene, out newClip);
            if(newClip != _source.clip)
            {
                _source.Stop();
                _source.clip = newClip;
                _source.Play();
            }
        }
    }
}