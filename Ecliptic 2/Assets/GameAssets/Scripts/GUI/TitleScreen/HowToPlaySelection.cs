using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Title
{
    public class HowToPlaySelection : MonoBehaviour, ISelection
    {
        [SerializeField] private TitleScreenSelections _selections;
        private void Awake()
        {
            if (_selections == null) return;
            _selections.Options.Add(this);

        }
        public void Selected()
        {
            throw new System.NotImplementedException();
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}