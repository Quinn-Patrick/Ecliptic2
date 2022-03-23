using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Audio
{
    [CreateAssetMenu(fileName = "New Music Map", menuName = "Music Map")]
    public class MusicMapping : ScriptableObject
    {
        public List<Loader.Scene> Scenes;
        public List<AudioClip> Music;
    }
}