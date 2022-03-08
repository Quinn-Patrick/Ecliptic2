using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EclipticTwo.Gui
{
    public class MapPanel : MonoBehaviour, IPauseScreenElement
    {
        [SerializeField] private Image _image;
        public void Hide()
        {
            _image.color = new Color(1, 1, 1, 0);
        }

        public void Show()
        {
            _image.color = new Color(1, 1, 1, 1);
        }
    }
}