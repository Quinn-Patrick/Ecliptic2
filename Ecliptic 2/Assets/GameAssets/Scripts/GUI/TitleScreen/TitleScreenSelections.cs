using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Title
{
    public class TitleScreenSelections : MonoBehaviour
    {
        [SerializeField] private IInputReader _input;
        private int _selection;
        public List<ISelection> Options = new List<ISelection>();
        private bool _canChangeSelection;

        public delegate void SelectionChangeHandler();
        public event SelectionChangeHandler SelectionChanged;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
        }

        private void Start()
        {
            Options.Sort(delegate (ISelection x, ISelection y)
            {
                if (x.GetTransform().position.y < y.GetTransform().position.y) return 1;
                else return -1;
            });
        }

        private void Update()
        {
            if (_input == null) return;
            ConfirmSelection();
            BrowseSelections();
        }

        private void ConfirmSelection()
        {
            if (_input.GetAction())
            {
                Options[_selection].Selected();
            }
        }
        private void BrowseSelections()
        {
            if (Mathf.Abs(_input.GetThrust()) < float.Epsilon)
            {
                _canChangeSelection = true;
                return;
            }
            if (_canChangeSelection)
            {
                SelectionChanged?.Invoke();
                _selection += (int)Mathf.Sign(_input.GetThrust());
                _canChangeSelection = false;
                EnsureSelection();
            }
        }

        private void EnsureSelection()
        {
            if(_selection >= Options.Count)
            {
                _selection = 0;
                return;
            }
            if(_selection < 0)
            {
                _selection = Options.Count - 1;
            }
        }

        public int GetSelectionNumber()
        {
            return _selection;
        }
    }
}