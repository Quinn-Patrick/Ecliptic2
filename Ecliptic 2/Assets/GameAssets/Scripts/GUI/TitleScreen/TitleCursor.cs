using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Title
{
    public class TitleCursor : MonoBehaviour
    {
        [SerializeField] private float _gap;
        [SerializeField] private TitleScreenSelections _selector;

        private Vector2 _startPosition;
        private void Awake()
        {
            _startPosition = transform.position;
        }
        void Update()
        {
            transform.position = new Vector2(_startPosition.x, _startPosition.y - _gap * _selector.GetSelectionNumber());
        }
    }
}