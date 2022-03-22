using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Gui
{
    public class TitleScreenInputs : MonoBehaviour
    {
        [SerializeField] private IInputReader _input;
        private bool InputsAllowed = false;
        private void Awake()
        {
            _input = gameObject.GetComponent<IInputReader>();
        }

        private void Update()
        {
            if(!_input.GetAction() && !_input.GetZoom() && !_input.GetPause())
            {
                InputsAllowed = true;
            }
            if (InputsAllowed)
            {
                if (_input.GetAction())
                {
                    Loader.Load(Loader.Scene.Level1);
                }
                if (_input.GetZoom())
                {
                    Loader.Load(Loader.Scene.HowToPlay1);
                }
                if (_input.GetPause())
                {
                    Loader.Load(Loader.Scene.Options);
                }
            }
        }
    }
}