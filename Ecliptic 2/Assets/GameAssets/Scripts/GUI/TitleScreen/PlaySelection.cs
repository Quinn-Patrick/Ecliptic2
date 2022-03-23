using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EclipticTwo.Core;
using EclipticTwo.TimingAndScoring;

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
            Score.Instance.ResetScore();
            Timer.Instance.StartTime();
            Metrics.Instance.ResetMetrics();
            SceneManager.LoadScene(Loader.Scene.Level1.ToString());
        }
        public Transform GetTransform()
        {
            return transform;
        }
    }
}