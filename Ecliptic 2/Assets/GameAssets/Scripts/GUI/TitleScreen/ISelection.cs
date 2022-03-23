using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Title
{
    public interface ISelection
    {
        public void Selected();
        public Transform GetTransform();
    }
}