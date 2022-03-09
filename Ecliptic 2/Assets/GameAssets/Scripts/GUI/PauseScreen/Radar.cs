using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Gui
{
    public class Radar : MonoBehaviour
    {
       [SerializeField] public float Scale { get; set; }
       [SerializeField] public Vector2 Center { get; set; }

        private void Start()
        {
            if(Scale == 0)
            {
                Scale = 7f;
            }
        }
    }
}