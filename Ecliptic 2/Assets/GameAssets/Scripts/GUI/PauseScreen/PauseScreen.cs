using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Gui
{
    public class PauseScreen : MonoBehaviour
    {
        private List<IPauseScreenElement> _elements = new List<IPauseScreenElement>();
        [SerializeField] private IInputReader _input;
        private bool _canPause;
        private bool _paused;
        private float _baseTimeScale;
        private void Awake()
        {
            _baseTimeScale = Time.timeScale;
            _input = GetComponent<IInputReader>();
            foreach (Transform t in transform)
            {
                IPauseScreenElement newElement = t.gameObject.GetComponent<IPauseScreenElement>();
                if (newElement == null) continue;
                _elements.Add(newElement);
            }
            foreach(IPauseScreenElement e in _elements)
            {
                e.Hide();
            }
        }
        private void Update()
        {
            if (_input == null) return;
            if (_input.GetPause())
            {
                if (_canPause)
                {
                    PauseUnpause();
                    _canPause = false;
                }
            }
            else
            {
                _canPause = true;
            }
        }

        private void PauseUnpause()
        {
            if (!_paused)
            {
                Time.timeScale = 0;
                foreach (IPauseScreenElement e in _elements)
                {
                    e.Show();
                }
                _paused = true;
                return;
            }
            Time.timeScale = _baseTimeScale;
            foreach (IPauseScreenElement e in _elements)
            {
                e.Hide();
            }
            _paused = false;
        }
    }
}