using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using EclipticTwo.Title;

namespace EclipticTwo.Audio
{
    public class TitleScreenAudio : SoundPlayer
    {
        [SerializeField] private AudioClip _scrollClip;
        [SerializeField] private TitleScreenSelections _title;

        private void OnEnable()
        {
            _title.SelectionChanged += () => PlaySound(_scrollClip);
        }
        private void OnDisable()
        {
            _title.SelectionChanged -= () => PlaySound(_scrollClip);
        }
    }
}